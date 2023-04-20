using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using WireSales_Prj.Properties;
using System.Runtime.InteropServices;
using System.Collections.Specialized;

namespace WireSales_Prj
{
    public class Global_Cls
    {
        public enum MessageType { SError, SWarning, SConfirmation, SInformation };
        
        static public int UserCode_Exist=1;  
        static public string UserName_Exist="";

        static public MainHM_frm MainForm = null;
        static public StartHM_frm StartForm = null;

        static public string SoftwareCode = "L2+S";
        //static public string SoftwareCode = "N2+S";
                                            //"L1";//"L2";"+S"
                                            //"N1";//"N2";"+S"
        static public bool ClientSoftOK = false;
        
        

        #region All Message Forms
        static public bool Message_Sara(int Code_Msg, MessageType TypeMsg, bool OK_Cancel, string Str_Msg)
        {
            return Message_Sara(Code_Msg, TypeMsg, OK_Cancel, Str_Msg, "");
        }

        static public bool Message_Sara(int Code_Msg, MessageType TypeMsg, bool OK_Cancel, string Str_Msg, string Str_Error)
        {
            MessageSara_Frm MSF = new MessageSara_Frm();

            MSF.label_MsgS.Text = Str_Msg;
            MSF.pictureBox_Error.Visible = (TypeMsg == MessageType.SError); MSF.pictureBox_Error.Top = 20;
            MSF.pictureBox_Warning.Visible = (TypeMsg == MessageType.SWarning); MSF.pictureBox_Warning.Top = 20;
            MSF.pictureBox_Configuration.Visible = (TypeMsg == MessageType.SConfirmation); MSF.pictureBox_Configuration.Top = 20;
            MSF.pictureBox_Information.Visible = (TypeMsg == MessageType.SInformation); MSF.pictureBox_Information.Top = 20;
            MSF.button_Cancel.Visible = OK_Cancel;

            if (Str_Error != "")
            {
                MSF.button_Details.Visible = true;
                MSF.label_Detail.Text = Str_Error;
            }

            if (!OK_Cancel) MSF.button_OK.Left = 133;

            if (MSF.ShowDialog() == System.Windows.Forms.DialogResult.OK) return true;
            return false;
        }
        #endregion


 


        #region Date Convertor & Control
        static public string MiladiDateToShamsi(DateTime MiladiDate)
        {
            if (MiladiDate == null) return "0000/00/00";
            System.Globalization.PersianCalendar farsi = new System.Globalization.PersianCalendar();
            int dd, mm, yy;
            string Ret;

            yy = farsi.GetYear(MiladiDate); 
              Ret = yy.ToString() + "/";
            mm = farsi.GetMonth(MiladiDate);
            if (mm < 10) Ret = Ret + "0" + mm.ToString() + "/";
            else Ret = Ret + mm.ToString() + "/";
            dd = farsi.GetDayOfMonth(MiladiDate);
            if (dd < 10) Ret = Ret + "0" + dd.ToString();
            else Ret = Ret + dd.ToString();

            return Ret; 

            
        }


        static public DateTime ShamsiDateToMiladi(string DateString, string year, string month, string dy)
        {

            if (DateString == "" && year == "" && month == "" && dy == "")
                return DateTime.MinValue;
            
            short yy, mm, dd;

            if (DateString!="")
            {
                yy = Convert.ToInt16(DateString.Substring(0, 4));
                mm = Convert.ToInt16(DateString.Substring(5, 2));
                dd = Convert.ToInt16(DateString.Substring(8, 2));
            }
            else 
            {
                yy = Convert.ToInt16(year);
                mm = Convert.ToInt16(month);
                dd = Convert.ToInt16(dy);
            }

            DateTime MiladiDate;
            System.Globalization.PersianCalendar farsi = new System.Globalization.PersianCalendar();
            MiladiDate = farsi.ToDateTime(yy, mm, dd,12,0,0,0);

            return MiladiDate;
            
            
        }
        static public DateTime ShamsiDateToMiladi(string DateString) { return ShamsiDateToMiladi(DateString, "", "", ""); }

        static public DateTime ShamsiDateToMiladi(string year, string mnth, string dy) { return ShamsiDateToMiladi("", year, mnth, dy); }

        static public bool CheckShamsiDate(string DateString)
        {
            int y, m, d;
            try
            {
                y = Convert.ToInt32(DateString.Substring(0, 4));
                m = Convert.ToInt32(DateString.Substring(5, 2));
                d = Convert.ToInt32(DateString.Substring(8, 2));
            }
            catch
            { return false; }

            if ((y < 1300 | y > 1420) | ((y % 4 != 3) & (m == 12) & (d == 30))
                | ((m >= 7) & (d == 31)) | (m > 12) | (d > 31) | (m == 0) | (d == 0))
                return false;
            return true;
        }


        static public string DigitSeparator(string txt)
        {
            if (txt == null) return "";
            txt = txt.Replace(",", "");
            string stx = "";
            int i = 1;
            while (txt.Length - 3 * i > 0)
            {
                stx = "," + txt.Substring(txt.Length - i * 3, 3) + stx;
                i++;
            }
            txt = txt.Substring(0, txt.Length - (i - 1) * 3) + stx;
            return txt;
        }


        static public string DigitSeparator(string txt1, string txt2)
        {
            return DigitSeparator(txt1) + "-" + DigitSeparator(txt2);
        }

        #endregion



        static public void SetWireCodeName(ref int WCode, ref string WName)
        {
            MainForms.SelectWire_frm SWf = new WireSales_Prj.MainForms.SelectWire_frm();
            SWf.ShowDialog();
            WCode = SWf.WCode;
            WName = SWf.WName;
        }
        
        static public string RootSaveLoad()
        {
            if (Global_Cls.ClientSoftOK)
                return "\\\\" + Global_Cls.ServerName + "\\SaRAServer";
            else 
                return Application.StartupPath;
        }

        static public string ChangeK(string txt)
        {
            txt = txt.Replace("ک", "ك");
            txt = txt.Replace("ی", "ي");
            return txt;
        }           
        
        #region All Parameter Settings

        //LocalConfig

        static public string Adver_separator = ",";

        static public string ServerName = "LocalHost";//"127.0.0.1";

        static public string ConnectionDef = @"Data Source=" + Global_Cls.ServerName + @"\sqlexpress;Integrated Security=True;";
//        static public string ConnectionDef = @"Data Source=" + Global_Cls.ServerName + @";Integrated Security=True;";

        static public string ServerNameForLock = "127.0.0.1";

        static public byte ColorDisplay = 0;

        static public StringCollection AllSelectField_WireSales;

        static public StringCollection AllSelectField_Wire;
        
        static public StringCollection AllSelectField_WAction;

        static public StringCollection AllSelectField_WireBuy;


        //MainConfig
        static public int BkpExitType = 0;

        static public string BkpAutoRoot = "D:\\BackUpData";

        static public string PssRstrr = "uvwxy";



        static public string ConnectionStr = "";

       
        
        //Lock Parameter

        //def mini
        static public string Lock_UserID = "4A1427124B175EE35469B9CB9CDF49";
        static public string Lock_SerialNo = "2009-8807-3471";
                
        //teh0001
        //static public string Lock_UserID = "37EEFCA121525BC7951595B1EF78FD2A";
        //static public string Lock_SerialNo = "2019-8809-1408";
            
        //static public string Lock_UserID = "37EEFCA121525BC7951595B1EF78FD2A";
        //static public string Lock_SerialNo = "2009-8809-1285";
            
        

        

        static public string Lock_SpecialID = "FGPCO881001SaRA";
        static public string Lock_Data = "FGPCO2";

        #endregion

    }

}
