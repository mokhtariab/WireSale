using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WireSales_Prj.Properties;
using DevComponents.DotNetBar;
using System.Data.SqlClient;

namespace WireSales_Prj
{
    public partial class WireSale_UC: UserControl
    {
        public WireSale_UC()
        {
            InitializeComponent();
        }

        private DataClasses_MainDataContext DCMDC = new DataClasses_MainDataContext(Global_Cls.ConnectionStr);
        public int SearchOrNo = 0;
        public string ListWhereSearch = "";
        private bool LoadStatus = false;//ContexMenu
        int dgRowCnt = 0;


        #region Load & UI
        private void ListWire_UC_Load(object sender, EventArgs e)
        {
            SetPermission();
            
            dgRowCnt = dataGridView_ListWireSale.RowCount;
            ShowListWireSale(dgRowCnt - 1);

            
            //ContexMenu
            for (int i = 0; i < dataGridView_ListWireSale.ColumnCount; i++)
                if (dataGridView_ListWireSale.Columns[i].Visible)
                {
                    ToolStripMenuItem TSI = new ToolStripMenuItem();
                    TSI.Alignment = ToolStripItemAlignment.Right;
                    TSI.CheckOnClick = true;
                    TSI.Name = dataGridView_ListWireSale.Columns[i].Name;
                    TSI.Text = dataGridView_ListWireSale.Columns[i].HeaderText;
                    TSI.Checked = true;

                    if (Global_Cls.AllSelectField_WireSales.Count != 0)
                        try
                        {
                            if (!Global_Cls.AllSelectField_WireSales.Contains(TSI.Name))
                            {
                                TSI.Checked = false;
                                dataGridView_ListWireSale.Columns[i].Visible = false;
                            }
                        }
                        catch { }
                    contextMenuStrip_WireSale.Items.Add(TSI);
                }
            LoadStatus = true;
            //ContexMenu

        }


        private void SetPermission()
        {
            string UPer = Global_Cls.MainForm.UserPermission;
            if (UPer != "" && UPer != "admin")
            {
                if (UPer.Contains(button_NewWireSale.Name)) button_NewWireSale.Enabled = false;
                if (UPer.Contains(button_EditWireSale.Name)) button_EditWireSale.Enabled = false;
                if (UPer.Contains(button_DelWireSale.Name)) button_DelWireSale.Enabled = false;
            }
        }

        private void contextMenuStrip_Wire_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                dataGridView_ListWireSale.Columns[e.ClickedItem.Name].Visible = (e.ClickedItem as ToolStripMenuItem).CheckState == CheckState.Unchecked;
            }
            catch { }
        }

        private void dataGridView_ListWire_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView_ListWireSale.RowCount != 0)
                button_EditWire_Click(this, null);
        }

        private void WireSale_UC_Layout(object sender, LayoutEventArgs e)
        {
            if (LoadStatus)
            {
                Global_Cls.AllSelectField_WireSales.Clear();
                for (int i = 0; i < contextMenuStrip_WireSale.Items.Count; i++)
                    if ((contextMenuStrip_WireSale.Items[i] as ToolStripMenuItem).Checked)
                        Global_Cls.AllSelectField_WireSales.Add((contextMenuStrip_WireSale.Items[i] as ToolStripMenuItem).Name);
            }
        }

        
        #endregion



        #region Show List
        private void ShowListWireSale(int RowFocus)
        {
            if (SearchOrNo==1)
            {
                var SUS = from prd in DCMDC.Vw_WireSaleLists
                          select prd;

                if (checkBox_WCode.Checked)
                    SUS = SUS.Where(m => m.WireCode >= (int)((textBox_WCode1.Text == "") ? 0 : (int.Parse(textBox_WCode1.Text))) && m.WireCode <= (int)((textBox_WCode2.Text == "") ? 0 : (int.Parse(textBox_WCode2.Text))));
                if (checkBox_WName.Checked)
                    SUS = SUS.Where(m => m.WireName.Contains(Global_Cls.ChangeK(textBox_WName.Text)));
                if (checkBox_Amount.Checked)
                    SUS = SUS.Where(m => m.SaleAmount >= (double)((textBox_Amount1.Text == "") ? 0 : (double.Parse(textBox_Amount1.Text))) && m.SaleAmount <= (double)((textBox_Amount2.Text == "") ? 0 : (double.Parse(textBox_Amount2.Text))));

                dataGridView_ListWireSale.DataSource = SUS;
            }
            else if (SearchOrNo ==0)
            {
                var SUN = from prd in DCMDC.Vw_WireSaleLists
                          select prd;

                dataGridView_ListWireSale.DataSource = SUN;
            }
            else if (SearchOrNo == -1)
            {
                try
                {
                    string StrConn = Global_Cls.ConnectionStr;

                    SqlConnection SqConn = new SqlConnection(StrConn);
                    SqConn.Open();

                    SqlCommand SqCmd = new SqlCommand();
                    SqCmd.Connection = SqConn;

                    SqCmd.CommandText = "SELECT  * From Vw_WireSaleList "
                            + "Where (1=1) "
                            + ListWhereSearch;
                    DataTable retValue = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(SqCmd);
                    da.Fill(retValue);
                    dataGridView_ListWireSale.DataSource = retValue;
                    SqConn.Close();
                }
                catch { }
            }

            double SumWireAmount = 0;
            for (int i = 0; i < dataGridView_ListWireSale.RowCount; i++)
                SumWireAmount += int.Parse(dataGridView_ListWireSale.Rows[i].Cells["SaleAmount"].Value.ToString());

            labelSum.Text = SumWireAmount.ToString();

            try
            {
                dataGridView_ListWireSale.CurrentCell = dataGridView_ListWireSale.Rows[RowFocus].Cells[dataGridView_ListWireSale.CurrentCell.ColumnIndex];
            }
            catch
            {
                try { dataGridView_ListWireSale.CurrentCell = dataGridView_ListWireSale.Rows[0].Cells[0]; }
                catch { }
            }

        }
        #endregion


        
        #region Search

        TextBox tx = new TextBox();
        

        private void textBox_WAmu_KeyPress(object sender, KeyPressEventArgs e)
        {
            tx = (TextBox)sender;
            if ((tx.Text.Contains(".") && e.KeyChar == '.')
                || (!System.Char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Delete && e.KeyChar != (char)Keys.Back && e.KeyChar != '.'))
            { e.KeyChar = '\0'; return; }
        }

        private void textBox_WCode1_KeyPress(object sender, KeyPressEventArgs e)
        {
            tx = (TextBox)sender;
            if (e.KeyChar == '.' || (!System.Char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Delete && e.KeyChar != (char)Keys.Back))
            { e.KeyChar = '\0'; return; }
        }

        private void button_Search_Click(object sender, EventArgs e)
        {
            SearchOrNo = 1;
            ShowListWireSale(0);
            try
            {
                dataGridView_ListWireSale.CurrentCell = dataGridView_ListWireSale.Rows[dataGridView_ListWireSale.RowCount - 1].Cells[dataGridView_ListWireSale.CurrentCell.ColumnIndex];
            }
            catch
            { }

        }

        private void dataGridView_ListWire_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                SearchOrNo = 0;
                ShowListWireSale(dgRowCnt - 1);

                checkBox_WName.Checked = false;
                checkBox_WCode.Checked = false;
                checkBox_Amount.Checked = false; 
                
                textBox_WCode1.Text = "0";  textBox_WCode2.Text = "0";
                textBox_Amount1.Text = "0"; textBox_Amount2.Text = "0";

                exPanel_Search.Expanded = false;
            }
        }

        #endregion




        #region All Buttons

        private void button_NewWire_Click(object sender, EventArgs e)
        {
            NEWireSale_frm NeWire = new NEWireSale_frm();
            NeWire.NewOrEditWireSale = 1;
            NeWire.SetData_NEWireSale();
            NeWire.ShowDialog();
            ShowListWireSale(dataGridView_ListWireSale.RowCount - 1);
        }

        private void button_EditWire_Click(object sender, EventArgs e)
        {
            if (dataGridView_ListWireSale.RowCount == 0) return;
            int indx = dataGridView_ListWireSale.CurrentRow.Index;
            NEWireSale_frm NeWire = new NEWireSale_frm();
            NeWire.NewOrEditWireSale = 2;
            NeWire.WrID = Convert.ToInt32(dataGridView_ListWireSale.CurrentRow.Cells["id"].Value);
            NeWire.SetData_NEWireSale();
            NeWire.ShowDialog();
            ShowListWireSale(indx);
        }


        private void button_DelWire_Click(object sender, EventArgs e)
        {

            try
            {
                if (dataGridView_ListWireSale.RowCount != 0)
                {
                    int SelCount = dataGridView_ListWireSale.SelectedRows.Count;
                    if (SelCount == 1)
                    {
                        if (!Global_Cls.Message_Sara(0, Global_Cls.MessageType.SConfirmation, true, " آیا به حذف این فروش کالا )سیم( اطمینان دارید؟ ")) return;
                        int RFocus = dataGridView_ListWireSale.CurrentRow.Index;
                        TBL_WireSale tw = DCMDC.TBL_WireSales.First(tp => tp.id.Equals(Convert.ToInt32(dataGridView_ListWireSale.CurrentRow.Cells["id"].Value)));
                        DCMDC.TBL_WireSales.DeleteOnSubmit(tw);
                        DCMDC.SubmitChanges();
                        ShowListWireSale(RFocus - 1);
                    }
                    else
                    {
                        if (!Global_Cls.Message_Sara(0, Global_Cls.MessageType.SConfirmation, true, " آیا مایلید این " + SelCount.ToString() + " فروش کالا )سیم( از سیستم حذف شوند؟ ")) return;
                        while (SelCount > 0)
                        {
                            SelCount--;
                            TBL_WireSale thsf = DCMDC.TBL_WireSales.First(tp => tp.id.Equals(Convert.ToInt32(dataGridView_ListWireSale.SelectedRows[SelCount].Cells["id"].Value)));
                            DCMDC.TBL_WireSales.DeleteOnSubmit(thsf);
                            DCMDC.SubmitChanges();
                        }
                        ShowListWireSale(0);
                    }

                }
            }
            catch (Exception ex)
            {
                Global_Cls.Message_Sara(0, Global_Cls.MessageType.SError, false, "امکان حذف این کالا به دلیل استفاده در سیستم وجود ندارد");
            }

        }

        #endregion

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            gridControl1.DataSource = dataGridView_ListWireSale.DataSource;
            gridControl1.ShowPreview();
        }

    }
}
