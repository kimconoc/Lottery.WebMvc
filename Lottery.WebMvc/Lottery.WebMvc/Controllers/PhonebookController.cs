using Lottery.DoMain.Constant;
using Lottery.DoMain.Models;
using Lottery.WebMvc.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lottery.WebMvc.Controllers
{
    public class PhonebookController : BaseController
    {
        public ActionResult ListPlayer()
        {
            return View();
        }
        public ActionResult CreatePlayer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ExecuteCreatePlayer(string playerJson)
        {
            var userData = GetCurrentUser();
            var player = JsonConvert.DeserializeObject<PhonebookModel>(playerJson);
            player.UserID = userData.Id;
            player.IsDeleted = false;
            player.PhoneNumber = "";
            if (player.Id == null)
            {
                var playerBase = provider.PostAsync<object>(ApiUri.POST_UserUpdatePhonebook, player);
                if (playerBase == null || playerBase.Result == null || !playerBase.Result.IsSuccessful)
                {
                    return View(Server_Error());
                }
            }
           
            return Json(Success_Request(true));

        }
    }
}