using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class RoleBLL
    {

        #region DIRECT PROPERTIES


        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public int RoleID { get; set; }

        public string RoleName { get; set; }

        public string RolePermissions { get; set; }


        #endregion


        public RoleBLL()
        {

        }


        public RoleBLL(RoleDAL dal)
        {
            this.RoleID = dal.RoleID;
            this.RoleName = dal.RoleName;
            this.RolePermissions = dal.RolePermissions;
        }

    }
}
