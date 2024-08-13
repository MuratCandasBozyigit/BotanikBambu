using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotanikBambu.Models
{
    public class Trucker:BaseModel
    {
        public string TruckerName { get; set; }
        public string TruckerSurname { get; set; }  
        public string TruckPlate { get; set; }
       //JavaScript ile buraya hex ekle tablodan secilsin pushlkansın
       public int? HexCode { get; set; }

    }
}
