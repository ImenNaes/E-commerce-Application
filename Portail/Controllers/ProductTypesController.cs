using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using BLL.Entities;
using DAL.Repositories;
namespace Portail.Controllers
{
    public class ProductTypesController : Controller
    {
        private ProductTypeRepository prodTyperepository;
        private ProductCategorieRepository prodCategrepository;

        public ProductTypesController()
        {
            prodTyperepository = new ProductTypeRepository();
            prodCategrepository = new ProductCategorieRepository();
        }
        // GET: ProductTypes
        public ActionResult Index()
        {
            IEnumerable<ProductType> Typeslist= prodTyperepository.GetAll();
            return View(Typeslist.ToList());
        }
        public byte[] Images(HttpPostedFileBase picturefile)
        {
            BinaryReader reader = new BinaryReader(picturefile.InputStream);
            byte[] imagebytes = reader.ReadBytes(picturefile.ContentLength);
            return imagebytes;

        }
        public ActionResult Create()
        {
            IEnumerable<ProductCategorie> categlist = prodCategrepository.GetAll().ToList();
            ViewBag.categories = new SelectList(categlist, "ID", "NameEn");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductType productType, HttpPostedFileBase picture)
        {
            if (picture != null)
            {
                productType.Icon = Images(picture);
            }
            prodTyperepository.Save(productType);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(Guid id)
        {
            IEnumerable<ProductCategorie> categlist = prodCategrepository.GetAll().ToList();
            ViewBag.categories = new SelectList(categlist, "ID", "NameEn");
            var type = prodTyperepository.GetById(id); 
            return View(type);
        }

        [HttpPost]
        public ActionResult Edit(ProductType typee)
        {
            var obj = prodTyperepository.Update(typee);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(Guid id)
        {
            prodTyperepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}