using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class UserDAL
    {

        #region DIRECT PROPERTIES


        public int UserID { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public int RoleID { get; set; }


        #endregion


        #region INDIRECT PROPERTIES


        // ----- Roles Properties ----- //
        public string RoleName { get; set; }
        public string RolePermissions { get; set; }


        #endregion

    }
}
