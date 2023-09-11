using Amin.Controllers;
using Amin.CustomAuthen;
using Amin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static Admin.Common.Constant;
using System.Linq.Dynamic;

namespace Admin.Controllers
{
    public class UserController : BaseController
    {
        public ActionResult ListUser()
        {
            return View();
        }
        public ActionResult GetListUser(DataTablesQueryModel queryModel)
        {
            return null;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeactivateUser(Guid id)
        {
            return Json(Success_Request());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ActivateUser(Guid id)
        {
            return Json(Success_Request());
        }
    }
}