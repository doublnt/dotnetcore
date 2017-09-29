using System;

namespace WebSocketCommon
{
    /// <summary>
    /// A Entity about Message.
    /// </summary>
    public enum MessageType
    {
        Text,
        ClientMethodInvocation,
        ConnectionEvent
    }
    public class Message
    {
        public MessageType MessageType { get; set; }
        public string Data { get; set; }
    }
}
