using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL.Repositories;
using BLL.Entities;

namespace Business.Controllers
{
    public class CartsController : Controller
    {
        private CartsRepository cartsrepo;
        public CartsController()
        {
            cartsrepo = new CartsRepository();
        }
        // GET: Carts
        public ActionResult Index()
        {
            //if (((List<BLL.Entities.Carts>)Session["Cart"]) != null && ((List<BLL.Entities.Carts>)Session["Cart"]).Count() != 0)
            //    return View("Index");
            //else
            //    return RedirectToAction("Index", "Home");   
            return View("Index");
        }


      
        public ActionResult Delete(Guid id, string returnURL)
        {
                var cart = cartsrepo.GetById(id);
                if (cart != null)
                {
                    cartsrepo.DeleteFull(cart);
                    //db.SaveChanges();
                }
                string ss = Request.Cookies["ai_Cart"].Value;
                Session["Cart"] = cartsrepo.GetwithExpression(c => c.ai_Cart == ss);
                return Redirect(returnURL);
        }

        public ActionResult DeleteAll(string returnURL)
        {
                string ss = Request.Cookies["ai_Cart"].Value;
                var cart = cartsrepo.GetwithExpression(c => c.ai_Cart == ss);
                if (cart != null)
                {
                    cartsrepo.DeleteRange(cart);
                }
                Session["Cart"] = null;
                return Redirect(returnURL);   
        }

        public ActionResult Edit_QTY(Guid id, int Quantity, Guid PBDid)
        {
                //BLL.Entities.Product PDItem = new BLL.Entities.Product();
                //PDItem = Productdb.GetInclude(c => c.ID == PBDid).FirstOrDefault();
                string ai_cartCookies = Request.Cookies["ai_Cart"].Value;
                BLL.Entities.Carts CurrentCart = new BLL.Entities.Carts();
                if (Quantity > 0)
                {
                    BLL.Entities.Carts c = cartsrepo.GetById(id);
                    c.Quantity = Quantity;
                    cartsrepo.Update(c);
                    Session["Cart"] = cartsrepo.GetwithExpression(x => x.ai_Cart == ai_cartCookies);
                    return RedirectPermanent(Url.Action("index", "Carts") + "/Index");
                }
                else
                {
                    TempData["errorUpdateQty"] = "You are trying to add the quantity greater than the exist";
                    return RedirectPermanent(Url.Action("index", "Carts") + "/Index");
                }
           
        }


    }
}