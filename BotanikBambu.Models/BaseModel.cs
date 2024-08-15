using System;

namespace BotanikBambu.Models
{
    public class BaseModel
    {
        public int Id { get; set; }
        public Guid Guid { get; set; } = Guid.NewGuid();
        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; } = false;
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime? DateUpdated { get; set; }
        public DateTime? DateDeleted { get; set; }
        public int? OwnerId { get; set; }
        public int? ModifierId { get; set; }

        public void MarkAsDeleted()
        {
            IsDeleted = true;
            DateDeleted = DateTime.Now;
        }

       
        public void MarkAsUpdated(int? modifierId = null)
        {
            DateUpdated = DateTime.Now;
            ModifierId = modifierId;
        }
    }
}
