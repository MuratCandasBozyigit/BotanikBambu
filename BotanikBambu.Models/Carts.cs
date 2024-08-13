using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotanikBambu.Models
{
    public class Carts : BaseModel
    {
        //Ana sayfada ürünün gözükeceği yerlerss
        public string Name { get; set; }
        public string? Description { get; set; }
       
        public string? CoverPicture { get; set; }
      
        public virtual ICollection<Photo> Photos { get; set; } = [];

    }
}
