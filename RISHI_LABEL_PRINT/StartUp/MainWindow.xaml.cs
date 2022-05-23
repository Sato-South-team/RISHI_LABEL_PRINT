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
using System.Windows.Shapes;
using System.Diagnostics;
using System.Data;

namespace RISHI_LABEL_PRINT.StartUp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        #region Varialble and Objects
        BUSINESS_LAYER.LogCreation.LogCreation obj_Log = new BUSINESS_LAYER.LogCreation.LogCreation();

        System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();

        //  BUSINESS_LAYER.Transaction.Transaction obj_Transaction = new BUSINESS_LAYER.Transaction.Transaction();
        #endregion

        #region Methods
        private void ShowDateTime()
        {
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }
               #endregion
        
        #region Events
           
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            txtDatetime.Text = DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss");
          
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                txtuserID.Text ="Application is using by "+  CommonClasses.CommonVariable.UserName;
                ShowDateTime();
                this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
                WindowState = WindowState.Maximized;
                //while (NavigationService.CanGoBack)
                //{
                //    try
                //    {
                //        NavigationService.RemoveBackEntry();
                //    }
                //    catch (Exception ex)
                //    {
                //        break;
                //    }
                //}
            }
            catch (Exception ex)
            {
                obj_Log.CreateLog(ex.Message.ToString(), MethodBase.GetCurrentMethod().ToString(), "MAIN_WINDOW", CommonClasses.CommonVariable.UserID);
                CommonClasses.CommonMethods.MessageBoxShow(ex.Message.ToString(), CommonClasses.CommonVariable.CustomStriing.Error.ToString());
            }
        }

        private void BtnMasters_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                GridSubMenu.Children.RemoveRange(0, 9);

                if (CommonClasses.CommonVariable.Rights == "" || CommonClasses.CommonVariable.Rights == null)
                {
                    CommonClasses.CommonMethods.MessageBoxShow("NO RIGHTS TO ACCESS THE MASTERS", CommonClasses.CommonVariable.CustomStriing.Information.ToString());
                    return;
                }
                for (int J = 0; J < GridSubMenu.RowDefinitions.Count; J++)
                {
                    int ControlsCount = 0;

                    if (ControlsCount != 5)   //how many Controls in Grid
                    {
                        for (int i = 0; i < GridSubMenu.ColumnDefinitions.Count; i++)
                        {
                            if (i == 0 && J == 0)
                            {
                                Grid g = new Grid();
                                Button obj = new Button();
                                obj.Content = "USER MASTER";
                                //obj.Height = 80;
                                //obj.Width = 190;
                                obj.Style = null;
                                obj.Style = (Style)FindResource("SubMenuButton");
                                Grid.SetColumn(obj, i);
                                Grid.SetRow(obj, J);
                                GridSubMenu.Children.Add(obj);
                                ControlsCount = ControlsCount + 1;

                                if (CommonClasses.CommonVariable.Rights.Contains("USER MASTER"))
                                {
                                    obj.Click += UserMaster_Click;
                                }
                                else
                                {
                                    obj.Click -= UserMaster_Click;
                                    obj.ToolTip = "Access Denied";
                                }
                            }
                            if (i == 1 && J == 0)
                            {
                                Grid g = new Grid();
                                Button obj = new Button();
                                obj.Content = "GROUP MASTER";
                                //obj.Height = 80;
                                //obj.Width = 190;
                                obj.Style = (Style)FindResource("SubMenuButton");
                                Grid.SetColumn(obj, i);
                                Grid.SetRow(obj, J);
                                GridSubMenu.Children.Add(obj);
                                ControlsCount = ControlsCount + 1;
                               // obj.Click += GroupMaster_Click;
                                if (CommonClasses.CommonVariable.Rights.Contains("GROUP MASTER"))
                                    obj.Click += GroupMaster_Click;
                                else
                                {
                                    obj.Click -= GroupMaster_Click;
                                    obj.ToolTip = "Access Denied";
                                }
                            }
                            if (i == 2 && J == 0)
                            {
                                Grid g = new Grid();
                                Button obj = new Button();
                                obj.Content = "DEVICE IP MASTER";
                              //  obj.Height = 80;
                               // obj.Width = 190;
                                obj.Style = (Style)FindResource("SubMenuButton");
                                Grid.SetColumn(obj, i);
                                Grid.SetRow(obj, J);
                                GridSubMenu.Children.Add(obj);
                                ControlsCount = ControlsCount + 1;
                                // obj.Click += GroupMaster_Click;
                                if (CommonClasses.CommonVariable.Rights.Contains("DEVICE IP MASTER"))
                                    obj.Click += ProductMaster_Click;
                                else
                                {
                                    obj.Click -= ProductMaster_Click;
                                    obj.ToolTip = "Access Denied";
                                }
                            }
                            //Module Master
                            if (i == 3 && J == 0)
                            {
                                Grid g = new Grid();
                                Button obj = new Button();
                                obj.Content = "LINE MASTER";
                              //  obj.Height = 80;
                               // obj.Width = 190;
                                obj.Style = (Style)FindResource("SubMenuButton");
                                Grid.SetColumn(obj, i);
                                Grid.SetRow(obj, J);
                                GridSubMenu.Children.Add(obj);
                                ControlsCount = ControlsCount + 1;
                                // obj.Click += GroupMaster_Click;
                                if (CommonClasses.CommonVariable.Rights.Contains("LINE MASTER"))
                                    obj.Click += AssetMaster_Click;
                                else
                                {
                                    obj.Click -= AssetMaster_Click;
                                    obj.ToolTip = "Access Denied";
                                }
                            }
                            //ProblemDefeact Master
                            //if (i == 0 && J == 1)
                            //{
                            //    Grid g = new Grid();
                            //    Button obj = new Button();
                            //    obj.Content = "PROCESS MASTER";
                            //   // obj.Height = 80;
                            //   // obj.Width = 270;
                            //    //obj.FontSize = 15;
                            //    obj.Style = (Style)FindResource("SubMenuButton");
                            //    Grid.SetColumn(obj, i);
                            //    Grid.SetRow(obj, J);
                            //    GridSubMenu.Children.Add(obj);
                            //    ControlsCount = ControlsCount + 1;
                            //    // obj.Click += GroupMaster_Click;
                            //    if (CommonClasses.CommonVariable.Rights.Contains("PROCESS MASTER"))
                            //        obj.Click += ProcessMaster_Click;
                            //    else
                            //    {
                            //        obj.Click -= ProcessMaster_Click;
                            //        obj.ToolTip = "Access Denied";
                            //    }
                            //}
                          
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                obj_Log.CreateLog(ex.Message.ToString(), MethodBase.GetCurrentMethod().ToString(), "MAIN_WINDOW", CommonClasses.CommonVariable.UserID);
                CommonClasses.CommonMethods.MessageBoxShow(ex.Message.ToString(), CommonClasses.CommonVariable.CustomStriing.Error.ToString());
            }
        }

       

        private void AssetMaster_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Close();
                Masters.AssetMaster obj_page = new Masters.AssetMaster();
                obj_page.ShowDialog();
               // NavigationService.Navigate(new Masters.AssetMaster());

            }
            catch (Exception ex)
            {
                obj_Log.CreateLog(ex.Message.ToString(), MethodBase.GetCurrentMethod().ToString(), "MAIN_WINDOW", CommonClasses.CommonVariable.UserID);
                CommonClasses.CommonMethods.MessageBoxShow(ex.Message.ToString(), CommonClasses.CommonVariable.CustomStriing.Error.ToString());
            }
        }

        private void ProductMaster_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Close();
                Masters.ProductMaster obj_page = new Masters.ProductMaster();
                obj_page.ShowDialog();
                //NavigationService.Navigate(new Masters.ProductMaster());

            }
            catch (Exception ex)
            {
                obj_Log.CreateLog(ex.Message.ToString(), MethodBase.GetCurrentMethod().ToString(), "MAIN_WINDOW", CommonClasses.CommonVariable.UserID);
                CommonClasses.CommonMethods.MessageBoxShow(ex.Message.ToString(), CommonClasses.CommonVariable.CustomStriing.Error.ToString());
            }
        }

        
        private void GroupMaster_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Close();
                Masters.GroupMaster obj_page = new Masters.GroupMaster();
                obj_page.ShowDialog();
              //  NavigationService.Navigate(new Masters.GroupMaster());

            }
            catch (Exception ex)
            {
                obj_Log.CreateLog(ex.Message.ToString(), MethodBase.GetCurrentMethod().ToString(), "MAIN_WINDOW", CommonClasses.CommonVariable.UserID);
                CommonClasses.CommonMethods.MessageBoxShow(ex.Message.ToString(), CommonClasses.CommonVariable.CustomStriing.Error.ToString());
            }

        }

        private void UserMaster_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Close();
                Masters.UserMaster obj_page = new Masters.UserMaster();
                obj_page.ShowDialog();
               // NavigationService.Navigate(new Masters.UserMaster());
            }
            catch (Exception ex)
            {
                obj_Log.CreateLog(ex.Message.ToString(), MethodBase.GetCurrentMethod().ToString(), "MAIN_WINDOW", CommonClasses.CommonVariable.UserID);
                CommonClasses.CommonMethods.MessageBoxShow(ex.Message.ToString(), CommonClasses.CommonVariable.CustomStriing.Error.ToString());
            }

        }

        private void BtnTransport_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                GridSubMenu.Children.RemoveRange(0, 9);

                if (CommonClasses.CommonVariable.Rights == "" || CommonClasses.CommonVariable.Rights == null)
                {
                    CommonClasses.CommonMethods.MessageBoxShow("NO RIGHTS TO ACCESS THE MASTERS", CommonClasses.CommonVariable.CustomStriing.Information.ToString());
                    return;
                }
                for (int J = 0; J < GridSubMenu.RowDefinitions.Count; J++)
                {
                    int ControlsCount = 0;

                    if (ControlsCount != 5)   //how many Controls in Grid
                    {
                        for (int i = 0; i < GridSubMenu.ColumnDefinitions.Count; i++)
                        {
                            if (i == 0 && J == 0)
                            {
                                Grid g = new Grid();
                                Button obj = new Button();
                                obj.Content = "LABEL PRINTING";
                                // obj.Height = 80;
                                //obj.Width = 190;
                                obj.Style = (Style)FindResource("SubMenuButton");
                                Grid.SetColumn(obj, i);
                                Grid.SetRow(obj, J);
                                GridSubMenu.Children.Add(obj);
                                ControlsCount = ControlsCount + 1;

                                if (CommonClasses.CommonVariable.Rights.Contains("LABEL PRINTING"))
                                {
                                    obj.Click += LABEL_PRINTING_Click;
                                }
                                else
                                {
                                    obj.Click -= LABEL_PRINTING_Click;
                                    obj.ToolTip = "Access Denied";
                                }
                            }
                            if (i == 1 && J == 0)
                            {
                                Grid g = new Grid();
                                Button obj = new Button();
                                obj.Content = "DASH BOARD";
                                //  obj.Height = 80;
                                //obj.Width = 190;
                                obj.Style = (Style)FindResource("SubMenuButton");
                                Grid.SetColumn(obj, i);
                                Grid.SetRow(obj, J);
                                GridSubMenu.Children.Add(obj);
                                ControlsCount = ControlsCount + 1;

                                if (CommonClasses.CommonVariable.Rights.Contains("DASH BOARD"))
                                {
                                    obj.Click += DashBoard_Click;
                                }
                                else
                                {
                                    obj.Click -= DashBoard_Click;
                                    obj.ToolTip = "Access Denied";
                                }
                            }


                        }
                    }
                }
            }
            catch (Exception ex)
            {
                obj_Log.CreateLog(ex.Message.ToString(), MethodBase.GetCurrentMethod().ToString(), "MAIN_WINDOW", CommonClasses.CommonVariable.UserID);
                CommonClasses.CommonMethods.MessageBoxShow(ex.Message.ToString(), CommonClasses.CommonVariable.CustomStriing.Error.ToString());

            }
        }


        private void LABEL_PRINTING_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Close();
                Transactions.Label_Print obj_page = new Transactions.Label_Print();
                obj_page.ShowDialog();
               // NavigationService.Navigate(new Transactions.Label_Print());

            }
            catch (Exception ex)
            {
                obj_Log.CreateLog(ex.Message.ToString(), MethodBase.GetCurrentMethod().ToString(), "MAIN_WINDOW", CommonClasses.CommonVariable.UserID);
                CommonClasses.CommonMethods.MessageBoxShow(ex.Message.ToString(), CommonClasses.CommonVariable.CustomStriing.Error.ToString());
            }
        }
        private void DashBoard_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Close();
                Transactions.DashBoard obj_page = new Transactions.DashBoard();
                obj_page.ShowDialog();
              //  NavigationService.Navigate(new Transactions.DashBoard());

            }
            catch (Exception ex)
            {
                obj_Log.CreateLog(ex.Message.ToString(), MethodBase.GetCurrentMethod().ToString(), "MAIN_WINDOW", CommonClasses.CommonVariable.UserID);
                CommonClasses.CommonMethods.MessageBoxShow(ex.Message.ToString(), CommonClasses.CommonVariable.CustomStriing.Error.ToString());
            }
        }
        private void BtnReport_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int ControlsCount = 0;
                GridSubMenu.Children.RemoveRange(0, 9);

                if (CommonClasses.CommonVariable.Rights == "" || CommonClasses.CommonVariable.Rights == null)
                {
                    CommonClasses.CommonMethods.MessageBoxShow("NO RIGHTS TO ACCESS THE MASTERS", CommonClasses.CommonVariable.CustomStriing.Information.ToString());
                    return;
                }
                for (int J = 0; J < GridSubMenu.RowDefinitions.Count; J++)
                {
                    if (ControlsCount != 3)   //how many Controls in Grid
                    {
                        for (int i = 0; i < GridSubMenu.ColumnDefinitions.Count; i++)
                        {
                            if (i == 0 && J == 0)
                            {
                                Grid g = new Grid();
                                Button obj = new Button();
                                obj.Content = "SUMMARY REPORT";
                                
                                 obj.Style = (Style)FindResource("SubMenuButton");
                                Grid.SetColumn(obj, i);
                                Grid.SetRow(obj, J);
                                GridSubMenu.Children.Add(obj);
                                ControlsCount = ControlsCount + 1;

                                if (CommonClasses.CommonVariable.Rights.Contains("SUMMARY REPORT"))
                                {
                                    obj.Click += TransactionReport_Click;
                                }
                                else
                                {
                                    obj.Click -= TransactionReport_Click;
                                    obj.ToolTip = "Access Denied";
                                }
                            }
                            if (i == 1 && J == 0)
                            {
                                Grid g = new Grid();
                                Button obj = new Button();
                                obj.Content = "DETAILED REPORT";

                                obj.Style = (Style)FindResource("SubMenuButton");
                                Grid.SetColumn(obj, i);
                                Grid.SetRow(obj, J);
                                GridSubMenu.Children.Add(obj);
                                ControlsCount = ControlsCount + 1;

                                if (CommonClasses.CommonVariable.Rights.Contains("DETAILED REPORT"))
                                {
                                    obj.Click += DetailedReport_Click;
                                }
                                else
                                {
                                    obj.Click -= DetailedReport_Click;
                                    obj.ToolTip = "Access Denied";
                                }
                            }
                            if (i == 2 && J == 0)
                            {
                                Grid g = new Grid();
                                Button obj = new Button();
                                obj.Content = "DAILY REPORT";

                                obj.Style = (Style)FindResource("SubMenuButton");
                                Grid.SetColumn(obj, i);
                                Grid.SetRow(obj, J);
                                GridSubMenu.Children.Add(obj);
                                ControlsCount = ControlsCount + 1;

                                if (CommonClasses.CommonVariable.Rights.Contains("DAILY REPORT"))
                                {
                                    obj.Click += DailyReport_Click;
                                }
                                else
                                {
                                    obj.Click -= DailyReport_Click;
                                    obj.ToolTip = "Access Denied";
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                obj_Log.CreateLog(ex.Message.ToString(), MethodBase.GetCurrentMethod().ToString(), "MAIN_WINDOW", CommonClasses.CommonVariable.UserID);
                CommonClasses.CommonMethods.MessageBoxShow(ex.Message.ToString(), CommonClasses.CommonVariable.CustomStriing.Error.ToString());

            }
        }

        private void DetailedReport_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Close();
                Reports.Report.Detailed_Report obj_page = new Reports.Report.Detailed_Report();
                obj_page.ShowDialog();
                //NavigationService.Navigate(new Reports.Report.Detailed_Report());

            }
            catch (Exception ex)
            {
                obj_Log.CreateLog(ex.Message.ToString(), MethodBase.GetCurrentMethod().ToString(), "MAIN_WINDOW", CommonClasses.CommonVariable.UserID);
                CommonClasses.CommonMethods.MessageBoxShow(ex.Message.ToString(), CommonClasses.CommonVariable.CustomStriing.Error.ToString());
            }
        }
        private void DailyReport_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Close();
                Reports.Report.DialyReport obj_page = new Reports.Report.DialyReport();
                obj_page.ShowDialog();
              //  NavigationService.Navigate(new Reports.Report.DialyReport());

            }
            catch (Exception ex)
            {
                obj_Log.CreateLog(ex.Message.ToString(), MethodBase.GetCurrentMethod().ToString(), "MAIN_WINDOW", CommonClasses.CommonVariable.UserID);
                CommonClasses.CommonMethods.MessageBoxShow(ex.Message.ToString(), CommonClasses.CommonVariable.CustomStriing.Error.ToString());
            }
        }

        private void TransactionReport_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Close();
                Reports.Report.TransactionReport obj_page = new Reports.Report.TransactionReport();
                obj_page.ShowDialog();
                //NavigationService.Navigate(new Reports.Report.TransactionReport());

            }
            catch (Exception ex)
            {
                obj_Log.CreateLog(ex.Message.ToString(), MethodBase.GetCurrentMethod().ToString(), "MAIN_WINDOW", CommonClasses.CommonVariable.UserID);
                CommonClasses.CommonMethods.MessageBoxShow(ex.Message.ToString(), CommonClasses.CommonVariable.CustomStriing.Error.ToString());
            }
        }
        #endregion

        private void ImgSmily3_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                this.Close();
                StartUp.Login obj_page = new StartUp.Login();
                obj_page.ShowDialog();
                //while (NavigationService.CanGoBack)
                //{
                //    try
                //    {
                //        NavigationService.RemoveBackEntry();
                //    }
                //    catch (Exception ex)
                //    {
                //        break;
                //    }
                //}
                //NavigationService.Navigate(new StartUp.Login());
                //dispatcherTimer.Stop();

            }
            catch (Exception ex)
            {
                obj_Log.CreateLog(ex.Message.ToString(), MethodBase.GetCurrentMethod().ToString(), "MAIN_WINDOW", CommonClasses.CommonVariable.UserID);
                CommonClasses.CommonMethods.MessageBoxShow(ex.Message.ToString(), CommonClasses.CommonVariable.CustomStriing.Error.ToString());
            }

        }
    }
}
