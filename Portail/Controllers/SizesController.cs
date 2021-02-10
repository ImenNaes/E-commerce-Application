using BLL.Entities;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portail.Controllers
{
    public class SizesController : Controller
    {

        private SizesRepository sizesrepo;
        private ProductTypeRepository productTypeRepository;
        public SizesController()
        {
            sizesrepo = new SizesRepository();
        }
        // GET: Products
        public ActionResult Index()
        {
            var list = sizesrepo.GetAll();
            return View(list.ToList());
        }

        public ActionResult Create()
        {
          
            //IEnumerable<ProductType> listTypes = productTypeRepository.GetAll().ToList();
            //ViewBag.Types = new SelectList(listTypes, "ID", "NameEn");
            return View();
        }
        [HttpPost]
        public ActionResult Create(Size size)
        {
            sizesrepo.Save(size);
            return RedirectToAction("Index");
           
        }


    }
}