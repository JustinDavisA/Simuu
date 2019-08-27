using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ItemMapper : Mapper
    {
        // ----- Items ----- //
        int offsetToItemID;
        int offsetToItemName;
        int offsetToItemEnergyModifier;
        int offsetToItemThirstModifier;
        int offsetToItemHungerModifier;
        int offsetToUserID;

        // ----- Users ----- //
        int offsetToUserName;
        int offsetToUserEmail;
        int offsetToPasswordHash;
        int offsetToPasswordSalt;
        int offsetToRoleID;


        public ItemMapper(System.Data.SqlClient.SqlDataReader reader)
        {
            // ----- Items ----- //
            offsetToItemID = reader.GetOrdinal("ItemID");
            Assert(0 == offsetToItemID, $"ItemID is {offsetToItemID}, not 0 as expected");

            offsetToItemName = reader.GetOrdinal("ItemName");
            Assert(1 == offsetToItemName, $"ItemName is {offsetToItemName}, not 1 as expected");

            offsetToItemEnergyModifier = reader.GetOrdinal("ItemEnergyModifier");
            Assert(2 == offsetToItemEnergyModifier, $"ItemEnergyModifier is {offsetToItemEnergyModifier}, not 2 as expected");

            offsetToItemThirstModifier = reader.GetOrdinal("ItemThirstModifier");
            Assert(3 == offsetToItemThirstModifier, $"ItemThirstModifier is {offsetToItemThirstModifier}, not 3 as expected");

            offsetToItemHungerModifier = reader.GetOrdinal("ItemHungerModifier");
            Assert(4 == offsetToItemHungerModifier, $"ItemHungerModifier is {offsetToItemHungerModifier}, not 4 as expected");

            offsetToUserID = reader.GetOrdinal("UserID");
            Assert(5 == offsetToUserID, $"UserID is {offsetToUserID}, not 5 as expected");

            // ----- Users ----- //
            offsetToUserName = reader.GetOrdinal("UserName");
            Assert(6 == offsetToUserName, $"UserName is {offsetToUserName}, not 6 as expected");

            offsetToUserEmail = reader.GetOrdinal("UserEmail");
            Assert(7 == offsetToUserEmail, $"UserEmail is {offsetToUserEmail}, not 7 as expected");

            offsetToPasswordHash = reader.GetOrdinal("PasswordHash");
            Assert(8 == offsetToPasswordHash, $"PasswordHash is {offsetToPasswordHash}, not 8 as expected");

            offsetToPasswordSalt = reader.GetOrdinal("PasswordSalt");
            Assert(9 == offsetToPasswordSalt, $"PasswordSalt is {offsetToPasswordSalt}, not 9 as expected");

            offsetToRoleID = reader.GetOrdinal("RoleID");
            Assert(10 == offsetToRoleID, $"RoleID is {offsetToRoleID}, not 10 as expected");
        }

        public ItemDAL ItemFromReader(System.Data.SqlClient.SqlDataReader reader)
        {
            ItemDAL proposedReturnValue = new ItemDAL();

            // ----- Items ----- //
            proposedReturnValue.ItemID = reader.GetInt32(offsetToItemID);
            proposedReturnValue.ItemName = reader.GetString(offsetToItemName);
            proposedReturnValue.ItemEnergyModifier = reader.GetInt32(offsetToItemEnergyModifier);
            proposedReturnValue.ItemThirstModifier = reader.GetInt32(offsetToItemThirstModifier);
            proposedReturnValue.ItemHungerModifier = reader.GetInt32(offsetToItemHungerModifier);
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
