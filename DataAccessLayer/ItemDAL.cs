using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ItemDAL
    {

        #region DIRECT PROPERTIES


        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public int ItemEnergyModifier { get; set; }
        public int ItemThirstModifier { get; set; }
        public int ItemHungerModifier { get; set; }
        public int UserID { get; set; }
        

        #endregion


        #region INDIRECT PROPERTIES


        // ----- Users Properties ----- //
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public int RoleID { get; set; }


        #endregion

    }
}
