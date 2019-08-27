using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using LoggingLayer;

namespace DataAccessLayer
{
    public class ContextDAL : IDisposable
    {

        #region CONTEXT

        SqlConnection _connection;

        public ContextDAL()
        {
            _connection = new SqlConnection();
        }

        public string ConnectionString
        {
            get { return _connection.ConnectionString; }
            set { _connection.ConnectionString = value; }
        }

        void EnsureConnected()
        {
            if (_connection.State == System.Data.ConnectionState.Open)
            {
                //Do nothing - Valid connection state
            }
            else if (_connection.State == System.Data.ConnectionState.Broken)
            {
                _connection.Close();
                _connection.Open();
            }
            else if (_connection.State == System.Data.ConnectionState.Closed)
            {
                _connection.Open();
            }
            else
            {
                // Do nothing - No available connection states
            }
        }

        bool Log(Exception ex)
        {
            Console.WriteLine(ex.ToString());
            Logger.Log(ex);
            return false;
        }

        public void Dispose()
        {
            _connection.Dispose();
        }

        #endregion


        #region ITEMS

        // ----- Create ----- //
        public int Item_Create(string itemName, int itemEnergyModifier, int itemThirstModifier, int itemHungerModifier)
        {
            int proposedReturnValue = -1;
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("Item_Create", _connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ItemName", itemName);
                    command.Parameters.AddWithValue("@ItemEnergyModifier", itemEnergyModifier);
                    command.Parameters.AddWithValue("@ItemThirstModifier", itemThirstModifier);
                    command.Parameters.AddWithValue("@ItemHungerModifier", itemHungerModifier);
                    command.Parameters.AddWithValue("@ItemID", 0);
                    command.Parameters["@ItemID"].Direction = System.Data.ParameterDirection.Output;
                    command.ExecuteNonQuery();
                    proposedReturnValue = Convert.ToInt32(command.Parameters["@ItemID"].Value);
                }
            }
            catch (Exception ex) when (Log(ex))
            {
                // No access to scope - Exception thrown before entering
            }
            return proposedReturnValue;
        }

        // ----- Read ----- //
        public List<ItemDAL> Items_Get(int skip, int take)
        {
            List<ItemDAL> proposedReturnValue = new List<ItemDAL>();
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("Items_Get", _connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Skip", skip);
                    command.Parameters.AddWithValue("@Take", take);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        ItemMapper mapper = new ItemMapper(reader);
                        while (reader.Read())
                        {
                            ItemDAL reading = mapper.ItemFromReader(reader);
                            proposedReturnValue.Add(reading);
                        }
                    }
                }
            }
            catch (Exception ex) when (Log(ex))
            {
                // No access to scope - Exception thrown before entering
            }
            return proposedReturnValue;
        }

        public List<ItemDAL> Items_GetRelatedToUserID(int userID, int skip, int take)
        {
            List<ItemDAL> proposedReturnValue = new List<ItemDAL>();
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("Items_GetRelatedToItemID", _connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ItemID", userID);
                    command.Parameters.AddWithValue("@Skip", skip);
                    command.Parameters.AddWithValue("@Take", take);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        ItemMapper mapper = new ItemMapper(reader);
                        while (reader.Read())
                        {
                            ItemDAL reading = mapper.ItemFromReader(reader);
                            proposedReturnValue.Add(reading);
                        }
                    }
                }
            }
            catch (Exception ex) when (Log(ex))
            {
                // No access to scope - Exception thrown before entering
            }
            return proposedReturnValue;
        }

        public int Items_ObtainCount()
        {
            int proposedReturnValue = -1;
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("Items_ObtainCount", _connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    object answer = command.ExecuteScalar();
                    proposedReturnValue = (int)answer;
                }
            }
            catch (Exception ex) when (Log(ex))
            {
                // No access to scope - Exception thrown before entering
            }

            return proposedReturnValue;
        }

        public ItemDAL Item_FindByItemID(int itemID)
        {
            ItemDAL ProposedReturnValue = null;
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("Item_FindByItemID", _connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ItemID", itemID);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        ItemMapper mapper = new ItemMapper(reader);
                        int count = 0;
                        while (reader.Read())
                        {
                            ProposedReturnValue = mapper.ItemFromReader(reader);
                            count++;
                        }
                        if (count > 1)
                        {
                            throw new Exception($"Found more than 1 Item with key {itemID}");
                        }
                    }
                }
            }
            catch (Exception ex) when (Log(ex))
            {
                // No access to scope - Exception thrown before entering
            }
            return ProposedReturnValue;
        }

        // ----- Update ----- //
        public void Item_JustUpdate(int itemID, string itemName, int itemEnergyModifier, int itemThirstModifier, int itemHungerModifier)
        {
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("Item_JustUpdate", _connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ItemID", itemID);
                    command.Parameters.AddWithValue("@ItemName", itemName);
                    command.Parameters.AddWithValue("@ItemEnergyModifier", itemEnergyModifier);
                    command.Parameters.AddWithValue("@ItemThirstModifier", itemThirstModifier);
                    command.Parameters.AddWithValue("@ItemHungerModifier", itemHungerModifier);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex) when (Log(ex))
            {
                // No access to scope - Exception thrown before entering
            }
        }

        // ----- Delete ----- //
        public void Item_Delete(int itemID)
        {
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("Item_Delete", _connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ItemID", itemID);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex) when (Log(ex))
            {
                // No access to scope - Exception thrown before entering
            }
        }

        #endregion


        #region ROLES

        // ----- Create ----- //
        public int Role_Create(string roleName, string rolePermissions)
        {
            int proposedReturnValue = -1;
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("Role_Create", _connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@RoleName", roleName);
                    command.Parameters.AddWithValue("@RolePErmissions", rolePermissions);
                    command.Parameters.AddWithValue("@RoleID", 0);
                    command.Parameters["@RoleID"].Direction = System.Data.ParameterDirection.Output;
                    command.ExecuteNonQuery();
                    proposedReturnValue = Convert.ToInt32(command.Parameters["@RoleID"].Value);
                }
            }
            catch (Exception ex) when (Log(ex))
            {
                // No access to scope - Exception thrown before entering
            }
            return proposedReturnValue;
        }

        // ----- Read ----- //
        public List<RoleDAL> Roles_Get(int skip, int take)
        {
            List<RoleDAL> proposedReturnValue = new List<RoleDAL>();
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("Roles_Get", _connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Skip", skip);
                    command.Parameters.AddWithValue("@Take", take);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        RoleMapper mapper = new RoleMapper(reader);
                        while (reader.Read())
                        {
                            RoleDAL reading = mapper.RoleFromReader(reader);
                            proposedReturnValue.Add(reading);
                        }
                    }
                }
            }
            catch (Exception ex) when (Log(ex))
            {
                // No access to scope - Exception thrown before entering
            }
            return proposedReturnValue;
        }

        public int Roles_ObtainCount()
        {
            int proposedReturnValue = -1;
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("Roles_ObtainCount", _connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    object answer = command.ExecuteScalar();
                    proposedReturnValue = (int)answer;
                }
            }
            catch (Exception ex) when (Log(ex))
            {
                // No access to scope - Exception thrown before entering
            }
            return proposedReturnValue;
        }

        public RoleDAL Role_FindByRoleID(int roleID)
        {
            RoleDAL ProposedReturnValue = null;
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("Role_FindByRoleID", _connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@RoleID", roleID);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        RoleMapper mapper = new RoleMapper(reader);
                        int count = 0;
                        while (reader.Read())
                        {
                            ProposedReturnValue = mapper.RoleFromReader(reader);
                            count++;
                        }
                        if (count > 1)
                        {
                            throw new Exception($"Found more than 1 Role with key {roleID}");
                        }
                    }
                }
            }
            catch (Exception ex) when (Log(ex))
            {
                // No access to scope - Exception thrown before entering
            }
            return ProposedReturnValue;
        }

        // ----- Update ----- //
        public void Role_JustUpdate(int roleID, string roleName, string rolePermissions)
        {
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("Role_JustUpdate", _connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@RoleID", roleID);
                    command.Parameters.AddWithValue("@RoleName", roleName);
                    command.Parameters.AddWithValue("@RolePermissions", rolePermissions);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex) when (Log(ex))
            {
                // No access to scope - Exception thrown before entering
            }
        }

        // ----- Delete ----- //
        public void Role_Delete(int roleID)
        {
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("Role_Delete", _connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@RoleID", roleID);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex) when (Log(ex))
            {
                // No access to scope - Exception thrown before entering
            }
        }

        #endregion


        #region SIMUUS

        // ----- Create ----- //
        public int Simuu_Create(string simuuName, int simuuAge, DateTime simuuBirth, DateTime simuuDeath, int simuuCoordinates, int impulseToRest, int impulseToDrink, int impulseToEat, int statEnergy, int statThirst, int statHunger, int statMovementSpeed, int statSenseRadius)
        {
            int proposedReturnValue = -1;
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("Simuu_Create", _connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@SimuuName", simuuName);
                    command.Parameters.AddWithValue("@SimuuAge", simuuAge);
                    command.Parameters.AddWithValue("@SimuuBirth", simuuBirth);
                    command.Parameters.AddWithValue("@SimuuDeath", simuuDeath);
                    command.Parameters.AddWithValue("@SimuuCoordinates", simuuCoordinates);
                    command.Parameters.AddWithValue("@ImpulseToRest", impulseToRest);
                    command.Parameters.AddWithValue("@ImpulseToDrink", impulseToDrink);
                    command.Parameters.AddWithValue("@ImpulseToEat", impulseToEat);
                    command.Parameters.AddWithValue("@StatEnergy", statEnergy);
                    command.Parameters.AddWithValue("@StatThirst", statThirst);
                    command.Parameters.AddWithValue("@StatHunger", statHunger);
                    command.Parameters.AddWithValue("@StatMovementSpeed", statMovementSpeed);
                    command.Parameters.AddWithValue("@StatSenseRadius", statSenseRadius);
                    command.Parameters.AddWithValue("@SimuuID", 0);
                    command.Parameters["@SimuuID"].Direction = System.Data.ParameterDirection.Output;
                    command.ExecuteNonQuery();
                    proposedReturnValue = Convert.ToInt32(command.Parameters["@SimuuID"].Value);
                }
            }
            catch (Exception ex) when (Log(ex))
            {
                // No access to scope - Exception thrown before entering
            }
            return proposedReturnValue;
        }

        // ----- Read ----- //
        public List<SimuuDAL> Simuus_Get(int skip, int take)
        {
            List<SimuuDAL> proposedReturnValue = new List<SimuuDAL>();
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("Simuus_Get", _connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Skip", skip);
                    command.Parameters.AddWithValue("@Take", take);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        SimuuMapper mapper = new SimuuMapper(reader);
                        while (reader.Read())
                        {
                            SimuuDAL reading = mapper.SimuuFromReader(reader);
                            proposedReturnValue.Add(reading);
                        }
                    }
                }
            }
            catch (Exception ex) when (Log(ex))
            {
                // No access to scope - Exception thrown before entering
            }
            return proposedReturnValue;
        }

        public int Simuus_ObtainCount()
        {
            int proposedReturnValue = -1;
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("Simuus_ObtainCount", _connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    object answer = command.ExecuteScalar();
                    proposedReturnValue = (int)answer;
                }
            }
            catch (Exception ex) when (Log(ex))
            {
                // No access to scope - Exception thrown before entering
            }

            return proposedReturnValue;
        }

        public List<SimuuDAL> Simuus_GetRelatedToUserID(int userID, int skip, int take)
        {
            List<SimuuDAL> proposedReturnValue = new List<SimuuDAL>();
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("Simuus_GetRelatedToUserID", _connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserID", userID);
                    command.Parameters.AddWithValue("@Skip", skip);
                    command.Parameters.AddWithValue("@Take", take);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        SimuuMapper mapper = new SimuuMapper(reader);
                        while (reader.Read())
                        {
                            SimuuDAL reading = mapper.SimuuFromReader(reader);
                            proposedReturnValue.Add(reading);
                        }
                    }
                }
            }
            catch (Exception ex) when (Log(ex))
            {
                // No access to scope - Exception thrown before entering
            }
            return proposedReturnValue;
        }

        public SimuuDAL Simuu_FindBySimuuID(int simuuID)
        {
            SimuuDAL ProposedReturnValue = null;
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("Simuu_FindBySimuuID", _connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@SimuuID", simuuID);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        SimuuMapper mapper = new SimuuMapper(reader);
                        int count = 0;
                        while (reader.Read())
                        {
                            ProposedReturnValue = mapper.SimuuFromReader(reader);
                            count++;
                        }
                        if (count > 1)
                        {
                            throw new Exception($"Found more than 1 Simuu with key {simuuID}");
                        }
                    }
                }
            }
            catch (Exception ex) when (Log(ex))
            {
                // No access to scope - Exception thrown before entering
            }
            return ProposedReturnValue;
        }

        // ----- Update ----- //
        public void Simuu_JustUpdate(int simuuID, string simuuName, int simuuAge, DateTime simuuBirth, DateTime simuuDeath, int simuuCoordinates, int impulseToRest, int impulseToDrink, int impulseToEat, int statEnergy, int statThirst, int statHunger, int statMovementSpeed, int statSenseRadius)
        {
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("Simuu_JustUpdate", _connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@SimuuID", simuuID);
                    command.Parameters.AddWithValue("@SimuuName", simuuName);
                    command.Parameters.AddWithValue("@SimuuAge", simuuAge);
                    command.Parameters.AddWithValue("@SimuuBirth", simuuBirth);
                    command.Parameters.AddWithValue("@SimuuDeath", simuuDeath);
                    command.Parameters.AddWithValue("@SimuuCoordinates", simuuCoordinates);
                    command.Parameters.AddWithValue("@ImpulseToRest", impulseToRest);
                    command.Parameters.AddWithValue("@ImpulseToDrink", impulseToDrink);
                    command.Parameters.AddWithValue("@ImpulseToEat", impulseToEat);
                    command.Parameters.AddWithValue("@StatEnergy", statEnergy);
                    command.Parameters.AddWithValue("@StatThirst", statThirst);
                    command.Parameters.AddWithValue("@StatHunger", statHunger);
                    command.Parameters.AddWithValue("@StatMovementSpeed", statMovementSpeed);
                    command.Parameters.AddWithValue("@StatSenseRadius", statSenseRadius);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex) when (Log(ex))
            {
                // No access to scope - Exception thrown before entering
            }
        }

        // ----- Delete ----- //
        public void Simuu_Delete(int simuuID)
        {
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("Simuu_Delete", _connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@SimuuID", simuuID);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex) when (Log(ex))
            {
                // No access to scope - Exception thrown before entering
            }
        }

        #endregion


        #region USERS

        // ----- Create ----- //
        public int User_Create(string userName, string userEmail, string passwordHash, string passwordSalt, int roleID)
        {
            int proposedReturnValue = -1;
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("User_Create", _connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserName", userName);
                    command.Parameters.AddWithValue("@UserEmail", userEmail);
                    command.Parameters.AddWithValue("@PasswordHash", passwordHash);
                    command.Parameters.AddWithValue("@PasswordSalt", passwordSalt);
                    command.Parameters.AddWithValue("@RoleID", roleID);
                    command.Parameters.AddWithValue("@UserID", 0);
                    command.Parameters["@UserID"].Direction = System.Data.ParameterDirection.Output;
                    command.ExecuteNonQuery();
                    proposedReturnValue = Convert.ToInt32(command.Parameters["@UserID"].Value);
                }
            }
            catch (Exception ex) when (Log(ex))
            {
                // No access to scope - Exception thrown before entering
            }
            return proposedReturnValue;
        }

        // ----- Read ----- //
        public List<UserDAL> Users_Get(int skip, int take)
        {
            List<UserDAL> proposedReturnValue = new List<UserDAL>();
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("Users_Get", _connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Skip", skip);
                    command.Parameters.AddWithValue("@Take", take);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        UserMapper mapper = new UserMapper(reader);
                        while (reader.Read())
                        {
                            UserDAL reading = mapper.UserFromReader(reader);
                            proposedReturnValue.Add(reading);
                        }
                    }
                }
            }
            catch (Exception ex) when (Log(ex))
            {
                // No access to scope - Exception thrown before entering
            }
            return proposedReturnValue;
        }

        public int Users_ObtainCount()
        {
            int proposedReturnValue = -1;
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("Users_ObtainCount", _connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    object answer = command.ExecuteScalar();
                    proposedReturnValue = (int)answer;
                }
            }
            catch (Exception ex) when (Log(ex))
            {
                // No access to scope - Exception thrown before entering
            }

            return proposedReturnValue;
        }

        public List<UserDAL> Users_GetRelatedToRoleID(int roleID, int skip, int take)
        {
            List<UserDAL> proposedReturnValue = new List<UserDAL>();
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("Users_GetRelatedToRoleID", _connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@RoleID", roleID);
                    command.Parameters.AddWithValue("@Skip", skip);
                    command.Parameters.AddWithValue("@Take", take);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        UserMapper mapper = new UserMapper(reader);
                        while (reader.Read())
                        {
                            UserDAL reading = mapper.UserFromReader(reader);
                            proposedReturnValue.Add(reading);
                        }
                    }
                }
            }
            catch (Exception ex) when (Log(ex))
            {
                // No access to scope - Exception thrown before entering
            }
            return proposedReturnValue;
        }

        public UserDAL User_FindByUserID(int userID)
        {
            UserDAL ProposedReturnValue = null;
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("User_FindByUserID", _connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserID", userID);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        UserMapper mapper = new UserMapper(reader);
                        int count = 0;
                        while (reader.Read())
                        {
                            ProposedReturnValue = mapper.UserFromReader(reader);
                            count++;
                        }
                        if (count > 1)
                        {
                            throw new Exception($"Found more than 1 User with key {userID}");
                        }
                    }
                }
            }
            catch (Exception ex) when (Log(ex))
            {
                // No access to scope - Exception thrown before entering
            }
            return ProposedReturnValue;
        }

        public UserDAL User_FindByUserUserName(string userName)
        {
            UserDAL ProposedReturnValue = null;
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("User_FindByUserUserName", _connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserName", userName);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        UserMapper mapper = new UserMapper(reader);
                        int count = 0;
                        while (reader.Read())
                        {
                            ProposedReturnValue = mapper.UserFromReader(reader);
                            count++;
                        }
                        if (count > 1)
                        {
                            throw new Exception($"Found more than 1 User with username {userName}");
                        }
                    }
                }
            }
            catch (Exception ex) when (Log(ex))
            {
                // No access to scope - Exception thrown before entering
            }
            return ProposedReturnValue;
        }

        public UserDAL User_FindByUserEmail(string userEmail)
        {
            UserDAL proposedReturnValue = null;
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("User_FindByUserEmail", _connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserEmail", userEmail);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        UserMapper mapper = new UserMapper(reader);
                        int count = 0;
                        while (reader.Read())
                        {
                            proposedReturnValue = mapper.UserFromReader(reader);
                            count++;
                        }
                        if (count > 1)
                        {
                            throw new Exception($"Found more than 1 User with email {userEmail}");
                        }
                    }
                }
            }
            catch (Exception ex) when (Log(ex))
            {
                // No access to scope - Exception thrown before entering
            }
            return proposedReturnValue;
        }

        // ----- Update ----- //
        public void User_JustUpdate(int userID, string userName, string userEmail, string passwordHash, string passwordSalt, int roleID)
        {
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("User_JustUpdate", _connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserID", userID);
                    command.Parameters.AddWithValue("@UserName", userName);
                    command.Parameters.AddWithValue("@UserEmail", userEmail);
                    command.Parameters.AddWithValue("@PasswordHash", passwordHash);
                    command.Parameters.AddWithValue("@PasswordSalt", passwordSalt);
                    command.Parameters.AddWithValue("@RoleID", roleID);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex) when (Log(ex))
            {
                // No access to scope - Exception thrown before entering
            }
        }

        // ----- Delete ----- //
        public void User_Delete(int userID)
        {
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("User_Delete", _connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserID", userID);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex) when (Log(ex))
            {
                // No access to scope - Exception thrown before entering
            }
        }

        #endregion

    }
}
