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
    public class ProductsController : Controller
    {
        private ProductRepository productRepository;
        private ProductTypeRepository productTypeRepository;
        private ProductCategorieRepository productcategorieRepository;
        private SizesRepository sizesRepo;
        private ProductStatus prodstatus;
        public ProductsController()
        {
            productRepository = new ProductRepository();
            productTypeRepository = new ProductTypeRepository();
            productcategorieRepository = new ProductCategorieRepository();
            prodstatus = new ProductStatus();
            sizesRepo = new SizesRepository();
        }
        // GET: Products
        public ActionResult Index()
        {
            var list = productRepository.GetAll();
            return View(list.ToList());
        }

        public ActionResult Create()
        {
            IEnumerable<ProductCategorie> categlist = productcategorieRepository.GetAll().ToList();
            ViewBag.categories = new SelectList(categlist, "ID", "NameEn");

            IEnumerable<Size> sizes = sizesRepo.GetAll().ToList();
            ViewBag.sizes = new SelectList(sizes, "ID", "Value");

            IEnumerable<ProductType> listTypes = productTypeRepository.GetAll().ToList();
            ViewBag.Types = new SelectList(listTypes, "ID", "NameEn");
            return View();
        }
        public byte[] Images(HttpPostedFileBase picturefile)
        {
            BinaryReader reader = new BinaryReader(picturefile.InputStream);
            byte[] imagebytes = reader.ReadBytes(picturefile.ContentLength);
            return imagebytes;
        }
        [HttpPost]
        public ActionResult Create(Product product/*, List<HttpPostedFileBase> smallimageList*/, HttpPostedFileBase picturefile)
        {
            //if (smallimageList.Count > 0 || smallimageList != null)
            //{
            //    new HomeController().SaveToFolder(product.ID.ToString(), smallimageList, null);
            //}
            //if (picturefile != null)
            //{
            //    product.MainImage.ImageContent = Images(picturefile);
            //}
            //product.MainImage.ProductSmallImages.Add(smallimageList);
            productRepository.Save(product);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(Guid id)
        {
            IEnumerable<ProductType> listtypes = productTypeRepository.GetAll().ToList();
            ViewBag.producttypes = new SelectList(listtypes, "ID", "NameEn");
            var product = productRepository.GetById(id);
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            Product prod = productRepository.Update(product);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(Guid id)
        {
            productRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}