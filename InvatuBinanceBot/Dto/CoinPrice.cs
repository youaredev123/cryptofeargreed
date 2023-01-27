using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dto
{
    public class CoinPrice
    {
        public string Symbol { get; set; }
        public string Close { get; set; }
        public decimal PriceChange { get; set; }
        public decimal PriceChangePercent { get; set; }
        public decimal Volumn24H { get; set; }
        public decimal MarketCap { get; set; }
    }
}
