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
    public partial class Wire_UC: UserControl
    {
        public Wire_UC()
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
            

            dgRowCnt = 
                dataGridView_ListWire.RowCount;
            ShowListWire(dgRowCnt - 1);

            
            //ContexMenu
            for (int i = 0; i < dataGridView_ListWire.ColumnCount; i++)
                if (dataGridView_ListWire.Columns[i].Visible)
                {
                    ToolStripMenuItem TSI = new ToolStripMenuItem();
                    TSI.Alignment = ToolStripItemAlignment.Right;
                    TSI.CheckOnClick = true;
                    TSI.Name = dataGridView_ListWire.Columns[i].Name;
                    TSI.Text = dataGridView_ListWire.Columns[i].HeaderText;
                    TSI.Checked = true;

                    if (Global_Cls.AllSelectField_Wire.Count != 0)
                        try
                        {
                            if (!Global_Cls.AllSelectField_Wire.Contains(TSI.Name))
                            {
                                TSI.Checked = false;
                                dataGridView_ListWire.Columns[i].Visible = false;
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
                if (UPer.Contains(button_NewWire.Name)) button_NewWire.Enabled = false;
                if (UPer.Contains(button_EditWire.Name)) button_EditWire.Enabled = false;
                if (UPer.Contains(button_DelWire.Name)) button_DelWire.Enabled = false;
            }
        }

        private void contextMenuStrip_Wire_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                dataGridView_ListWire.Columns[e.ClickedItem.Name].Visible = (e.ClickedItem as ToolStripMenuItem).CheckState == CheckState.Unchecked;
            }
            catch { }
        }

        private void dataGridView_ListWire_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView_ListWire.RowCount != 0)
                button_EditWire_Click(this, null);
        }

        private void Wire_UC_Layout(object sender, LayoutEventArgs e)
        {
            if (LoadStatus)
            {
                Global_Cls.AllSelectField_Wire.Clear();
                for (int i = 0; i < contextMenuStrip_Wire.Items.Count; i++)
                    if ((contextMenuStrip_Wire.Items[i] as ToolStripMenuItem).Checked)
                        Global_Cls.AllSelectField_Wire.Add((contextMenuStrip_Wire.Items[i] as ToolStripMenuItem).Name);
            }

        }


        #endregion



        #region Show List
        private void ShowListWire(int RowFocus)
        {
            if (SearchOrNo==1)
            {
                var SUS = from prd in DCMDC.Vw_WireLists
                          select prd;

                if (checkBox_WCode.Checked)
                    SUS = SUS.Where(m => m.WireCode >= (int)((textBox_WCode1.Text == "") ? 0 : (int.Parse(textBox_WCode1.Text))) && m.WireCode <= (int)((textBox_WCode2.Text == "") ? 0 : (int.Parse(textBox_WCode2.Text))));
                if (checkBox_WName.Checked)
                    SUS = SUS.Where(m => m.WireName.Contains(Global_Cls.ChangeK(textBox_WName.Text)));
                if (checkBox_Amount.Checked)
                    SUS = SUS.Where(m => m.WireAmount >= (double)((textBox_Amount1.Text == "") ? 0 : (double.Parse(textBox_Amount1.Text))) && m.WireAmount <= (double)((textBox_Amount2.Text == "") ? 0 : (double.Parse(textBox_Amount2.Text))));

                dataGridView_ListWire.DataSource = SUS;
            }
            else if (SearchOrNo ==0)
            {                
                var SUN = from prd in DCMDC.Vw_WireLists
                          select prd;

                dataGridView_ListWire.DataSource = SUN;
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

                    SqCmd.CommandText = "SELECT  * From Vw_WireList "
                            + "Where (1=1) "
                            + ListWhereSearch;
                    DataTable retValue = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(SqCmd);
                    da.Fill(retValue);
                    dataGridView_ListWire.DataSource = retValue;
                    SqConn.Close();
                }
                catch { }
            }

            double SumWireAmount = 0;
            for (int i = 0; i < dataGridView_ListWire.RowCount; i++)
                SumWireAmount += int.Parse(dataGridView_ListWire.Rows[i].Cells["WireAmount"].Value.ToString());

            labelSum.Text = SumWireAmount.ToString();

            try
            {
                dataGridView_ListWire.CurrentCell = dataGridView_ListWire.Rows[RowFocus].Cells[dataGridView_ListWire.CurrentCell.ColumnIndex];
            }
            catch
            {
                try { dataGridView_ListWire.CurrentCell = dataGridView_ListWire.Rows[0].Cells[0]; }
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
                dataGridView_ListWire.CurrentCell = dataGridView_ListWire.Rows[dataGridView_ListWire.RowCount - 1].Cells[dataGridView_ListWire.CurrentCell.ColumnIndex];
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
            NEWire_frm NeWire = new NEWire_frm();
            NeWire.NewOrEditWire = 1;
            NeWire.SetData_NEWire();
            NeWire.ShowDialog();
            ShowListWire(dataGridView_ListWire.RowCount-1);
        }

        private void button_EditWire_Click(object sender, EventArgs e)
        {
            if (dataGridView_ListWire.RowCount == 0) return;
            int indx = dataGridView_ListWire.CurrentRow.Index;
            NEWire_frm NeWire = new NEWire_frm();
            NeWire.NewOrEditWire = 2;
            NeWire.WrCd = Convert.ToInt32(dataGridView_ListWire.CurrentRow.Cells["WireCode"].Value);
            NeWire.SetData_NEWire();

            NeWire.ShowDialog();
            ShowListWire(indx);
        }


        private void button_DelWire_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView_ListWire.RowCount != 0)
                {
                    int SelCount = dataGridView_ListWire.SelectedRows.Count;
                    if (SelCount == 1)
                    {
                        if (!Global_Cls.Message_Sara(0, Global_Cls.MessageType.SConfirmation, true, " آیا به حذف این کالا )سیم( اطمینان دارید؟ ")) return;
                        int RFocus = dataGridView_ListWire.CurrentRow.Index;
                        TBL_Wire tw = DCMDC.TBL_Wires.First(tp => tp.WireCode.Equals(Convert.ToInt32(dataGridView_ListWire.CurrentRow.Cells[1].Value)));
                        DCMDC.TBL_Wires.DeleteOnSubmit(tw);
                        DCMDC.SubmitChanges();
                        ShowListWire(RFocus - 1);
                    }
                    else
                    {
                        if (!Global_Cls.Message_Sara(0, Global_Cls.MessageType.SConfirmation, true, " آیا مایلید این " + SelCount.ToString() + " کالا )سیم( از سیستم حذف شوند؟ ")) return;
                        while (SelCount > 0)
                        {
                            SelCount--;
                            TBL_Wire thsf = DCMDC.TBL_Wires.First(tp => tp.WireCode.Equals(Convert.ToInt32(dataGridView_ListWire.SelectedRows[SelCount].Cells[1].Value)));
                            DCMDC.TBL_Wires.DeleteOnSubmit(thsf);
                            DCMDC.SubmitChanges();
                        }
                        ShowListWire(0);
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
            gridControl1.DataSource = dataGridView_ListWire.DataSource;
            gridControl1.ShowPreview();
        }




    }
}
