using DAL.Repositories;
using BLL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Portail.Controllers
{
    public class PaymentDetailsController : Controller
    {
        // GET: PaymentDetails
        private PaymentDetailsRepository paymentDetailsRepository;
        public PaymentDetailsController()
        {
            paymentDetailsRepository = new PaymentDetailsRepository();
        }
        public ActionResult Index()
        {
            IEnumerable<PaymentDetails> detailslist= paymentDetailsRepository.GetAll().ToList();           
            return View(detailslist);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(PaymentDetails paymentDetails)
        {
            paymentDetailsRepository.Save(paymentDetails);
            return RedirectToAction("Index");
        }
        public ActionResult Edit(Guid id)
        {
            var detailsrow = paymentDetailsRepository.GetById(id);
            return View(detailsrow);
        }

        [HttpPost]
        public ActionResult Edit(PaymentDetails details)
        {
            var edited = paymentDetailsRepository.Update(details);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(Guid id)
        {
            paymentDetailsRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}