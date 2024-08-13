using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotanikBambu.Models
{
    public class Payment : BaseModel
    {
        public string? Receipt { get; set; }
        public DateTime PaymentDate { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int Amount { get; set; }

    }
}
