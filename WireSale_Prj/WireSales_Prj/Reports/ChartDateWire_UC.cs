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
    public partial class ChartDateWire_UC : UserControl
    {
        public ChartDateWire_UC()
        {
            InitializeComponent();
        }

        private DataClasses_MainDataContext DCDC = new DataClasses_MainDataContext(Global_Cls.ConnectionStr);

        #region Load

        private void ChartDateWire_UC_Load(object sender, EventArgs e)
        {
            SetDateToModules();
        }

        
        


        #region Set Date Module

        private void SetDateToModules()
        {
            PersianCalendar farsi = new PersianCalendar();

            string DateStr = Global_Cls.MiladiDateToShamsi(DateTime.Today);
            comboBox_WireYear1.Text = farsi.GetYear(DateTime.Now).ToString(); comboBox_WireYear2.Text = comboBox_WireYear1.Text;
            comboBox_WireMonth1.Text = farsi.GetMonth(DateTime.Now).ToString(); comboBox_WireMonth2.Text = comboBox_WireMonth1.Text;
            comboBox_Wireday1.Text = farsi.GetDayOfMonth(DateTime.Now).ToString(); comboBox_Wireday2.Text = comboBox_Wireday1.Text;        
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

        #endregion
        #endregion

   
        #region Preview Chart

        private void buttonItem_OK_Click(object sender, EventArgs e)
        {

            string TitleTxt = "", TitleTxt1 = "", TitleTxt2 = "", TitleTxt3 = "", TitleDef = "";
            //Sel Wire
            string WCode = "";
            TitleTxt = " آمار خرید و فروش کلیه کالاها  ";
            TitleTxt1 = " آمار خرید و فروش کلیه کالاها  ";
            TitleTxt2 = " آمار خرید و فروش کلیه کالاها  ";
            TitleTxt3 = " آمار خرید و فروش کلیه کالاها  ";
            if (checkBox_WName.Checked)
            {
                WCode = textBox_WireName.Tag + ";";
                TitleTxt = " آمار خرید و فروش  " + textBox_WireName.Text;
                TitleTxt1 = " آمار خرید و فروش  " + textBox_WireName.Text;
                TitleTxt2 = " آمار خرید و فروش  " + textBox_WireName.Text;
                TitleTxt3 = " آمار خرید و فروش  " + textBox_WireName.Text;
            }
            if (radioButton_Daily.Checked)
                TitleDef = " از روز " + comboBox_WireYear1.Text + "/" + comboBox_WireMonth1.Text + "/" + comboBox_Wireday1.Text +
                    " تا " + comboBox_WireYear2.Text + "/" + comboBox_WireMonth2.Text + "/" + comboBox_Wireday2.Text;
            else
            if (radioButton_Monthly.Checked)
                TitleDef = " از ماه " + comboBox_WireYear1.Text + "/" + comboBox_WireMonth1.Text +
                    " تا " + comboBox_WireYear2.Text + "/" + comboBox_WireMonth2.Text;
            else
            if (radioButton_Yearly.Checked)
                TitleDef = " از سال " + comboBox_WireYear1.Text + " تا " + comboBox_WireYear2.Text;
  

            //View Percent
            bool AxAmountPercent = radioButton_AxAmount.Checked;

            //sort
            int SortInt = 0;
            if (radioButton_SortAmount.Checked)
            { SortInt = 1; }
            else if (radioButton_SortBuy.Checked)
            { SortInt = 2; }
            else if (radioButton_SortSale.Checked)
            { SortInt = 3; }


            //Select Series
            string SelSeries = "";
            if (checkBox_VAmount.Checked) SelSeries = "am;";
            if (checkBox_VBuy.Checked) SelSeries += "by;";
            if (checkBox_VSale.Checked) SelSeries += "sl;";
            if (SelSeries == "")
            {
                Global_Cls.Message_Sara(0, Global_Cls.MessageType.SWarning, false, "سری را مشخص نمایید");
                return;
            }

            //Sel Date
            DateTime Date1 = DateTime.Now;
            DateTime Date2 = DateTime.Now;
            int DateType = 0;
           
            if (radioButton_Daily.Checked)
            {
                Date1 = Global_Cls.ShamsiDateToMiladi(comboBox_WireYear1.Text, comboBox_WireMonth1.Text, comboBox_Wireday1.Text);
                Date2 = Global_Cls.ShamsiDateToMiladi(comboBox_WireYear2.Text, comboBox_WireMonth2.Text, comboBox_Wireday2.Text);
                DateType = 0;
            }
            else if (radioButton_Monthly.Checked)
            {
                Date1 = Global_Cls.ShamsiDateToMiladi(comboBox_WireYear1.Text, comboBox_WireMonth1.Text, "01");
                Date2 = Global_Cls.ShamsiDateToMiladi(comboBox_WireYear2.Text, comboBox_WireMonth2.Text, "30");

                DateType = 1;
            }
            else if (radioButton_Yearly.Checked)
            {
                Date1 = Global_Cls.ShamsiDateToMiladi(comboBox_WireYear1.Text, "01", "01");
                Date2 = Global_Cls.ShamsiDateToMiladi(comboBox_WireYear2.Text, "12", "29");

                DateType = 2;
            }

            //Sel Type Chart
            int SelTypeChart = comboBox_ChartType.SelectedIndex;


            try
            {
                if (checkBox_Compare.Checked)
                {
                    if (radioButton_Yearly.Checked) return;
                    TitleTxt += " در سال " + comboBox_WireYear2.Text + "  n ";
                    TitleTxt1 += " در سال " + (int.Parse(comboBox_WireYear2.Text) - 1).ToString() + "  n ";
                    TitleTxt2 += " در سال " + (int.Parse(comboBox_WireYear2.Text) - 2).ToString() + "  n ";
                    TitleTxt3 += " در سال " + (int.Parse(comboBox_WireYear2.Text) - 3).ToString() + "  n ";

                    ChartDateWCompare_UC Uc = new ChartDateWCompare_UC();
                    Uc._WCode = WCode;
                    Uc._SortType = SortInt;
                    Uc._SelTypeChart = SelTypeChart + 1;
                    Uc._SelSeries = SelSeries;
                    Uc._Date2 = Date2;
                    Uc._Date1 = Date1;
                    Uc._AxAmountPercent = AxAmountPercent;
                    Uc._DateType = DateType;
                    Uc._Title = TitleTxt;
                    Uc._Title1 = TitleTxt1;
                    Uc._Title2 = TitleTxt2;
                    Uc._Title3 = TitleTxt3;
                    Global_Cls.MainForm.AddTabToTabControl("ChartDateWCompare" + DateTime.Now.ToLocalTime().ToString(), (string)((textBox_TabN.Text == "") ? " گزارش آماری مقایسه ای " : (textBox_TabN.Text)), Uc);
                }
                else
                {
                    //TitleTxt += "  n  ";
                    ChartDateWReg_UC Uc = new ChartDateWReg_UC();
                    Uc._WCode = WCode;
                    Uc._SortType = SortInt;
                    Uc._SelTypeChart = SelTypeChart + 1;
                    Uc._SelSeries = SelSeries;
                    Uc._Date2 = Date2;
                    Uc._Date1 = Date1;
                    Uc._AxAmountPercent = AxAmountPercent;
                    Uc._DateType = DateType;
                    Uc._Title = TitleTxt + TitleDef;
                    Global_Cls.MainForm.AddTabToTabControl("ChartDateWReg" + DateTime.Now.ToLocalTime().ToString(), (string)((textBox_TabN.Text == "") ? " گزارش آماری دوره زمانی " : (textBox_TabN.Text)), Uc);
                }
            }
            catch { }
           
        }
        #endregion

        private void btnWireName_Click(object sender, EventArgs e)
        {
            int Wcode = 0;
            string WName = "";
            Global_Cls.SetWireCodeName(ref Wcode, ref WName);
            textBox_WireName.Text = WName;
            textBox_WireName.Tag = Wcode.ToString();
        }

   

    }
}
