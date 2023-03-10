using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Dto
{
    public class Coin
    {
        public int ID { get; set; }

        public int CoinMarketID { get; set; }

        public string Name { get; set; }

        public string Symbol { get; set; }

        public decimal Price { get; set; }
        public decimal PercentChange24H { get; set; }
        public decimal PercentChange7d { get; set; }
        public decimal Volume24H { get; set; }
        public decimal VolumeChange24H { get; set; }
        public decimal MarketCap { get; set; }

        public decimal MaxSupply { get; set; }
        public decimal CirculatingSupply { get; set; }
        public decimal TotalSupply { get; set; }

        /*[NotMapped]
        public List<decimal> Last7DaysData { get; set; }*/
    }
}
