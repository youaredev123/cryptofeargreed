using HtmlAgilityPack;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;

namespace CronJob
{
    class Program
    {
        private static string API_KEY = ConfigurationManager.AppSettings["CoinMarketCapAPIKey"];
        static void Main(string[] args)
        {
            FetchCoinMarketCap();
            Console.WriteLine("Starting Crawl data ");
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load("https://alternative.me/crypto/fear-and-greed-index/");

            var columns = doc.DocumentNode.SelectNodes("//div[@class='column is-one-third']");
            var historyBlock = columns[1].SelectSingleNode("//div[@class='block']");
            var historyDatas = historyBlock.SelectNodes("//div[contains(@class, 'fng-value')]");
            foreach (var item in historyDatas)
            {
                var meterDate = item.SelectSingleNode(".//div[@class='gray']").InnerText;
                var meterType = item.SelectSingleNode(".//div[@class='status']").InnerText;
                var meterVal = item.SelectSingleNode(".//div[@class='fng-circle']").InnerText;
                InsertOrUpdate(new MeterModel
                {
                    MeterDate = meterDate,
                    MeterType = meterType,
                    MeterVal = meterVal
                });
            }
            Console.WriteLine("Successfully inserted or updated values ");
        }
        public static void InsertOrUpdate(MeterModel model)
        {
            var context = new ApplicationDBContext();
            context.Database.EnsureCreated();
            var exist = context.MeterModel.Where(x => x.MeterDate == model.MeterDate).FirstOrDefault();
            if (exist == null)
            {
                context.MeterModel.Add(model);
            }
            else
            {
                exist.MeterType = model.MeterType;
                exist.MeterVal = model.MeterVal;
                context.MeterModel.Update(exist);
            }
            // Saves changes
            context.SaveChanges();
        }
        public static void FetchCoinMarketCap()
        {
            Console.WriteLine("Starting Fetch Top 100 Coins");
            var URL = new UriBuilder("https://pro-api.coinmarketcap.com/v1/cryptocurrency/listings/latest");

            var queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString["start"] = "1";
            queryString["limit"] = "100";
            queryString["convert"] = "USD";

            URL.Query = queryString.ToString();

            var client = new WebClient();
            client.Headers.Add("X-CMC_PRO_API_KEY", API_KEY);
            client.Headers.Add("Accepts", "application/json");
            string response = client.DownloadString(URL.ToString());
            dynamic resJson = JsonConvert.DeserializeObject(response);
            foreach(var item in resJson.data)
            {
                Coin coin = new Coin
                {
                    Name = item.name,
                    CoinMarketID = item.id,
                    Symbol = item.symbol,
                    MarketCap = item.quote.USD.market_cap,
                    Price = item.quote.USD.price,
                    PercentChange24H = item.quote.USD.percent_change_24h,
                    PercentChange7d = item.quote.USD.percent_change_7d,
                    Volume24H = item.quote.USD.volume_24h,
                    VolumeChange24H = item.quote.USD.volume_change_24h,
                    MaxSupply = !string.IsNullOrEmpty(Convert.ToString(item.max_supply)) ? item.max_supply : 0,
                    TotalSupply = !string.IsNullOrEmpty(Convert.ToString(item.total_supply)) ? item.total_supply : 0,
                    CirculatingSupply = !string.IsNullOrEmpty(Convert.ToString(item.circulating_supply)) ? item.circulating_supply : 0,
                };
                InsertOrUpdateCoin(coin, Convert.ToString(item.last_updated));
            }
        }

        public static void InsertOrUpdateCoin(Coin coin, string lastUpdated)
        {
            var context = new ApplicationDBContext();
            context.Database.EnsureCreated();
            var exist = context.Coins.Where(x => x.Symbol == coin.Symbol).FirstOrDefault();
            if (exist == null)
            {
                context.Coins.Add(coin);
            }
            else
            {
                exist.CoinMarketID = coin.CoinMarketID;
                exist.Price = coin.Price;
                exist.PercentChange24H = coin.PercentChange24H;
                exist.PercentChange7d = coin.PercentChange7d;
                exist.MaxSupply = coin.MaxSupply;
                exist.TotalSupply = coin.TotalSupply;
                exist.CirculatingSupply = coin.CirculatingSupply;
                exist.Volume24H = coin.Volume24H;
                exist.VolumeChange24H = coin.VolumeChange24H;
                exist.MarketCap = coin.MarketCap;
                context.Coins.Update(exist);
            }
            // Saves changes
            context.SaveChanges();

            // draw own graph last7days
            /*var coinId = exist == null ? coin.ID : exist.ID;

            context.CoinHistories.Add( new CoinHistory
            {
                CoinId = coinId,
                Price = coin.Price,
                LastUpdated = DateTime.Parse(lastUpdated, null, System.Globalization.DateTimeStyles.RoundtripKind)
            });
            context.SaveChanges();*/
        }
    }
}
