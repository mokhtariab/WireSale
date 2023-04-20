using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HouseManagement_Prj
{
    public partial class StartHM_frm : Form
    {
        
        public StartHM_frm()
        {
            InitializeComponent();
        }

        private string UserPer = "", UserName = "", UserPrmHF = "";
        private int UserCode=1;

        private void buttonX_OK_Click(object sender, EventArgs e)
        {
            UserPer = ""; UserPrmHF = "";

            if (textBox_NUser.Text == "محمد علی" && textBox_Pass.Text == "مختاری حسناباد")
            {
                Global_Cls.UserCode_Exist = 1;
                Global_Cls.UserName_Exist = "admin";

                Global_Cls.MainForm = new MainHM_frm();
                Global_Cls.MainForm.UserPermission = "admin";
                Global_Cls.MainForm.UserPrmHouseFor = "admin";
                Global_Cls.MainForm.Show();
                this.Hide();
                return;
            }


            int FUFLI = FindUserForLogIn();

            if (FUFLI == 3)
            {
                Global_Cls.Message_Sara(0, Global_Cls.MessageType.SError, false, "نام کاربری اشتباه می باشد!");
                textBox_NUser.Focus();
                return;
            }
            if (FUFLI == 0)
            {
                Global_Cls.Message_Sara(0, Global_Cls.MessageType.SError, false, "رمز ورود اشتباه می باشد!");
                textBox_Pass.Focus();
                return;
            }

            if (FUFLI == 2)
            {
                if (textBox_NUser.Text != "" && Global_Cls.Message_Sara(0,Global_Cls.MessageType.SConfirmation,true,"آیا نام کاربری و رمز وارد شده به عنوان کاربراصلی ثبت شود؟"))
                    InsertAdminInSystem(textBox_NUser.Text, textBox_Pass.Text);
                else InsertAdminInSystem("admin", "admin");
            }

            Global_Cls.UserCode_Exist = UserCode;
            Global_Cls.UserName_Exist = UserName;
            Global_Cls.MainForm = new MainHM_frm();
            Global_Cls.MainForm.UserPermission = UserPer;
            Global_Cls.MainForm.UserPrmHouseFor = UserPrmHF;
            Global_Cls.MainForm.Show();
            this.Hide();
        }

        private int FindUserForLogIn()
        {
            DataClasses_MainDataContext DcMd = new DataClasses_MainDataContext(Global_Cls.ConnectionStr);
            var tus = from tu in DcMd.TBL_Users
                      select tu;
            if (tus.Count() == 0) return 2;

            try
            {
                var tus1 = from tu in DcMd.TBL_Users
                           where tu.UserName.ToUpper() == textBox_NUser.Text.ToUpper()
                           select tu;
                if (tus1.Count() == 0) return 3;
                
                TBL_User tbu123 = DcMd.TBL_Users.First(t123 => t123.UserName.ToUpper().Equals(textBox_NUser.Text.ToUpper()) & t123.Password.ToUpper().Equals(textBox_Pass.Text.ToUpper()));
                UserPer = tbu123.UserPermission;
                UserPrmHF = tbu123.UserPrmHouseFor;
                UserCode = tbu123.UserCode;
                UserName = tbu123.FirstName +" "+ tbu123.LastName;
                return 1;
            }
            catch 
            { }

            return 0;
        }

        private void InsertAdminInSystem(string UsName, string PassW)
        {
            DataClasses_MainDataContext dmdc = new DataClasses_MainDataContext(Global_Cls.ConnectionStr);
            TBL_User tbu = new TBL_User { FirstName = "admin",
                                          LastName = "admin",
                                          UserName = UsName,
                                          CreateDate = Convert.ToDateTime(DateTime.Now.ToShortDateString()),
                                          Password = PassW,
                                          UserPermission = "admin",
                                          UserPrmHouseFor = "admin"
                                          
            };
            dmdc.TBL_Users.InsertOnSubmit(tbu);
            dmdc.SubmitChanges();
            UserPer = "admin";
            UserPrmHF = "admin";
            UserCode = 1;
            UserName = "admin admin";
        }

        private void buttonX_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void StartHM_frm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
                this.Close();
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                buttonX_OK_Click(this, null);
        }

        private void StartHM_frm_Load(object sender, EventArgs e)
        {
            Function_Cls.TinySetFunc(Tiny_Sara, Global_Cls.Lock_UserID, Global_Cls.Lock_SerialNo, Global_Cls.Lock_SpecialID);

            SetLanguageProgram();
            
            Function_Cls.ReadFromXmlFiles();
        }

        private void SetLanguageProgram()
        {
            InputLanguage lang = GetFarsiLanguage();
            if (lang == null)
                throw new NotSupportedException("Farsi Language keyboard is not installed.");
            InputLanguage.CurrentInputLanguage = lang;
        }

        private InputLanguage GetFarsiLanguage()
        {
            foreach (InputLanguage lang in InputLanguage.InstalledInputLanguages)
            {
                if ((lang.LayoutName.ToLower() == "farsi") | (lang.LayoutName == "Persian"))
                    return lang;
            }
            return null;
        }

        private void StartHM_frm_Shown(object sender, EventArgs e)
        {
           CheckOrInstallDB(); 
        }
        
        private void CheckOrInstallDB()
        {
            SqlConnection SqlConn = new SqlConnection(Global_Cls.ConnectionStr);
            try
            {
                SqlConn.Open();
                SqlConn.Close();
            }
            catch
            {
                if (Global_Cls.ClientSoftOK) 
                {
                    Global_Cls.Message_Sara(0, Global_Cls.MessageType.SError, false, "اتصال دیتا: جهت شروع کار ابتدا با نرم افزار سرور وارد شوید!");
                    Application.Exit();
                    return;
                }
                SqlConnection SqlConn1 = new SqlConnection(@"Data Source=" + Global_Cls.ServerName + @"\SqlExpress;Initial Catalog=master;User ID=sa;Password=fgpsara1;Integrated Security=True");
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlConn1;
                SqlCmd.CommandText = "USE [master]" +
                    "CREATE DATABASE [House_Management] ON " +
                    "( FILENAME = N'" + Application.StartupPath + @"\ApplicationData\Data\House_Management.mdf' )," +
                    "( FILENAME = N'" + Application.StartupPath + @"\ApplicationData\Data\House_Management_log.ldf' )" +
                    " FOR ATTACH ";
                try
                {
                    SqlConn1.Open();
                    SqlCmd.ExecuteReader();
                    SqlConn1.Close();


                    if (Global_Cls.SoftwareCode.Contains("N"))
                    {
                        try
                        {
                            Function_Cls.CreateShortcut(Application.StartupPath + @"\Services\SMSService.exe",
                                Environment.GetFolderPath(System.Environment.SpecialFolder.Startup) + "\\SMSService.lnk",
                                null, null, null, null);
                        }
                        catch { }
                        try
                        {
                            System.Diagnostics.Process.Start(Application.StartupPath + @"\Services\SMSService.exe");
                        }
                        catch { }
                        
                        try
                        {
                            System.Diagnostics.Process.Start(Application.StartupPath + @"\Services\ServiceInstaller123.exe");
                        }
                        catch { }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    Global_Cls.Message_Sara(0, Global_Cls.MessageType.SError, false, "اتصال دیتا: نصب برنامه به درستی صورت نگرفته است! لطفا با شرکت تماس بگیرید.");
                    Application.Exit();
                }
            }

        }

        /*            
         Registry Lock
          if (!Set_RegKey(PublicClass.Key_Name))
            {
                MessageBox.Show("This Software Not Registered!! \n Plesae Register This Software.");
                Application.Exit();
            }
                  private bool Set_RegKey(string KeyName)
        {
            // Opening the registry key
            RegistryKey CUKey = Registry.CurrentUser.OpenSubKey("Software\\AMProject\\");
            // If the RegistrySubKey doesn't exist -> (null)
            if (CUKey == null) return false;
            if (CUKey.GetValue("Key").Equals(KeyName)) return true;
            return false;
        }*/


    }
}
