using Lottery.WebMvc.Models;
using Lottery.WebMvc.Controllers;
using Lottery.DoMain.Constant;
using Lottery.DoMain.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;

namespace Lottery.WebMvc.Controllers
{
    public class AdminController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ExecuteCalculation(string calculationJson)
        {
            var calculations = JsonConvert.DeserializeObject<List<CalculationModel>>(calculationJson);

            var calculationBase = provider.PostAsync<Calculation>(ApiUri.POST_CalculationCal1, calculations);
            if (calculationBase == null || calculationBase.Result == null || calculationBase.Result.Data == null)
            {
                ViewBag.Message = "Tài khoản đăng nhập không đúng";
                return View(Server_Error());
            }

            return Json(Success_Request(calculationBase.Result.Data));

        }

    }
}