using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Entities;
using BLL.Interfaces.Repositories;
using BLL.Interfaces.Services;

namespace BLL.Services
{
    public class CityService: BaseService<City> , ICityService
    {
        private readonly ICityRepository _cityrepository;
        public CityService(ICityRepository cityrepository) : base(cityrepository)
        {
            _cityrepository = cityrepository;
        }
    }
}
