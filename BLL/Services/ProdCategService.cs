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
    public class ProdCategService: BaseService<ProductCategorie> , IProdCategService
    {
        private readonly IProdCategoriesRepository _prodCategrepository;
        public ProdCategService(IProdCategoriesRepository prodCategrepository) : base(prodCategrepository)
        {
            _prodCategrepository = prodCategrepository;
        }
    }
}
