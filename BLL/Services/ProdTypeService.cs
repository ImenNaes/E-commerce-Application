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
    public class ProdTypeService : BaseService<ProductType> , IProdTypeService
    {
        private readonly IProdTypesRepository _prodTyperepository;
        public ProdTypeService(IProdTypesRepository prodTyperepository) : base(prodTyperepository)
        {
            _prodTyperepository = prodTyperepository;
        }
    }
}
