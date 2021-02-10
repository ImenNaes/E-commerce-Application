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
    public class InvoicesController : Controller
    {
        private InvoiceRepository invoicesrepo;
        public InvoicesController()
        {
            invoicesrepo = new InvoiceRepository();
        }
        // GET: Invoices
        public ActionResult Index()
        {
            IEnumerable<Invoice> invoices= invoicesrepo.GetAll().ToList();
            return View(invoices);
        }
     
    }
}