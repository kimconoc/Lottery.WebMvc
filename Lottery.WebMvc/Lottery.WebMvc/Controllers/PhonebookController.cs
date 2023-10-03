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
        public ActionResult UpdatePlayer(int playerId)
        {
            var userData = GetCurrentUser();
            List<Phonebook> phonebooks = new List<Phonebook>();
            var dataBase = provider.GetAsync<List<Phonebook>>(string.Format(ApiUri.Get_Phonebook + "/{0}", userData.Id));
            if (dataBase != null && dataBase.Result != null && dataBase.Result.Data != null)
            {
                phonebooks = dataBase.Result.Data;
            }
            var phonebook = phonebooks.FirstOrDefault(x => x.Id == playerId);

            return View(phonebook);
        }

        [HttpPost]
        public ActionResult ExecuteCreatePlayer(string playerJsons)
        {
            var userData = GetCurrentUser();
            var players = JsonConvert.DeserializeObject<List<PhonebookModel>>(playerJsons);
            players[0].UserID = userData.Id;
            // Tạo mới
            if (players[0].Id == null)
            {
                players[0].IsDeleted = false;
                players[0].PhoneNumber = "";
                var playerBase = provider.PutAsync<object>(ApiUri.POST_UserUpdatePhonebook, players);
                if (playerBase != null || playerBase.Result != null || playerBase.Result.IsSuccessful)
                {
                    return Json(Success_Request(playerBase.Result.IsSuccessful));
                }
            }
            // Update
            else if (players[0].Id != null && !players[0].IsDeleted)
            {
                if (string.IsNullOrEmpty(players[0].PhoneNumber))
                {
                    players[0].PhoneNumber = "";
                }
                var playerBase = provider.PutAsync<object>(ApiUri.POST_UserUpdatePhonebook, players);
                if (playerBase != null || playerBase.Result != null || playerBase.Result.IsSuccessful)
                {
                    return Json(Success_Request(playerBase.Result.IsSuccessful));
                }
            }
            
            return View(Server_Error());

        }
        [HttpPost]
        public ActionResult ExecuteDeletePlayer(int playerId)
        {
            var userData = GetCurrentUser();
            List<Phonebook> phonebooks = new List<Phonebook>();
            var dataBase = provider.GetAsync<List<Phonebook>>(string.Format(ApiUri.Get_Phonebook + "/{0}", userData.Id));
            if (dataBase != null && dataBase.Result != null && dataBase.Result.Data != null)
            {
                phonebooks = dataBase.Result.Data;
            }
            var phonebook = phonebooks.FirstOrDefault(x => x.Id == playerId);
            phonebook.IsDeleted = true;
            var players = new List<Phonebook>();
            players.Add(phonebook);

            // Xóa
            var playerBase = provider.PutAsync<object>(ApiUri.POST_UserUpdatePhonebook, players);
            if (playerBase != null || playerBase.Result != null || playerBase.Result.IsSuccessful)
            {
                return Json(Success_Request(playerBase.Result.IsSuccessful));
            }

            return View(Server_Error());
        }
    }
}