using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WireSales_Prj.MainForms
{
    public partial class SelectWire_frm : Form
    {
        public SelectWire_frm()
        {
            InitializeComponent();
        }

        DataClasses_MainDataContext DCDC = new DataClasses_MainDataContext(Global_Cls.ConnectionStr);
        DevComponents.DotNetBar.Controls.TextBoxX tbx = null;

        private void textBox_WireCode_TextChanged(object sender, EventArgs e)
        {
            tbx = (DevComponents.DotNetBar.Controls.TextBoxX)sender;
            try
            {
                var SU = from prd in DCDC.TBL_Wires
                         select new
                         {
                             prd.WireCode,
                             prd.WireName
                         };

                if (textBox_WireCode.Text != "")
                    SU = SU.Where(i => i.WireCode == Convert.ToInt32(textBox_WireCode.Text));

                if (textBox_WireName.Text != "")
                    SU = SU.Where(i => i.WireName.Contains(textBox_WireName.Text));
                dataGridView_SelectWire.DataSource = SU;
            }
            catch { }


        }


        public int WCode = 0;
        public string WName = "";

        private void dataGridView_SelectWire_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                WCode = int.Parse(dataGridView_SelectWire.CurrentRow.Cells["WireCode"].Value.ToString());
                WName = dataGridView_SelectWire.CurrentRow.Cells["WireName"].Value.ToString();
                Close();
            }
            catch { }
        }

        private void SelectWire_frm_Load(object sender, EventArgs e)
        {
            textBox_WireCode_TextChanged(textBox_WireCode, null);
        }

    }
}
