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
        public ActionResult ExecuteCreatePlayer(string playerJsons)
        {
            var userData = GetCurrentUser();
            var players = JsonConvert.DeserializeObject<List<PhonebookModel>>(playerJsons);
            players[0].UserID = userData.Id;
            players[0].IsDeleted = false;
            players[0].PhoneNumber = "";
            // Tạo mới
            if (players[0].Id == null)
            {
                var playerBase = provider.PutAsync<object>(ApiUri.POST_UserUpdatePhonebook, players);
                if (playerBase != null || playerBase.Result != null || playerBase.Result.IsSuccessful)
                {
                    return Json(Success_Request(playerBase.Result.IsSuccessful));
                }
            }
            // Update
            else if (players[0].Id != null && !players[0].IsDeleted)
            {
                var playerBase = provider.PutAsync<object>(ApiUri.POST_UserUpdatePhonebook, players);
                if (playerBase != null || playerBase.Result != null || playerBase.Result.IsSuccessful)
                {
                    return Json(Success_Request(playerBase.Result.IsSuccessful));
                }
            }
            // Xóa
            else if (players[0].Id != null && players[0].IsDeleted)
            {
                var playerBase = provider.PutAsync<object>(ApiUri.POST_UserUpdatePhonebook, players);
                if (playerBase != null || playerBase.Result != null || playerBase.Result.IsSuccessful)
                {
                    return Json(Success_Request(playerBase.Result.IsSuccessful));
                }
            }    

            return View(Server_Error());

        }
    }
}