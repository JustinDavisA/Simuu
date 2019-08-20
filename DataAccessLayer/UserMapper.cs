using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class UserMapper : Mapper
    {

        // ----- Users ----- //
        int offsetToUserID;
        int offsetToUserName;
        int offsetToUserEmail;
        int offsetToPasswordHash;
        int offsetToPasswordSalt;
        int offsetToRoleID;

        // ----- Roles ----- //
        int offsetToRoleName;
        int offsetToRolePermissions;


        public UserMapper(System.Data.SqlClient.SqlDataReader reader)
        {
            // ----- Users ----- //
            offsetToUserID = reader.GetOrdinal("UserID");
            Assert(0 == offsetToUserID, $"UserID is {offsetToUserID}, not 0 as expected");

            offsetToUserName = reader.GetOrdinal("UserName");
            Assert(1 == offsetToUserName, $"UserName is {offsetToUserName}, not 1 as expected");

            offsetToUserEmail = reader.GetOrdinal("UserEmail");
            Assert(2 == offsetToUserEmail, $"UserEmail is {offsetToUserEmail}, not 2 as expected");

            offsetToPasswordHash = reader.GetOrdinal("PasswordHash");
            Assert(3 == offsetToPasswordHash, $"PasswordHash is {offsetToPasswordHash}, not 3 as expected");

            offsetToPasswordSalt = reader.GetOrdinal("PasswordSalt");
            Assert(4 == offsetToPasswordSalt, $"PasswordSalt is {offsetToPasswordSalt}, not 4 as expected");

            offsetToRoleID = reader.GetOrdinal("RoleID");
            Assert(5 == offsetToRoleID, $"RoleID is {offsetToRoleID}, not 5 as expected");

            // ----- Roles ----- //
            offsetToRoleName = reader.GetOrdinal("RoleName");
            Assert(6 == offsetToRoleName, $"RoleName is {offsetToRoleName}, not 6 as expected");

            offsetToRolePermissions = reader.GetOrdinal("RolePermissions");
            Assert(7 == offsetToRolePermissions, $"RolePermissions is {offsetToRolePermissions}, not 7 as expected");

        }
        

        public UserDAL UserFromReader(System.Data.SqlClient.SqlDataReader reader)
        {
            UserDAL proposedReturnValue = new UserDAL();

            // ----- Users ----- //
            proposedReturnValue.UserID = reader.GetInt32(offsetToUserID);
            proposedReturnValue.UserName = reader.GetString(offsetToUserName);
            proposedReturnValue.UserEmail = reader.GetString(offsetToUserEmail);
            proposedReturnValue.PasswordHash = reader.GetString(offsetToPasswordHash);
            proposedReturnValue.PasswordSalt = reader.GetString(offsetToPasswordSalt);
            proposedReturnValue.RoleID = reader.GetInt32(offsetToRoleID);

            // ----- Roles ----- //
            proposedReturnValue.RoleName = reader.GetString(offsetToRoleName);
            proposedReturnValue.RolePermissions = reader.GetString(offsetToRolePermissions);

            return proposedReturnValue;
        }

    }
}
