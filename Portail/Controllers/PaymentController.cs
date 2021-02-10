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
    public class PaymentController : Controller
    {
        private PaymentRepository paymentRepository;
        public PaymentController()
        {
            paymentRepository = new PaymentRepository();
        }
        // GET: Payment
        public ActionResult Index()
        {
            IEnumerable<Payment> paymentlist= paymentRepository.GetAll().ToList();
            return View(paymentlist);
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Payment payment)
        {
            paymentRepository.Save(payment);
            return RedirectToAction("Index");
        }


        public ActionResult Edit(Guid id)
        {
            var pay = paymentRepository.GetById(id);
            return View(pay);           
        }

        [HttpPost]
        public ActionResult Edit(Payment payment)
        {
            var edited = paymentRepository.Update(payment);
            return View(edited);
        }

        public ActionResult Delete(Guid id)
        {
            paymentRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}