using BLL.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portail.Controllers
{
    public class HomeController : Controller
    {
        //private readonly IProdCategService _prodCategService;
        //public HomeController(IProdCategService prodCategServ)
        //{
        //    _prodCategService = prodCategServ;
        //}
        public ActionResult Index()
        {
           
            return View();
        }
        public ActionResult Traduction(Guid idlanguage, string url)
        {
            
            return RedirectToLocal(url);
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        public void SaveToFolder(string id, List<HttpPostedFileBase> filess, HttpPostedFileBase singlefile)
        {

            int j = 1;
            var f1 = System.Web.HttpContext.Current.Server.MapPath("~/TempImages/");
            if (filess != null)
            {
                foreach (var file in filess)
                {
                    if (file != null)
                    {
                        //var f =Server.MapPath("/Images/");
                        var path = Path.Combine(f1, id + "_" + j + ".jpg");
                        file.SaveAs(path);
                        j++;

                    }
                }

            }
            if (singlefile != null)
            {
                var path = Path.Combine(f1, id + "_" + j + ".jpg");
                singlefile.SaveAs(path);

            }

        }

        public List<string> GetImagesFromFolder(Guid? id)
        {
            var f1 = System.Web.HttpContext.Current.Server.MapPath("~/TempImages/");
            var data = new List<string>();
            DirectoryInfo hdDirectoryInWhichToSearch = new DirectoryInfo(f1);
            FileInfo[] filesInDir = hdDirectoryInWhichToSearch.GetFiles("*" + id.ToString() + "*.*");
            if (id != null)
            {
                foreach (FileInfo foundFile in filesInDir)
                {
                    string fullName = "../TempImages/" + foundFile.Name;
                    data.Add(fullName);
                }
                if (data.Count() != 0)
                    return data;
            }
            return null;


        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}