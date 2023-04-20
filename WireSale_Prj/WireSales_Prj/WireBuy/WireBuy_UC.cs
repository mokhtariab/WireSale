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
    public partial class WireBuy_UC: UserControl
    {
        public WireBuy_UC()
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

            dgRowCnt = dataGridView_ListWireBuy.RowCount;
            ShowListWireBuy(dgRowCnt - 1);

            
            //ContexMenu
            for (int i = 0; i < dataGridView_ListWireBuy.ColumnCount; i++)
                if (dataGridView_ListWireBuy.Columns[i].Visible)
                {
                    ToolStripMenuItem TSI = new ToolStripMenuItem();
                    TSI.Alignment = ToolStripItemAlignment.Right;
                    TSI.CheckOnClick = true;
                    TSI.Name = dataGridView_ListWireBuy.Columns[i].Name;
                    TSI.Text = dataGridView_ListWireBuy.Columns[i].HeaderText;
                    TSI.Checked = true;

                    if (Global_Cls.AllSelectField_WireBuy.Count != 0)
                        try
                        {
                            if (!Global_Cls.AllSelectField_WireBuy.Contains(TSI.Name))
                            {
                                TSI.Checked = false;
                                dataGridView_ListWireBuy.Columns[i].Visible = false;
                            }
                        }
                        catch { }
                    contextMenuStrip_WireBuy.Items.Add(TSI);
                }
            LoadStatus = true;
            //ContexMenu

        }

        private void SetPermission()
        {
            string UPer = Global_Cls.MainForm.UserPermission;
            if (UPer != "" && UPer != "admin")
            {
                if (UPer.Contains(button_NewWireBuy.Name)) button_NewWireBuy.Enabled = false;
                if (UPer.Contains(button_EditWireBuy.Name)) button_EditWireBuy.Enabled = false;
                if (UPer.Contains(button_DelWireBuy.Name)) button_DelWireBuy.Enabled = false;
            }
        }

        private void contextMenuStrip_Wire_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                dataGridView_ListWireBuy.Columns[e.ClickedItem.Name].Visible = (e.ClickedItem as ToolStripMenuItem).CheckState == CheckState.Unchecked;
            }
            catch { }
        }

        private void dataGridView_ListWire_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView_ListWireBuy.RowCount != 0)
                button_EditWire_Click(this, null);
        }

        private void WireBuy_UC_Layout(object sender, LayoutEventArgs e)
        {
            if (LoadStatus)
            {
                Global_Cls.AllSelectField_WireBuy.Clear();
                for (int i = 0; i < contextMenuStrip_WireBuy.Items.Count; i++)
                    if ((contextMenuStrip_WireBuy.Items[i] as ToolStripMenuItem).Checked)
                        Global_Cls.AllSelectField_WireBuy.Add((contextMenuStrip_WireBuy.Items[i] as ToolStripMenuItem).Name);
            }

        }

        #endregion



        #region Show List
        private void ShowListWireBuy(int RowFocus)
        {
            if (SearchOrNo==1)
            {
                var SUS = from prd in DCMDC.Vw_WireBuyLists
                          select prd;

                if (checkBox_WCode.Checked)
                    SUS = SUS.Where(m => m.WireCode >= (int)((textBox_WCode1.Text == "") ? 0 : (int.Parse(textBox_WCode1.Text))) && m.WireCode <= (int)((textBox_WCode2.Text == "") ? 0 : (int.Parse(textBox_WCode2.Text))));
                if (checkBox_WName.Checked)
                    SUS = SUS.Where(m => m.WireName.Contains(Global_Cls.ChangeK(textBox_WName.Text)));
                if (checkBox_Amount.Checked)
                    SUS = SUS.Where(m => m.BuyAmount >= (double)((textBox_Amount1.Text == "") ? 0 : (double.Parse(textBox_Amount1.Text))) && m.BuyAmount <= (double)((textBox_Amount2.Text == "") ? 0 : (double.Parse(textBox_Amount2.Text))));

                dataGridView_ListWireBuy.DataSource = SUS;
            }
            else if (SearchOrNo ==0)
            {                
                var SUN = from prd in DCMDC.Vw_WireBuyLists
                          select prd;

                dataGridView_ListWireBuy.DataSource = SUN;
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

                    SqCmd.CommandText = "SELECT  * From Vw_WireBuyList "
                            + "Where (1=1) "
                            + ListWhereSearch;
                    DataTable retValue = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(SqCmd);
                    da.Fill(retValue);
                    dataGridView_ListWireBuy.DataSource = retValue;
                    SqConn.Close();
                }
                catch { }
            }

            double SumWireAmount = 0;
            for (int i = 0; i < dataGridView_ListWireBuy.RowCount; i++)
                SumWireAmount += int.Parse(dataGridView_ListWireBuy.Rows[i].Cells["BuyAmount"].Value.ToString());

            labelSum.Text = SumWireAmount.ToString();

            try
            {
                dataGridView_ListWireBuy.CurrentCell = dataGridView_ListWireBuy.Rows[RowFocus].Cells[dataGridView_ListWireBuy.CurrentCell.ColumnIndex];
            }
            catch
            {
                try { dataGridView_ListWireBuy.CurrentCell = dataGridView_ListWireBuy.Rows[0].Cells[0]; }
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
            ShowListWireBuy(0);
            try
            {
                dataGridView_ListWireBuy.CurrentCell = dataGridView_ListWireBuy.Rows[dataGridView_ListWireBuy.RowCount - 1].Cells[dataGridView_ListWireBuy.CurrentCell.ColumnIndex];
            }
            catch
            { }

        }

        private void dataGridView_ListWire_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                SearchOrNo = 0;
                ShowListWireBuy(dgRowCnt - 1);

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
            NEWireBuy_frm NeWire = new NEWireBuy_frm();
            NeWire.NewOrEditWireBuy = 1;
            NeWire.SetData_NEWireBuy();
            NeWire.ShowDialog();
            ShowListWireBuy(dataGridView_ListWireBuy.RowCount-1);
        }

        private void button_EditWire_Click(object sender, EventArgs e)
        {
            if (dataGridView_ListWireBuy.RowCount == 0) return;
            int indx = dataGridView_ListWireBuy.CurrentRow.Index;
            NEWireBuy_frm NeWire = new NEWireBuy_frm();
            NeWire.NewOrEditWireBuy = 2;
            NeWire.WrID = Convert.ToInt32(dataGridView_ListWireBuy.CurrentRow.Cells["id"].Value);
            NeWire.SetData_NEWireBuy();
            NeWire.ShowDialog();
            ShowListWireBuy(indx);
        }


        private void button_DelWire_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (dataGridView_ListWireBuy.RowCount != 0)
                {
                    int SelCount = dataGridView_ListWireBuy.SelectedRows.Count;
                    if (SelCount == 1)
                    {
                        if (!Global_Cls.Message_Sara(0, Global_Cls.MessageType.SConfirmation, true, " آیا به حذف این خرید کالا )سیم( اطمینان دارید؟ ")) return;
                        int RFocus = dataGridView_ListWireBuy.CurrentRow.Index;
                        TBL_WireBuy tw = DCMDC.TBL_WireBuys.First(tp => tp.id.Equals(Convert.ToInt32(dataGridView_ListWireBuy.CurrentRow.Cells["id"].Value)));
                        DCMDC.TBL_WireBuys.DeleteOnSubmit(tw);
                        DCMDC.SubmitChanges();
                        ShowListWireBuy(RFocus - 1);
                    }
                    else
                    {
                        if (!Global_Cls.Message_Sara(0, Global_Cls.MessageType.SConfirmation, true, " آیا مایلید این " + SelCount.ToString() + " خرید کالا )سیم( از سیستم حذف شوند؟ ")) return;
                        while (SelCount > 0)
                        {
                            SelCount--;
                            TBL_WireBuy thsf = DCMDC.TBL_WireBuys.First(tp => tp.id.Equals(Convert.ToInt32(dataGridView_ListWireBuy.SelectedRows[SelCount].Cells["id"].Value)));
                            DCMDC.TBL_WireBuys.DeleteOnSubmit(thsf);
                            DCMDC.SubmitChanges();
                        }
                        ShowListWireBuy(0);
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
            gridControl1.DataSource = dataGridView_ListWireBuy.DataSource;
            gridControl1.ShowPreview();
        }

        

        
    }
}
