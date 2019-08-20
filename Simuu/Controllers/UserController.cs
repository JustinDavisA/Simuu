﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using BusinessLogicLayer;

namespace Simuu.Controllers
{
    public class UserController : Controller
    {
        // CREATE: List of Roles for drop-down selection in CREATE: User
        List<SelectListItem> GetRoleItems()
        {
            List<SelectListItem> ProposedReturnValue = new List<SelectListItem>();
            using (ContextBLL ctx = new ContextBLL())
            {
                List<RoleBLL> roles = ctx.Roles_Get(0, 25);
                foreach (RoleBLL role in roles)
                {
                    SelectListItem item = new SelectListItem();
                    item.Value = role.RoleID.ToString();
                    item.Text = role.RoleName;
                    ProposedReturnValue.Add(item);
                }
            }
            return ProposedReturnValue;
        }

        // GET: User
        public ActionResult Index()
        {
            List<UserBLL> model = new List<UserBLL>();
            try
            {
                using (ContextBLL ctx = new ContextBLL())
                {
                    model = ctx.Users_Get(0, 20);
                }
            }
            catch (Exception ex)
            {
                ViewBag.Exception = ex;
                return View("Error");
            }
            return View(model);
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
                using (ContextBLL ctx = new ContextBLL())
                {
                    ctx.User_Create(collection);
                }
                return RedirectToAction("Index");
            }
            catch (Exception Ex)
            {
                ViewBag.Exception = Ex;
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
                // TODO: Add insert logic here
                using (ContextBLL ctx = new ContextBLL())
                {
                    ctx.User_JustUpdate(collection);
                }
                return RedirectToAction("Index");
            }
            catch (Exception Ex)
            {
                ViewBag.Exception = Ex;
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
            try
            {
                using (ContextBLL ctx = new ContextBLL())
                {
                    ctx.User_Delete(id);
                }

                return RedirectToAction("Index");
            }
            catch (Exception Ex)
            {
                ViewBag.Exception = Ex;
                return View("Error");
            }
        }
    }
}
