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
    public partial class WireAction_UC: UserControl
    {
        public WireAction_UC()
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
            

            dgRowCnt = dataGridView_ListWAction.RowCount;
            ShowListWire(dgRowCnt - 1);

            
            //ContexMenu
            for (int i = 0; i < dataGridView_ListWAction.ColumnCount; i++)
                if (dataGridView_ListWAction.Columns[i].Visible)
                {
                    ToolStripMenuItem TSI = new ToolStripMenuItem();
                    TSI.Alignment = ToolStripItemAlignment.Right;
                    TSI.CheckOnClick = true;
                    TSI.Name = dataGridView_ListWAction.Columns[i].Name;
                    TSI.Text = dataGridView_ListWAction.Columns[i].HeaderText;
                    TSI.Checked = true;

                    if (Global_Cls.AllSelectField_WAction.Count != 0)
                        try
                        {
                            if (!Global_Cls.AllSelectField_WAction.Contains(TSI.Name))
                            {
                                TSI.Checked = false;
                                dataGridView_ListWAction.Columns[i].Visible = false;
                            }
                        }
                        catch { }
                    contextMenuStrip_Wire.Items.Add(TSI);
                }
            LoadStatus = true;
            //ContexMenu

        }


        private void SetPermission()
        {
            string UPer = Global_Cls.MainForm.UserPermission;
            if (UPer != "" && UPer != "admin")
            {
                //if (UPer.Contains(button_NewWire.Name)) button_NewWire.Enabled = false;
                //if (UPer.Contains(button_EditWire.Name)) button_EditWire.Enabled = false;
                //if (UPer.Contains(button_DelWire.Name)) button_DelWire.Enabled = false;
            }
        }

        private void contextMenuStrip_Wire_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                dataGridView_ListWAction.Columns[e.ClickedItem.Name].Visible = (e.ClickedItem as ToolStripMenuItem).CheckState == CheckState.Unchecked;
            }
            catch { }
        }

        private void dataGridView_ListWire_DoubleClick(object sender, EventArgs e)
        {
            //if (dataGridView_ListWAction.RowCount != 0)
            //    button_EditWire_Click(this, null);
        }

        private void WireAction_UC_Layout(object sender, LayoutEventArgs e)
        {
            if (LoadStatus)
            {
                Global_Cls.AllSelectField_WAction.Clear();
                for (int i = 0; i < contextMenuStrip_Wire.Items.Count; i++)
                    if ((contextMenuStrip_Wire.Items[i] as ToolStripMenuItem).Checked)
                        Global_Cls.AllSelectField_WAction.Add((contextMenuStrip_Wire.Items[i] as ToolStripMenuItem).Name);
            }

        }


        #endregion



        #region Show List
        private void ShowListWire(int RowFocus)
        {
            if (SearchOrNo==1)
            {
                var SUS = from prd in DCMDC.Vw_ActionBuySales
                          select new
                          {
                              prd.idbuy,
                              prd.idsale,
                              prd.WireCode,
                              prd.WireName,
                              ActionDate = Global_Cls.MiladiDateToShamsi(prd.ActionDate.Value),
                              prd.Buy,
                              prd.Sale,
                              prd.Inventory
                          };

                if (checkBox_WCode.Checked)
                    SUS = SUS.Where(m => m.WireCode >= (int)((textBox_WCode1.Text == "") ? 0 : (int.Parse(textBox_WCode1.Text))) && m.WireCode <= (int)((textBox_WCode2.Text == "") ? 0 : (int.Parse(textBox_WCode2.Text))));
                if (checkBox_WName.Checked)
                    SUS = SUS.Where(m => m.WireName.Contains(Global_Cls.ChangeK(textBox_WName.Text)));
                if (checkBox_Amount.Checked)
                    SUS = SUS.Where(m => m.Inventory >= (double)((textBox_Amount1.Text == "") ? 0 : (double.Parse(textBox_Amount1.Text))) && m.Inventory <= (double)((textBox_Amount2.Text == "") ? 0 : (double.Parse(textBox_Amount2.Text))));

                dataGridView_ListWAction.DataSource = SUS;
            }
            else if (SearchOrNo ==0)
            {
                var SUS = from prd in DCMDC.Vw_ActionBuySales
                          select new
                          {
                              prd.idbuy,
                              prd.idsale,
                              prd.WireCode,
                              prd.WireName,
                              ActionDate = Global_Cls.MiladiDateToShamsi(prd.ActionDate.Value),
                              prd.Buy,
                              prd.Sale,
                              prd.Inventory
                          };

                dataGridView_ListWAction.DataSource = SUS;
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

                    SqCmd.CommandText = "SELECT * From Vw_ActionWireList "
                            + "Where (1=1) "
                            + ListWhereSearch;
                    DataTable retValue = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(SqCmd);
                    da.Fill(retValue);
                    dataGridView_ListWAction.DataSource = retValue;
                    SqConn.Close();
                }
                catch { }
            }

            double SumWireAmount = 0, SumWireSale = 0, SumWireBuy = 0;
            for (int i = 0; i < dataGridView_ListWAction.RowCount; i++)
            {
                SumWireAmount += int.Parse(dataGridView_ListWAction.Rows[i].Cells["Inventory"].Value.ToString());
                SumWireSale += int.Parse(dataGridView_ListWAction.Rows[i].Cells["Sale"].Value.ToString());
                SumWireBuy += int.Parse(dataGridView_ListWAction.Rows[i].Cells["Buy"].Value.ToString());
            }
            labelSum.Text = SumWireAmount.ToString();
            labelBuy.Text = SumWireBuy.ToString();
            labelSale.Text = SumWireSale.ToString();

            try
            {
                dataGridView_ListWAction.CurrentCell = dataGridView_ListWAction.Rows[RowFocus].Cells[dataGridView_ListWAction.CurrentCell.ColumnIndex];
            }
            catch
            {
                try { dataGridView_ListWAction.CurrentCell = dataGridView_ListWAction.Rows[0].Cells[0]; }
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
            if (e.KeyChar == '.' || (!System.Char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Delete && e.KeyChar != (char)Keys.Back ))
            { e.KeyChar = '\0'; return; }
        }


        private void button_Search_Click(object sender, EventArgs e)
        {
            SearchOrNo = 1;
            ShowListWire(0);
            try
            {
                dataGridView_ListWAction.CurrentCell = dataGridView_ListWAction.Rows[dataGridView_ListWAction.RowCount - 1].Cells[dataGridView_ListWAction.CurrentCell.ColumnIndex];
            }
            catch
            { }

        }

        private void dataGridView_ListWire_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                SearchOrNo = 0;
                ShowListWire(dgRowCnt - 1);

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
        }

        private void button_EditWire_Click(object sender, EventArgs e)
        {
            if (dataGridView_ListWAction.RowCount == 0) return;
            int indx = dataGridView_ListWAction.CurrentRow.Index;

            double buy = Convert.ToInt32(dataGridView_ListWAction.CurrentRow.Cells["Buy"].Value);

            if (buy > 0)
            {
                NEWireBuy_frm NeWire = new NEWireBuy_frm();
                NeWire.NewOrEditWireBuy = 2;
                NeWire.WrID = Convert.ToInt32(dataGridView_ListWAction.CurrentRow.Cells["idbuy"].Value);
                NeWire.SetData_NEWireBuy();

                NeWire.ShowDialog();
            }
            else
            {
                NEWireSale_frm NeWire = new NEWireSale_frm();
                NeWire.NewOrEditWireSale = 2;
                NeWire.WrID = Convert.ToInt32(dataGridView_ListWAction.CurrentRow.Cells["idsale"].Value);
                NeWire.SetData_NEWireSale();

                NeWire.ShowDialog();
            }

            
            ShowListWire(indx);
        }

        #endregion

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            gridControl1.DataSource = dataGridView_ListWAction.DataSource;
            gridControl1.ShowPreview();
        }




    }
}
