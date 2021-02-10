using BLL.Entities;
using BLL.Interfaces.Services;
using BLL.Interfaces.Repositories;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace Portail.Controllers
{
    public class ProductCategoriesController : Controller
    {
        private ProductCategorieRepository _prodCategService;
        public ProductCategoriesController()
        {
            _prodCategService = new ProductCategorieRepository();
        }
        //public ProductCategoriesController(IProdCategoriesRepository prodCategService)
        //{
        //    _prodCategService= prodCategService;
        //}

        // GET: ProductCategories
        public ActionResult Index()
        {
           var list= _prodCategService.GetAll();          
            return View(list.Where(c=>c.IsDeleted==false).ToList());
        }
        public byte[] Images(HttpPostedFileBase picturefile)
        {
            BinaryReader reader = new BinaryReader(picturefile.InputStream);
            byte[] imagebytes = reader.ReadBytes(picturefile.ContentLength);
            return imagebytes;
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ProductCategorie productCategorie, HttpPostedFileBase picturefile)
        {          
            if (picturefile != null)
            {
                productCategorie.Icon = Images(picturefile);
            }
            _prodCategService.Save(productCategorie);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(Guid id)
        {
            var categorie = _prodCategService.GetById(id);          
            return View(categorie);
        }

        [HttpPost]
        public ActionResult Edit(ProductCategorie category)
        {
            ProductCategorie categ= _prodCategService.Update(category);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(Guid id)
        {
             _prodCategService.Delete(id);
            return RedirectToAction("Index");
        }
       
    }
}