using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using BusinessLogicLayer;
using Simuu;

namespace Simuu.Controllers
{
    [MustBeInRole(Roles = Constants.AdminRoleName)]
    public class UserController : Controller
    {

        // Pagination for Users
        public ActionResult Page(int PageNumber, int PageSize)
        {
            ViewBag.PageNumber = PageNumber;
            ViewBag.PageSize = PageSize;
            List<UserBLL> model = new List<UserBLL>();
            try
            {
                using (ContextBLL ctx = new ContextBLL())
                {
                    ViewBag.TotalCount = ctx.Users_ObtainCount();
                    model = ctx.Users_Get(PageNumber * PageSize, PageSize);
                }
                return View("Index", model);
            }
            catch (Exception ex)
            {
                ViewBag.Exception = ex;
                return View("Error");
            }
        }

        // Create a List of Roles for drop-down selection
        List<SelectListItem> GetRoleItems()
        {
            List<SelectListItem> proposedReturnValue = new List<SelectListItem>();
            using (ContextBLL ctx = new ContextBLL())
            {
                List<RoleBLL> roles = ctx.Roles_Get(0, 25);
                foreach (RoleBLL role in roles)
                {
                    SelectListItem item = new SelectListItem();
                    item.Value = role.RoleID.ToString();
                    item.Text = role.RoleName;
                    proposedReturnValue.Add(item);
                }
            }
            return proposedReturnValue;
        }

        // GET: User
        public ActionResult Index()
        {
            return RedirectToRoute(new { Controller = "User", Action = "Page", PageNumber = 0, PageSize = ApplicationConfig.DefaultPageSize });
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            UserBLL user;
            try
            {
                using (ContextBLL ctx = new ContextBLL())
                {
                    user = ctx.User_FindByUserID(id);
                    if (null == user)
                    {
                        return View("Error"); // Make an item not found view?
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Exception = ex;
                return View("Error");
            }
            return View(user);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            UserBLL defUser = new UserBLL();
            defUser.UserID = 0;
            ViewBag.Roles = GetRoleItems();
            return View(defUser);
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(UserBLL collection)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(collection);
                }
                using (ContextBLL ctx = new ContextBLL())
                {
                    BusinessLogicLayer.UserBLL user = ctx.User_FindByUserName(collection.UserName);
                    user = new UserBLL();
                    user.UserName = collection.UserName;
                    user.UserEmail = collection.UserEmail;
                    user.PasswordSalt = System.Web.Helpers.Crypto.GenerateSalt(Constants.SaltSize);
                    user.PasswordHash = System.Web.Helpers.Crypto.HashPassword(collection.PasswordHash + user.PasswordSalt);
                    user.RoleID = collection.RoleID;
                    ctx.User_Create(user);
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Exception = ex;
                return View("Error");
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            UserBLL user;
            try
            {
                using (ContextBLL ctx = new ContextBLL())
                {
                    user = ctx.User_FindByUserID(id);
                    if (null == user)
                    {
                        return View("Error"); // Make an item not found view?
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Exception = ex;
                return View("Error");
            }
            ViewBag.Roles = GetRoleItems();
            return View(user);
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, UserBLL collection)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(collection);
                }
                // TODO: Add insert logic here
                using (ContextBLL ctx = new ContextBLL())
                {
                    ctx.User_JustUpdate(collection);
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Exception = ex;
                return View("Error");
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            UserBLL user;
            try
            {
                using (ContextBLL ctx = new ContextBLL())
                {
                    user = ctx.User_FindByUserID(id);
                    if (null == user)
                    {
                        return View("Error"); // Make item not found view?
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Exception = ex;
                return View("Error");
            }
            return View(user);
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, UserBLL collection)
        {
            if (!ModelState.IsValid)
            {
                return View(collection);
            }
            try
            {
                using (ContextBLL ctx = new ContextBLL())
                {
                    ctx.User_Delete(id);
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Exception = ex;
                return View("Error");
            }
        }

        // POST Simuu-Create + User-Create
        public ActionResult CreateUserSimuu()
        {
            ViewBag.Message = "Your Simulation page.";

            return View();
        }
    }
}
