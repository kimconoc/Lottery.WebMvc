using Admin.Common;
using Admin.Models;
using Amin.CustomAuthen;
using Amin.Models;
using Lottery.DoMain.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Amin.Controllers
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
            bool isValidADAccount = LoginAdAccount(model.UserName, model.Password);
            if (isValidADAccount)
            {
                try
                {
                    var userAdmin = new UserAdmin()
                    {
                        Id = new Guid(),
                        Username = model.UserName,
                        DisplayName = model.UserName,
                        Roles = Constant.AdminRoles.SuperAdmin,
                    };
                    if (userAdmin == null)
                    {
                        ViewBag.Message = "User is not registered to application";
                    }
                    else
                    {
                        var userData = StoreUserData(userAdmin);
                        FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, model.UserName, DateTime.Now, DateTime.Now.AddMinutes(720), false, JsonConvert.SerializeObject(userData), FormsAuthentication.FormsCookiePath);
                        string hash = FormsAuthentication.Encrypt(ticket);
                        HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, hash);
                        Response.Cookies.Add(cookie);
                        return RedirectToAction("Index", "Admin");
                    }
                }
                catch(Exception ex)
                {
                    ViewBag.Message = "Have error when login. Please check with our Administrator";
                }

            }
            else
            {
                ViewBag.Message = "Input informations is incorrect";
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
        private bool LoginAdAccount(string userName, string password)
        {
            return true;
        }
        private UserData StoreUserData(UserAdmin userAdmin)
        {
            var userData = new UserData
            {
                UserId = userAdmin.Id,
                Username = userAdmin.Username,
                DisplayName = userAdmin.DisplayName,
                Roles = userAdmin.Roles != null? new List<string>(userAdmin.Roles.Split(',')) : new List<string>(),
            };
            return userData;
        }

        #endregion Login 
    }
}