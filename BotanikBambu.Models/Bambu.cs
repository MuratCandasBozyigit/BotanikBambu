using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotanikBambu.Models
{
    public class Bambu : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Model { get; set; }
       

        public int? ColorId { get; set; }
        public virtual Color? Color { get; set; }

        public string? ProfilePhoto { get; set; }
        public bool IsPublic { get; set; } = true;
      
        public virtual ICollection<Carts> Carts { get; set; } = [];

        
    }
}
