using BLL.Entities;
using BLL.Interfaces.Repositories;
using BLL.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ProductService : BaseService<Product>, IProductService
    {
        private readonly IProductRepository _prodrepository;
        public ProductService(IProductRepository prodrepository) : base(prodrepository)
        {
            _prodrepository = prodrepository;
        }
    }
}
