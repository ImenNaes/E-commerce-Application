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
    public class CitiesController : Controller
    {
        private CitiesRepository citiesrepository;
        private CountriesRepository countriesRepository;

        public CitiesController()
        {
            citiesrepository = new CitiesRepository();
            countriesRepository = new CountriesRepository();
        }
        // GET: Cities
        public ActionResult Index()
        {
            IEnumerable<City> citieslist= citiesrepository.GetAll();
           
            return View(citieslist.ToList());
        }


        public ActionResult Create()
        {
            IEnumerable<Country> countries = countriesRepository.GetAll().ToList();        
            ViewBag.countries = new SelectList(countries, "ID", "NameEn");
            return View();
        }

        [HttpPost]
        public ActionResult Create(City city)
        {
            citiesrepository.Save(city);
            return RedirectToAction("Index");
        }


        public ActionResult Edit(Guid id)
        {
            IEnumerable<Country> countries = countriesRepository.GetAll().ToList();
            ViewBag.countries = new SelectList(countries, "ID", "NameEn");
            var cityrow = citiesrepository.GetById(id);
            return View(cityrow);
        }

        [HttpPost]
        public ActionResult Edit(City city)
        {
            citiesrepository.Update(city);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(Guid id)
        {
            citiesrepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}