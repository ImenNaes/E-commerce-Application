using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Entities;
using BLL.Interfaces.Repositories;

namespace DAL.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public IEnumerable<Product> GetProductsByTypeID(Guid TypeId)
        {
            var list = _ctx.Products.Where(c=>c.TypeID== TypeId);
            return list.ToList();
        }
        public IEnumerable<Product> GetProductsBycategID(Guid CategId)
        {
            var list = _ctx.Products.Where(c => c.CategID == CategId).OrderByDescending(c=>c.CreationDate);
            return list.ToList();
        }

        public Product GetProductsByID(Guid prodid)
        {
            ////Product prod = new Product();
            var prod = _ctx.Products.Where(c => c.ID == prodid).SingleOrDefault();
            return prod;
        }
        public IEnumerable<Product> MostViewedProducts()
        {
            var topProductsIds = _ctx.ProductViews // table with a row for each view of a product
                .GroupBy(x => x.PrID) //group all rows with same product id together
                .OrderByDescending(g => g.Count()) // move products with highest views to the top
               // .Take(5) // take top 5
                .Select(x => x.Key) // get id of products
                .ToList(); // execute query and convert it to a list

            var topProducts = _ctx.Products // table with products information
                .Where(x => topProductsIds.Contains(x.ID)); // get info of products that their Ids are retrieved in previous query
            return topProducts.ToList();
        }

        public void SaveViews(ProductViews obj)
        {
            _ctx.Set<ProductViews>().Add(obj);
            _ctx.SaveChanges();
        }
    }
}
