using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUSINESS_LAYER.Transaction
{
    public class Transaction
    {
        #region Objects
        DATA_LAYER.DatabaseConnectivity.DatabaseConnections obj_DB = new DATA_LAYER.DatabaseConnectivity.DatabaseConnections();
        DATA_LAYER.DatabaseConnectivity.ERP_DatabaseConnections obj_ERPDB = new DATA_LAYER.DatabaseConnectivity.ERP_DatabaseConnections();
        #endregion

        #region PickList
        
        #endregion

        #region "Label printing"
        public string BL_LabelPrintingTransaction()
        {
            try
            {
                return obj_DB.ExecuteProcedureParam("Proc_PrintDetails", ENTITY_LAYER.Masters.Masters.RefNo, ENTITY_LAYER.Masters.Masters.Workorderno, ENTITY_LAYER.Masters.Masters.Pono, ENTITY_LAYER.Masters.Masters.ArticleNo, ENTITY_LAYER.Masters.Masters.Lineno, ENTITY_LAYER.Masters.Masters.Qty, ENTITY_LAYER.Masters.Masters.status, ENTITY_LAYER.Masters.Masters.Serialno,ENTITY_LAYER.Masters.Masters.Barcode ,ENTITY_LAYER.Login.Login.UserID, ENTITY_LAYER.Masters.Masters.Type, ENTITY_LAYER.Masters.Masters.T_Refcntd, ENTITY_LAYER.Masters.Masters.T_Refcntu, ENTITY_LAYER.Masters.Masters.WorkCenter, ENTITY_LAYER.Masters.Masters.Unit);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable BL_LabelPrintingDetails(string workordno)
        {
            try
            {
                if (workordno != "")
                {
                    return obj_ERPDB.ExecuteDataTable("select t_worn as 'WorkOrderNo' , t_corn as 'PONo' , t_unit as 'Unit', (select  t_wocn from ttifib0211000 where  t_prno like '%FIB%' and t_worn= t1.t_worn) as 'WorkCenter', t_qnty as 'Qty'  , t_Refcntd, t_Refcntu, t_cref as 'ArticaleNo' from ttifib0201000 as t1 where t1.t_worn = '" + workordno+ "'");
                }
                else
                {
                    return obj_ERPDB.ExecuteDataTable("SELECT t_worn as 'WorkOrderNo' ,(select t_dsca from ttirou0021000 where t_mcno = TT1.t_mcno) as 'LineNo'  FROM ttifib0211000 as TT1 where  t_prno like '%FIB%' ");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet BL_TransactionReport()
        {
            try
            {

                return obj_DB.ExecuteDataSetParam("Proc_Report", ENTITY_LAYER.Masters.Masters.Dtfrom, ENTITY_LAYER.Masters.Masters.Dtto, ENTITY_LAYER.Masters.Masters.Type, ENTITY_LAYER.Masters.Masters.Workorderno);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet BL_DashboardDetails()
        {
            try
            {

                return obj_DB.ExecuteDataSetParam("Proc_PrintDetails", ENTITY_LAYER.Masters.Masters.RefNo, ENTITY_LAYER.Masters.Masters.Workorderno, ENTITY_LAYER.Masters.Masters.Pono, ENTITY_LAYER.Masters.Masters.ArticleNo, ENTITY_LAYER.Masters.Masters.Lineno, ENTITY_LAYER.Masters.Masters.Qty, ENTITY_LAYER.Masters.Masters.status, ENTITY_LAYER.Masters.Masters.Serialno, ENTITY_LAYER.Masters.Masters.Barcode, ENTITY_LAYER.Login.Login.UserID, ENTITY_LAYER.Masters.Masters.Type, ENTITY_LAYER.Masters.Masters.T_Refcntd, ENTITY_LAYER.Masters.Masters.T_Refcntu, ENTITY_LAYER.Masters.Masters.WorkCenter, ENTITY_LAYER.Masters.Masters.Unit);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet BL_LabelPrintingDetails()
        {
            try
            {
                return obj_DB.ExecuteDataSetParam("Proc_PrintDetails", ENTITY_LAYER.Masters.Masters.RefNo, ENTITY_LAYER.Masters.Masters.Workorderno, ENTITY_LAYER.Masters.Masters.Pono, ENTITY_LAYER.Masters.Masters.ArticleNo, ENTITY_LAYER.Masters.Masters.Lineno, ENTITY_LAYER.Masters.Masters.Qty, ENTITY_LAYER.Masters.Masters.status, ENTITY_LAYER.Masters.Masters.Serialno, ENTITY_LAYER.Masters.Masters.Barcode, ENTITY_LAYER.Login.Login.UserID, ENTITY_LAYER.Masters.Masters.Type, ENTITY_LAYER.Masters.Masters.T_Refcntd, ENTITY_LAYER.Masters.Masters.T_Refcntu, ENTITY_LAYER.Masters.Masters.WorkCenter, ENTITY_LAYER.Masters.Masters.Unit);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

    }
}
