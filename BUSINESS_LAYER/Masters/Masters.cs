using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUSINESS_LAYER.Masters
{
    public class Masters
    {
        #region Objects
        DATA_LAYER.DatabaseConnectivity.DatabaseConnections obj_DB = new DATA_LAYER.DatabaseConnectivity.DatabaseConnections();
        #endregion

        #region GroupMaster
        public string BL_GroupMasterTransaction()
        {
            try
            {
                return obj_DB.ExecuteProcedureParam("Proc_GroupMaster", ENTITY_LAYER.Masters.Masters.GroupID, ENTITY_LAYER.Masters.Masters.Rights, ENTITY_LAYER.Masters.Masters.Type, ENTITY_LAYER.Login.Login.UserID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet BL_GroupMasterDetails()
        {
            try
            {
                return obj_DB.ExecuteDataSetParam("Proc_GroupMaster", ENTITY_LAYER.Masters.Masters.GroupID, ENTITY_LAYER.Masters.Masters.Rights, ENTITY_LAYER.Masters.Masters.Type, ENTITY_LAYER.Login.Login.UserID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region UserMaster
        public string BL_UserMasterTransaction()
        {
            try
            {
                return obj_DB.ExecuteProcedureParam("Proc_UserMaster", ENTITY_LAYER.Masters.Masters.RefNo, ENTITY_LAYER.Masters.Masters.UserID, ENTITY_LAYER.Masters.Masters.UserName, ENTITY_LAYER.Masters.Masters.Password, ENTITY_LAYER.Masters.Masters.GroupID, ENTITY_LAYER.Login.Login.UserID, ENTITY_LAYER.Masters.Masters.Type);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet BL_UserMasterDetails()
        {
            try
            {
                return obj_DB.ExecuteDataSetParam("Proc_UserMaster", ENTITY_LAYER.Masters.Masters.RefNo, ENTITY_LAYER.Masters.Masters.UserID, ENTITY_LAYER.Masters.Masters.UserName, ENTITY_LAYER.Masters.Masters.Password, ENTITY_LAYER.Masters.Masters.GroupID, ENTITY_LAYER.Login.Login.UserID, ENTITY_LAYER.Masters.Masters.Type);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region LineMaster
        public string BL_LineMasterTransaction()
        {
            try
            {
                return obj_DB.ExecuteProcedureParam("Proc_LineMaster", ENTITY_LAYER.Masters.Masters.RefNo, ENTITY_LAYER.Masters.Masters.Lineno, ENTITY_LAYER.Masters.Masters.Linename, ENTITY_LAYER.Masters.Masters.Status, ENTITY_LAYER.Login.Login.UserID, ENTITY_LAYER.Masters.Masters.Type);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet BL_LineMasterDetails()
        {
            try
            {
                return obj_DB.ExecuteDataSetParam("Proc_LineMaster", ENTITY_LAYER.Masters.Masters.RefNo, ENTITY_LAYER.Masters.Masters.Lineno, ENTITY_LAYER.Masters.Masters.Linename, ENTITY_LAYER.Masters.Masters.Status, ENTITY_LAYER.Login.Login.UserID, ENTITY_LAYER.Masters.Masters.Type);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion


        #region DeviceIPMaster
        public string BL_DeviceIpMasterTransaction()
        {
            try
            {
                return obj_DB.ExecuteProcedureParam("Proc_DeviceIPMaster", ENTITY_LAYER.Masters.Masters.RefNo, ENTITY_LAYER.Masters.Masters.devicetype, ENTITY_LAYER.Masters.Masters.Linename, ENTITY_LAYER.Masters.Masters.ip, ENTITY_LAYER.Masters.Masters.port, ENTITY_LAYER.Masters.Masters.Status, ENTITY_LAYER.Login.Login.UserID, ENTITY_LAYER.Masters.Masters.Type);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet BL_DeviceIpMasterDetails()
        {
            try
            {
                return obj_DB.ExecuteDataSetParam("Proc_DeviceIPMaster", ENTITY_LAYER.Masters.Masters.RefNo, ENTITY_LAYER.Masters.Masters.devicetype, ENTITY_LAYER.Masters.Masters.Linename, ENTITY_LAYER.Masters.Masters.ip, ENTITY_LAYER.Masters.Masters.port, ENTITY_LAYER.Masters.Masters.Status, ENTITY_LAYER.Login.Login.UserID, ENTITY_LAYER.Masters.Masters.Type);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
       
    }
}


