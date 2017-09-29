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
    public class WSConnectionManager
    {
        private static ConcurrentDictionary<string, WebSocket> _socketConcurrentDictionary = new ConcurrentDictionary<string, WebSocket>();

        public void AddSocket(WebSocket socket)
        {
            _socketConcurrentDictionary.TryAdd(CreateGuid(), socket);
        }

        public async Task RemoveSocket(WebSocket socket)
        {
            _socketConcurrentDictionary.TryRemove(GetSocketId(socket), out WebSocket aSocket);

            await aSocket.CloseAsync(
                closeStatus: WebSocketCloseStatus.NormalClosure,
                statusDescription: "Close by User",
                cancellationToken: CancellationToken.None).ConfigureAwait(false);
        }

        public string GetSocketId(WebSocket socket)
        {
            return _socketConcurrentDictionary.FirstOrDefault(k => k.Value == socket).Key;
        }

        public ConcurrentDictionary<string, WebSocket> GetAll()
        {
            return _socketConcurrentDictionary;
        }

        public string CreateGuid()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
