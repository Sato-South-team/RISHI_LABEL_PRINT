using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RISHI_LABEL_PRINT.Reports.Report
{
    /// <summary>
    /// Interaction logic for Detailed_Report.xaml
    /// </summary>
    public partial class Detailed_Report : Window
    {
        public Detailed_Report()
        {
            InitializeComponent();
        }
        #region Variable and Objects
        BUSINESS_LAYER.LogCreation.LogCreation obj_Log = new BUSINESS_LAYER.LogCreation.LogCreation();
        BUSINESS_LAYER.Masters.Masters obj_Mast = new BUSINESS_LAYER.Masters.Masters();
        System.Windows.Threading.DispatcherTimer dispatcherTimer1 = new System.Windows.Threading.DispatcherTimer();
        System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
        BUSINESS_LAYER.Transaction.Transaction obj_Tran = new BUSINESS_LAYER.Transaction.Transaction();

        #endregion
        private void ShowDateTime()
        {
            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                ShowDateTime();
                Transaction("GetDetails");
                this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
                WindowState = WindowState.Maximized;

            }
            catch (Exception ex)
            {
                obj_Log.CreateLog(ex.Message.ToString(), MethodBase.GetCurrentMethod().ToString(), "DASHBOARD_REPORT", CommonClasses.CommonVariable.UserID);
                CommonClasses.CommonMethods.MessageBoxShow(ex.Message.ToString(), CommonClasses.CommonVariable.CustomStriing.Error.ToString());
            }
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            txtDatetime.Text = DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss");
        }
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.LeftAlt) && Keyboard.IsKeyDown(Key.S) || Keyboard.IsKeyDown(Key.RightAlt) && Keyboard.IsKeyDown(Key.S))
            {
                BtnShow_Click(sender, e);
            }
            if (Keyboard.IsKeyDown(Key.LeftAlt) && Keyboard.IsKeyDown(Key.C) || Keyboard.IsKeyDown(Key.RightAlt) && Keyboard.IsKeyDown(Key.C))
            {
                BtnClear_Click(sender, e);
            }
            if (Keyboard.IsKeyDown(Key.LeftAlt) && Keyboard.IsKeyDown(Key.E) || Keyboard.IsKeyDown(Key.RightAlt) && Keyboard.IsKeyDown(Key.E) || Keyboard.IsKeyDown(Key.Escape) && Keyboard.IsKeyDown(Key.Escape))
            {
                BtnExit_Click(sender, e);
            }
        }

        private void Transaction(string Type)
        {
            if (Type == "GetDetails")
            {
                ENTITY_LAYER.Masters.Masters.Type = Type;
                System.Data.DataSet dt = obj_Tran.BL_TransactionReport();
                CommonClasses.CommonMethods.FillComboBox(cmbwrkno, dt.Tables[0], "WorkOrderNo");

            }
            if (Type == "DetailedReport")
            {
                if (dtpFrom.Text != "" && dtpTo.Text != "")
                {
                    ENTITY_LAYER.Masters.Masters.Dtfrom = dtpFrom.SelectedDate.Value.ToString("dd MMM yyyy HH:mm:ss");
                    ENTITY_LAYER.Masters.Masters.Dtto = dtpTo.SelectedDate.Value.ToString("dd MMM yyyy HH:mm:ss");
                }
                ENTITY_LAYER.Masters.Masters.Type = Type;
                ENTITY_LAYER.Masters.Masters.Workorderno = cmbwrkno.Text;
                System.Data.DataTable dt = obj_Tran.BL_TransactionReport().Tables[0];

                Report.ReportViewer.dtReport = dt;
                Report.ReportViewer.ReportName = ENTITY_LAYER.Masters.Masters.Type;
                // NavigationService.Navigate(new Report.ReportViewer());
                this.Close();
                Report.ReportViewer obj_page = new Report.ReportViewer();
                obj_page.ShowDialog();
                //crystalReportsViewer1.ViewerCore.RefreshReport();

            }
        }
        private void BtnShow_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool Falg = false;
                if (dtpFrom.Text != "" && dtpTo.Text != "")
                {
                    Falg = true;
                    //CommonClasses.CommonMethods.MessageBoxShow("PLEASE SELECT DATE", CommonClasses.CommonVariable.CustomStriing.Information.ToString());
                    //return;
                }
                if (cmbwrkno.SelectedIndex > -1)
                {
                    Falg = true;
                    //CommonClasses.CommonMethods.MessageBoxShow("PLEASE SELECT TO DATE", CommonClasses.CommonVariable.CustomStriing.Information.ToString());
                    //return;
                }
                if (Falg == false)
                {
                    CommonClasses.CommonMethods.MessageBoxShow("PLEASE SELECT ANY INFORMATION", CommonClasses.CommonVariable.CustomStriing.Information.ToString());
                    return;
                }
                Transaction("DetailedReport");

            }
            catch (Exception ex)
            {
                obj_Log.CreateLog(ex.Message.ToString(), MethodBase.GetCurrentMethod().ToString(), "DASHBOARD_REPORT", CommonClasses.CommonVariable.UserID);
                CommonClasses.CommonMethods.MessageBoxShow(ex.Message.ToString(), CommonClasses.CommonVariable.CustomStriing.Error.ToString());
            }
        }
        public void Clear()
        {
            cmbwrkno.Text = "";
            dtpFrom.Text = "";
            dtpTo.Text = "";
        }
        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Clear();
            }
            catch (Exception ex)
            {
                obj_Log.CreateLog(ex.Message.ToString(), MethodBase.GetCurrentMethod().ToString(), "DASHBOARD_REPORT", CommonClasses.CommonVariable.UserID);
                CommonClasses.CommonMethods.MessageBoxShow(ex.Message.ToString(), CommonClasses.CommonVariable.CustomStriing.Error.ToString());
            }
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
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
                obj_Log.CreateLog(ex.Message.ToString(), MethodBase.GetCurrentMethod().ToString(), "DASHBOARD_REPORT", CommonClasses.CommonVariable.UserID);
                CommonClasses.CommonMethods.MessageBoxShow(ex.Message.ToString(), CommonClasses.CommonVariable.CustomStriing.Error.ToString());
            }
        }
    }
}
