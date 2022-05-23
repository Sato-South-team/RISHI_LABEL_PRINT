using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RISHI_LABEL_PRINT.Transactions
{
    /// <summary>
    /// Interaction logic for DashBoard.xaml
    /// </summary>
    public partial class DashBoard : Window
    {
        public DashBoard()
        {
            InitializeComponent();
        }
        #region Variable and Objects
        BUSINESS_LAYER.LogCreation.LogCreation obj_Log = new BUSINESS_LAYER.LogCreation.LogCreation();
        BUSINESS_LAYER.Masters.Masters obj_Mast = new BUSINESS_LAYER.Masters.Masters();
        System.Windows.Threading.DispatcherTimer dispatcherTimer1 = new System.Windows.Threading.DispatcherTimer();
        System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
        BUSINESS_LAYER.Transaction.Transaction obj_Tran = new BUSINESS_LAYER.Transaction.Transaction();
        int RefNo = 0;
        string serialNo = "";
        string Addbarcode = "";
        //DataTable dt_Workorder = null;
        string t_Refcntd = "";
        string t_Refcntu = "";
        string WorkCenter = "";
        string Unit = "";
        int Qty = 0;
        #endregion
        private void CmbWono_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (cmbWono.SelectedValue != null)
                {
                    try
                    {
                        Transaction("WorkOrderqty");
                    }
                    catch (Exception ex)
                    {
                        obj_Log.CreateLog(ex.Message.ToString(), MethodBase.GetCurrentMethod().ToString(), "DASHBOARD", CommonClasses.CommonVariable.UserID);
                        CommonClasses.CommonMethods.MessageBoxShow(ex.Message.ToString(), CommonClasses.CommonVariable.CustomStriing.Error.ToString());

                    }


                }
                
            }
            catch (Exception ex)
            {
                obj_Log.CreateLog(ex.Message.ToString(), MethodBase.GetCurrentMethod().ToString(), "DASHBOARD", CommonClasses.CommonVariable.UserID);
                CommonClasses.CommonMethods.MessageBoxShow(ex.Message.ToString(), CommonClasses.CommonVariable.CustomStriing.Error.ToString());
            }
        }

        private void ShowDateTime()
        {
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();

           
            dispatcherTimer1.Tick += new EventHandler(dispatcherTimer1_Tick);
            dispatcherTimer1.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer1.Start();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            txtDatetime.Text = DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss");
        }
        private void dispatcherTimer1_Tick(object sender, EventArgs e)
        {
           try
            {
                if (cmbWono.SelectedIndex > -1)
                    Transaction("WorkOrderqty");
            }
            catch (Exception ex)
            {
                obj_Log.CreateLog(ex.Message.ToString(), MethodBase.GetCurrentMethod().ToString(), "DASHBOARD", CommonClasses.CommonVariable.UserID);
                CommonClasses.CommonMethods.MessageBoxShow(ex.Message.ToString(), CommonClasses.CommonVariable.CustomStriing.Error.ToString());

            }
        }
        private void Transaction(string Type)
        {
            if (Type == "WorkOrderqty")
            {
                ENTITY_LAYER.Masters.Masters.Type = Type;
                ENTITY_LAYER.Masters.Masters.Workorderno = cmbWono.SelectedValue.ToString();
                DataSet dt = obj_Tran.BL_DashboardDetails();
                if (dt.Tables.Count > 0)
                {

                    lblworkorno.Content = cmbWono.SelectedValue.ToString();
                    if (dt.Tables[0].Rows.Count > 0)
                        lbllineno.Content = dt.Tables[0].Rows[0]["LineNo"].ToString();
                    if (dt.Tables[1].Rows.Count > 0)
                        lblprtqty.Content = dt.Tables[1].Rows[0]["Printed Qty"].ToString();
                    if (dt.Tables[2].Rows.Count > 0)
                        lblscnqty.Content = dt.Tables[2].Rows[0]["Scanned Qty"].ToString();
                    if (dt.Tables[3].Rows.Count > 0)
                        txtLastScanned.Text = dt.Tables[3].Rows[0]["serialno"].ToString();
                    if (dt.Tables[4].Rows.Count > 0)
                    {
                        if (dt.Tables[4].Rows[0]["connectionStatus"].ToString() == "CONNECTED")
                        {
                            txtScanerStatus.Foreground = Brushes.Green;
                            txtScanerStatus.Background = Brushes.Black;
                            Grid1.Background = Brushes.Black;
                            txtScanerStatus.Text = dt.Tables[4].Rows[0]["ip"] + " : " + dt.Tables[4].Rows[0]["connectionStatus"].ToString();
                        }
                        else
                        {
                            txtScanerStatus.Foreground = Brushes.White;
                            txtScanerStatus.Background = Brushes.Red;

                            Grid1.Background = Brushes.Red;
                            txtScanerStatus.Text = dt.Tables[4].Rows[0]["ip"] + " : " + dt.Tables[4].Rows[0]["connectionStatus"].ToString();

                        }
                    }
                }
            }
            if (Type == "WorkOrderno")
            {
                ENTITY_LAYER.Masters.Masters.Type = Type;
                DataSet dt = obj_Tran.BL_DashboardDetails();
                DataView dv = new DataView(dt.Tables[0]);
                CommonClasses.CommonMethods.FillComboBox(cmbWono, dt.Tables[0], "WorkOrderNo", "WorkOrderNo");

            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                ShowDateTime();
                Transaction("WorkOrderno");
                this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
                WindowState = WindowState.Maximized;
            }
            catch (Exception ex)
            {
                obj_Log.CreateLog(ex.Message.ToString(), MethodBase.GetCurrentMethod().ToString(), "DASHBOARD", CommonClasses.CommonVariable.UserID);
                CommonClasses.CommonMethods.MessageBoxShow(ex.Message.ToString(), CommonClasses.CommonVariable.CustomStriing.Error.ToString());
            }
        }
        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
               // Clear();
                dispatcherTimer.Stop();
            }
            catch (Exception ex)
            {
                obj_Log.CreateLog(ex.Message.ToString(), MethodBase.GetCurrentMethod().ToString(), "DASHBOARD", CommonClasses.CommonVariable.UserID);
                CommonClasses.CommonMethods.MessageBoxShow(ex.Message.ToString(), CommonClasses.CommonVariable.CustomStriing.Error.ToString());
            }
        }
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (Keyboard.IsKeyDown(Key.LeftAlt) && Keyboard.IsKeyDown(Key.C) || Keyboard.IsKeyDown(Key.RightAlt) && Keyboard.IsKeyDown(Key.C))
            {
               btnClear_Click(sender, e);
            }
            if (Keyboard.IsKeyDown(Key.LeftAlt) && Keyboard.IsKeyDown(Key.B) || Keyboard.IsKeyDown(Key.RightAlt) && Keyboard.IsKeyDown(Key.B) || Keyboard.IsKeyDown(Key.Escape) && Keyboard.IsKeyDown(Key.Escape))
            {
                btnExit_Click(sender, e);
            }
        }
        public void clear()
        {

            cmbWono.SelectedIndex = -1;
            lblworkorno.Content = "0";
            lbllineno.Content = "0";
            lblprtqty.Content = "0";
            lblscnqty.Content = "0";
        }
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                clear();
            }
            catch (Exception ex)
            {
                obj_Log.CreateLog(ex.Message.ToString(), MethodBase.GetCurrentMethod().ToString(), "DASHBOARD", CommonClasses.CommonVariable.UserID);
                CommonClasses.CommonMethods.MessageBoxShow(ex.Message.ToString(), CommonClasses.CommonVariable.CustomStriing.Error.ToString());
            }
        }
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // NavigationService.GoBack();
                this.Close();
                StartUp.MainWindow obj_page = new StartUp.MainWindow();
                obj_page.ShowDialog();
            }
            catch (Exception ex)
            {
                obj_Log.CreateLog(ex.Message.ToString(), MethodBase.GetCurrentMethod().ToString(), "DASHBOARD", CommonClasses.CommonVariable.UserID);
                CommonClasses.CommonMethods.MessageBoxShow(ex.Message.ToString(), CommonClasses.CommonVariable.CustomStriing.Error.ToString());
            }
        }
        private bool ControlValidation()
        {
            if (cmbWono.SelectedIndex == -1)
            {
                CommonClasses.CommonMethods.MessageBoxShow("PLEASE SELECT WORKORDER NO.", CommonClasses.CommonVariable.CustomStriing.Information.ToString());
                cmbWono.Focus();
                return false;
            }
            return true;
        }
        

    }
}
