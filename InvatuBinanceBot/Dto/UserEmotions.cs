using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dto
{
    public class UserEmotions
    {
        [Key]
        public Int64 ID { get; set; }

        [Required]
        [MaxLength(15)]
        public string IPAddress { get; set; }

        [Required]
        public string CoinName { get; set; }
        [Required]
        public string Emotion { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
