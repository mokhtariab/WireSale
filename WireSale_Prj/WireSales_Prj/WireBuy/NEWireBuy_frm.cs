using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic.FileIO;
using System.Collections.ObjectModel;
using System.Diagnostics;
using WireSales_Prj.Properties;
using System.Data.SqlClient;

namespace WireSales_Prj
{
    public partial class NEWireBuy_frm : Form
    {
        public NEWireBuy_frm()
        {
            InitializeComponent();
        }
        public int NewOrEditWireBuy, WrID;
        private bool CloseOK = false;

        DataClasses_MainDataContext DCMD = new DataClasses_MainDataContext(Global_Cls.ConnectionStr);


        #region Load Data
        public void SetData_NEWireBuy()
        {
            
            //Start Use Permission
            //string UPer = Global_Cls.MainForm.UserPermission;
            //if (UPer != "" && UPer != "admin")
            //{
            //    if (UPer.Contains(checkBox_AddTelNotebook.Name)) checkBox_AddTelNotebook.Enabled = false;
            //    if (UPer.Contains(checkBoxItem_ListCuHouse.Name)) checkBoxItem_ListCuHouse.Enabled = false;
            //}
            //End Use Permission

            


            if (NewOrEditWireBuy == 2)
            {
                buttonItem_OkNext.Visible = false;
                groupPanel_Main.Text = "ویرایش خرید کالا";

                try
                {
                    TBL_WireBuy tbhf = DCMD.TBL_WireBuys.First(thfh => thfh.id.Equals(WrID));

                    textBox_WireCode.Text = tbhf.WireCode.ToString();

                    textBox_Stock.Text = tbhf.BuyAmount.ToString();
                    
                    string DateStr = Global_Cls.MiladiDateToShamsi(Convert.ToDateTime(tbhf.BuyDate));
                    comboBox_Year1.Text = Convert.ToInt16(DateStr.Substring(0, 4)).ToString();
                    comboBox_Month1.Text = Convert.ToInt16(DateStr.Substring(5, 2)).ToString();
                    comboBox_day1.Text = Convert.ToInt16(DateStr.Substring(8, 2)).ToString();

                    TBL_Wire tw = DCMD.TBL_Wires.First(fg => fg.WireCode == int.Parse(textBox_WireCode.Text));
                    textBox_WireName.Text = tw.WireName;

                }
                catch //(Exception ex)
                {
                    Global_Cls.Message_Sara(0, Global_Cls.MessageType.SError, false, "اشکال در لود");
                }


            }
            else if (NewOrEditWireBuy == 1)
            {
                textBox_Stock.Text = "0";
                string DateStr = Global_Cls.MiladiDateToShamsi(DateTime.Today);
                comboBox_Year1.Text = Convert.ToInt16(DateStr.Substring(0, 4)).ToString();
                comboBox_Month1.Text = Convert.ToInt16(DateStr.Substring(5, 2)).ToString();
                comboBox_day1.Text = Convert.ToInt16(DateStr.Substring(8, 2)).ToString();
            }

        }

        #endregion



        #region OK Data
        private void buttonItem_OK_Click(object sender, EventArgs e)
        {
            if (OkFunction())
            {
                CloseOK = true;
                Close();
            }
        }

        private void buttonItem_OkNext_Click(object sender, EventArgs e)
        {
            if (OkFunction())
            {
                  SetData_NEWireBuy();
            }
        }

        private bool OkFunction()
        {

            if (textBox_WireName.Text == "")
            { Global_Cls.Message_Sara(0, Global_Cls.MessageType.SWarning, false, "نام کالا را وارد نمایید"); textBox_WireName.Focus(); return false; }

            if (textBox_Stock.Text == "" || textBox_Stock.Text == "0")
            { Global_Cls.Message_Sara(0, Global_Cls.MessageType.SWarning, false, "مقدار خرید را مشخص نمایید"); textBox_Stock.Focus(); return false; }
            

           

            DataClasses_MainDataContext DCD = new DataClasses_MainDataContext(Global_Cls.ConnectionStr);
            if (NewOrEditWireBuy == 1)
                try
                {
                    TBL_WireBuy THF = new TBL_WireBuy
                    {
                        WireCode = int.Parse( textBox_WireCode.Text ),
                        BuyAmount = double.Parse( textBox_Stock.Text ),
                        BuyDate = Global_Cls.ShamsiDateToMiladi(comboBox_Year1.Text, comboBox_Month1.Text, comboBox_day1.Text)
                    };
                    DCD.TBL_WireBuys.InsertOnSubmit(THF);
                    DCD.SubmitChanges();

                }
                catch (Exception ex)
                {
                    if (ex.Message.IndexOf("Duplicated Row!") > -1)
                        Global_Cls.Message_Sara(0, Global_Cls.MessageType.SError, false, "اطلاعات وارد شده تکراری است!");
                    else
                        Global_Cls.Message_Sara(0, Global_Cls.MessageType.SError, false, "لطفا با کمی فاصله دوباره تایید کنید!", ex.ToString());

                    return false;
                }
            else
                if (NewOrEditWireBuy == 2)
                    try
                    {
                        TBL_WireBuy tbhf = DCD.TBL_WireBuys.First(thfh => thfh.id.Equals(WrID));

                        tbhf.WireCode = int.Parse( textBox_WireCode.Text );
                        tbhf.BuyDate = Global_Cls.ShamsiDateToMiladi(comboBox_Year1.Text, comboBox_Month1.Text, comboBox_day1.Text);
                        tbhf.BuyAmount = double.Parse(textBox_Stock.Text);

                        DCD.SubmitChanges();

                    }
                    catch (Exception ex)
                    {
                        if (ex.Message.IndexOf("Duplicated Row!") > -1)
                            Global_Cls.Message_Sara(0, Global_Cls.MessageType.SError, false, "اطلاعات وارد شده تکراری است!");
                        else
                            Global_Cls.Message_Sara(0, Global_Cls.MessageType.SError, false, "لطفا با کمی فاصله دوباره تایید کنید!", ex.ToString());

                        return false;
                    }



            return true;
        }

        #endregion



        #region UI Control Func
        TextBox tx = new TextBox();

        private void textBox_Subbuild_KeyPress(object sender, KeyPressEventArgs e)
        {
            tx = (TextBox)sender;
            if ((tx.Text.Contains(".") && e.KeyChar == '.')
                || (!System.Char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Delete && e.KeyChar != (char)Keys.Back && e.KeyChar != '.'))
            { e.KeyChar = '\0'; return; }
        }


        private void NEHouse_frm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Global_Cls.MainForm.CloseAllOK && !CloseOK && !Global_Cls.Message_Sara(0, Global_Cls.MessageType.SConfirmation, true, "آیا از این فرم خارج می شوید؟"))
                e.Cancel = true;
        }



        
        private void panel_Date_Leave(object sender, EventArgs e)
        {
            if (Convert.ToInt16(comboBox_Month1.Text) > 6 && Convert.ToInt16(comboBox_day1.Text) == 31) comboBox_day1.Text = "30";
            if (Convert.ToInt16(comboBox_Month1.Text) == 12 && (Convert.ToInt16(comboBox_day1.Text) == 31 || Convert.ToInt16(comboBox_day1.Text) == 30)) comboBox_day1.Text = "29";
        }

     

        private void btnWireName_Click(object sender, EventArgs e)
        {
            int Wcode=0;
            string WName="";
            Global_Cls.SetWireCodeName(ref Wcode, ref WName);
            textBox_WireName.Text = WName;
            textBox_WireCode.Text = Wcode.ToString();
        }

        #endregion

        
    }
}
