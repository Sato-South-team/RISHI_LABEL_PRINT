using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Data;
using System.Reflection;
using SAPBusinessObjects.WPF.Viewer;

namespace RISHI_LABEL_PRINT.Reports.Report
{
    /// <summary>
    /// Interaction logic for ReportViewer.xaml
    /// </summary>
    public partial class ReportViewer : Window
    {
        #region Variables and Objects
        BUSINESS_LAYER.LogCreation.LogCreation obj_Log = new BUSINESS_LAYER.LogCreation.LogCreation();
        System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();

        public static DataTable dtReport = new DataTable();
        public static string ReportName = "";
        //[DllImport("Winspool.drv")]
        //private static extern bool SetDefaultPrinter(string printerName);
        //ReportDocument Doc = new ReportDocument();
        #endregion

        public ReportViewer()
        {
            InitializeComponent();
        }
        private void ShowDateTime()
        {
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            txtDatetime.Text = DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss");
        }
        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                
                dispatcherTimer.Stop();
            }
            catch (Exception ex)
            {
                obj_Log.CreateLog(ex.Message.ToString(), MethodBase.GetCurrentMethod().ToString(), "REPORT_VIEWER", CommonClasses.CommonVariable.UserID);
                CommonClasses.CommonMethods.MessageBoxShow(ex.Message.ToString(), CommonClasses.CommonVariable.CustomStriing.Error.ToString());
            }
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
                WindowState = WindowState.Maximized;
                switch (ReportName)
                {

                    case "TransactionReport":
                        Reports.CrystallReports.TransactionReport objTransportReport = new CrystallReports.TransactionReport(); ;
                        objTransportReport.SetDataSource(dtReport);
                        crystalReportsViewer1.ViewerCore.ReportSource = objTransportReport;
                        crystalReportsViewer1.ToggleSidePanel = Constants.SidePanelKind.None;
                        break;
                    case "DetailedReport":
                        Reports.CrystallReports.DetailledReport objDetailledReport = new CrystallReports.DetailledReport(); ;
                        objDetailledReport.SetDataSource(dtReport);
                        crystalReportsViewer1.ViewerCore.ReportSource = objDetailledReport;
                        crystalReportsViewer1.ToggleSidePanel = Constants.SidePanelKind.None;
                        break;
                    case "DailyReport":
                        Reports.CrystallReports.DailySummaryReport objDailyReport = new CrystallReports.DailySummaryReport(); ;
                        objDailyReport.SetDataSource(dtReport);
                        crystalReportsViewer1.ViewerCore.ReportSource = objDailyReport;
                        crystalReportsViewer1.ToggleSidePanel = Constants.SidePanelKind.None;
                        break;
                }
            }
            catch (Exception ex)
            {
                obj_Log.CreateLog(ex.Message.ToString(), MethodBase.GetCurrentMethod().ToString(), "REPORT_VIEWER", CommonClasses.CommonVariable.UserID);
                CommonClasses.CommonMethods.MessageBoxShow(ex.Message.ToString(), CommonClasses.CommonVariable.CustomStriing.Error.ToString());

            }
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //NavigationService.GoBack();
                this.Close();
                StartUp.MainWindow obj_page = new StartUp.MainWindow();
                obj_page.ShowDialog();
            }
            catch (Exception ex)
            {
                obj_Log.CreateLog(ex.Message.ToString(), MethodBase.GetCurrentMethod().ToString(), "REPORT_VIEWER", CommonClasses.CommonVariable.UserID);
                CommonClasses.CommonMethods.MessageBoxShow(ex.Message.ToString(), CommonClasses.CommonVariable.CustomStriing.Error.ToString());
            }
        }
        private void ImgSmily3_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
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
                obj_Log.CreateLog(ex.Message.ToString(), MethodBase.GetCurrentMethod().ToString(), "REPORT_VIEWER", CommonClasses.CommonVariable.UserID);
                CommonClasses.CommonMethods.MessageBoxShow(ex.Message.ToString(), CommonClasses.CommonVariable.CustomStriing.Error.ToString());
            }
        }
    }
}
