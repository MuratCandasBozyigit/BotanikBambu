using BotanikBambu.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BotanikBambu.Data.Configurations
{
    public class GenderConfiguration : IEntityTypeConfiguration<Gender>
    {
        public void Configure(EntityTypeBuilder<Gender> builder)
        {
            builder.Ignore(x => x.Guid);
            builder.Ignore(x => x.DateCreated);

            builder.HasData(new Gender { Id = 1, Name = "Kadın", }, new Gender { Id = 2, Name = "Erkek" }, new Gender { Id = 3, Name = "Diğer" });
        }
    }
}
