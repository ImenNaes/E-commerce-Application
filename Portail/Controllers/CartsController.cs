using Portail.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Portail.Controllers
{
    public class CartsController : Controller
    {
        // GET: Carts
        HttpClient client = new HttpClient();

        // GET: Payment
        public ActionResult Index()
        {
            IEnumerable<Carts> cartslist;
            client.BaseAddress = new Uri("https://localhost:44363/api/");
            //HTTP GET
            var responseTask = client.GetAsync("Carts");
            responseTask.Wait();
            var result = responseTask.Result;

            var readTask = result.Content.ReadAsAsync<Carts[]>();
            readTask.Wait();

            var carts = readTask.Result;
            cartslist = carts;
            return View(cartslist);
        }
      
    }
}