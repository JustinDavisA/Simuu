using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class RoleMapper : Mapper
    {

        // ----- Roles ----- //
        int offsetToRoleID;
        int offsetToRoleName;
        int offsetToRolePermissions;


        public RoleMapper(System.Data.SqlClient.SqlDataReader reader)
        {
            // ----- Roles ----- //
            offsetToRoleID = reader.GetOrdinal("RoleID");
            Assert(0 == offsetToRoleID, $"RoleID is {offsetToRoleID}, not 0 as expected");

            offsetToRoleName = reader.GetOrdinal("RoleName");
            Assert(1 == offsetToRoleName, $"RoleName is {offsetToRoleName}, not 1 as expected");

            offsetToRolePermissions = reader.GetOrdinal("RolePermissions");
            Assert(2 == offsetToRolePermissions, $"RolePermissions is {offsetToRolePermissions}, not 2 as expected");
        }


        public RoleDAL RoleFromReader(System.Data.SqlClient.SqlDataReader reader)
        {
            RoleDAL proposedReturnValue = new RoleDAL();

            // ----- Roles ----- //
            proposedReturnValue.RoleID = reader.GetInt32(offsetToRoleID);
            proposedReturnValue.RoleName = reader.GetString(offsetToRoleName);
            proposedReturnValue.RolePermissions = reader.GetString(offsetToRolePermissions);

            return proposedReturnValue;
        }

    }
}
