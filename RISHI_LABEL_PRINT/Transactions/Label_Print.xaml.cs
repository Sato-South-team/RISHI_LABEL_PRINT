using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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

namespace RISHI_LABEL_PRINT.Transactions
{
    /// <summary>
    /// Interaction logic for Label_Print.xaml
    /// </summary>
    public partial class Label_Print : Window
    {
        public Label_Print()
        {
            InitializeComponent();
        }
        #region Variable and Objects
        BUSINESS_LAYER.LogCreation.LogCreation obj_Log = new BUSINESS_LAYER.LogCreation.LogCreation();
        BUSINESS_LAYER.Masters.Masters obj_Mast = new BUSINESS_LAYER.Masters.Masters();

        System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
        BUSINESS_LAYER.Transaction.Transaction obj_Tran = new BUSINESS_LAYER.Transaction.Transaction();
        int RefNo = 0;
        string serialNo = "";
        string Addbarcode="";
        DataTable dt_Workorder = null;
        string t_Refcntd = "";
        string t_Refcntu = "";
        string WorkCenter = "";
        string Unit = "",PrinterName,PrnData;
        int Qty = 0;
        #endregion



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
                Clear();
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
            if (Keyboard.IsKeyDown(Key.LeftAlt) && Keyboard.IsKeyDown(Key.P) || Keyboard.IsKeyDown(Key.RightAlt) && Keyboard.IsKeyDown(Key.P))
            {
                btnUpdate_Click(sender, e);
            }
            if (Keyboard.IsKeyDown(Key.LeftAlt) && Keyboard.IsKeyDown(Key.C) || Keyboard.IsKeyDown(Key.RightAlt) && Keyboard.IsKeyDown(Key.C))
            {
                btnClear_Click(sender, e);
            }
            if (Keyboard.IsKeyDown(Key.LeftAlt) && Keyboard.IsKeyDown(Key.B) || Keyboard.IsKeyDown(Key.RightAlt) && Keyboard.IsKeyDown(Key.B) || Keyboard.IsKeyDown(Key.Escape) && Keyboard.IsKeyDown(Key.Escape))
            {
                btnExit_Click(sender, e);
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
            if (cmbLine.SelectedIndex == -1)
            {
                CommonClasses.CommonMethods.MessageBoxShow("PLEASE SEELCT LINE NO", CommonClasses.CommonVariable.CustomStriing.Information.ToString());
                cmbLine.Focus();
                return false;
            }
            //if (txtArticleno.Text == "")
            //{
            //    CommonClasses.CommonMethods.MessageBoxShow("PLEASE CHECK ARTICLE NO EMPTY", CommonClasses.CommonVariable.CustomStriing.Information.ToString());
            //    txtArticleno.Focus();
            //    return false;
            //}

            //if (txtlineno.Text == "")
            //{
            //    CommonClasses.CommonMethods.MessageBoxShow("PLEASE CHECK LINENO EMPTY", CommonClasses.CommonVariable.CustomStriing.Information.ToString());
            //    txtlineno.Focus();
            //    return false;
            //}
            if (txtqty.Text == "")
            {
                CommonClasses.CommonMethods.MessageBoxShow("PLEASE CHECK QTY", CommonClasses.CommonVariable.CustomStriing.Information.ToString());
                txtqty.Focus();
                return false;
            }


            return true;
        }

        private void Transaction(string Type)
        {
            if (Type == "Save")
            {

                ENTITY_LAYER.Masters.Masters.Workorderno = cmbWono.Text;
                ENTITY_LAYER.Masters.Masters.Pono = txtPoNo.Text;
                ENTITY_LAYER.Masters.Masters.ArticleNo = txtArticleno.Text;
                ENTITY_LAYER.Masters.Masters.Lineno = cmbLine.Text;
                ENTITY_LAYER.Masters.Masters.Qty = Qty.ToString();
                ENTITY_LAYER.Masters.Masters.status = "0";
                ENTITY_LAYER.Masters.Masters.Serialno = serialNo;
                ENTITY_LAYER.Masters.Masters.RefNo = RefNo;
                ENTITY_LAYER.Masters.Masters.Barcode = Addbarcode;
                ENTITY_LAYER.Masters.Masters.T_Refcntd = t_Refcntd;
                ENTITY_LAYER.Masters.Masters.T_Refcntu = t_Refcntu;
                ENTITY_LAYER.Masters.Masters.WorkCenter = WorkCenter;
                ENTITY_LAYER.Masters.Masters.Unit = Unit;
                ENTITY_LAYER.Masters.Masters.Type = Type;
                CommonClasses.CommonVariable.Result = obj_Tran.BL_LabelPrintingTransaction();
                if (CommonClasses.CommonVariable.Result == "Saved")
                {
                    // CommonClasses.CommonMethods.MessageBoxShow(CommonClasses.CommonVariable.DataSaved, CommonClasses.CommonVariable.CustomStriing.Successfull.ToString());
                    //Clear();
                }
                else if (CommonClasses.CommonVariable.Result == "Updated")
                {
                    CommonClasses.CommonMethods.MessageBoxShow(CommonClasses.CommonVariable.DataUpdated, CommonClasses.CommonVariable.CustomStriing.Successfull.ToString());
                    Clear();
                }
                else if (CommonClasses.CommonVariable.Result == "Duplicate")
                    CommonClasses.CommonMethods.MessageBoxShow(CommonClasses.CommonVariable.Duplicate, CommonClasses.CommonVariable.CustomStriing.Information.ToString());
                else if (CommonClasses.CommonVariable.Result != "Deleted")
                    CommonClasses.CommonMethods.MessageBoxShow(CommonClasses.CommonVariable.Result, CommonClasses.CommonVariable.CustomStriing.Information.ToString());

            }
            if (Type == "WorkOrderDetails")
            {
                DataTable dt = obj_Tran.BL_LabelPrintingDetails(cmbWono.SelectedValue.ToString());
                if (dt.Rows.Count > 0)
                {
                    txtPoNo.Text = dt.Rows[0]["POno"].ToString().Trim();
                    txtArticleno.Text = dt.Rows[0]["ArticaleNo"].ToString().Trim();
                    txtqty.Text = dt.Rows[0]["Qty"].ToString().Trim();
                    Qty = Convert.ToInt32(dt.Rows[0]["Qty"].ToString());
                    t_Refcntd = dt.Rows[0]["t_Refcntd"].ToString().Trim();
                    t_Refcntu = dt.Rows[0]["t_Refcntu"].ToString().Trim();
                    Unit = dt.Rows[0]["Unit"].ToString().Trim();
                    WorkCenter = dt.Rows[0]["WorkCenter"].ToString().Trim();
                }
                else
                {
                    txtPoNo.Text = "";
                    txtArticleno.Text = "";
                    txtqty.Text = "0";
                    Qty = 0;
                    t_Refcntd = "";
                    t_Refcntu = "";
                    Unit = "";
                    WorkCenter = "";
                }

            }
            if (Type == "WorkOrderno")
            {
                dt_Workorder = obj_Tran.BL_LabelPrintingDetails("");
                DataView dv = new DataView(dt_Workorder);
                CommonClasses.CommonMethods.FillComboBox(cmbWono, dv.ToTable(true, "WorkOrderNo") , "WorkOrderNo", "WorkOrderNo");
            }

            if (Type == "GetLineNo")
            {
                DataView dv = new DataView(dt_Workorder);
                dv.RowFilter= "WorkOrderNo='"+cmbWono.SelectedValue.ToString()+"'";
                CommonClasses.CommonMethods.FillComboBox(cmbLine, dv.ToTable(true, "LineNo"), "LineNo", "LineNo");
            }
            if (Type == "GetLastSerialNo")
            {
                ENTITY_LAYER.Masters.Masters.Workorderno = cmbWono.SelectedValue.ToString();
                ENTITY_LAYER.Masters.Masters.Type = Type;
                DataSet dt = obj_Tran.BL_LabelPrintingDetails();
                serialNo = dt.Tables[0].Rows[0][0].ToString();
                PrnData = dt.Tables[1].Rows[0]["Prndata"].ToString();
                PrinterName = dt.Tables[1].Rows[0]["PrinterName"].ToString();
            }

        }

        private void Clear()
        {
            cmbWono.Text = "";
            cmbLine.Text = "";
            txtArticleno.Text = "";
            txtPoNo.Text = "";
            txtqty.Text = "";
            t_Refcntu = "";
            t_Refcntd = "";
            Unit = "";
            WorkCenter = "";
            cmbWono.Focus();
            RefNo = 0;
        }
      
      
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ControlValidation())
                {
                    int NOOflabel = Convert.ToInt32(txtqty.Text);
                    //if (NOOflabel > Qty)
                    //{
                    //    txtqty.Focus();
                    //    CommonClasses.CommonMethods.MessageBoxShow("ENTERED QTY IS MORE THAN THE ACTUAL QTY", CommonClasses.CommonVariable.CustomStriing.Information.ToString());
                    //    return;
                    //}
                    Transaction("GetLastSerialNo");

                    //if((Convert.ToInt32(serialNo)+ NOOflabel)>Qty)
                    //{
                    //    int Available= Qty-Convert.ToInt32(serialNo)  ;
                    //    CommonClasses.CommonMethods.MessageBoxShow("AVAILABLE QTY IS "+Available.ToString()+", PLEASE ENTER VALID DATA,", CommonClasses.CommonVariable.CustomStriing.Information.ToString());
                    //    txtqty.Focus();
                    //    return;
                    //}

                    for (int i1 = 0; i1 < NOOflabel; i1++)
                    {
                        serialNo = (Convert.ToInt32(serialNo) + 1).ToString().PadLeft(4, '0');
                        Addbarcode = ""; ;
                        Addbarcode = serialNo+"|"+cmbWono.SelectedValue.ToString() + "|" + txtPoNo.Text + "|" + cmbLine.Text+ "|" +txtArticleno.Text ;
                        PrintLable(cmbWono.SelectedValue.ToString(), txtPoNo.Text, txtArticleno.Text, cmbLine.SelectedValue.ToString(), txtqty.Text, serialNo, Addbarcode);
                        Transaction("Save");
                    }
                }
            }
            catch (Exception ex)
            {
                obj_Log.CreateLog(ex.Message.ToString(), MethodBase.GetCurrentMethod().ToString(), "DASHBOARD", CommonClasses.CommonVariable.UserID);
                CommonClasses.CommonMethods.MessageBoxShow(ex.Message.ToString(), CommonClasses.CommonVariable.CustomStriing.Error.ToString());
            }
        }

        private void PrintLable(string Wono, string Pono, string article, string line, string Qty, string serialno,string Barcode)
        {
            string sbpl = null;
            sbpl = PrnData;
            sbpl = sbpl.Replace("{WONO}", Wono);
            sbpl = sbpl.Replace("{SLNO}", serialno);
            sbpl = sbpl.Replace("{Len}", Addbarcode.Length.ToString());
            sbpl = sbpl.Replace("{BARCODE}", Barcode);
            SATOPrinterAPI.Driver Satoprint = new SATOPrinterAPI.Driver();
            Satoprint.SendRawData(PrinterName, sbpl);
        }

      
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Clear();
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

       
        private void txtInvoiceqty_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            try
            {
                CommonClasses.CommonMethods.NumericValue(e);
            }
            catch (Exception ex)
            {
                obj_Log.CreateLog(ex.Message.ToString(), MethodBase.GetCurrentMethod().ToString(), "DASHBOARD", CommonClasses.CommonVariable.UserID);
                CommonClasses.CommonMethods.MessageBoxShow(ex.Message.ToString(), CommonClasses.CommonVariable.CustomStriing.Error.ToString());
            }
        }

        private void CmbWono_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (cmbWono.SelectedValue != null)
                {
                    Transaction("GetLineNo");
                    Transaction("WorkOrderDetails");
                }
                else
                {
                    CommonClasses.CommonMethods.UNFill_ComboBox(cmbLine);
                    txtPoNo.Text = "";
                    txtArticleno.Text = "";
                    txtqty.Text = "";

                }
            }
            catch (Exception ex)
            {
                obj_Log.CreateLog(ex.Message.ToString(), MethodBase.GetCurrentMethod().ToString(), "DASHBOARD", CommonClasses.CommonVariable.UserID);
                CommonClasses.CommonMethods.MessageBoxShow(ex.Message.ToString(), CommonClasses.CommonVariable.CustomStriing.Error.ToString());
            }
        }

       
    }
}
