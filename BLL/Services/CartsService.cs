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
    public class CartsService: BaseService<Carts>, ICartsService
    {
        private readonly ICartsRepository _cartsrepository;
        public CartsService(ICartsRepository cartsrepository) : base(cartsrepository)
        {
            _cartsrepository = cartsrepository;
        }
    }
}
