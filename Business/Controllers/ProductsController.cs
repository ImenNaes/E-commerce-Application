using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using BLL.Entities;
using BLL.Interfaces.Services;
using BLL.Interfaces.Repositories;
using DAL.Repositories;
//using Business.Models;
using DAL.ApiContext;
using Business.Models;
using PagedList;

namespace Business.Controllers
{
    public class ProductsController : Controller
    {
        private ProductRepository prodrepository;
        private ProductCategorieRepository prodCategoryrepository;
        private ProductTypeRepository prodTypeRepository;
        private BoxReviewRepository boxReviewRepository;
        private SizesRepository sizesRepository;
        private ImageRepository ImageRepository;
        private SmallImagesRepository smallImagesRepository;
        public ProductsController()
        {
            prodrepository = new ProductRepository();
            prodCategoryrepository = new ProductCategorieRepository();
            prodTypeRepository = new ProductTypeRepository();
            boxReviewRepository = new BoxReviewRepository();
            sizesRepository = new SizesRepository();
            ImageRepository = new ImageRepository();
            smallImagesRepository = new SmallImagesRepository();
        }
        public class FilterViewModel
        {
            public List<BLL.Entities.ProductCategorie> ListCategories { get; set; }
            public List<BLL.Entities.ProductType> ListTypes { get; set; }
        }

        // GET: Products
        public ActionResult List(Guid typeId/*, String SearchName = null, String Size = null, String PriceMin = null, String PriceMax = null*/)
        {
            //FilterViewModel listviewmodel = new FilterViewModel();
          
            ViewBag.typeID = typeId;
            //ViewBag.SearchName = SearchName;
            ////ViewBag.Place = (Place != null ? Place : Guid.Empty.ToString());
            //ViewBag.size = Size;
            //ViewBag.PriceMin = PriceMin;
            //ViewBag.PriceMax = PriceMax;

            //return View(listviewmodel);
            return View();
        }

        public class ProductsViewModel
        {
            public List<BLL.Entities.Product> ListProducts { get; set; }
            public int Pagenumber { get; set; }
            public int PageCount { get; set; }
         }
        public ActionResult ListPartial(Guid typeID, int? Page)
        {
            try
            {
                int pageSize = 5;
                int pageIndex = 1;
                IEnumerable<BLL.Entities.Product> list = prodrepository.GetProductsByTypeID(typeID);
                IPagedList<BLL.Entities.Product> ProductsList = list.ToPagedList(Page.HasValue ? Convert.ToInt32(Page) : pageIndex, pageSize);
                ViewBag.typeID = typeID;
                //switch (sortOrder)

                //{

                //    case "date_desc":
                //        list = list.OrderByDescending(s => s.CreationDate);
                //        break;
                //    default:  // Name ascending 
                //        list = list.OrderBy(s => s.NameEn);
                //        break;
                //}

                return PartialView(ProductsList);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public ActionResult ProductDetails(Guid prodid)
        {
            //EFContext ef = new EFContext();
            //BLL.Entities.ProductViews pv = new ProductViews();
            //pv.PrID = prodid;
            //ef.Set<ProductViews>().Add(pv);
            //ef.SaveChanges();
            var sizes = sizesRepository.GetAll();
            ViewBag.Sizes = new SelectList(sizes, "Value");
            var product = prodrepository.GetById(prodid);
           
            return View(product);
        }

        public ActionResult BestSeller()
        {

            return PartialView();
        }

        public int Rating(int number, Guid productid)
            {
                var userid = Guid.Parse("F376E831-C788-47E9-ABD6-8A141D7D7FBE");
                var findrecord = boxReviewRepository.GetwithExpression(c => c.ProdID == productid && c.Userid == userid).SingleOrDefault();
                 return number;
            //var userid = Guid.Parse("F376E831-C788-47E9-ABD6-8A141D7D7FBE"); // Guid.Parse                var prod_id = Guid.Parse(productid);
            //var findrecord = boxReviewRepository.GetwithExpression(c => c.ProdID == productid && c.Userid == userid).SingleOrDefault();
            //    if (findrecord == null)
            //    {
            //       BLL.Entities.BoxReviews Review = new BoxReviews();
            //        Review.ProdID = productid;
            //        Review.rating = number;
            //        boxReviewRepository.Save(Review);

            //    }
            //    else
            //    {
            //        findrecord.rating = number;
            //        boxReviewRepository.Update(findrecord);
            //    }
        }
 
        public ActionResult ReviewPartial(Guid prodid)
        {
            //var userid = Guid.Parse("F376E831-C788-47E9-ABD6-8A141D7D7FBE"); // Guid.Parse(User.Identity.GetUserId());

            //var average = boxReviewRepository.GetwithExpression(c => c.ProdID == prodid).GroupBy(c => c.rating).ToList();
            //double totalVoters = 0;
            //double totalPoints = 0;
            //for (int i = 0; i < average.Count(); i++)
            //{
            //    var res = average[i];
            //    totalVoters += res.Count();
            //    totalPoints += res.Key * res.Count();
            //}
            //double avg_rating = Convert.ToDouble(String.Format("{0:0.0}", totalPoints / totalVoters));
            //ViewBag.avg = avg_rating;
            //var findrecord = boxReviewRepository.GetwithExpression(c => c.ProdID == prodid && c.Userid == userid).SingleOrDefault();
            //if (findrecord != null)
            //{
            //    ViewBag.Rate = findrecord.rating;
            //    ViewBag.Favourite = findrecord.Favourite;
            //}
            //else
            //{
            //    ViewBag.Rate = 0;
            //}
            ViewBag.productid = prodid;
            return PartialView();
        }

        [HttpPost]
        public ActionResult ReviewPartial(BoxReviews model, string returnURL)
        {
            //var userid = Guid.Parse("F376E831-C788-47E9-ABD6-8A141D7D7FBE"); // Guid.Parse                var prod_id = Guid.Parse(productid);
            //var findrecord = boxReviewRepository.GetwithExpression(c => c.ProdID == boxReviews.ProdID && c.Userid == userid).SingleOrDefault();
            //if (findrecord == null)
            //{
            //    BLL.Entities.BoxReviews Review = new BoxReviews();
            //    Review.rating = Rating();
            //    boxReviewRepository.Save(Review);

            //}
            //else
            //{
            //    findrecord.rating = number;
            //    boxReviewRepository.Update(findrecord);
            //}
            // model.rating = number;
            var url = returnURL;
            boxReviewRepository.Save(model);
            return Redirect(returnURL);
        }
        public ActionResult _RecentProducts()
        {
            IEnumerable<BLL.Entities.Product> products = null;
            //var products = prodrepository.GetProductsBycategID(Categid);
            var date1 = DateTime.Now.AddDays(-40); // Last 30 Days products
            products = prodrepository.GetwithExpression(c => c.CreationDate > date1 && c.productstatus == ProductStatus.Confirmed).Take(6).ToList();
            return PartialView(products);
        }

        public ActionResult _MostViewedProducts()
        {
            var list=prodrepository.MostViewedProducts().Take(4);
            return PartialView(list);
        }

        public ActionResult _BestSellerProducts(Guid Categid)
        {
            IEnumerable<BLL.Entities.Product> products = null;
            //var products = prodrepository.GetProductsBycategID(Categid);
            var date1 = DateTime.Now.AddDays(-40); // Last 30 Days products
            products = prodrepository.GetwithExpression(c => c.CreationDate > date1 && c.productstatus == ProductStatus.Confirmed).ToList();
            return View(products);
        }


        //[Authorize]
        //public int Rating(int number, string productid)
        //{
        //    var userid = Guid.Parse(User.Identity.GetUserId());
        //    var prod_id = Guid.Parse(productid);
        //    var findrecord = ReviewBoxesdb.Get(c => c.ProductsID == prod_id && c.UserID == userid).SingleOrDefault();
        //    if (findrecord == null)
        //    {
        //        ReviewBoxes Review = new ReviewBoxes();
        //        Review.ProductsID = Guid.Parse(productid);
        //        Review.Rating = number;
        //        int i = ReviewBoxesdb.Add(Review);
        //        return i;
        //    }
        //    else
        //    {
        //        findrecord.Rating = number;
        //        int i = ReviewBoxesdb.Update(findrecord);
        //        return i;
        //    }
        //}
        //[Authorize]
        //public int Favourite(string productid, bool favourite)
        //{
        //    var userid = Guid.Parse(User.Identity.GetUserId());
        //    var prod_id = Guid.Parse(productid);
        //    var findrecord = ReviewBoxesdb.GetSingleOrDefault(c => c.ProductsID == prod_id && c.UserID == userid);
        //    if (findrecord == null)
        //    {
        //        ReviewBoxes Review = new ReviewBoxes();
        //        Review.ProductsID = Guid.Parse(productid);
        //        Review.Rating = 0;
        //        Review.Favourite = favourite;
        //        int i = ReviewBoxesdb.Add(Review);
        //        return i;
        //    }
        //    else
        //    {
        //        findrecord.Favourite = favourite;
        //        int i = ReviewBoxesdb.Update(findrecord);
        //        return i;
        //    }
        //}
    }
}