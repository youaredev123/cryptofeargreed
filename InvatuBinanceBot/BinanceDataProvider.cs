using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Binance.Net.Enums;
using Binance.Net.Interfaces;
using CryptoExchange.Net.Sockets;
using Dto;
using InvatuBinanceBot.Websocket;
using Newtonsoft.Json;

namespace InvatuBinanceBot
{
    public interface IBinanceDataProvider
    {
        Task Start();
        Task Stop();
    }

    public class BinanceDataProvider : IBinanceDataProvider
    {
        private IBinanceSocketClient _socketClient;
        private UpdateSubscription _subscription;
        
        public IWebsocketHandler WebsocketHandler { get; }

        public BinanceDataProvider(IBinanceSocketClient socketClient, IWebsocketHandler websocketHandler)
        {
            _socketClient = socketClient;
            WebsocketHandler = websocketHandler;
            Start().Wait(); // Probably want to do this in some initialization step at application startup
        }

        public async Task Start()
        {
            var subResult = await _socketClient.Spot.SubscribeToAllSymbolTickerUpdatesAsync(data =>
            {
                var allTicker = data.Data;
                List<CoinPrice> coins = allTicker.Where(x => x.Symbol.EndsWith("USDT"))
                .Select(x => new CoinPrice { 
                    Symbol = x.Symbol,
                    Close = x.LastPrice.ToString(),
                    PriceChangePercent = x.PriceChangePercent,
                    PriceChange = x.PriceChange,
                    Volumn24H = x.LastQuantity,
                    MarketCap = x.LastPrice * x.BaseVolume
                }).ToList();
                WebsocketHandler.SendMessageToSockets(JsonConvert.SerializeObject(coins));
                Thread.Sleep(1000);

            });
            if (subResult.Success)
                _subscription = subResult.Data;
        }

        public async Task Stop()
        {
            await _socketClient.UnsubscribeAsync(_subscription);
            
        }
    }
}
