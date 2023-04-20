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
    public partial class NEWire_frm : Form
    {
        public NEWire_frm()
        {
            InitializeComponent();
        }
        public int NewOrEditWire, WrCd;
        private int MaxWireCode;
        private bool CloseOK = false;

        DataClasses_MainDataContext DCMD = new DataClasses_MainDataContext(Global_Cls.ConnectionStr);


        #region Load Data
        public void SetData_NEWire()
        {
            
            //Start Use Permission
            //string UPer = Global_Cls.MainForm.UserPermission;
            //if (UPer != "" && UPer != "admin")
            //{
            //    if (UPer.Contains(checkBox_AddTelNotebook.Name)) checkBox_AddTelNotebook.Enabled = false;
            //    if (UPer.Contains(checkBoxItem_ListCuHouse.Name)) checkBoxItem_ListCuHouse.Enabled = false;
            //}
            //End Use Permission

            try
            {
                var MaxID = (from prd in DCMD.TBL_Wires
                             select prd.WireCode).Max();
                MaxWireCode = MaxID+1;
            }
            catch
            {
                MaxWireCode = 1;
            }



            if (NewOrEditWire == 2)
            {
                buttonItem_OkNext.Visible = false;
                textBox_FN.Enabled = false;
                groupPanel_FNoDate.Text = "ویرایش کالا";

                try
                {
                    TBL_Wire tbhf = DCMD.TBL_Wires.First(thfh => thfh.WireCode.Equals(WrCd));

                    textBox_FN.Text = tbhf.WireCode.ToString();

                    textBox_WireName.Text = tbhf.WireName;
                    textBox_Specify.Text = tbhf.WireDsc;
                    textBox_Stock.Text = tbhf.WireAmount.ToString();

                    string DateStr = Global_Cls.MiladiDateToShamsi(Convert.ToDateTime(tbhf.CreateDate));
                    comboBox_Year1.Text = Convert.ToInt16(DateStr.Substring(0, 4)).ToString();
                    comboBox_Month1.Text = Convert.ToInt16(DateStr.Substring(5, 2)).ToString();
                    comboBox_day1.Text = Convert.ToInt16(DateStr.Substring(8, 2)).ToString();

                }
                catch //(Exception ex)
                {
                    Global_Cls.Message_Sara(0, Global_Cls.MessageType.SError, false, "اشکال در لود");
                }


            }
            else if (NewOrEditWire == 1)
            {
                textBox_FN.Text = MaxWireCode.ToString();
                textBox_WireName.Text = "";
                textBox_Specify.Text = "";
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
                  SetData_NEWire();
            }
        }

        private bool OkFunction()
        {

            try
            {
                int i = Convert.ToInt32(textBox_FN.Text);
            }
            catch
            {
                Global_Cls.Message_Sara(0, Global_Cls.MessageType.SError, false, "کد کالا باید عددی باشد!");
                textBox_FN.Focus();
                return false;
            }
           
            if (textBox_WireName.Text == "")
            { Global_Cls.Message_Sara(0, Global_Cls.MessageType.SWarning, false, "نام کالا را وارد نمایید"); textBox_WireName.Focus(); return false; }
            

           

            DataClasses_MainDataContext DCD = new DataClasses_MainDataContext(Global_Cls.ConnectionStr);
            if (NewOrEditWire == 1)
                try
                {
                    // Test Re FileNo
                    var FN = (from prd in DCMD.TBL_Wires
                              where prd.WireCode.ToString() == textBox_FN.Text
                              select prd).Count();
                    if (FN > 0)
                    {
                        Global_Cls.Message_Sara(0, Global_Cls.MessageType.SWarning, false, "کد کالای ورودی تکراری است!");
                        textBox_FN.Focus();
                        return false;
                    }


                    TBL_Wire THF = new TBL_Wire
                    {
                        WireCode = int.Parse( textBox_FN.Text ),
                        WireName = textBox_WireName.Text,
                        WireDsc = textBox_Specify.Text,
                        WireAmount = double.Parse( textBox_Stock.Text ),
                        CreateDate = Global_Cls.ShamsiDateToMiladi(comboBox_Year1.Text, comboBox_Month1.Text, comboBox_day1.Text)
                    };
                    DCD.TBL_Wires.InsertOnSubmit(THF);
                    DCD.SubmitChanges();

                }
                catch (Exception ex)
                {
                    if (ex.Message.IndexOf("Duplicated Row!") > -1)
                        Global_Cls.Message_Sara(0, Global_Cls.MessageType.SError, false, "اطلاعات وارد شده تکراری است!");
                    else if (ex.Message.IndexOf("Duplicated Tbl_Second!") > -1)
                        Global_Cls.Message_Sara(0, Global_Cls.MessageType.SError, false, "اطلاعات وارد شده در لیست بایگانی، حذفیات و یا قراردادها وجود دارد!");
                    else
                        Global_Cls.Message_Sara(0, Global_Cls.MessageType.SError, false, "لطفا با کمی فاصله دوباره تایید کنید!", ex.ToString());

                    return false;
                }
            else
                if (NewOrEditWire == 2)
                    try
                    {
                        TBL_Wire tbhf = DCD.TBL_Wires.First(thfh => thfh.WireCode.Equals(WrCd));

                        tbhf.WireCode = int.Parse( textBox_FN.Text );
                        tbhf.CreateDate = Global_Cls.ShamsiDateToMiladi(comboBox_Year1.Text, comboBox_Month1.Text, comboBox_day1.Text);
                        tbhf.WireName = textBox_WireName.Text;
                        tbhf.WireDsc = textBox_Specify.Text;
                        tbhf.WireAmount = double.Parse(textBox_Stock.Text);

                        DCD.SubmitChanges();

                    }
                    catch (Exception ex)
                    {
                        if (ex.Message.IndexOf("Duplicated Row!") > -1)
                            Global_Cls.Message_Sara(0, Global_Cls.MessageType.SError, false, "اطلاعات وارد شده تکراری است!");
                        else if (ex.Message.IndexOf("Duplicated Tbl_Second!") > -1)
                            Global_Cls.Message_Sara(0, Global_Cls.MessageType.SError, false, "اطلاعات وارد شده در لیست بایگانی، حذفیات و یا قراردادها وجود دارد!");
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


        private void textBox_FN_Leave(object sender, EventArgs e)
        {
            try { int i = Convert.ToInt32(textBox_FN.Text); }
            catch
            {
                Global_Cls.Message_Sara(0, Global_Cls.MessageType.SError, false, "کد کالا باید عددی باشد!");
                textBox_FN.Focus();
            }

        }

        private void panel_Date_Leave(object sender, EventArgs e)
        {
            if (Convert.ToInt16(comboBox_Month1.Text) > 6 && Convert.ToInt16(comboBox_day1.Text) == 31) comboBox_day1.Text = "30";
            if (Convert.ToInt16(comboBox_Month1.Text) == 12 && (Convert.ToInt16(comboBox_day1.Text) == 31 || Convert.ToInt16(comboBox_day1.Text) == 30)) comboBox_day1.Text = "29";
        }

        #endregion

        

    }
}
