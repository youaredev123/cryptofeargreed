using System;
using System.Net.WebSockets;
using System.Threading.Tasks;

namespace InvatuBinanceBot.Websocket
{
    public interface IWebsocketHandler
    {
        Task Handle(Guid id, WebSocket websocket);
        Task SendMessageToSockets(string message);
    }
}