using Lottery.WebMvc.Models;
using Amin.CustomAuthen;
using Lottery.DoMain.Constant;
using Lottery.DoMain.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Lottery.DoMain.Enum;

namespace Lottery.WebMvc.Controllers
{
    public class AccountController : BaseController
    {
        #region Login
        public ActionResult Login()
        {
            var userData = GetCurrentUser();
            if (userData != null)
            {
                return RedirectToAction("IndexImport", "Calculation");
            }    

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string ReturnUrl = "")
        {
            try
            {
                var userBase = provider.PostAsync<User>(ApiUri.POST_UserLogin, model);
                if (userBase == null || userBase.Result == null || userBase.Result.Data == null)
                {
                    ViewBag.Message = "Đã có lỗi xảy ra!";
                    return View(model);
                }
                var userData = userBase.Result.Data;
                if (!userData.isLoginSuccess)
                {
                    ViewBag.Message = "Tài khoản đăng nhập không đúng!";
                    return View(model);
                }
                else
                {
                    ExecuteSaveCookies(userData);
                    return RedirectToAction("IndexImport", "Calculation");
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Have error when login. Please check with our Administrator!";
            }

            return View(model);
        }
        public ActionResult Logout()
        {
            RemoteCookies();
            return RedirectToAction("Login", "Account");
        }
        #endregion Login 

        public ActionResult Account()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ExecuteUpdateAccount(string accountJson)
        {
            try
            {
                var account = JsonConvert.DeserializeObject<UserModel>(accountJson);

                var ResultBase = provider.PutAsync<object>(ApiUri.PUT_UpdateUser, account);
                if (ResultBase == null || ResultBase.Result == null || !ResultBase.Result.IsSuccessful)
                {
                    return View(Server_Error());
                }

                RemoteCookies();

                User userData = null;
                var dataBase = provider.GetAsync<User>(string.Format(ApiUri.GET_UserInfo + "/{0}", account.UserID));
                if (dataBase != null && dataBase.Result != null && dataBase.Result.Data != null)
                {
                    userData = dataBase.Result.Data;
                }
                ExecuteSaveCookies(userData);
                return Json(Success_Request(true));
            }
            catch 
            {
                return View(Server_Error());
            }
        }

        private void ExecuteSaveCookies(User userData)
        {
            userData.UserAgent = IdentifyUserAgent();
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, userData.Account, DateTime.Now, DateTime.Now.AddMinutes(720), false, JsonConvert.SerializeObject(userData), FormsAuthentication.FormsCookiePath);
            string hash = FormsAuthentication.Encrypt(ticket);
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, hash);
            Response.Cookies.Add(cookie);
        }
        private void RemoteCookies()
        {
            if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            {
                try
                {
                    string session = Request.Cookies[FormsAuthentication.FormsCookieName].Value;
                }
                catch (Exception) { }
            }

            FormsAuthentication.SignOut();
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, "");
            cookie.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie);
        }
    }
}