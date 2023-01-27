using System;
using System.Collections.Generic;
using System.Text;

namespace CronJob
{
    public class CoinHistory
    {
        public int ID { get; set; }
        public int CoinId { get; set; }

        public decimal Price { get; set; }
        public DateTime LastUpdated { get; set; }

    }
}
