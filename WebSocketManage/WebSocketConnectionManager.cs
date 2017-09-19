// This class is for Managing WebSocket and Manage WebSocket group about get/set sockets which Created by Robert.
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebSocketManage
{
    public class WebSocketConnectionManager
    {
        private ConcurrentDictionary<string, WebSocket> _sockets = new ConcurrentDictionary<string, WebSocket>();
        private ConcurrentDictionary<string, List<string>> _groups = new ConcurrentDictionary<string, List<string>>();

        public ConcurrentDictionary<string, WebSocket> GetAll()
        {
            return _sockets;
        }

        public WebSocket GetSocketById(string id)
        {
            return _sockets.FirstOrDefault(k => k.Key == id).Value;
        }

        public List<string> GetAllFromGroup(string groupId)
        {
            return _groups.ContainsKey(groupId) ?
                _groups[groupId] : default(List<string>);
        }

        public string GetId(WebSocket socket)
        {
            return _sockets.FirstOrDefault(k => k.Value == socket).Key;
        }

        public void AddSocket(WebSocket socket)
        {
            _sockets.TryAdd(CreateConnectionId(), socket);
        }

        public void AddToGroup(string socketId, string groupId)
        {
            if (_groups.ContainsKey(groupId))
            {
                var list = _groups[groupId];
                list.Add(socketId);
                _groups[groupId] = list;
                return;
            }
            _groups.TryAdd(groupId, new List<string> { socketId });
        }

        public async Task RemoveSocket(string socketId)
        {
            _sockets.TryRemove(socketId, out WebSocket socket);

            await socket.CloseAsync(
                closeStatus: WebSocketCloseStatus.NormalClosure,
                statusDescription: "Close by WebSocketManage",
                cancellationToken: CancellationToken.None).ConfigureAwait(false);
        }

        private string CreateConnectionId()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
