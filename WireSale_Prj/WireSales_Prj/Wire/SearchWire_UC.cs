using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WireSales_Prj.Properties;
using System.Globalization;

namespace WireSales_Prj
{
    public partial class SearchWire_UC : UserControl
    {
        public SearchWire_UC()
        {
            InitializeComponent();
        }

        private DataClasses_MainDataContext DCDC = new DataClasses_MainDataContext(Global_Cls.ConnectionStr);

        #region Load
        
        private void SearchHouse_UC_Load(object sender, EventArgs e)
        {
            SetDateToModules();
            SetPermission();
            if (radioButton_Wire.Enabled)
            {
                radioButton_Wire.Checked = true;
                radioButton_Wire_Click(this, null);
            }
        }

        private void SetPermission()
        {
            string UPer = Global_Cls.MainForm.UserPermission;
            if (UPer != "" && UPer != "admin")
            {
                if (UPer.Contains(radioButton_Wire.Name)) radioButton_Wire.Enabled = false;
                if (UPer.Contains(radioButton_WBuy.Name)) radioButton_WBuy.Enabled = false;
                if (UPer.Contains(radioButton_WSale.Name)) radioButton_WSale.Enabled = false;
            }
        }
        
        #endregion


        #region Set Date Module

        private void SetDateToModules()
        {
            PersianCalendar farsi = new PersianCalendar();

            string DateStr = Global_Cls.MiladiDateToShamsi(DateTime.Today);
            comboBox_WireYear1.Text = farsi.GetYear(DateTime.Now).ToString(); comboBox_WireYear2.Text = comboBox_WireYear1.Text;
            comboBox_WireMonth1.Text = farsi.GetMonth(DateTime.Now).ToString(); comboBox_WireMonth2.Text = comboBox_WireMonth1.Text;
            comboBox_Wireday1.Text = farsi.GetDayOfMonth(DateTime.Now).ToString(); comboBox_Wireday2.Text = comboBox_Wireday1.Text;

            comboBox_WBYear1.Text = farsi.GetYear(DateTime.Now).ToString(); comboBox_WBYear2.Text = comboBox_WBYear1.Text;
            comboBox_WBMonth1.Text = farsi.GetMonth(DateTime.Now).ToString(); comboBox_WBMonth2.Text = comboBox_WBMonth1.Text;
            comboBox_WBDay1.Text = farsi.GetDayOfMonth(DateTime.Now).ToString(); comboBox_WBDay2.Text = comboBox_WBDay1.Text;

            comboBox_WSYear1.Text = farsi.GetYear(DateTime.Now).ToString(); comboBox_WSYear2.Text = comboBox_WSYear1.Text;
            comboBox_WSMonth1.Text = farsi.GetMonth(DateTime.Now).ToString(); comboBox_WSMonth2.Text = comboBox_WSMonth1.Text;
            comboBox_WSDay1.Text = farsi.GetDayOfMonth(DateTime.Now).ToString(); comboBox_WSDay2.Text = comboBox_WSDay1.Text;
        
        }

        private void panel_DWire1_Leave(object sender, EventArgs e)
        {
            if (Convert.ToInt16(comboBox_WireMonth1.Text) > 6 && Convert.ToInt16(comboBox_Wireday1.Text) == 31) comboBox_Wireday1.Text = "30";
            if (Convert.ToInt16(comboBox_WireMonth1.Text) == 12 && (Convert.ToInt16(comboBox_Wireday1.Text) == 31 || Convert.ToInt16(comboBox_Wireday1.Text) == 30)) comboBox_Wireday1.Text = "29";
        }

        private void panel_DWire2_Leave(object sender, EventArgs e)
        {
            if (Convert.ToInt16(comboBox_WireMonth2.Text) > 6 && Convert.ToInt16(comboBox_Wireday2.Text) == 31) comboBox_Wireday2.Text = "30";
            if (Convert.ToInt16(comboBox_WireMonth2.Text) == 12 && (Convert.ToInt16(comboBox_Wireday2.Text) == 31 || Convert.ToInt16(comboBox_Wireday2.Text) == 30)) comboBox_Wireday2.Text = "29";
        }

        private void panel_WDSale1_Leave(object sender, EventArgs e)
        {
            if (Convert.ToInt16(comboBox_WSMonth1.Text) > 6 && Convert.ToInt16(comboBox_WSDay1.Text) == 31) comboBox_WSDay1.Text = "30";
            if (Convert.ToInt16(comboBox_WSMonth1.Text) == 12 && (Convert.ToInt16(comboBox_WSDay1.Text) == 31 || Convert.ToInt16(comboBox_WSDay1.Text) == 30)) comboBox_WSDay1.Text = "29";
        }

        private void panel_WDSale2_Leave(object sender, EventArgs e)
        {
            if (Convert.ToInt16(comboBox_WSMonth2.Text) > 6 && Convert.ToInt16(comboBox_WSDay2.Text) == 31) comboBox_WSDay2.Text = "30";
            if (Convert.ToInt16(comboBox_WSMonth2.Text) == 12 && (Convert.ToInt16(comboBox_WSDay2.Text) == 31 || Convert.ToInt16(comboBox_WSDay2.Text) == 30)) comboBox_WSDay2.Text = "29";
        }

        private void panel_WDBuy1_Leave(object sender, EventArgs e)
        {
            if (Convert.ToInt16(comboBox_WBMonth1.Text) > 6 && Convert.ToInt16(comboBox_WBDay1.Text) == 31) comboBox_WBDay1.Text = "30";
            if (Convert.ToInt16(comboBox_WBMonth1.Text) == 12 && (Convert.ToInt16(comboBox_WBDay1.Text) == 31 || Convert.ToInt16(comboBox_WBDay1.Text) == 30)) comboBox_WBDay1.Text = "29";
        }

        private void panel_WDBuy2_Leave(object sender, EventArgs e)
        {
            if (Convert.ToInt16(comboBox_WBMonth2.Text) > 6 && Convert.ToInt16(comboBox_WBDay2.Text) == 31) comboBox_WBDay2.Text = "30";
            if (Convert.ToInt16(comboBox_WBMonth2.Text) == 12 && (Convert.ToInt16(comboBox_WBDay2.Text) == 31 || Convert.ToInt16(comboBox_WBDay2.Text) == 30)) comboBox_WBDay2.Text = "29";
        }

        #endregion


        #region Search
        private void buttonItem_OK_Click(object sender, EventArgs e)
        {
            
            string ListWhereSearch = "";

            if (checkBox_WireCode.Checked) ListWhereSearch += " And (WireCode >= " + (string)((textBox_WCode1.Text == "") ? "0" : (textBox_WCode1.Text)) + ") And (WireCode <= " + (string)((textBox_WCode2.Text == "") ? "0" : (textBox_WCode2.Text)) + ")";
            if (checkBox_WName.Checked) ListWhereSearch += " And (WireName Like N'%" + Global_Cls.ChangeK(textBox_WName.Text) + "%')";

            if (radioButton_Wire.Checked)
            {
                panel_DWire1_Leave(this, null);
                panel_DWire2_Leave(this, null);

                if (checkBox_WDsc.Checked) ListWhereSearch += " And (WireDsc Like N'%" + Global_Cls.ChangeK(textBox_WDsc.Text) + "%')";
                if (checkBox_Wire.Checked) ListWhereSearch += " And (WireAmount >= " + (string)((textBox_Wire1.Text == "") ? "0" : (textBox_Wire1.Text)) + ") And (WireAmount <= " + (string)((textBox_Wire2.Text == "") ? "0" : (textBox_Wire2.Text)) + ")";
                if (checkBox_DWire.Checked) ListWhereSearch += " And (CreateDate >= '" + Global_Cls.ShamsiDateToMiladi(comboBox_WireYear1.Text, comboBox_WireMonth1.Text, comboBox_Wireday1.Text).ToShortDateString() + "') And (CreateDate <= '" + Global_Cls.ShamsiDateToMiladi(comboBox_WireYear2.Text, comboBox_WireMonth2.Text, comboBox_Wireday2.Text).ToShortDateString() + "')";

                try
                {
                    Wire_UC Uc = new Wire_UC();
                    Uc.SearchOrNo = -1;
                    Uc.ListWhereSearch = ListWhereSearch;

                    Global_Cls.MainForm.AddTabToTabControl("Wire" + DateTime.Now.ToLocalTime().ToString(), (string)((textBox_TabN.Text == "") ? " لیست کالاها-سیم ها " : (textBox_TabN.Text)), Uc);
                }
                catch { }
            }
            else
                if (radioButton_WSale.Checked)
                {
                    panel_WDSale1_Leave(this, null);
                    panel_WDSale2_Leave(this, null);


                    if (checkBox_WDsc.Checked) ListWhereSearch += " And (WireDsc Like N'%" + Global_Cls.ChangeK(textBox_WDsc.Text) + "%')";
                    if (checkBox_WSale.Checked) ListWhereSearch += " And (SaleAmount >= " + (string)((textBox_WSale1.Text == "") ? "0" : (textBox_WSale1.Text)) + ") And (SaleAmount <= " + (string)((textBox_WSale2.Text == "") ? "0" : (textBox_WSale2.Text)) + ")";
                    if (checkBox_WDSale.Checked) ListWhereSearch += " And (SaleDate >= '" + Global_Cls.ShamsiDateToMiladi(comboBox_WSYear1.Text, comboBox_WSMonth1.Text, comboBox_WSDay1.Text).ToShortDateString() + "') And (SaleDate <= '" + Global_Cls.ShamsiDateToMiladi(comboBox_WSYear2.Text, comboBox_WSMonth2.Text, comboBox_WSDay2.Text).ToShortDateString() + "')";

                    try
                    {
                        WireSale_UC Uc = new WireSale_UC();
                        Uc.SearchOrNo = -1;
                        Uc.ListWhereSearch = ListWhereSearch;

                        Global_Cls.MainForm.AddTabToTabControl("WireSale" + DateTime.Now.ToLocalTime().ToString(), (string)((textBox_TabN.Text == "") ? " لیست فروش کالاها-سیم ها " : (textBox_TabN.Text)), Uc);
                    }
                    catch { }
                }

                else
                    if (radioButton_WBuy.Checked)
                    {
                        panel_WDBuy1_Leave(this, null);
                        panel_WDBuy2_Leave(this, null);


                        if (checkBox_WDsc.Checked) ListWhereSearch += " And (WireDsc Like N'%" + Global_Cls.ChangeK(textBox_WDsc.Text) + "%')";
                        if (checkBox_WBuy.Checked) ListWhereSearch += " And (BuyAmount >= " + (string)((textBox_WBuy1.Text == "") ? "0" : (textBox_WBuy1.Text)) + ") And (BuyAmount <= " + (string)((textBox_WBuy2.Text == "") ? "0" : (textBox_WBuy2.Text)) + ")";
                        if (checkBox_WDBuy.Checked) ListWhereSearch += " And (BuyDate >= '" + Global_Cls.ShamsiDateToMiladi(comboBox_WBYear1.Text, comboBox_WBMonth1.Text, comboBox_WBDay1.Text).ToShortDateString() + "') And (BuyDate <= '" + Global_Cls.ShamsiDateToMiladi(comboBox_WBYear2.Text, comboBox_WBMonth2.Text, comboBox_WBDay2.Text).ToShortDateString() + "')";

                        try
                        {
                            WireBuy_UC Uc = new WireBuy_UC();
                            Uc.SearchOrNo = -1;
                            Uc.ListWhereSearch = ListWhereSearch;

                            Global_Cls.MainForm.AddTabToTabControl("WireBuy" + DateTime.Now.ToLocalTime().ToString(), (string)((textBox_TabN.Text == "") ? " لیست خرید کالاها-سیم ها " : (textBox_TabN.Text)), Uc);
                        }
                        catch { }
                    }

            else if (radioButton_WBuySale.Checked)
            {
                panel_DWire1_Leave(this, null);
                panel_DWire2_Leave(this, null);
                panel_WDSale1_Leave(this, null);
                panel_WDSale2_Leave(this, null);
                panel_WDBuy1_Leave(this, null);
                panel_WDBuy2_Leave(this, null);


                if (checkBox_Wire.Checked) ListWhereSearch += " And (Inventory >= " + (string)((textBox_Wire1.Text == "") ? "0" : (textBox_Wire1.Text)) + ") And (Inventory <= " + (string)((textBox_Wire2.Text == "") ? "0" : (textBox_Wire2.Text)) + ")";
                if (checkBox_DWire.Checked) ListWhereSearch += " And (ActionDate >= '" + Global_Cls.ShamsiDateToMiladi(comboBox_WireYear1.Text, comboBox_WireMonth1.Text, comboBox_Wireday1.Text).ToShortDateString() + "') And (ActionDate <= '" + Global_Cls.ShamsiDateToMiladi(comboBox_WireYear2.Text, comboBox_WireMonth2.Text, comboBox_Wireday2.Text).ToShortDateString() + "')";
                if (checkBox_WSale.Checked) ListWhereSearch += " And (Sale >= " + (string)((textBox_WSale1.Text == "") ? "0" : (textBox_WSale1.Text)) + ") And (Sale <= " + (string)((textBox_WSale2.Text == "") ? "0" : (textBox_WSale2.Text)) + ")";
                if (checkBox_WBuy.Checked) ListWhereSearch += " And (Buy >= " + (string)((textBox_WBuy1.Text == "") ? "0" : (textBox_WBuy1.Text)) + ") And (Buy <= " + (string)((textBox_WBuy2.Text == "") ? "0" : (textBox_WBuy2.Text)) + ")";

                try
                {
                    WireAction_UC Uc = new WireAction_UC();
                    Uc.SearchOrNo = -1;
                    Uc.ListWhereSearch = ListWhereSearch;

                    Global_Cls.MainForm.AddTabToTabControl("WireAction" + DateTime.Now.ToLocalTime().ToString(), (string)((textBox_TabN.Text == "") ? " لیست خرید و فروش کالاها-سیم ها " : (textBox_TabN.Text)), Uc);
                }
                catch { }
            }
            
        }
        #endregion


        #region Other
        TextBox tx = new TextBox();
        private void textBox_Subbuild_KeyPress(object sender, KeyPressEventArgs e)
        {
            tx = (TextBox)sender;
            if ((tx.Text.Contains(".") && e.KeyChar == '.')
                || (!System.Char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Delete && e.KeyChar != (char)Keys.Back && e.KeyChar != '.'))
            { e.KeyChar = '\0'; return; }
        }

        private void radioButton_Wire_Click(object sender, EventArgs e)
        {
            groupPanel_Wire.Enabled = radioButton_Wire.Checked || radioButton_WBuySale.Checked;
            groupPanel_WBuy.Enabled = radioButton_WBuy.Checked || radioButton_WBuySale.Checked;
            groupPanel_WSale.Enabled = radioButton_WSale.Checked || radioButton_WBuySale.Checked;
        }

      #endregion

  

    }
}
