using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotanikBambu.Models
{
    public class Photo : BaseModel
    {
        public string Path { get; set; }
        public int CartId { get; set; }
        public virtual Carts Cart { get; set; }
        public double Size { get; set; }

    }
}
