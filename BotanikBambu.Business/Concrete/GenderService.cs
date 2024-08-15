using BotanikBambu.Business.Abstract;
using BotanikBambu.Models;
using BotanikBambu.Repository.Shared.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotanikBambu.Business.Concrete
{
    internal class GenderService(IRepository<Gender>genderRepo):Service<Gender>(genderRepo),IGenderService
    {
    }
}
