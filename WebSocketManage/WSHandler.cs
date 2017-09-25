using System;
using System.Collections.Generic;
using System.IO;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebSocketManage
{
    public class WSHandler
    {
        protected WSConnectionManager _wsConnectionManager;

        public WSHandler(WSConnectionManager wSConnectionManager)
        {
            _wsConnectionManager = wSConnectionManager;
        }

        public async Task SendMessageAsync(
            WebSocket socket,
            string message,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var buffer = Encoding.UTF8.GetBytes(message);
            var segment = new ArraySegment<byte>(buffer);

            await socket.SendAsync(segment, WebSocketMessageType.Text, true, cancellationToken);
        }
        public async Task<string> ReceiveAsync(WebSocket webSocket, CancellationToken cancellationToken)
        {
            var buffer = new ArraySegment<byte>(new byte[1024 * 8]);
            using (var ms = new MemoryStream())
            {
                WebSocketReceiveResult result;
                do
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    result = await webSocket.ReceiveAsync(buffer, cancellationToken);
                    ms.Write(buffer.Array, buffer.Offset, result.Count);
                }
                while (!result.EndOfMessage);

                ms.Seek(0, SeekOrigin.Begin);
                if (result.MessageType != WebSocketMessageType.Text)
                {
                    return null;
                }

                using (var reader = new StreamReader(ms, Encoding.UTF8))
                {
                    return await reader.ReadToEndAsync();
                }
            }
        }
    }
}
