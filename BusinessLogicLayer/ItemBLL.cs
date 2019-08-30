using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class ItemBLL
    {

        #region DIRECT PROPERTIES


        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public int ItemID { get; set; }

        public string ItemName { get; set; }

        public int ItemEnergyModifier { get; set; }

        public int ItemThirstModifier { get; set; }

        public int ItemHungerModifier { get; set; }

        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public int UserID { get; set; }


        #endregion


        #region INDIRECT PROPERTIES


        // ----- Users Properties ----- //
        public string UserName { get; set; }

        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public string UserEmail { get; set; }

        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public string PasswordHash { get; set; }

        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public string PasswordSalt { get; set; }

        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public int RoleID { get; set; }


        #endregion


        public ItemBLL()
        {

        }


        public ItemBLL(ItemDAL dal)
        {
            this.ItemID = dal.ItemID;
            this.ItemName = dal.ItemName;
            this.ItemEnergyModifier = dal.ItemEnergyModifier;
            this.ItemThirstModifier = dal.ItemThirstModifier;
            this.ItemHungerModifier = dal.ItemHungerModifier;
            this.UserID = dal.UserID;

            // ----- User Properties ----- //
            this.UserName = dal.UserName;
            this.UserEmail = dal.UserEmail;
            this.PasswordHash = dal.PasswordHash;
            this.PasswordSalt = dal.PasswordSalt;
            this.RoleID = dal.RoleID;
        }

    }
}
