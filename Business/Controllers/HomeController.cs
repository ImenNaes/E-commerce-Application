using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using BLL.Entities;
using DAL.Repositories;

namespace Business.Controllers
{
    public class HomeController : Controller
    {
        private ProductCategorieRepository categrepository;
        private ProductTypeRepository productTypeReposiory;
        private ProductRepository productReposiory;

        public HomeController()
        {
            categrepository = new ProductCategorieRepository();
            productTypeReposiory = new ProductTypeRepository();
            productReposiory = new ProductRepository();
        }
      
        public ActionResult GetCategories()
        {
            IEnumerable<ProductCategorie> list = categrepository.GetAll();
            //IEnumerable<ProductType> listTypes = productTypeReposiory.GetAll();
            //ViewBag.Types = listTypes;
            return PartialView(list);
        }
        public ActionResult Index()
        {
            var client = Helper.GlobalWebApi.GetClient();
            return View("Index");
        }


        public ActionResult Index3()
        {
            var client = Helper.GlobalWebApi.GetClient();
            return View();
        }

        public ActionResult GetProductsByCategOne()
        {
            Guid categid = Guid.Parse("AA992F23-3070-4A85-BC60-84E5E9ACC62D");
            var categ = categrepository.GetById(categid);
            ViewBag.categname = categ.NameEn;
            var productsList1 = productReposiory.GetProductsBycategID(categid);
            return PartialView(productsList1);
        }
        public ActionResult GetProductsByCategtwo()
        {
            Guid categid = Guid.Parse("2B7AB4ED-64C7-4B23-AEC9-B68A61C601B8");
            var categ = categrepository.GetById(categid);
            ViewBag.categname = categ.NameEn;
            var productsList = productReposiory.GetProductsBycategID(categid);
            return PartialView(productsList);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Wishlist()
        {
            ViewBag.Message = "Wishlist";

            return View();
        }

        public ActionResult DailyDeals()
        {
            ViewBag.Message = "Deals";

            return View();
        }

    }
}