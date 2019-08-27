using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using BusinessLogicLayer;
using Simuu.Models;

namespace Simuu.Controllers
{
    [MustBeInRole(Roles = "Administrator")]
    public class RoleController : Controller
    {

        // Pagination for Roles
        public ActionResult Page(int PageNumber, int PageSize)
        {
            ViewBag.PageNumber = PageNumber;
            ViewBag.PageSize = PageSize;
            List<RoleBLL> model = new List<RoleBLL>();
            try
            {
                using (ContextBLL ctx = new ContextBLL())
                {
                    ViewBag.TotalCount = ctx.Roles_ObtainCount();
                    model = ctx.Roles_Get(PageNumber * PageSize, PageSize);
                }
                return View("Index", model);
            }
            catch (Exception ex)
            {
                ViewBag.Exception = ex;
                return View("Error");
            }
        }

        // CREATE: List of Roles for drop-down selection
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

        // GET: Role
        public ActionResult Index()
        {
            return RedirectToRoute(new { Controller = "Role", Action = "Page", PageNumber = 0, PageSize = ApplicationConfig.DefaultPageSize });
        }

        // GET: Role/Details/5
        public ActionResult Details(int id)
        {
            RoleBLL role;
            try
            {
                using (ContextBLL ctx = new ContextBLL())
                {
                    role = ctx.Role_FindByRoleID(id);
                    if (null == role)
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
            return View(role);
        }

        // GET: Role/Create
        public ActionResult Create()
        {
            RoleBLL defRole = new RoleBLL();
            defRole.RoleID = 0;
            ViewBag.Roles = GetRoleItems();
            return View(defRole);
        }

        // POST: Role/Create
        [HttpPost]
        public ActionResult Create(RoleBLL collection)
        {
            try
            {
                using (ContextBLL ctx = new ContextBLL())
                {
                    ctx.Role_Create(collection);
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Exception = ex;
                return View("Error");
            }
        }

        // GET: Role/Edit/5
        public ActionResult Edit(int id)
        {
            RoleBLL role;
            try
            {
                using (ContextBLL ctx = new ContextBLL())
                {
                    role = ctx.Role_FindByRoleID(id);
                    if (null == role)
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
            return View(role);
        }

        // POST: Role/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, RoleBLL collection)
        {
            try
            {
                // TODO: Add insert logic here
                using (ContextBLL ctx = new ContextBLL())
                {
                    ctx.Role_JustUpdate(collection);
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Exception = ex;
                return View("Error");
            }
        }

        // GET: Role/Delete/5
        public ActionResult Delete(int id)
        {
            RoleBLL role;
            try
            {
                using (ContextBLL ctx = new ContextBLL())
                {
                    role = ctx.Role_FindByRoleID(id);
                    if (null == role)
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
            return View(role);
        }

        // POST: Role/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, RoleBLL collection)
        {
            try
            {
                using (ContextBLL ctx = new ContextBLL())
                {
                    ctx.Role_Delete(id);
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
