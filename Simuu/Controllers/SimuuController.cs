using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using BusinessLogicLayer;

namespace Simuu.Controllers
{
    public class SimuuController : Controller
    {

        // Pagination for Users
        public ActionResult Page(int PageNumber, int PageSize)
        {
            ViewBag.PageNumber = PageNumber;
            ViewBag.PageSize = PageSize;
            List<SimuuBLL> Model = new List<SimuuBLL>();
            try
            {
                using (ContextBLL ctx = new ContextBLL())
                {
                    ViewBag.TotalRoleCount = ctx.Users_ObtainCount();
                    Model = ctx.Simuus_Get(PageNumber * PageSize, PageSize);
                }
                return View("Index", Model);
            }
            catch (Exception ex)
            {
                ViewBag.Exception = ex;
                return View("Error");
            }
        }

        // Create a List of Roles for drop-down selection in CREATE: User
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
            ViewBag.Roles = GetRoleItems();
            return View(defSimuu);
        }

        // POST: Simuu/Create
        [HttpPost]
        public ActionResult Create(SimuuBLL collection)
        {
            try
            {
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
            ViewBag.Roles = GetRoleItems();
            return View(simuu);
        }

        // POST: Simuu/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, SimuuBLL collection)
        {
            try
            {
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
