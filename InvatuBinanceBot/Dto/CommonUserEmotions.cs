using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dto
{
    public class CommonUserEmotions
    {
        public int ID { get; set; }
        public string IPAddress { get; set; }
        public string Emotion { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
