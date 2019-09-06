using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class SimuuDAL
    {

        #region DIRECT PROPERTIES


        public int SimuuID { get; set; }
        public string SimuuName { get; set; }
        public int SimuuAge { get; set; }
        public DateTime SimuuBirth { get; set; }
        public DateTime SimuuDeath { get; set; }
        public int SimuuXCoordinate { get; set; }
        public int SimuuYCoordinate { get; set; }
        public int ImpulseToRest { get; set; }
        public int ImpulseToDrink { get; set; }
        public int ImpulseToEat { get; set; }
        public int StatEnergy { get; set; }
        public int StatThirst { get; set; }
        public int StatHunger { get; set; }
        public int SimuuMovementSpeed { get; set; }
        public int SimuuSenseRadius { get; set; }
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
