using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Threading;
using WebSocketCommon;
using System.Reflection;

namespace WebSocketManage
{
    /// <summary>
    /// Handle websocket when connected or recieve message.
    /// </summary>
    public abstract class WebSocketHandler
    {
        protected WebSocketConnectionManager _webSocketConnectionManager { get; set; }
        private JsonSerializerSettings _jsonSerializerSettings = new JsonSerializerSettings()
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };

        public WebSocketHandler(WebSocketConnectionManager webSocketConnectionManager)
        {
            _webSocketConnectionManager = webSocketConnectionManager;
        }

        public virtual async Task OnConnected(WebSocket socket)
        {
            //将当前Socket 存入Dictionary中
            _webSocketConnectionManager.AddSocket(socket);

            await SendMessageAsync(socket, new Message()
            {
                MessageType = MessageType.ConnectionEvent,
                Data = _webSocketConnectionManager.GetId(socket)
            }).ConfigureAwait(false);
        }

        public virtual async Task OnDisconnected(WebSocket socket)
        {
            var socketId = _webSocketConnectionManager.GetId(socket);
            await _webSocketConnectionManager.RemoveSocket(socketId).ConfigureAwait(false);
        }

        public async Task SendMessageAsync(WebSocket socket, Message message)
        {
            if (socket.State != WebSocketState.Open) return;

            var serializedMessage = JsonConvert.SerializeObject(message, _jsonSerializerSettings);
            var encodeMessage = Encoding.UTF8.GetBytes(serializedMessage);
            await socket.SendAsync(
                buffer: new ArraySegment<byte>(
                    array: encodeMessage,
                    offset: 0,
                    count: encodeMessage.Length),
                messageType: WebSocketMessageType.Text,
                endOfMessage: true,
                cancellationToken: CancellationToken.None).ConfigureAwait(false);
        }

        public async Task SendMessageAsync(string socketId, Message message)
        {
            var socket = _webSocketConnectionManager.GetSocketById(socketId);

            await SendMessageAsync(socket, message);
        }

        public async Task SendMessageToAllAsync(Message message)
        {
            foreach (var item in _webSocketConnectionManager.GetAll())
            {
                if (item.Value.State == WebSocketState.Open)
                    await SendMessageAsync(item.Value, message).ConfigureAwait(false);
            }
        }

        public async Task InvokeClientMethodAsync(string socketId, string methodName, object[] arguments)
        {
            var message = new Message()
            {
                MessageType = MessageType.ClientMethodInvocation,
                Data = JsonConvert.SerializeObject(new InvocationDescriptor()
                {
                    MethodName = methodName,
                    Arguments = arguments
                }, _jsonSerializerSettings)
            };
            await SendMessageAsync(socketId, message);
        }

        public async Task InvokeClientMethodToAllAsync(string methodName, params object[] arguments)
        {
            foreach (var pair in _webSocketConnectionManager.GetAll())
            {
                if (pair.Value.State == WebSocketState.Open)
                    await InvokeClientMethodAsync(pair.Key, methodName, arguments).ConfigureAwait(false);
            }
        }

        public async Task SendMessageToGroupAsync(string groupID, Message message)
        {
            var sockets = _webSocketConnectionManager.GetAllFromGroup(groupID);
            if (sockets != null)
            {
                foreach (var socket in sockets)
                {
                    await SendMessageAsync(socket, message);
                }
            }
        }

        public async Task SendMessageToGroupAsync(string groupID, Message message, string except)
        {
            var sockets = _webSocketConnectionManager.GetAllFromGroup(groupID);
            if (sockets != null)
            {
                foreach (var id in sockets)
                {
                    if (id != except)
                        await SendMessageAsync(id, message);
                }
            }
        }

        public async Task InvokeClientMethodToGroupAsync(string groupID, string methodName, params object[] arguments)
        {
            var sockets = _webSocketConnectionManager.GetAllFromGroup(groupID);
            if (sockets != null)
            {
                foreach (var id in sockets)
                {
                    await InvokeClientMethodAsync(id, methodName, arguments);
                }
            }
        }

        public async Task InvokeClientMethodToGroupAsync(string groupID, string methodName, string except, params object[] arguments)
        {
            var sockets = _webSocketConnectionManager.GetAllFromGroup(groupID);
            if (sockets != null)
            {
                foreach (var id in sockets)
                {
                    if (id != except)
                        await InvokeClientMethodAsync(id, methodName, arguments);
                }
            }
        }

        public async Task ReceiveAsync(WebSocket socket, WebSocketReceiveResult result, string serializedInvocationDescriptor)
        {
            var invocationDescriptor = JsonConvert.DeserializeObject<InvocationDescriptor>(serializedInvocationDescriptor);

            var method = this.GetType().GetMethod(invocationDescriptor.MethodName);

            if (method == null)
            {
                await SendMessageAsync(socket, new Message()
                {
                    MessageType = MessageType.Text,
                    Data = $"Cannot find method {invocationDescriptor.MethodName}"
                }).ConfigureAwait(false);
                return;
            }

            try
            {
                method.Invoke(this, invocationDescriptor.Arguments);
            }
            catch (TargetParameterCountException)
            {
                await SendMessageAsync(socket, new Message()
                {
                    MessageType = MessageType.Text,
                    Data = $"The {invocationDescriptor.MethodName} method does not take {invocationDescriptor.Arguments.Length} parameters!"
                }).ConfigureAwait(false);
            }

            catch (ArgumentException)
            {
                await SendMessageAsync(socket, new Message()
                {
                    MessageType = MessageType.Text,
                    Data = $"The {invocationDescriptor.MethodName} method takes different arguments!"
                }).ConfigureAwait(false);
            }
        }
    }
}
