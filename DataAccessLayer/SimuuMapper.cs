using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    class SimuuMapper : Mapper
    {

        // ----- Simuus ----- //
        int offsetToSimuuID;
        int offsetToSimuuName;
        int offsetToSimuuAge;
        int offsetToSimuuBirth;
        int offsetToSimuuDeath;
        int offsetToSimuuCoordinates;
        int offsetToImpulseToRest;
        int offsetToImpulseToDrink;
        int offsetToImpulseToEat;
        int offsetToSimuuEnergy;
        int offsetToSimuuThirst;
        int offsetToSimuuHunger;
        int offsetToSimuuMovementSpeed;
        int offsetToSimuuSenseRadius;
        int offsetToUserID;


        // ----- Users ----- //
        int offsetToUserName;
        int offsetToUserEmail;
        int offsetToPasswordHash;
        int offsetToPasswordSalt;
        int offsetToRoleID;


        public SimuuMapper(System.Data.SqlClient.SqlDataReader reader)
        {
            // ----- Simuus ----- //
            offsetToSimuuID = reader.GetOrdinal("SimuuID");
            Assert(0 == offsetToSimuuID, $"SimuuID is {offsetToSimuuID}, not 0 as expected");

            offsetToSimuuName = reader.GetOrdinal("SimuuName");
            Assert(1 == offsetToSimuuName, $"SimuuName is {offsetToSimuuName}, not 1 as expected");

            offsetToSimuuAge = reader.GetOrdinal("SimuuAge");
            Assert(2 == offsetToSimuuAge, $"SimuuAge is {offsetToSimuuAge}, not 2 as expected");

            offsetToSimuuBirth = reader.GetOrdinal("SimuuBirth");
            Assert(3 == offsetToSimuuBirth, $"SimuuBirth is {offsetToSimuuBirth}, not 3 as expected");

            offsetToSimuuDeath = reader.GetOrdinal("SimuuDeath");
            Assert(4 == offsetToSimuuDeath, $"SimuuDeath is {offsetToSimuuDeath}, not 4 as expected");

            offsetToSimuuCoordinates = reader.GetOrdinal("SimuuCoordinates");
            Assert(5 == offsetToSimuuCoordinates, $"SimuuCoordinates is {offsetToSimuuCoordinates}, not 5 as expected");

            offsetToImpulseToRest = reader.GetOrdinal("ImpulseToRest");
            Assert(6 == offsetToImpulseToRest, $"ImpulseToRest is {offsetToImpulseToRest}, not 6 as expected");

            offsetToImpulseToDrink = reader.GetOrdinal("ImpulseToDrink");
            Assert(7 == offsetToImpulseToDrink, $"ImpulseToDrink is {offsetToImpulseToDrink}, not 7 as expected");

            offsetToImpulseToEat = reader.GetOrdinal("ImpulseToEat");
            Assert(8 == offsetToImpulseToEat, $"ImpulseToEat is {offsetToImpulseToEat}, not 8 as expected");

            offsetToSimuuEnergy = reader.GetOrdinal("StatEnergy");
            Assert(9 == offsetToSimuuEnergy, $"SimuuEnergy is {offsetToSimuuEnergy}, not 9 as expected");

            offsetToSimuuThirst = reader.GetOrdinal("StatThirst");
            Assert(10 == offsetToSimuuThirst, $"SimuuThirst is {offsetToSimuuThirst}, not 10 as expected");

            offsetToSimuuHunger = reader.GetOrdinal("StatHunger");
            Assert(11 == offsetToSimuuHunger, $"SimuuHunger is {offsetToSimuuHunger}, not 11 as expected");

            offsetToSimuuMovementSpeed = reader.GetOrdinal("StatMovementSpeed");
            Assert(12 == offsetToSimuuMovementSpeed, $"SimuuMovementSpeed is {offsetToSimuuMovementSpeed}, not 12 as expected");

            offsetToSimuuSenseRadius = reader.GetOrdinal("StatSenseRadius");
            Assert(13 == offsetToSimuuSenseRadius, $"SimuuSenseRadius is {offsetToSimuuSenseRadius}, not 13 as expected");

            offsetToUserID = reader.GetOrdinal("UserID");
            Assert(14 == offsetToUserID, $"UserID is {offsetToUserID}, not 14 as expected");

            // ----- Users ----- //
            offsetToUserName = reader.GetOrdinal("UserName");
            Assert(15 == offsetToUserName, $"UserName is {offsetToUserName}, not 15 as expected");

            offsetToUserEmail = reader.GetOrdinal("UserEmail");
            Assert(16 == offsetToUserEmail, $"UserEmail is {offsetToUserEmail}, not 16 as expected");

            offsetToPasswordHash = reader.GetOrdinal("PasswordHash");
            Assert(17 == offsetToPasswordHash, $"PasswordHash is {offsetToPasswordHash}, not 17 as expected");

            offsetToPasswordSalt = reader.GetOrdinal("PasswordSalt");
            Assert(18 == offsetToPasswordSalt, $"PasswordSalt is {offsetToPasswordSalt}, not 18 as expected");

            offsetToRoleID = reader.GetOrdinal("RoleID");
            Assert(19 == offsetToRoleID, $"RoleID is {offsetToRoleID}, not 19 as expected");
        }


        public SimuuDAL SimuuFromReader(System.Data.SqlClient.SqlDataReader reader)
        {
            SimuuDAL proposedReturnValue = new SimuuDAL();

            // ----- Simuus ----- //
            proposedReturnValue.SimuuID = reader.GetInt32(offsetToSimuuID);
            proposedReturnValue.SimuuName = reader.GetString(offsetToSimuuName);
            proposedReturnValue.SimuuAge = reader.GetInt32(offsetToSimuuAge);
            proposedReturnValue.SimuuBirth = GetDateTimeOrDefault(reader, offsetToSimuuBirth, DateTime.MinValue);
            proposedReturnValue.SimuuDeath = GetDateTimeOrDefault(reader, offsetToSimuuDeath, DateTime.MinValue);
            proposedReturnValue.SimuuCoordinates = reader.GetInt32(offsetToSimuuCoordinates);
            proposedReturnValue.ImpulseToRest = reader.GetInt32(offsetToImpulseToRest);
            proposedReturnValue.ImpulseToDrink = reader.GetInt32(offsetToImpulseToDrink);
            proposedReturnValue.ImpulseToEat = reader.GetInt32(offsetToImpulseToEat);
            proposedReturnValue.StatEnergy = reader.GetInt32(offsetToSimuuEnergy);
            proposedReturnValue.StatThirst = reader.GetInt32(offsetToSimuuThirst);
            proposedReturnValue.StatHunger = reader.GetInt32(offsetToSimuuHunger);
            proposedReturnValue.SimuuMovementSpeed = reader.GetInt32(offsetToSimuuMovementSpeed);
            proposedReturnValue.SimuuSenseRadius = reader.GetInt32(offsetToSimuuSenseRadius);
            proposedReturnValue.UserID = reader.GetInt32(offsetToUserID);

            // ----- Users ----- //
            proposedReturnValue.UserName = reader.GetString(offsetToUserName);
            proposedReturnValue.UserEmail = reader.GetString(offsetToUserEmail);
            proposedReturnValue.PasswordHash = reader.GetString(offsetToPasswordHash);
            proposedReturnValue.PasswordSalt = reader.GetString(offsetToPasswordSalt);
            proposedReturnValue.RoleID = reader.GetInt32(offsetToRoleID);

            return proposedReturnValue;
        }

    }
}
