using Lottery.WebMvc.Models;
using Amin.CustomAuthen;
using Lottery.WebMvc.Models;
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
                    ViewBag.Message = "Tài khoản đăng nhập không đúng";
                    return View(model);
                }
                var userData = userBase.Result.Data;
                userData.UserAgent = IdentifyUserAgent();
                if (userData == null)
                {
                    ViewBag.Message = "User is not registered to application";
                }
                else
                {
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, model.LoginName, DateTime.Now, DateTime.Now.AddMinutes(720), false, JsonConvert.SerializeObject(userData), FormsAuthentication.FormsCookiePath);
                    string hash = FormsAuthentication.Encrypt(ticket);
                    HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, hash);
                    Response.Cookies.Add(cookie);

                    if (IdentifyUserAgent() == (int)UserAgentEnum.Iphone || IdentifyUserAgent() == (int)UserAgentEnum.Android)
                    {
                        return RedirectToAction("IndexMb", "Calculation");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Calculation");
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Have error when login. Please check with our Administrator";
            }

            return View(model);
        }
        public ActionResult Logout()
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

            return RedirectToAction("Login", "Account");
        }
        #endregion Login 
    }
}