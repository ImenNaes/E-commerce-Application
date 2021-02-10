using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
namespace DAL
{
   public static class HtmlExtensions
    {
        public static MvcHtmlString Image(this HtmlHelper html, byte[] image, string strClass)
        {
            var Base64String = Convert.ToBase64String(image, 0, image.Length);
            var imgSrc = String.Format("data:image/jpg;base64,{0}", Base64String);
            return new MvcHtmlString("<img src='" + Base64String + "' class='" + strClass+ "'/>");
        }
    }
}
