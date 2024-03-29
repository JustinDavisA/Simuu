﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using BusinessLogicLayer;

namespace Simuu.Controllers
{
    public class OwnedSimuuController : Controller
    {

        // Return true or false 
        bool IsThisMine(ContextBLL ctx, ItemBLL mine)
        {
            if (User.IsInRole(Constants.AdminRoleName))
            {
                return true;
            }
            UserBLL me = ctx.User_FindByUserName(User.Identity.Name);
            if (me == null)
            {
                return false;
            }
            return me.UserID == mine.UserID;
        }

        // Pagination for Users
        public ActionResult Page(int PageNumber, int PageSize)
        {
            ViewBag.PageNumber = PageNumber;
            ViewBag.PageSize = PageSize;
            List<SimuuBLL> model = new List<SimuuBLL>();
            try
            {
                using (ContextBLL ctx = new ContextBLL())
                {
                    UserBLL currentUser = ctx.User_FindByUserName(User.Identity.Name);
                    if (null == currentUser)
                    {
                        ViewBag.Exception = new Exception($"Could Not Find Record for User: {User.Identity.Name}");
                        return View("Error");
                    }
                    ViewBag.TotalCount = ctx.Simuus_ObtainCountRelatedToUserID(currentUser.UserID);
                    model = ctx.Simuus_GetRelatedToUserID(currentUser.UserID, PageNumber * PageSize, PageSize);
                }
                return View("..\\Simuu\\Index", model);
            }
            catch (Exception ex)
            {
                ViewBag.Exception = ex;
                return View("Error");
            }
        }

        // Create a List of Users for drop-down selection
        List<SelectListItem> GetUserItems()
        {
            List<SelectListItem> proposedReturnValue = new List<SelectListItem>();
            using (ContextBLL ctx = new ContextBLL())
            {
                List<UserBLL> users = ctx.Users_Get(0, 25);
                foreach (UserBLL user in users)
                {
                    SelectListItem item = new SelectListItem();
                    item.Value = user.UserID.ToString();
                    item.Text = user.UserName;
                    proposedReturnValue.Add(item);
                }
            }
            return proposedReturnValue;
        }

        // GET: Simuu
        public ActionResult Index()
        {
            return RedirectToRoute(new { Controller = "Simuu", Action = "Page", PageNumber = 0, PageSize = ApplicationConfig.DefaultPageSize });
        }

        // GET: Simuu/Details/5
        public ActionResult Details(int id)
        {
            SimuuBLL simuu;
            try
            {
                using (ContextBLL ctx = new ContextBLL())
                {
                    simuu = ctx.Simuu_FindBySimuuID(id);
                    if (null == simuu)
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
            return View(simuu);
        }

        // GET: Simuu/Create
        public ActionResult Create()
        {
            SimuuBLL defSimuu = new SimuuBLL();
            defSimuu.UserID = 0;
            ViewBag.Users = GetUserItems();
            return View(defSimuu);
        }

        // POST: Simuu/Create
        [HttpPost]
        public ActionResult Create(SimuuBLL collection)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(collection);
                }
                using (ContextBLL ctx = new ContextBLL())
                {
                    ctx.Simuu_Create(collection);
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Exception = ex;
                return View("Error");
            }
        }

        // GET: Simuu/Edit/5
        public ActionResult Edit(int id)
        {
            SimuuBLL simuu;
            try
            {
                using (ContextBLL ctx = new ContextBLL())
                {
                    simuu = ctx.Simuu_FindBySimuuID(id);
                    if (null == simuu)
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
            ViewBag.Users = GetUserItems();
            return View(simuu);
        }

        // POST: Simuu/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, SimuuBLL collection)
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
                    ctx.Simuu_JustUpdate(collection);
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Exception = ex;
                return View("Error");
            }
        }

        // GET: Simuu/Delete/5
        public ActionResult Delete(int id)
        {
            SimuuBLL simuu;
            try
            {
                using (ContextBLL ctx = new ContextBLL())
                {
                    simuu = ctx.Simuu_FindBySimuuID(id);
                    if (null == simuu)
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
            return View(simuu);
        }

        // POST: Simuu/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, SimuuBLL collection)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(collection);
                }
                using (ContextBLL ctx = new ContextBLL())
                {
                    ctx.Simuu_Delete(id);
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Exception = ex;
                return View("Error");
            }
        }

    }
}
