using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WireSales_Prj
{
    public partial class ExportExcel_Uc : UserControl
    {
        public ExportExcel_Uc()
        {
            InitializeComponent();
        }

        #region Export Excel

        private void buttonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (buttonEdit1.Text == "")
            {
                System.Windows.Forms.MessageBox.Show("نام شيت را وارد كنيد");
                buttonEdit1.Focus();
                return;
            }


            System.Windows.Forms.OpenFileDialog op = new System.Windows.Forms.OpenFileDialog();
            op.Filter = "Excel Files (*.xls;*.xlsx)|*.xls;*.xlsx";
            if (op.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //if ((sender as UILibrary.Windows.Forms.Button).Name == "btnPPMLoadExcel")
                //{
                //    TxtPPMAddrName.Text = op.FileName;
                //    SetExcelToGrid(op.FileName, TxtPPMSheetName.Text);
                //    btnClaimOK.Enabled = false;
                //    btnPPMOK.Enabled = true;
                //}
                //else
                //{
                //TxtClaimAddrName.Text = op.FileName;
                SetExcelToGrid(op.FileName, buttonEdit1.Text);
                //btnClaimOK.Enabled = true;
                //btnPPMOK.Enabled = false;


                //DicAll.Clear();
                //labelEvent.Text = "0 ردیف تکراری          0 ردیف ناقص";
                //ChangeButtonDo = true;
            }
        }

        private void SetExcelToGrid(string PathStr, string SheetName)
        {
            System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection();

            conn.ConnectionString = @"provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + PathStr + @";Extended Properties=Excel 8.0;";

            System.Data.OleDb.OleDbCommand command = new System.Data.OleDb.OleDbCommand
            (
               "SELECT * FROM [" + SheetName + "$]", conn
            );
            System.Data.DataSet ds = new System.Data.DataSet();
            System.Data.OleDb.OleDbDataAdapter adapter = new System.Data.OleDb.OleDbDataAdapter(command);
            try
            {

                adapter.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];

                //gridControl1.RetrieveStructure();

                //gridControl1.CurrentTable.Columns.Add("Status", Janus.Windows.GridEX.ColumnType.Text);
                //gridControl1.CurrentTable.Columns["Status"].BoundMode = Janus.Windows.GridEX.ColumnBoundMode.Unbound;
                //gridControl1.CurrentTable.Columns["Status"].Visible = false;


                //Janus.Windows.GridEX.GridEXColumn GC = new Janus.Windows.GridEX.GridEXColumn("Status");
                //Janus.Windows.GridEX.GridEXFormatCondition GFC1 = new Janus.Windows.GridEX.GridEXFormatCondition();
                //GFC1.Column = GC;
                //GFC1.ConditionOperator = Janus.Windows.GridEX.ConditionOperator.Equal;
                //GFC1.FilterCondition = new Janus.Windows.GridEX.GridEXFilterCondition(GridPPMClaim.RootTable.Columns["Status"], Janus.Windows.GridEX.ConditionOperator.Equal, "0");

                //GFC1.Key = "Duplicate";
                //GFC1.FormatStyle.BackColor = System.Drawing.Color.Salmon;
                //GridPPMClaim.CurrentTable.FormatConditions.Add(GFC1);

                //Janus.Windows.GridEX.GridEXFormatCondition GFC2 = new Janus.Windows.GridEX.GridEXFormatCondition();
                //GFC2.Column = GC;
                //GFC2.ConditionOperator = Janus.Windows.GridEX.ConditionOperator.Equal;
                //GFC2.FilterCondition = new Janus.Windows.GridEX.GridEXFilterCondition(GridPPMClaim.RootTable.Columns["Status"], Janus.Windows.GridEX.ConditionOperator.Equal, "1");

                //GFC2.Key = "DeComplete";
                //GFC2.FormatStyle.BackColor = System.Drawing.Color.LightSkyBlue;
                //GridPPMClaim.CurrentTable.FormatConditions.Add(GFC2);


                //System.Windows.Forms.BindingSource BS = new System.Windows.Forms.BindingSource(ds.Tables[0], "");
                //bindNavigatorPPMClaim.BindingSource = BS;


            }
            catch (System.Exception ex)
            {
                if (ex.ToString().Contains("is not a valid"))
                {
                    System.Windows.Forms.MessageBox.Show("نام شيت اشتباه است");
                    //TxtSheetName.Focus();
                }
                else
                    System.Windows.Forms.MessageBox.Show("اشكال در لود ديتا" + ex.ToString());
            }
        }

        #endregion

        private void buttonX1_Click(object sender, EventArgs e)
        {


            //var deleteConvert = from Cnv in bn.TBL_Converts
            //                    select Cnv;

            //foreach (var detail in deleteConvert)
            //{
            //    bn.TBL_Converts.DeleteOnSubmit(detail);
            //}

            //try
            //{
            //    bn.SubmitChanges();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex);
            //}

            if (Global_Cls.Message_Sara(0, Global_Cls.MessageType.SWarning, true, "درصورت تایید، اطلاعات جدید در این دوره جایگزین اطلاعات قدیمی می شود! آیا مایلید؟"))
            {
                try
                {
                    SqlConnection SqlConn = new SqlConnection(Global_Cls.ConnectionStr);
                    SqlCommand SqlCmd = new SqlCommand();

                    SqlCmd.CommandText = " truncate table [dbo].[TBL_Convert] ";

                    SqlCmd.CommandType = CommandType.Text;
                    SqlCmd.Connection = SqlConn;
                    SqlConn.Open();

                    SqlCmd.ExecuteReader();

                    SqlConn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }



                DataClasses_MainDataContext bn = new DataClasses_MainDataContext();
                try
                {
                    for (int i = 0; i < dataGridView1.RowCount; i++)

                        if (Convert.ToString(dataGridView1.Rows[i].Cells["Name"].Value) != "")
                        {
                            TBL_Convert gf = new TBL_Convert();
                            if (dataGridView1.Rows[i].Cells["Buy"].Value.ToString() != "")
                                gf.Buy = int.Parse(dataGridView1.Rows[i].Cells["Buy"].Value.ToString());
                            gf.Date = dataGridView1.Rows[i].Cells["Date"].Value.ToString();
                            if (dataGridView1.Rows[i].Cells["Sale"].Value.ToString() != "")
                                gf.Sale = int.Parse(dataGridView1.Rows[i].Cells["Sale"].Value.ToString());
                            gf.WName = dataGridView1.Rows[i].Cells["Name"].Value.ToString();
                            bn.TBL_Converts.InsertOnSubmit(gf);
                            bn.SubmitChanges();
                        }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


                try
                {
                    bn.Sp_SetConvert(Global_Cls.ShamsiDateToMiladi(comboBox_Year1.Text, comboBox_Month1.Text, comboBox_day1.Text),
                    Global_Cls.ShamsiDateToMiladi(comboBox_Year2.Text, comboBox_Month2.Text, comboBox_day2.Text));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void ExportExcel_Uc_Load(object sender, EventArgs e)
        {
            string DateStr = Global_Cls.MiladiDateToShamsi(DateTime.Today);
            comboBox_Year1.Text = Convert.ToInt16(DateStr.Substring(0, 4)).ToString();
            comboBox_Month1.Text = Convert.ToInt16(DateStr.Substring(5, 2)).ToString();
            comboBox_day1.Text = Convert.ToInt16(DateStr.Substring(8, 2)).ToString();
            
            comboBox_Year2.Text = Convert.ToInt16(DateStr.Substring(0, 4)).ToString();
            comboBox_Month2.Text = Convert.ToInt16(DateStr.Substring(5, 2)).ToString();
            comboBox_day2.Text = Convert.ToInt16(DateStr.Substring(8, 2)).ToString();
        }

    }
}
