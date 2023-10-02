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
using Lottery.DoMain.Enum;

namespace Lottery.WebMvc.Controllers
{
    public class CalculationController : BaseController
    {
        public ActionResult Index()
        {
            var userData = GetCurrentUser();
            if(userData == null || userData.UserAgent != (int)UserAgentEnum.Computer)
                return RedirectToAction("Login", "Account");

            return View();
        }
        public ActionResult IndexMb()
        {
            var userData = GetCurrentUser();
            if (userData == null || userData.UserAgent == (int)UserAgentEnum.Computer)
                return RedirectToAction("Login", "Account");

            return View();
        }

        [HttpPost]
        public ActionResult ExecuteCalculation(string calculationJson)
        {
            var calculations = JsonConvert.DeserializeObject<List<CalculationModel>>(calculationJson);

            var calculationBase = provider.PostAsync<Calculation>(ApiUri.POST_CalculationCal1, calculations);
            if (calculationBase == null || calculationBase.Result == null || calculationBase.Result.Data == null)
            {
                return View(Server_Error());
            }

            return Json(Success_Request(calculationBase.Result.Data));

        }

    }
}