using RISHI_LABEL_PRINT.CommonClasses;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace RISHI_LABEL_PRINT
{ 
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        BUSINESS_LAYER.LogCreation.LogCreation obj_Log = new BUSINESS_LAYER.LogCreation.LogCreation();

        private void StartUP(object sender, StartupEventArgs e)
        {
            try
            {
                if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\Log"))
                {
                    Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "\\Log");
                }
                string data = ConfigurationManager.AppSettings["ConnectionString"].ToString();
                string ERPdata = ConfigurationManager.AppSettings["ERPConnectionString"].ToString();
                if (data != "" && ERPdata!="")
                {
                    string[] DataSplit = data.Split(',');
                    string[] ERPDataSplit = ERPdata.Split(',');
                    if (DataSplit.Length > 0)
                    {
                        ENTITY_LAYER.DatabaseSettings.DatabaseSettings.SqldbServer = DataSplit[0].ToString();
                        ENTITY_LAYER.DatabaseSettings.DatabaseSettings.SqlDBUserID = DataSplit[1].ToString();
                        ENTITY_LAYER.DatabaseSettings.DatabaseSettings.SqlDBPassword = DataSplit[2].ToString();
                        ENTITY_LAYER.DatabaseSettings.DatabaseSettings.SqlDBName = DataSplit[3].ToString();

                        ENTITY_LAYER.DatabaseSettings.DatabaseSettings.ERPSqldbServer = ERPDataSplit[0].ToString();
                        ENTITY_LAYER.DatabaseSettings.DatabaseSettings.ERPSqlDBUserID = ERPDataSplit[1].ToString();
                        ENTITY_LAYER.DatabaseSettings.DatabaseSettings.ERPSqlDBPassword = ERPDataSplit[2].ToString();
                        ENTITY_LAYER.DatabaseSettings.DatabaseSettings.ERPSqlDBName = ERPDataSplit[3].ToString();

                        CommonVariable.obj_Login = new StartUp.Login();
                        CommonVariable.obj_Login.ShowDialog();
                    }
                    else
                    {
                        CommonClasses.CommonMethods.MessageBoxShow("INCORRECT DATABASE SETTING!!", CommonClasses.CommonVariable.CustomStriing.Information.ToString());

                    }
                }
                else
                {
                    StartUp.DatabaseSetting obj_DatabaseSetting = new StartUp.DatabaseSetting();
                    App.Current.MainWindow.Content = obj_DatabaseSetting;
                }

            }
            catch (Exception ex)
            {
                obj_Log.CreateLog(ex.Message.ToString(), MethodBase.GetCurrentMethod().ToString(), "MAINWINDOW", CommonClasses.CommonVariable.UserID);
                CommonClasses.CommonMethods.MessageBoxShow(ex.Message.ToString(), CommonClasses.CommonVariable.CustomStriing.Error.ToString());
            }
        }


        private void Grid_MouseLeftButtonUp_1(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                Process.GetProcessesByName("RISHI_LABEL_PRINT")[0].Kill();
            }
            catch (Exception ex)
            {
                obj_Log.CreateLog(ex.Message.ToString(), MethodBase.GetCurrentMethod().ToString(), "MAINWINDOW", CommonClasses.CommonVariable.UserID);
                CommonClasses.CommonMethods.MessageBoxShow(ex.Message.ToString(), CommonClasses.CommonVariable.CustomStriing.Error.ToString());
            }
        }
    }
}
