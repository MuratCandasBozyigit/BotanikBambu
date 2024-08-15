using BotanikBambu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BotanikBambu.Repository.Shared.Abstract;
using BotanikBambu.Business.Shared.Abstract;
using BotanikBambu.Business.Abstract;
namespace BotanikBambu.Business.Concrete
{
    public class CityService(IRepository<City>cityRepo):Service<City>(cityRepo),ICityService
    {
    }
}
