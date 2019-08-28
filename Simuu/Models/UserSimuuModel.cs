﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Simuu
{
    public class UserSimuuModel
    {

        #region DIRECT PROPERTIES

        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
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

        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public int UserID { get; set; }

        #endregion


        #region INDIRECT PROPERTIES

        // ----- Users Properties ----- //
        public string UserName { get; set; }

        public string UserEmail { get; set; }

        public string PasswordHash { get; set; }

        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public string PasswordSalt { get; set; }

        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public int RoleID { get; set; }

        #endregion

    }
}