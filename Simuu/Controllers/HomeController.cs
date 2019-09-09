using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using BusinessLogicLayer;

namespace Simuu.Controllers
{
    public class HomeController : Controller
    {

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        // GET: Home/About
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        // GET: Home/Contact
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        // GET: Home/Simulation
        public ActionResult Simulation()
        {
            ViewBag.Message = "Your Simulation page.";

            return View();
        }

        // GET: Home/Register
        public ActionResult Register()
        {
            return View();
        }

        // POST: Home/Register
        [HttpPost]
        public ActionResult Register(RegistrationModel info)
        {
            try
            {
                using (ContextBLL ctx = new ContextBLL())
                {
                    if (!ModelState.IsValid)
                    {
                        ViewBag.Users = ctx.User_FindByUserName(info.UserName);
                        return View(info);
                    }
                    UserBLL user = ctx.User_FindByUserName(info.UserName);
                    if (user != null)
                    {
                        info.Message = $"The Username '{info.UserName}' already exists in the database";
                        return View(info);
                    }
                    user = new UserBLL();
                    user.UserName = info.UserName;
                    user.UserEmail = info.UserEmail;
                    user.PasswordSalt = System.Web.Helpers.Crypto.GenerateSalt(Constants.SaltSize);
                    user.PasswordHash = System.Web.Helpers.Crypto.HashPassword(info.Password + user.PasswordSalt);
                    user.RoleID = 3;

                    ctx.User_Create(user);
                    Session["AUTHUsername"] = user.UserName;
                    Session["AUTHRoles"] = user.RoleName;
                    Session["AUTHTYPE"] = "HASHED";
                    return RedirectToAction("Index");
                }

            }
            catch (Exception)
            {
                info.Message = $"Required fields left blank!";
                return View(info);
            }
        }

        // GET: Home/Hash
        public ActionResult Hash()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return View("NotLoggedIn");
            }

            if (User.Identity.AuthenticationType.StartsWith("HASHED"))
            {
                return View("AlreadyHashed");
            }

            if (User.Identity.AuthenticationType.StartsWith("IMPERSONATED"))
            {
                return View("ActionNotAllowed");
            }

            using (BusinessLogicLayer.ContextBLL ctx = new BusinessLogicLayer.ContextBLL())
            {
                BusinessLogicLayer.UserBLL user = ctx.User_FindByUserName(User.Identity.Name);
                if (user == null)
                {
                    Exception Message = new Exception($"The Username '{User.Identity.Name}' does not exist in the database");
                    ViewBag.Exception = Message;
                    return View("Error");
                }
                user.PasswordSalt = System.Web.Helpers.Crypto.GenerateSalt(Constants.SaltSize);
                user.PasswordHash = System.Web.Helpers.Crypto.HashPassword(user.PasswordHash + user.PasswordSalt);
                ctx.User_JustUpdate(user);

                string ValidationType = $"HASHED:({user.UserID})";

                Session["AUTHUsername"] = user.UserEmail;
                Session["AUTHRoles"] = user.RoleName;
                Session["AUTHTYPE"] = ValidationType;

                return RedirectToAction("Index", "Home");
            }
        }

        // GET: Home/Login
        [HttpGet]
        public ActionResult Login()
        {
            LoginModel model = new LoginModel();
            model.Message = TempData["Message"]?.ToString() ?? "";
            model.ReturnURL = TempData["ReturnURL"]?.ToString() ?? @"~/Home";
            model.UserName = "";
            model.Password = "";
            return View(model);
        }

        // POST: Home/Login
        [HttpPost]
        public ActionResult Login(LoginModel info)
        {
            try
            {
            using (ContextBLL ctx = new ContextBLL())
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.Users = ctx.User_FindByUserName(info.UserName);
                    return View(info);
                }
                UserBLL user = ctx.User_FindByUserName(info.UserName);
                if (user == null)
                {
                    info.Message = $"The Username '{info.UserName}' does not exist in the database";
                    return View(info);
                }
                string actual = user.PasswordHash;
                string potential = info.Password;
                string ValidationType = $"ClearText:({user.UserID})";
                bool validateduser = actual == potential;
                if (!validateduser)
                {
                    potential = info.Password + user.PasswordSalt;
                    try
                    {
                        validateduser = System.Web.Helpers.Crypto.VerifyHashedPassword(actual, potential);
                        ValidationType = $"HASHED:({user.UserID})";
                    }
                    catch (Exception)
                    {
                        validateduser = false;
                    }
                }
                if (validateduser)
                {
                    Session["AUTHUser"] = user.UserName;
                    Session["AUTHRole"] = user.RoleName;
                    Session["AUTHTYPE"] = ValidationType;
                    return Redirect(info.ReturnURL);
                }
                info.Message = "The password was incorrect";
                return View(info);
                }

            }
            catch (Exception)
            {
                info.Message = $"Required fields left blank!";
                return View(info);
            }
        }

        // GET: Home/Logout
        public ActionResult Logout()
        {
            Session.Remove("AUTHUser");
            Session.Remove("AUTHRole");
            Session.Remove("AUTHTYPE");
            return RedirectToAction("Index");
        }

    }
}