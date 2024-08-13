using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BotanikBambu.Models
{
    public class User:BaseModel
    {
        public bool IsAdmin { get; set; } = false;
        public string Gsm { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? ProfilePicture { get; set; }
        public string FullName { get; set; }
        public DateTime? BirthDate { get; set; }
        [NotMapped]
        public DateTime? MembershipStartDate { get; set; }
        public string? Description { get; set; }
        public int GenderId { get; set; }
        public virtual Gender Gender { get; set; }
        public string ApplicationForm { get; set; }
        public int CityId { get; set; }
        public virtual City City { get; set; }
        public string? Instagram { get; set; }
        public string? Facebook { get; set; }
        public string? Twitter { get; set; }
    }
}
