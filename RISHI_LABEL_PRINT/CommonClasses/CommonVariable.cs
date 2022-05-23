using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RISHI_LABEL_PRINT.CommonClasses
{
 public class CommonVariable
    {
        #region Common_Variables
        public static string DataSaved = "DATA SAVED SUCCESSFULLY";
        public static string DataDeleted = "DATA DELETED SUCCESSFULLY";
        public static string DataUpdated = "DATA UPDATED SUCCESSFULLY";
        public static string Duplicate = "DATA ALREADY EXIST";
        public static string DeleteConfirm = "DO YOU WANT TO DELETE SELECTED DATA?";
        public static string RowSelection = " PLEASE SELECT ROW FROM LIST VIEW FOR YOUR TRANSACTION!!!";
        public static string UserID = "";
        public static string UserName = "";
        public static string UserType = "";
        public static string Rights = "";
        public static int RefNo = 0;
        public static string Active = "Active";
        public static string InActive = "InActive";
        public static string Result = "";
       
        public static StartUp.Login obj_Login = new StartUp.Login();
        public enum CustomStriing
        {
            YESNO,
            OKCancel,
            OK,
            Error,
            Successfull,
            Information,
            Question,
            Exclamatory,
        }
        #endregion
    }
}
