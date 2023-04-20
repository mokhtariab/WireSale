using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using WireSales_Prj.Properties;
using System.Configuration;
using System.IO;
using System.Xml.Linq;
using System.Collections.Specialized;
using System.Threading;

namespace WireSales_Prj
{
    class Function_Cls
    {

        #region BackUp & Restore DB

        static public void SetBackUpDBAll(string PathSaveBackup)
        {
            SqlConnection SqlConn = new SqlConnection(Global_Cls.ConnectionStr);
            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.CommandText = " BACKUP DATABASE [WireSales] TO DISK = N'" + PathSaveBackup + "' " +
                                 " WITH FORMAT, INIT, NAME = N'WireSales-Full Database Backup', SKIP, NOREWIND, NOUNLOAD,  STATS = 10 ";
            SqlCmd.CommandType = CommandType.Text;
            SqlCmd.Connection = SqlConn;

            SqlConn.Open();

            try
            {
                SqlCmd.ExecuteReader();
                
                Global_Cls.Message_Sara(0, Global_Cls.MessageType.SConfirmation, false, "عمل پشتیبانی با موفقیت انجام شد");
            }
            catch (Exception ex)
            {
                string ex_str = Convert.ToString(ex);
                if (ex_str.IndexOf("Cannot open backup device") > 0)
                    Global_Cls.Message_Sara(0, Global_Cls.MessageType.SError, false, "مسیر پشتیبانی را عوض کنید!");
                else
                    MessageBox.Show(Convert.ToString(ex));
            }
            SqlConn.Close();
        }

 
        static public void SetRestoreDBAll(string PathSaveRestore)
        {
            SqlConnection SqlConn = new SqlConnection(Global_Cls.ConnectionStr);
            SqlCommand SqlCmd = new SqlCommand();

            SqlCmd.CommandText =
                "use master " +
                "ALTER DATABASE [WireSales] SET SINGLE_USER WITH ROLLBACK IMMEDIATE " +
                "RESTORE DATABASE [WireSales] FROM  DISK = N'" + PathSaveRestore +
                "' WITH  FILE = 1,  NOUNLOAD,  REPLACE,  STATS = 10";
            //@"' WITH FILE = 1,  NOUNLOAD,  REPLACE, MOVE 'APPSERVER' TO 'C:\Program Files\Microsoft SQL Server\MSSQL.1\MSSQL\Data\APPSERVER_Data.MDF', " +
            //@"MOVE 'APPSERVER_Log' TO 'C:\Program Files\Microsoft SQL Server\MSSQL.1\MSSQL\Data\APPSERVER_Log.LDF' ";
            SqlCmd.CommandType = CommandType.Text;
            SqlCmd.Connection = SqlConn;

            SqlDataAdapter SDA = new SqlDataAdapter(SqlCmd.CommandText, SqlConn);
            SDA.UpdateCommand = new SqlCommand(SqlCmd.CommandText, SqlConn);

            SqlConn.Open();

            try
            {
                SDA.UpdateCommand.ExecuteReader();

                Global_Cls.Message_Sara(0, Global_Cls.MessageType.SConfirmation, false, "عمل بازیابی با موفقیت انجام شد");
            }
            catch (Exception ex)
            {
                string ex_str = Convert.ToString(ex);
                if (ex_str.IndexOf("Cannot open backup device") > 0)
                    Global_Cls.Message_Sara(0, Global_Cls.MessageType.SError, false, "مسیر بازیابی را عوض کنید!");
                else
                    MessageBox.Show(Convert.ToString(ex));
            }

            SqlConn.Close();
        }


        static public void Restore_Func(bool EditPass_EnterPass)
        {
            RstPass_frm RPF = new RstPass_frm();

            RPF.Edit_Enter = EditPass_EnterPass;
            if (EditPass_EnterPass)
            {
                RPF.groupPanel_NewPass.Visible = true;
                RPF.Height = 212; 
            }
            else
            {
                RPF.groupPanel_EnterPass.Visible = true;
                RPF.Height = 140;
            }

            RPF.ShowDialog();
        }

        #endregion


        
        #region Lock Set

        static public string GET_SUITABLE_PM(int iErrorNbr)
        {
            switch (iErrorNbr)
            {
                case 0:
                    return "ErrorNone";
                    break;
                case 1:
                    return "قفل متصل نمی باشد!";//"LockNotFound";
                    break;
                case 2:
                    return "اطلاعات قفل درست نمی باشد!";//"ErrorMissingKeyUser";
                    break;
                case 3:
                    return "قفل تفییر کرده است";//"LockChange";
                    break;
                case 4:
                    return "ErrorWriting";
                    break;
                case 5:
                    return "دستگاه سرور شناخته نشد";// "ErrorNetworkInit";
                    break;
                case 6:
                    return "سرویس قفل غیرفعال می باشد";//"ErrorSendRecieve";
                    break;
                case 7:
                    return "کاربر جدید در سیستم مجاز نمی باشد";// "ErrorLoginPermission";
                    break;
                case 8:
                    return "ErrorActiveXListening";
                    break;
                case 9:
                    return "ErrorInvalidData";
                    break;
                case 10:
                    return "ErrorInvalidLock";
                    break;
            }
            return "Unknown  Error";
        }


        static public bool TinySetFunc(AxTINYLib.AxTiny TinySara, string UserPass, string SrNo, string SpecID)
        {
            //TinyWire.Initialize = true;

            if (Global_Cls.SoftwareCode.Contains("N"))
            {
                TinySara.ServerIP = Global_Cls.ServerNameForLock;
                TinySara.NetWorkINIT = true;
                int jh = TinySara.OnLineUsers;
                TinySara.SetTrackingNtUser(true);
                if (TinySara.TinyErrCode == 0)
                {

                    TinySara.UserPassWord = UserPass;
                    TinySara.ShowTinyInfo = true;

                    if (TinySara.TinyErrCode == 0)
                    {
                        if (Global_Cls.Lock_SerialNo != TinySara.SerialNumber ||
                        Global_Cls.Lock_SpecialID != TinySara.SpecialID)
                        {
                            Global_Cls.Message_Sara(0, Global_Cls.MessageType.SError, false, "اطلاعات قفل همخوانی ندارد");
                            Application.Exit();
                            return false;
                        }

                        if (TinySara.DataPartition == "Test")
                        {
                            int Cnt = TinySara.Counter;
                            if (Cnt == 0)
                            {
                                Global_Cls.Message_Sara(0, Global_Cls.MessageType.SError, false, "مهلت تست تمام شده است! لطفا برای ادامه کار مجوز لازم را درخواست نمایید");
                                Application.Exit();
                                return false;
                            }
                            TinySara.Counter = Cnt - 1;
                        }
                        Global_Cls.Lock_Data = TinySara.DataPartition;

                    }
                    else
                    {
                        Global_Cls.Message_Sara(0, Global_Cls.MessageType.SError, false, GET_SUITABLE_PM(TinySara.TinyErrCode));
                        Application.Exit();
                        return false;
                    }
                }
                else
                {
                    Global_Cls.Message_Sara(0, Global_Cls.MessageType.SError, false, GET_SUITABLE_PM(TinySara.TinyErrCode));
                    Application.Exit();
                    return false;
                }

            }



            if (Global_Cls.SoftwareCode.Contains("L"))
            {
                TinySara.FirstTinyHID(UserPass);

                if (TinySara.TinyErrCode == 0)
                {

                    TinySara.UserPassWord = UserPass;
                    TinySara.ShowTinyInfo = true;

                    if (TinySara.TinyErrCode == 0)
                    {
                        if (Global_Cls.Lock_SerialNo != TinySara.GetSerialNumberHID() ||
                        Global_Cls.Lock_SpecialID != TinySara.GetSpecialIDHID())
                        {
                            Global_Cls.Message_Sara(0, Global_Cls.MessageType.SError, false, "اطلاعات قفل همخوانی ندارد");
                            Application.Exit();
                            return false;
                        }

                        if (TinySara.GetDataPartitionHID(0, 3) == "Test")
                        {
                            int Cnt = TinySara.GetCounterHID();
                            if (Cnt == 0)
                            {
                                Global_Cls.Message_Sara(0, Global_Cls.MessageType.SError, false, "مهلت تست تمام شده است! لطفا برای ادامه کار مجوز لازم را درخواست نمایید");
                                Application.Exit();
                                return false;
                            }
                            TinySara.SetCounterHID(Cnt - 1);
                        }
                        Global_Cls.Lock_Data = TinySara.GetDataPartitionHID(0, 7);

                    }
                    else
                    {
                        Global_Cls.Message_Sara(0, Global_Cls.MessageType.SError, false, GET_SUITABLE_PM(TinySara.TinyErrCode));
                        Application.Exit();
                        return false;
                    }
                }
                else
                {
                    Global_Cls.Message_Sara(0, Global_Cls.MessageType.SError, false, GET_SUITABLE_PM(TinySara.TinyErrCode));
                    Application.Exit();
                    return false;
                }

            }
            return true;

        }

        #endregion


        #region Read&Write ConfigFile & Settings

        //static public void ReadSettingFromDB()
        //{
        //    Global_Cls.AllSelectField_Wire = new StringCollection();
        //    Global_Cls.HouseFor = new StringCollection();
        //    Global_Cls.HouseForPrm = new StringCollection();
        //    Global_Cls.RequestFor = new StringCollection();

        //    DataClassesSecondDataContext da = new DataClassesSecondDataContext(Global_Cls.ConnectionStr);
        //    var result = da.TBL_SetDefaultSettings.First(c => c.SetID == 1);

        //    string TypeHousestr = result.TypeHouse;
        //    WriteToParameter(TypeHousestr, Global_Cls.TypeHouseAllCases);
            
        //    string HouseForStr = result.HouseFor;
        //    WriteToParameter(HouseForStr, Global_Cls.HouseFor);
            
        //    string RequestForStr = result.RequestFor;
        //    WriteToParameter(RequestForStr, Global_Cls.RequestFor);


        //    if (Global_Cls.MainForm.UserPrmHouseFor == "admin" || Global_Cls.MainForm.UserPrmHouseFor == "") 
        //        Global_Cls.HouseForPrm = Global_Cls.HouseFor;
        //    else
        //    {
        //        string UserPrmHouseForStr = Global_Cls.MainForm.UserPrmHouseFor;
        //        WriteToParameter(UserPrmHouseForStr, Global_Cls.HouseForPrm);
        //    }


        //}
        
        //public static void WriteSettingToDB()
        //{
        //    DataClassesSecondDataContext da = new DataClassesSecondDataContext(Global_Cls.ConnectionStr);
        //    var dd = da.TBL_SetDefaultSettings.First(c => c.SetID == 1);
        //    dd.TypeHouse = ReadFromParameter(Global_Cls.TypeHouseAllCases);
        //    dd.HouseFor = ReadFromParameter(Global_Cls.HouseFor);
        //    dd.RequestFor = ReadFromParameter(Global_Cls.RequestFor);
        //    da.SubmitChanges();
        //}

        
        public static void ReadFromXmlFiles()
        {
            Global_Cls.AllSelectField_Wire = new StringCollection();
            WriteToParameter(@"RowNo;WireCode;WireName;CreateDate;WireAmount;", Global_Cls.AllSelectField_Wire);
            Global_Cls.AllSelectField_WireBuy = new StringCollection();
            WriteToParameter(@"RowNo;WireCode;WireName;BuyDate;BuyAmount;", Global_Cls.AllSelectField_WireBuy);
            Global_Cls.AllSelectField_WireSales = new StringCollection();
            WriteToParameter(@"RowNo;WireCode;WireName;SaleDate;SaleAmount;", Global_Cls.AllSelectField_WireSales);
            Global_Cls.AllSelectField_WAction = new StringCollection();
            WriteToParameter(@"WireCode;WireName;ActionDate;Sale;Buy;Inventory;", Global_Cls.AllSelectField_WAction);

            if (File.Exists("LocalConfig.xml"))
            {
                XDocument loaded = XDocument.Load("LocalConfig.xml");

                var q = (from c in loaded.Descendants("setting")
                         select c).ToList();

                Global_Cls.Adver_separator = q.Find(j => j.FirstAttribute.Value == "Adver_separator").Value;
                Global_Cls.ServerName = q.Find(j => j.FirstAttribute.Value == "ServerName").Value;
                Global_Cls.ConnectionDef = q.Find(j => j.FirstAttribute.Value == "ConnectionDef").Value;
                Global_Cls.ServerNameForLock = q.Find(j => j.FirstAttribute.Value == "ServerNameForLock").Value;
                Global_Cls.ColorDisplay = Convert.ToByte(q.Find(j => j.FirstAttribute.Value == "ColorDisplay").Value);

                WriteToParameter(q.Find(j => j.FirstAttribute.Value == "AllSelectField_Wire").Value, Global_Cls.AllSelectField_Wire);
                WriteToParameter(q.Find(j => j.FirstAttribute.Value == "AllSelectField_WireBuy").Value, Global_Cls.AllSelectField_WireBuy);
                WriteToParameter(q.Find(j => j.FirstAttribute.Value == "AllSelectField_WireSales").Value, Global_Cls.AllSelectField_WireSales);
                WriteToParameter(q.Find(j => j.FirstAttribute.Value == "AllSelectField_WAction").Value, Global_Cls.AllSelectField_WAction);
            }
            
            
            string RootStr = Global_Cls.RootSaveLoad() + "\\MainConfig.xml";
            
            if (File.Exists(RootStr))
            {
                XDocument loaded = XDocument.Load(RootStr);

                var q = (from c in loaded.Descendants("setting")
                         select c).ToList();

                Global_Cls.BkpExitType = Convert.ToInt32(q.Find(j => j.FirstAttribute.Value == "BkpExitType").Value);
                Global_Cls.BkpAutoRoot = q.Find(j => j.FirstAttribute.Value == "BkpAutoRoot").Value;
                Global_Cls.PssRstrr = q.Find(j => j.FirstAttribute.Value == "PssRstrr").Value;
            }

        }

        public static void WriteToXmlFiles()
        {
            XElement xmlLoacl = new XElement("userSettings",
                        new XElement("setting",
                            new XAttribute("Name", "Adver_separator"),
                            new XElement("Value", Global_Cls.Adver_separator.ToString())
                        ),
                      new XElement("setting",
                            new XAttribute("Name", "ServerName"),
                            new XElement("Value", Global_Cls.ServerName)
                        ),
                        new XElement("setting",
                            new XAttribute("Name", "ConnectionDef"),
                            new XElement("Value", Global_Cls.ConnectionDef)
                        ),
                        new XElement("setting",
                            new XAttribute("Name", "ServerNameForLock"),
                            new XElement("Value", Global_Cls.ServerNameForLock)
                        ),
                        new XElement("setting",
                            new XAttribute("Name", "ColorDisplay"),
                            new XElement("Value", Global_Cls.ColorDisplay)
                        ),
                        new XElement("setting",
                            new XAttribute("Name", "AllSelectField_Wire"),
                            new XElement("Value", ReadFromParameter(Global_Cls.AllSelectField_Wire))
                        ),
                        new XElement("setting",
                            new XAttribute("Name", "AllSelectField_WAction"),
                            new XElement("Value", ReadFromParameter(Global_Cls.AllSelectField_WAction))
                        ),
                        new XElement("setting",
                            new XAttribute("Name", "AllSelectField_WireBuy"),
                            new XElement("Value", ReadFromParameter(Global_Cls.AllSelectField_WireBuy))
                        ),
                        new XElement("setting",
                            new XAttribute("Name", "AllSelectField_WireSales"),
                            new XElement("Value", ReadFromParameter(Global_Cls.AllSelectField_WireSales))
                        )
                    );
            xmlLoacl.Save(@"LocalConfig.xml");


            
            if (!Global_Cls.ClientSoftOK)
            {
                XElement XmlMain = new XElement("userSettings",
                        new XElement("setting",
                            new XAttribute("Name", "BkpExitType"),
                            new XElement("Value", Global_Cls.BkpExitType.ToString())
                        ),
                        new XElement("setting",
                            new XAttribute("Name", "BkpAutoRoot"),
                            new XElement("Value", Global_Cls.BkpAutoRoot)
                        ),
                        new XElement("setting",
                            new XAttribute("Name", "PssRstrr"),
                            new XElement("Value", Global_Cls.PssRstrr)
                        )
                    );

                XmlMain.Save(@"MainConfig.xml");
            }

        }


        private static void WriteToParameter(string StrEnter, StringCollection StrColect)
        {
            int i = 0;
            StrColect.Clear();
            while (StrEnter.Length > 0)
            {
                StrColect.Insert(i, StrEnter.Substring(0, StrEnter.IndexOf(";")));
                StrEnter = StrEnter.Remove(0, StrEnter.IndexOf(";") + 1);
                i++;
            }
        }

        public static string ReadFromParameter(StringCollection StrColect)
        {
            string Result = "";
            for (int i = 0; i < StrColect.Count; i++)
                Result += StrColect[i].ToString() + ";";
            return Result;
        }
        

        #endregion

        //public static void RunScript()
        //{
        //    SqlConnection SqlConn = new SqlConnection(Global_Cls.ConnectionStr);
        //    SqlCommand SqlCmd = new SqlCommand();

        //    SqlCmd.CommandText =
        //        " CREATE VIEW [dbo].[Vw_ActionBuySale] "+
        //        " AS "+
        //        " SELECT  TOP (100) PERCENT MAX(idbuy) AS idbuy, MAX(idsale) AS idsale, WireCode, WireName, ActionDate, SUM(Buy) AS Buy, SUM(Sale) AS Sale, dbo.CalculateInventory(WireCode, "+
        //        "                ActionDate) AS Inventory "+
        //        " FROM     dbo.Vw_WireAction "+
        //        " GROUP BY WireCode, WireName, ActionDate"+
        //        " ORDER BY WireCode, WireName, ActionDate";
        //    SqlCmd.CommandType = CommandType.Text;
        //    SqlCmd.Connection = SqlConn;

        //    SqlDataAdapter SDA = new SqlDataAdapter(SqlCmd.CommandText, SqlConn);
        //    SDA.UpdateCommand = new SqlCommand(SqlCmd.CommandText, SqlConn);

        //    SqlConn.Open();

        //    try
        //    {
        //        SDA.UpdateCommand.ExecuteReader();
        //    }
        //    catch (Exception ex)
        //    {
                
        //    }

        //    SqlConn.Close();
        //}
        

       //static public void CreateShortcut(string SourceFile, string ShortcutFile, string Description,
       //         string Arguments, string HotKey, string WorkingDirectory)
       // {
       //     // Check necessary parameters first:
       //     if (String.IsNullOrEmpty(SourceFile))
       //         throw new ArgumentNullException("SourceFile");
       //     if (String.IsNullOrEmpty(ShortcutFile))
       //         throw new ArgumentNullException("ShortcutFile");

       //     // Create WshShellClass instance:
       //     IWshRuntimeLibrary.WshShellClass wshShell = new IWshRuntimeLibrary.WshShellClass();

       //     // Create shortcut object:
       //     IWshRuntimeLibrary.IWshShortcut shorcut = (IWshRuntimeLibrary.IWshShortcut)wshShell.CreateShortcut(ShortcutFile);

       //     // Assign shortcut properties:
       //     shorcut.TargetPath = SourceFile;
       //     shorcut.Description = Description;
       //     if (!String.IsNullOrEmpty(Arguments))
       //         shorcut.Arguments = Arguments;
       //     if (!String.IsNullOrEmpty(HotKey))
       //         shorcut.Hotkey = HotKey;
       //     if (!String.IsNullOrEmpty(WorkingDirectory))
       //         shorcut.WorkingDirectory = WorkingDirectory;

       //     // Save the shortcut:
       //     shorcut.Save();
       // }

    }
}


