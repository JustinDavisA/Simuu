using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class SimuuBLL
    {

        #region DIRECT PROPERTIES

        public int SimuuID { get; set; }
        public string SimuuName { get; set; }
        public int SimuuAge { get; set; }
        public DateTime SimuuBirth { get; set; }
        public DateTime SimuuDeath { get; set; }
        public int SimuuCoordinates { get; set; }
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
        public int PasswordHash { get; set; }
        public int PasswordSalt { get; set; }
        public int RoleID { get; set; }

        #endregion


        public SimuuBLL()
        {

        }


        public SimuuBLL(SimuuDAL dal)
        {
            this.SimuuID = dal.SimuuID;
            this.SimuuName = dal.SimuuName;
            this.SimuuAge = dal.SimuuAge;
            this.SimuuBirth = dal.SimuuBirth;
            this.SimuuDeath = dal.SimuuDeath;
            this.SimuuCoordinates = dal.SimuuCoordinates;
            this.ImpulseToRest = dal.ImpulseToRest;
            this.ImpulseToDrink = dal.ImpulseToDrink;
            this.ImpulseToEat = dal.ImpulseToEat;
            this.StatEnergy = dal.StatEnergy;
            this.StatThirst = dal.StatThirst;
            this.StatHunger = dal.StatHunger;
            this.SimuuMovementSpeed = dal.SimuuMovementSpeed;
            this.SimuuSenseRadius = dal.SimuuSenseRadius;
            this.UserID = dal.UserID;

            // ----- Users Properties ----- //
            this.UserName = dal.UserName;
            this.UserEmail = dal.UserEmail;
            this.PasswordHash = dal.PasswordHash;
            this.PasswordSalt = dal.PasswordSalt;
            this.RoleID = dal.RoleID;
        }

    }
}
