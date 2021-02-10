using BLL.Entities;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Portail.Controllers
{
    public class CountriesController : Controller
    {
        private CountriesRepository countrierepositories;
        public CountriesController()
        {
            countrierepositories = new CountriesRepository();
        }
        // GET: Countries
        public ActionResult Index()
        {
            IEnumerable<Country> countrieslist= countrierepositories.GetAll();
            return View(countrieslist.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Country country)
        {
            countrierepositories.Save(country);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(Guid id)
        {
            var countryrow = countrierepositories.GetById(id);
            return View(countryrow);
        }

        [HttpPost]
        public ActionResult Edit(Country country)
        {
            var edit = countrierepositories.Update(country);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(Guid id)
        {
            countrierepositories.Delete(id);
            return RedirectToAction("Index");
        }
    }
}