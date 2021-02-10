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
    public class ContactSMSController : Controller
    {
        private ContactsRepository contacts;
        public ContactSMSController()
        {
            contacts = new ContactsRepository();
        }
        // GET: ContactSMS
        public ActionResult Index()
        {
            IEnumerable<ContactSMS> contactslist= contacts.GetAll().ToList();
            return View(contactslist);
        }

    }
}