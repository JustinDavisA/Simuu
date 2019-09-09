using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class ContextBLL : IDisposable
    {

        #region CONTEXT


        ContextDAL _context = new ContextDAL();

        public void Dispose()
        {
            ((IDisposable)_context).Dispose();
        }

        bool Log(Exception ex)
        {
            Console.WriteLine(ex);
            // LoggingLayer.Logger.Log(ex);   Where did I put this? It works
            return false;
        }

        public ContextBLL()
        {
            try
            {
                string connectionstring;
                connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString;
                _context.ConnectionString = connectionstring;
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
            proposedReturnValue = _context.Role_Create(roleName, rolePermissions);
            return proposedReturnValue;
        }

        public int Role_Create(RoleBLL role)
        {
            int proposedReturnValue = -1;
            proposedReturnValue = _context.Role_Create(role.RoleName, role.RolePermissions);
            return proposedReturnValue;
        }

        // ----- Read ----- //
        public List<RoleBLL> Roles_Get(int skip, int take)
        {
            List<RoleBLL> ProposedReturnValue = new List<RoleBLL>();
            List<RoleDAL> ListOfDataLayerObjects = _context.Roles_Get(skip, take);
            foreach (RoleDAL Role in ListOfDataLayerObjects)
            {
                RoleBLL BusinessObject = new RoleBLL(Role);
                ProposedReturnValue.Add(BusinessObject);
            }
            return ProposedReturnValue;
        }

        public RoleBLL Role_FindByRoleID(int roleID)
        {
            RoleBLL ProposedReturnValue = null;
            RoleDAL DataLayerObject = _context.Role_FindByRoleID(roleID);
            if (null != DataLayerObject)
            {
                ProposedReturnValue = new RoleBLL(DataLayerObject);
            }
            return ProposedReturnValue;
        }

        public int Roles_ObtainCount()
        {
            int proposedReturnValue = 0;
            proposedReturnValue = _context.Roles_ObtainCount();
            return proposedReturnValue;
        }

        // ----- Update ----- //
        public void Role_JustUpdate(int roleID, string roleName, string rolePermissions)
        {
            _context.Role_JustUpdate(roleID, roleName, rolePermissions);
        }

        public void Role_JustUpdate(RoleBLL role)
        {
            _context.Role_JustUpdate(role.RoleID, role.RoleName, role.RolePermissions);
        }

        // ----- Delete ----- //
        public void Role_Delete(int roleID)
        {
            _context.Role_Delete(roleID);
        }

        public void Role_Delete(RoleBLL role)
        {
            _context.Role_Delete(role.RoleID);
        }


        #endregion


        #region USERS


        // ----- Create ----- //
        public int User_Create(string userName, string userEmail, string passwordHash, string passwordSalt, int roleID)
        {
            int proposedReturnValue = -1;
            proposedReturnValue = _context.User_Create(userName, userEmail, passwordHash, passwordSalt, roleID);
            return proposedReturnValue;
        }

        public int User_Create(UserBLL user)
        {
            int proposedReturnValue = -1;
            proposedReturnValue = _context.User_Create(user.UserName, user.UserEmail, user.PasswordHash, user.PasswordSalt, user.RoleID);
            return proposedReturnValue;
        }

        // ----- Read ----- //
        public List<UserBLL> Users_Get(int skip, int take)
        {
            List<UserBLL> ProposedReturnValue = new List<UserBLL>();
            List<UserDAL> ListOfDataLayerObjects = _context.Users_Get(skip, take);
            foreach (UserDAL user in ListOfDataLayerObjects)
            {
                UserBLL BusinessObject = new UserBLL(user);
                ProposedReturnValue.Add(BusinessObject);
            }
            return ProposedReturnValue;
        }

        public List<UserBLL> Users_GetRelatedToRoleID(int roleID, int skip, int take)
        {
            List<UserBLL> ProposedReturnValue = new List<UserBLL>();
            List<UserDAL> ListOfDataLayerObjects = _context.Users_GetRelatedToRoleID(roleID, skip, take);
            foreach (UserDAL user in ListOfDataLayerObjects)
            {
                UserBLL BusinessObject = new UserBLL(user);
                ProposedReturnValue.Add(BusinessObject);
            }
            return ProposedReturnValue;
        }

        public UserBLL User_FindByUserID(int userID)
        {
            UserBLL ProposedReturnValue = null;
            UserDAL DataLayerObject = _context.User_FindByUserID(userID);
            if (null != DataLayerObject)
            {
                ProposedReturnValue = new UserBLL(DataLayerObject);
            }
            return ProposedReturnValue;
        }

        public UserBLL User_FindByUserName(string userName)
        {
            UserBLL ProposedReturnValue = null;
            UserDAL DataLayerObject = _context.User_FindByUserName(userName);
            if (null != DataLayerObject)
            {
                ProposedReturnValue = new UserBLL(DataLayerObject);
            }
            return ProposedReturnValue;
        }

        public UserBLL User_FindByUserEmail(string userEmail)
        {
            UserBLL ProposedReturnValue = null;
            UserDAL DataLayerObject = _context.User_FindByUserEmail(userEmail);
            if (null != DataLayerObject)
            {
                ProposedReturnValue = new UserBLL(DataLayerObject);
            }
            return ProposedReturnValue;
        }

        public int Users_ObtainCount()
        {
            int proposedReturnValue = 0;
            proposedReturnValue = _context.Users_ObtainCount();
            return proposedReturnValue;
        }

        // ----- Update ----- //
        public void User_JustUpdate(int userID, string userName, string userEmail, string passwordHash, string passwordSalt, int roleID)
        {
            _context.User_JustUpdate(userID, userName, userEmail, passwordHash, passwordSalt, roleID);
        }

        public void User_JustUpdate(UserBLL user)
        {
            _context.User_JustUpdate(user.UserID, user.UserName, user.UserEmail, user.PasswordHash, user.PasswordSalt, user.RoleID);
        }

        // ----- Delete ----- //
        public void User_Delete(int userID)
        {
            _context.User_Delete(userID);
        }

        public void User_Delete(UserBLL user)
        {
            _context.User_Delete(user.UserID);
        }


        #endregion


        #region SIMUUS


        // ----- Create ----- //
        public int Simuu_Create(string simuuName, int simuuAge, DateTime simuuBirth, DateTime simuuDeath, int simuuXCoordinate, int simuuYCoordinate, int impulseToRest, int impulseToDrink, int impulseToEat, int statEnergy, int statThirst, int statHunger, int statMovementSpeed, int statSenseRadius, int userID)
        {
            int proposedReturnValue = -1;
            proposedReturnValue = _context.Simuu_Create(simuuName, simuuAge, simuuBirth, simuuDeath, simuuXCoordinate, simuuYCoordinate, impulseToRest, impulseToDrink, impulseToEat, statEnergy, statThirst, statHunger, statMovementSpeed, statSenseRadius, userID);
            return proposedReturnValue;
        }

        public int Simuu_Create(SimuuBLL simuu)
        {
            int proposedReturnValue = -1;
            proposedReturnValue = _context.Simuu_Create(simuu.SimuuName, simuu.SimuuAge, simuu.SimuuBirth, simuu.SimuuDeath, simuu.SimuuXCoordinate, simuu.SimuuYCoordinate, simuu.ImpulseToRest, simuu.ImpulseToDrink, simuu.ImpulseToEat, simuu.StatEnergy, simuu.StatThirst, simuu.StatHunger, simuu.SimuuMovementSpeed, simuu.SimuuSenseRadius, simuu.UserID);
            return proposedReturnValue;
        }

        // ----- Read ----- //
        public List<SimuuBLL> Simuus_Get(int skip, int take)
        {
            List<SimuuBLL> ProposedReturnValue = new List<SimuuBLL>();
            List<SimuuDAL> ListOfDataLayerObjects = _context.Simuus_Get(skip, take);
            foreach (SimuuDAL Simuu in ListOfDataLayerObjects)
            {
                SimuuBLL BusinessObject = new SimuuBLL(Simuu);
                ProposedReturnValue.Add(BusinessObject);
            }
            return ProposedReturnValue;
        }

        public List<SimuuBLL> Simuus_GetRelatedToUserID(int userID, int skip, int take)
        {
            List<SimuuBLL> ProposedReturnValue = new List<SimuuBLL>();
            List<SimuuDAL> ListOfDataLayerObjects = _context.Simuus_GetRelatedToUserID(userID, skip, take);
            foreach (SimuuDAL simuu in ListOfDataLayerObjects)
            {
                SimuuBLL BusinessObject = new SimuuBLL(simuu);
                ProposedReturnValue.Add(BusinessObject);
            }
            return ProposedReturnValue;
        }

        public SimuuBLL Simuu_FindBySimuuID(int simuuID)
        {
            SimuuBLL ProposedReturnValue = null;
            SimuuDAL DataLayerObject = _context.Simuu_FindBySimuuID(simuuID);
            if (null != DataLayerObject)
            {
                ProposedReturnValue = new SimuuBLL(DataLayerObject);
            }
            return ProposedReturnValue;
        }

        public int Simuus_ObtainCount()
        {
            int proposedReturnValue = 0;
            proposedReturnValue = _context.Simuus_ObtainCount();
            return proposedReturnValue;
        }

        public int Simuus_ObtainCountRelatedToUserID(int userID)
        {
            int proposedReturnValue = 0;
            proposedReturnValue = _context.Simuus_ObtainCountRelatedToUserID(userID);
            return proposedReturnValue;
        }

        // ----- Update ----- //
        public void Simuu_JustUpdate(int simuuID, string simuuName, int simuuAge, DateTime simuuBirth, DateTime simuuDeath, int simuuXCoordinate, int simuuYCoordinate, int impulseToRest, int impulseToDrink, int impulseToEat, int statEnergy, int statThirst, int statHunger, int statMovementSpeed, int statSenseRadius)
        {
            _context.Simuu_JustUpdate(simuuID, simuuName, simuuAge, simuuBirth, simuuDeath, simuuXCoordinate, simuuYCoordinate, impulseToRest, impulseToDrink, impulseToEat, statEnergy, statThirst, statHunger, statMovementSpeed, statSenseRadius);
        }

        public void Simuu_JustUpdate(SimuuBLL simuu)
        {
            _context.Simuu_JustUpdate(simuu.SimuuID, simuu.SimuuName, simuu.SimuuAge, simuu.SimuuBirth, simuu.SimuuDeath, simuu.SimuuXCoordinate, simuu.SimuuYCoordinate, simuu.ImpulseToRest, simuu.ImpulseToDrink, simuu.ImpulseToEat, simuu.StatEnergy, simuu.StatThirst, simuu.StatHunger, simuu.SimuuMovementSpeed, simuu.SimuuSenseRadius);
        }

        // ----- Delete ----- //
        public void Simuu_Delete(int simuuID)
        {
            _context.Simuu_Delete(simuuID);
        }

        public void Simuu_Delete(SimuuBLL simuu)
        {
            _context.Simuu_Delete(simuu.SimuuID);
        }


        #endregion


        #region ITEMS


        // ----- Create ----- //
        public int Item_Create(string itemName, int itemEnergyModifier, int itemThirstModifier, int itemHungerModifier, int userID)
        {
            int proposedReturnValue = -1;
            proposedReturnValue = _context.Item_Create(itemName, itemEnergyModifier, itemThirstModifier, itemHungerModifier, userID);
            return proposedReturnValue;
        }

        public int Item_Create(ItemBLL item)
        {
            int proposedReturnValue = -1;
            proposedReturnValue = _context.Item_Create(item.ItemName, item.ItemEnergyModifier, item.ItemThirstModifier, item.ItemHungerModifier, item.UserID);
            return proposedReturnValue;
        }

        // ----- Read ----- //
        public List<ItemBLL> Items_Get(int skip, int take)
        {
            List<ItemBLL> ProposedReturnValue = new List<ItemBLL>();
            List<ItemDAL> ListOfDataLayerObjects = _context.Items_Get(skip, take);
            foreach (ItemDAL item in ListOfDataLayerObjects)
            {
                ItemBLL BusinessObject = new ItemBLL(item);
                ProposedReturnValue.Add(BusinessObject);
            }
            return ProposedReturnValue;
        }

        public List<ItemBLL> Items_GetRelatedToUserID(int userID, int skip, int take)
        {
            List<ItemBLL> proposedReturnValue = new List<ItemBLL>();
            List<ItemDAL> ListOfDataLayerObjects = _context.Items_GetRelatedToUserID(userID, skip, take);
            foreach (ItemDAL Item in ListOfDataLayerObjects)
            {
                ItemBLL BusinessObject = new ItemBLL(Item);
                proposedReturnValue.Add(BusinessObject);
            }
            return proposedReturnValue;
        }

        public ItemBLL Item_FindByItemID(int itemID)
        {
            ItemBLL ProposedReturnValue = null;
            ItemDAL DataLayerObject = _context.Item_FindByItemID(itemID);
            if (null != DataLayerObject)
            {
                ProposedReturnValue = new ItemBLL(DataLayerObject);
            }
            return ProposedReturnValue;
        }

        public int Items_ObtainCount()
        {
            int proposedReturnValue = 0;
            proposedReturnValue = _context.Items_ObtainCount();
            return proposedReturnValue;
        }

        public int Items_ObtainCountRelatedToUserID(int userID)
        {
            int proposedReturnValue = 0;
            proposedReturnValue = _context.Items_ObtainCountRelatedToUserID(userID);
            return proposedReturnValue;
        }

        // ----- Update ----- //
        public void Item_JustUpdate(int itemID, string itemName, int itemEnergyModifier, int itemThirstModifier, int itemHungerModifier)
        {
            _context.Item_JustUpdate(itemID, itemName, itemEnergyModifier, itemThirstModifier, itemHungerModifier);
        }

        public void Item_JustUpdate(ItemBLL item)
        {
            _context.Item_JustUpdate(item.ItemID, item.ItemName, item.ItemEnergyModifier, item.ItemThirstModifier, item.ItemHungerModifier);
        }

        // ----- Delete ----- //
        public void Item_Delete(int itemID)
        {
            _context.Item_Delete(itemID);
        }

        public void Item_Delete(ItemBLL item)
        {
            _context.Item_Delete(item.ItemID);
        }


        #endregion


        #region PROCESSING


        public List<SimuuBLL> ProcessSimuus()
        {
            SimulationLogic simLog = new SimulationLogic();
            int simCount = Simuus_ObtainCount();
            simLog.mySimuus = Simuus_Get(0, simCount);
            simLog.Process();
            foreach (var simuu in simLog.mySimuus)
            {
                Simuu_JustUpdate(simuu);
            }
            return simLog.mySimuus;
        }


        #endregion

    }
}
