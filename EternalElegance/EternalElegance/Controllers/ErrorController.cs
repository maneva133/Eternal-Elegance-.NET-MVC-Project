using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EternalElegance.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Unauthorized()
        {
            return View();
        }
    }

}