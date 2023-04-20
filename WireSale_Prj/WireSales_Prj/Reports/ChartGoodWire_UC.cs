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
    public partial class ChartGoodWire_UC : UserControl
    {
        public ChartGoodWire_UC()
        {
            InitializeComponent();
        }

        private DataClasses_MainDataContext DCDC = new DataClasses_MainDataContext(Global_Cls.ConnectionStr);

        #region Load

        private void ChartGoodWire_UC_Load(object sender, EventArgs e)
        {
            SetDateToModules();
        }

        
   
        #region Set Date Module

        private void SetDateToModules()
        {
            PersianCalendar farsi = new PersianCalendar();

            string DateStr = Global_Cls.MiladiDateToShamsi(DateTime.Today);
            comboBox_WireYear1.Text = farsi.GetYear(DateTime.Now).ToString(); comboBox_WireYear2.Text = comboBox_WireYear1.Text; comboBox_WireYear3.Text = comboBox_WireYear1.Text;
            comboBox_WireMonth1.Text = farsi.GetMonth(DateTime.Now).ToString(); comboBox_WireMonth2.Text = comboBox_WireMonth1.Text;
            comboBox_Wireday1.Text = farsi.GetDayOfMonth(DateTime.Now).ToString(); 
        }

        private void panel_DWire1_Leave(object sender, EventArgs e)
        {
            if (Convert.ToInt16(comboBox_WireMonth1.Text) > 6 && Convert.ToInt16(comboBox_Wireday1.Text) == 31) comboBox_Wireday1.Text = "30";
            if (Convert.ToInt16(comboBox_WireMonth1.Text) == 12 && (Convert.ToInt16(comboBox_Wireday1.Text) == 31 || Convert.ToInt16(comboBox_Wireday1.Text) == 30)) comboBox_Wireday1.Text = "29";
        }


        #endregion
        #endregion

   
        #region Preview Chart

        private void buttonItem_OK_Click(object sender, EventArgs e)
        {
            string TitleTxt = "", TitleTxt1 = "", TitleTxt2 = "", TitleTxt3 = "";
            //Sel Wire
            string WCode = "";
            if (RadioButton_SelWire.Checked)
            {
                for (int i = 0; i < listView_Wire.Items.Count;i++ )
                {
                    WCode += listView_Wire.Items[i].Tag.ToString();
                    WCode += ";";
                }
          }
            
            //View Percent
            bool AxAmountPercent = radioButton_AxAmount.Checked;

            //sort
            int SortInt = 1;
            if (radioButton_SortAmount.Checked)
            { SortInt = 1; }
            else if (radioButton_SortBuy.Checked)
            { SortInt = 2; }
            else if (radioButton_SortSale.Checked)
            { SortInt = 3; }


            //Select Series
            string SelSeries="";
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

            if (checkBox_Compare.Checked) radioButton_Yearly.Checked = true;
            if (radioButton_Daily.Checked)
            {
                Date1 = Global_Cls.ShamsiDateToMiladi(comboBox_WireYear1.Text, comboBox_WireMonth1.Text, comboBox_Wireday1.Text);
                Date2 = Global_Cls.ShamsiDateToMiladi(comboBox_WireYear1.Text, comboBox_WireMonth1.Text, comboBox_Wireday1.Text);
                TitleTxt = " آمار روز " + comboBox_WireYear1.Text + "/" + comboBox_WireMonth1.Text + "/" + comboBox_Wireday1.Text ;
            }
            else if (radioButton_Monthly.Checked)
            {
                Date1 = Global_Cls.ShamsiDateToMiladi(comboBox_WireYear2.Text, comboBox_WireMonth2.Text, "01");
                Date2 = Global_Cls.ShamsiDateToMiladi(comboBox_WireYear2.Text, comboBox_WireMonth2.Text, "30");
                TitleTxt = " آمار ماه " + comboBox_WireYear2.Text + "/" + comboBox_WireMonth2.Text ;
            }
            else if (radioButton_Yearly.Checked)
            {
                Date1 = Global_Cls.ShamsiDateToMiladi(comboBox_WireYear3.Text, "01", "01");
                Date2 = Global_Cls.ShamsiDateToMiladi(comboBox_WireYear3.Text, "12", "29");
                TitleTxt = " آمار سال " + comboBox_WireYear3.Text + "  n ";
                TitleTxt1 = " آمار سال " + (int.Parse(comboBox_WireYear3.Text) - 1).ToString() + "  n ";
                TitleTxt2 = " آمار سال " + (int.Parse(comboBox_WireYear3.Text) - 2).ToString() + "  n ";
                TitleTxt3 = " آمار سال " + (int.Parse(comboBox_WireYear3.Text) - 3).ToString() + "  n ";
            }

            //Sel Type Chart
            int SelTypeChart = comboBox_ChartType.SelectedIndex;

           
            try
            {
                if (checkBox_Compare.Checked)
                {
                    ChartGoodWCompare_UC Uc = new ChartGoodWCompare_UC();
                    Uc._WCode = WCode;
                    Uc._SortType = SortInt;
                    Uc._SelTypeChart = SelTypeChart+1;
                    Uc._SelSeries = SelSeries;
                    Uc._Date2 = Date2;
                    Uc._Date1 = Date1;
                    Uc._AxAmountPercent = AxAmountPercent;
                    Uc._Title = TitleTxt;
                    Uc._Title1 = TitleTxt1;
                    Uc._Title2 = TitleTxt2;
                    Uc._Title3 = TitleTxt3;
                    Global_Cls.MainForm.AddTabToTabControl("ChartGoodWCompare" + DateTime.Now.ToUniversalTime(), (string)((textBox_TabN.Text == "") ? " گزارش آماری مقایسه ای " : (textBox_TabN.Text)), Uc);
                }
                else
                {
                    ChartGoodWReg_UC Uc = new ChartGoodWReg_UC();
                    Uc._WCode = WCode;
                    Uc._SortType = SortInt;
                    Uc._SelTypeChart = SelTypeChart+1;
                    Uc._SelSeries = SelSeries;
                    Uc._Date2 = Date2;
                    Uc._Date1 = Date1;
                    Uc._AxAmountPercent = AxAmountPercent;
                    Uc._Title = TitleTxt;
                    Global_Cls.MainForm.AddTabToTabControl("ChartGoodWReg" + DateTime.Now.ToLocalTime().ToString(), (string)((textBox_TabN.Text == "") ? " گزارش آماری کالاها " : (textBox_TabN.Text)), Uc);
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
            if (listView_Wire.Items.ContainsKey(Wcode.ToString())) return;

            listView_Wire.Items.Add(Wcode.ToString(), WName, 0);
            listView_Wire.Items[Wcode.ToString()].Tag = Wcode.ToString();
        }

        private void btnDelItem_Click(object sender, EventArgs e)
        {
            int gh = listView_Wire.SelectedItems.Count;
            for (int i = 0; i < gh; i++)
            {
                listView_Wire.SelectedItems[0].Remove();
            }
        }


       

   

    }
}
