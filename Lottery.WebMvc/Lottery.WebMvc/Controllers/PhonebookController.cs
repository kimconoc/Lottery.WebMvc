using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lottery.WebMvc.Controllers
{
    public class PhonebookController : BaseController
    {
        public ActionResult CreatePlayer()
        {
            return View();
        }
    }
}