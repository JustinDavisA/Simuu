using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogicLayer;

namespace Simuu.Controllers
{
    public class UserSimuuController : Controller
    {

        List<SelectListItem> GetRoleItems(ContextBLL ctx)
        {
            List<SelectListItem> ProposedReturnValue = new List<SelectListItem>();

            List<RoleBLL> roles = ctx.Roles_Get(0, 25);
            foreach (RoleBLL r in roles)
            {
                SelectListItem i = new SelectListItem();

                i.Value = r.RoleID.ToString();
                i.Text = r.RoleName;
                ProposedReturnValue.Add(i);
            }
            return ProposedReturnValue;
        }

        // GET: OneViewTwoTables
        public ActionResult Create()
        {
            using (ContextBLL ctx = new ContextBLL())
            {
                UserSimuuModel Model = new UserSimuuModel();
                Model.UserID = 0;
                Model.SimuuBirth = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                Model.SimuuDeath = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                ViewBag.Roles = GetRoleItems(ctx);
                return View(Model);
            }
        }

        [HttpPost]
        public ActionResult Create(UserSimuuModel collection)
        {
            try
            {
                using (ContextBLL ctx = new ContextBLL())
                {
                    if (!ModelState.IsValid)
                    {
                        ViewBag.Roles = GetRoleItems(ctx);
                        return View(collection);
                    }
                    int UserID = ctx.User_Create(collection.UserName, collection.UserEmail, collection.Password, collection.Password, collection.RoleID);

                    ctx.Simuu_Create(collection.SimuuName, collection.SimuuAge, collection.SimuuBirth, collection.SimuuDeath, collection.SimuuXCoordinate, collection.SimuuYCoordinate, collection.ImpulseToRest, collection.ImpulseToDrink, collection.ImpulseToEat, collection.StatEnergy, collection.StatThirst, collection.StatHunger, collection.SimuuMovementSpeed, collection.SimuuSenseRadius, UserID);
                }
                return RedirectToAction("Index", "User");
            }
            catch (Exception ex)
            {
                ViewBag.Exception = ex;
                return View("Error");
            }
        }

    }
}
