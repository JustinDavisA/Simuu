using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using BusinessLogicLayer;

namespace Simuu.Controllers
{
    public class ItemController : Controller
    {

        // Pagination for Users
        public ActionResult Page(int PageNumber, int PageSize)
        {
            ViewBag.PageNumber = PageNumber;
            ViewBag.PageSize = PageSize;
            List<ItemBLL> Model = new List<ItemBLL>();
            try
            {
                using (ContextBLL ctx = new ContextBLL())
                {
                    ViewBag.TotalRoleCount = ctx.Roles_ObtainCount();
                    Model = ctx.Items_Get(PageNumber * PageSize, PageSize);
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

        // GET: Item
        public ActionResult Index()
        {
            return RedirectToRoute(new { Controller = "Item", Action = "Page", PageNumber = 0, PageSize = ApplicationConfig.DefaultPageSize });
        }

        // GET: Item/Details/5
        public ActionResult Details(int id)
        {
            ItemBLL item;
            try
            {
                using (ContextBLL ctx = new ContextBLL())
                {
                    item = ctx.Item_FindByItemID(id);
                    if (null == item)
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
            return View(item);
        }

        // GET: Item/Create
        public ActionResult Create()
        {
            ItemBLL defItem = new ItemBLL();
            defItem.ItemID = 0;
            ViewBag.Roles = GetRoleItems();
            return View(defItem);
        }

        // POST: Item/Create
        [HttpPost]
        public ActionResult Create(ItemBLL collection)
        {
            try
            {
                using (ContextBLL ctx = new ContextBLL())
                {
                    ctx.Item_Create(collection);
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Exception = ex;
                return View("Error");
            }
        }

        // GET: Item/Edit/5
        public ActionResult Edit(int id)
        {
            ItemBLL user;
            try
            {
                using (ContextBLL ctx = new ContextBLL())
                {
                    user = ctx.Item_FindByItemID(id);
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

        // POST: Item/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ItemBLL collection)
        {
            try
            {
                // TODO: Add insert logic here
                using (ContextBLL ctx = new ContextBLL())
                {
                    ctx.Item_JustUpdate(collection);
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Exception = ex;
                return View("Error");
            }
        }

        // GET: Item/Delete/5
        public ActionResult Delete(int id)
        {
            ItemBLL item;
            try
            {
                using (ContextBLL ctx = new ContextBLL())
                {
                    item = ctx.Item_FindByItemID(id);
                    if (null == item)
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
            return View(item);
        }

        // POST: Item/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, ItemBLL collection)
        {
            try
            {
                using (ContextBLL ctx = new ContextBLL())
                {
                    ctx.Item_Delete(id);
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
