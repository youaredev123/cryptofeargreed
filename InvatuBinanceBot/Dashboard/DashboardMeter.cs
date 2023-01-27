using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Binance.Net.Interfaces;
using Dto;
using HtmlAgilityPack;
using InvatuBinanceBot.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace InvatuBinanceBot.Dashboard
{
    public class DashboardMeter : Controller
    {
        private readonly ApplicationDBContext _context;
        private readonly IBinanceClient _binanceClient;
        private readonly IBinanceDataProvider _dataProvider;
        public DashboardMeter(ApplicationDBContext context, IBinanceClient client, IBinanceDataProvider dataProvider)
        {
            _context = context;
            _binanceClient = client;
            _dataProvider = dataProvider;
        }

        [HttpPost]
        public async Task<bool> SaveEmotions(string emotion, string IPAddress)
        {
            if (string.IsNullOrEmpty(emotion)) return false;
            await _context.UserEmotions.AddAsync(new UserEmotions
            {
                CreatedDate = DateTime.Now,
                CoinName = emotion.Split(',')[1],
                Emotion = emotion.Split(',')[0],
                IPAddress = IPAddress,


            });


            if (await _context.SaveChangesAsync() > 0)
            {
                return true;
            }
            return false;
        }

        //GET: Dashboard
        public async Task<IActionResult> Index()
        {
          
            List<MeterModel> meterValues = await _context.MeterModel.ToListAsync();
            List<Coin> coins = new List<Coin>();

            var btcCoin = await _context.Coins.Where(x => x.Symbol == "BTC").FirstOrDefaultAsync();
            var ethCoin = await _context.Coins.Where(x => x.Symbol == "ETH").FirstOrDefaultAsync();
            var solCoin = await _context.Coins.Where(x => x.Symbol == "SOL").FirstOrDefaultAsync();
            coins.Add(btcCoin);
            coins.Add(ethCoin);
            coins.Add(solCoin);
            ViewBag.Meter = meterValues[0].MeterVal;
            return View(new Tuple<List<MeterModel>, List<Coin>, Votes>(meterValues, coins, GetEmotionsCount()));
        }

        [HttpPost]
        public async Task<string> SaveUserEmotion(string emotion)
        {
            await _context.CommonUserEmotion.AddAsync(new CommonUserEmotions
            {
                CreatedDate = DateTime.Now,
                Emotion = emotion,
                IPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString()
            });

            await _context.SaveChangesAsync();


            return JsonConvert.SerializeObject(GetEmotionsCount());
        }


        public IActionResult GetCoins()
        {
            var draw = HttpContext.Request.Query["draw"].ToString();
            var start = HttpContext.Request.Query["start"].ToString();
            var length = HttpContext.Request.Query["length"].ToString();
            var sortColumn = HttpContext.Request.Query["columns[" + HttpContext.Request.Query["order[0][column]"].ToString() + "][name]"].ToString();
            var sortColumnDirection = HttpContext.Request.Query["order[0][dir]"].ToString();
            var searchValue = HttpContext.Request.Query["search[value]"].ToString();
            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;
            int recordsTotal = 0;

            var coins = from c in _context.Coins select c;

            if (!(string.IsNullOrEmpty(sortColumn) && !string.IsNullOrEmpty(sortColumnDirection)))
            {
                coins = sortColumnDirection.ToLower().Equals("asc") ?
                    coins.OrderBy(p => EF.Property<object>(p, sortColumn)) :
                    coins.OrderByDescending(p => EF.Property<object>(p, sortColumn));
            }

            if (!string.IsNullOrEmpty(searchValue))
            {
                coins = coins.Where(c => c.Price.ToString().Contains(searchValue)
                                            || c.Symbol.Contains(searchValue)
                                            || c.Name.Contains(searchValue)
                                            || c.Volume24H.ToString().Contains(searchValue)
                                            || c.PercentChange24H.ToString().Contains(searchValue)
                                            || c.MarketCap.ToString().Contains(searchValue));
            }

            recordsTotal = coins.Count();
            var data = coins.Skip(skip).Take(pageSize).ToList();

            // draw own graph last7days
            /*var dt = DateTime.Now.AddDays(-7);
            var coinsHisotry = from c in _context.CoinHistories where c.LastUpdated > dt select c;
            
            foreach (var item in data)
            {
                item.Last7DaysData = coinsHisotry.Where(x => x.CoinId == item.ID).Select(y => Math.Round(y.Price, 5)).ToList();
            }*/
            var jsonData = new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data };
            return Ok(jsonData);
        }

        private Votes GetEmotionsCount()
        {
            var todayEmotions = _context.CommonUserEmotion.Where(cue => cue.CreatedDate.Date == DateTime.Now.Date).ToList();
            return new Votes
            {
                BearishCount = todayEmotions.Where(cue => cue.Emotion.ToLower().Trim().Equals("bearish")).Select(cue => cue.IPAddress).Distinct().Count(),
                BullishCount = todayEmotions.Where(cue => cue.Emotion.ToLower().Trim().Equals("bullish")).Select(cue => cue.IPAddress).Distinct().Count()
            };
        }
    }
}