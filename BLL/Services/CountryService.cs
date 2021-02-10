using BLL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces.Repositories;
using BLL.Interfaces.Services;

namespace BLL.Services
{
    public class CountryService: BaseService<Country>
    {
        private readonly ICountryRepository _countryrepository;
        public CountryService(ICountryRepository countryrepository) : base(countryrepository)
        {
            _countryrepository = countryrepository;
        }
    }
}
