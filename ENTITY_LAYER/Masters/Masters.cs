using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace ENTITY_LAYER.Masters
{
    public static class Masters
    {
        #region Variables
        static int _RefNo;

        static string _Dtfrom, _Dtto;
        static string _Type, _UserID, _UserName, _GroupID, _Password, _Rights, _LoginID;
        static string _Lineno, _Linename, _devicetype, _ip, _port;
        static string _Workorderno, _Pono, _ArticleNo, _LineNo, _Qty,_status,_Barcode, _Serialno,_Status , _t_Refcntd,_t_Refcntu  ,_WorkCenter ,_Unit;
        public static string Dtfrom { get => _Dtfrom; set => _Dtfrom = value; }
        public static string Dtto { get => _Dtto; set => _Dtto = value; }

        public static string Lineno { get => _Lineno; set => _Lineno = value; }
        public static string Linename { get => _Linename; set => _Linename = value; }
        public static string devicetype { get => _devicetype; set => _devicetype = value; }
        public static string ip { get => _ip; set => _ip = value; }
        public static string port { get => _port; set => _port = value; }

        public static string Workorderno { get => _Workorderno; set => _Workorderno = value; }
        public static string Pono { get => _Pono; set => _Pono = value; }
        public static string ArticleNo { get => _ArticleNo; set => _ArticleNo = value; }
        public static string LineNo { get => _LineNo; set => _LineNo = value; }
        public static string Qty { get => _Qty; set => _Qty = value; }
        public static string status { get => _status; set => _status = value; }
        public static string Status { get => _Status; set => _Status = value; }




        public static int RefNo { get => _RefNo; set => _RefNo = value; }

        public static string Type { get => _Type; set => _Type = value; }
        public static string UserID { get => _UserID; set => _UserID = value; }
        public static string UserName { get => _UserName; set => _UserName = value; }
        public static string GroupID { get => _GroupID; set => _GroupID = value; }
        public static string Password { get => _Password; set => _Password = value; }
        public static string Rights { get => _Rights; set => _Rights = value; }
        public static string LoginID { get => _LoginID; set => _LoginID = value; }
        public static string Barcode { get => _Barcode; set => _Barcode = value; }
        public static string Serialno { get => _Serialno; set => _Serialno = value; }
        public static string T_Refcntd { get => _t_Refcntd; set => _t_Refcntd = value; }
        public static string T_Refcntu { get => _t_Refcntu; set => _t_Refcntu = value; }
        public static string WorkCenter { get => _WorkCenter; set => _WorkCenter = value; }
        public static string Unit { get => _Unit; set => _Unit = value; }
        #endregion
    }
}
