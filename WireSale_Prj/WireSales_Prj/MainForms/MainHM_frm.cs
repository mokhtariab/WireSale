using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using DevComponents.DotNetBar;
using WireSales_Prj.Properties;
using Microsoft.VisualBasic.FileIO;
using System.Collections.ObjectModel;
using System.Globalization;

namespace WireSales_Prj
{
    public partial class MainHM_frm : Form
    {

        public MainHM_frm()
        {
            InitializeComponent();
        }

        
        #region All Events in Forms
        

        public string UserPermission, UserPrmHouseFor;
        private void MainHM_frm_Shown(object sender, EventArgs e)
        {
            //main color
            if (Global_Cls.ColorDisplay == 0) { checkBoxItem_Black.Checked = true; checkBoxItem_Black_Click(this, null); }
            else if (Global_Cls.ColorDisplay == 1) { checkBoxItem_Silver.Checked = true; checkBoxItem_Silver_Click(this, null); }
            else if (Global_Cls.ColorDisplay == 2) { checkBoxItem_Blue.Checked = true; checkBoxItem_Blue_Click(this, null); }
            //

            //WireSales_Prj.Properties.Settings.Default.Initialize( , Properties.Resources.ResourceManager.ResourceSetType.FullName = "\\Settings.settings";
            if (UserPermission != "" && UserPermission != "admin")
            {
                foreach (Control c in this.Controls["ribbonControl_Main"].Controls)
                {
                    if (c.Name != "")
                        foreach (Control c1 in this.Controls["ribbonControl_Main"].Controls[c.Name].Controls)
                        {
                            if (c1.Name != "")
                            {
                                string sp = UserPermission;
                                string st = "";
                                while (sp != "")
                                {
                                    st = sp.Substring(0, sp.IndexOf(","));
                                    sp = sp.Substring(sp.IndexOf(",") + 1, sp.Length - (sp.IndexOf(",") + 1));
                                    BaseItem item = (c1 as RibbonBar).GetItem(st);
                                    try
                                    {
                                        item.Enabled = false;
                                    }
                                    catch { }
                                }
                            }
                        }
                }
            }


            
            tabNameStr = "tabControlPanel_StartPnl,";

        }



        private void MainHM_frm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Global_Cls.Message_Sara(0, Global_Cls.MessageType.SConfirmation, true, "آیا از برنامه خارج می شوید؟"))
            {
                e.Cancel = true;
                return;
            }

            try
            {
                for (int i = 0; i < tabControl_Main.Tabs.Count; i++)
                    tabControl_Main.Tabs.RemoveAt(i);
            }
            catch { }


            //setting
            if (Global_Cls.BkpExitType == 2)
            {
                string RootStr = Global_Cls.MiladiDateToShamsi(DateTime.Today);
                RootStr = RootStr.Replace("/", "");
                RootStr = Global_Cls.BkpAutoRoot + "\\" + RootStr + " " + DateTime.Now.Hour.ToString() + "-" + DateTime.Now.Minute.ToString() + ".bak";
                Function_Cls.SetBackUpDBAll(RootStr);
            }
            if (Global_Cls.BkpExitType == 1) Func_CallTheBackUp();

            //main color
            if (checkBoxItem_Black.Checked) Global_Cls.ColorDisplay = 0;
            else if (checkBoxItem_Silver.Checked) Global_Cls.ColorDisplay = 1;
            else if (checkBoxItem_Blue.Checked) Global_Cls.ColorDisplay = 2;
            //


            timer_Main.Enabled = false;
            Function_Cls.WriteToXmlFiles();

        }


        private void MainHM_frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }


        public bool CloseAllOK = false;
        private void notifyToolStrip_ItemExit_Click(object sender, EventArgs e)
        {
            try
            {
                CloseAllOK = true;
                Close();
            }
            catch { }
        }

        private void MainHM_frm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Tab)
            {
                if (tabControl_Main.SelectedTabIndex == tabControl_Main.Tabs.Count - 1)
                    tabControl_Main.SelectedTabIndex = 0;
                else
                    tabControl_Main.SelectNextTab();
            }
        }

        private void buttonItem_Help_Click(object sender, EventArgs e)
        {
            //Process.Start("SaraHelp.chm");
        }


        #endregion



        #region Add Tabs to TabControl Functions & Add UserControl to Tabs

        //private int Cnt;
        public string tabNameStr;

        public void AddTabToTabControl(string tabName, string tabCaption, UserControl UC)
        {
            if (tabNameStr != null && tabNameStr.Contains(tabName + "Pnl,"))
            {
                tabControl_Main.SelectedPanel = (TabControlPanel)tabControl_Main.Controls[tabName + "Pnl"];
                UC.Dispose();
                return;
            }

            DevComponents.DotNetBar.TabItem NewTabItem = new DevComponents.DotNetBar.TabItem(this.components);
            DevComponents.DotNetBar.TabControlPanel NewTabControlPanel = new DevComponents.DotNetBar.TabControlPanel();

            NewTabControlPanel.Controls.Add(UC);
            UC.Dock = DockStyle.Fill;
            NewTabControlPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            NewTabControlPanel.Location = new System.Drawing.Point(0, 0);
            NewTabControlPanel.Padding = new System.Windows.Forms.Padding(1);
            NewTabControlPanel.Size = new System.Drawing.Size(778, 289);
            NewTabControlPanel.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            NewTabControlPanel.Style.BorderColor.Color = System.Drawing.SystemColors.ControlDarkDark;
            NewTabControlPanel.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right)
                 | DevComponents.DotNetBar.eBorderSide.Top)));
            NewTabControlPanel.Style.GradientAngle = -90;
            NewTabControlPanel.TabIndex = 1;

            NewTabControlPanel.TabItem = NewTabItem;
            NewTabItem.AttachedControl = NewTabControlPanel;

            
            //
            tabNameStr += tabName + "Pnl,";

            NewTabControlPanel.Name = tabName + "Pnl";
            NewTabControlPanel.Text = tabCaption;

            try
            {
                NewTabItem.Name = tabName + "Itm";
            }
            catch
            {
            }
            NewTabItem.Text = tabCaption;

            tabControl_Main.Controls.Add(NewTabControlPanel);
            tabControl_Main.Tabs.Add(NewTabItem);
            tabControl_Main.Refresh();

            tabControl_Main.SelectedPanel = NewTabControlPanel;


            /*Cnt = 1;
            string tabstr = tabName + "Pnl";

            if (tabNameStr != null && tabNameStr.Contains(tabstr))
            {
                Cnt = tabNameStr.IndexOf(tabstr) + tabstr.Length;
                string newtabstr = tabNameStr.Substring(Cnt, tabNameStr.Length - Cnt);
                Cnt = Convert.ToInt32(tabNameStr.Substring(Cnt, newtabstr.IndexOf(","))) + 1;
            }
            else
                tabNameStr += tabName + "Pnl" + Cnt + ",";

            NewTabControlPanel.Name = tabName + "Pnl" + Cnt;
            NewTabControlPanel.Text = tabCaption + Cnt;

            NewTabItem.Name = tabName + "Itm" + Cnt;
            NewTabItem.Text = tabCaption + Cnt;

            tabNameStr = tabNameStr.Replace(tabName + "Pnl" + (Cnt - 1), tabName + "Pnl" + Cnt);

            tabControl_Main.Controls.Add(NewTabControlPanel);
            tabControl_Main.Tabs.Add(NewTabItem);
            tabControl_Main.Refresh();

            tabControl_Main.SelectedPanel = NewTabControlPanel;*/
        }

        public void DeleteTabFromTabControl(DevComponents.DotNetBar.TabItem TabItemName)
        {
            tabControl_Main.Tabs.Remove(TabItemName);
            tabControl_Main.Controls.Remove(TabItemName.AttachedControl);
        }


        private void tabControl_Main_ControlRemoved(object sender, ControlEventArgs e)
        {
            tabNameStr = tabNameStr.Replace(tabControl_Main.SelectedPanel.Name + ",", "");
            tabControl_Main.Tabs.Capacity--;
        }
        
        private void buttonItem_Users_Click(object sender, EventArgs e)
        {
            ListUser_UC Uc = new ListUser_UC();
            AddTabToTabControl("User", " کاربران ", Uc);
        }

        private void buttonItem_ListWire_Click(object sender, EventArgs e)
        {
            Wire_UC Uc = new Wire_UC();
            AddTabToTabControl("WireUC", " لیست کالا - سیم ", Uc);
        }

        private void buttonItem_ListWireBuy_Click(object sender, EventArgs e)
        {
            WireBuy_UC Uc = new WireBuy_UC();
            AddTabToTabControl("WireBuy", " لیست خرید کالا - سیم ", Uc);
        }

        private void buttonItem_ListWireSale_Click(object sender, EventArgs e)
        {
            WireSale_UC Uc = new WireSale_UC();
            AddTabToTabControl("WireSale", " لیست فروش کالا - سیم ", Uc);
        }

        private void buttonItem_SearchWireBS_Click(object sender, EventArgs e)
        {
            SearchWire_UC Uc = new SearchWire_UC();
            AddTabToTabControl("SearchWire", " جستجوی پیشرفته کالا - سیم ", Uc);
        }

        private void buttonItem_FileRep_Click(object sender, EventArgs e)
        {
            ChartDateWire_UC Uc = new ChartDateWire_UC();
            AddTabToTabControl("ChartDateWire", " گزارش آماری دوره زمانی ", Uc);
        }

        private void buttonItem_CustomRep_Click(object sender, EventArgs e)
        {
            ChartGoodWire_UC Uc = new ChartGoodWire_UC();
            AddTabToTabControl("ChartGoodWire", " گزارش آماری کالاها ", Uc);
        }

        private void buttonItem_LdExcel_Click(object sender, EventArgs e)
        {
            ExportExcel_Uc Uc = new ExportExcel_Uc();
            AddTabToTabControl("ExportExcel", " کانورت ", Uc);
        }

        private void buttonItem_Actionbuysale_Click(object sender, EventArgs e)
        {
            WireAction_UC Uc = new WireAction_UC();
            AddTabToTabControl("WireAction", " لیست خرید و فروش کالا ", Uc);
        }

        #endregion



        #region Backup Or Restore Functions
        private void buttonItem_Bkp_Click(object sender, EventArgs e)
        {
            Func_CallTheBackUp();
        }

        private void Func_CallTheBackUp()
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "All Files(*.bak)|*.bak";
            if (dlg.ShowDialog() == DialogResult.OK)
                Function_Cls.SetBackUpDBAll(dlg.FileName);
        }
       
        private void buttonItem_Rst_Click(object sender, EventArgs e)
        {
            Func_CallTheRestore();
        }

        private void Func_CallTheRestore()
        {
            if (Global_Cls.Message_Sara(0, Global_Cls.MessageType.SConfirmation, true, "آیا نسبت به عمل بازیابی مطمئنید؟"))
                Function_Cls.Restore_Func(false);
        }
        #endregion



        #region All Settings
        private void checkBoxItem_Black_Click(object sender, EventArgs e)
        {
            ribbonControl_Main.Office2007ColorTable = DevComponents.DotNetBar.Rendering.eOffice2007ColorScheme.Black;
        }

        private void checkBoxItem_Silver_Click(object sender, EventArgs e)
        {
            ribbonControl_Main.Office2007ColorTable = DevComponents.DotNetBar.Rendering.eOffice2007ColorScheme.Silver;
        }

        private void checkBoxItem_Blue_Click(object sender, EventArgs e)
        {
            ribbonControl_Main.Office2007ColorTable = DevComponents.DotNetBar.Rendering.eOffice2007ColorScheme.Blue;
        }

        #endregion



        #region Tools

        private void buttonItem_Calc_Click(object sender, EventArgs e)
        {
            Process.Start("calc.exe");
        }

        private void buttonItem_Notepad_Click(object sender, EventArgs e)
        {
            Process.Start("NotePad");
        }

        #endregion



        #region Reports

        
        #endregion



        #region Date Time UserName
        private void timer_Main_Tick(object sender, EventArgs e)
        {
            label_main.Text = taghvim() + "           ساعت: " +
                DateTime.Now.TimeOfDay.Hours.ToString() + ":" +
                DateTime.Now.TimeOfDay.Minutes.ToString() + ":" +
                DateTime.Now.TimeOfDay.Seconds.ToString() + "         کاربر: " +
                Global_Cls.UserName_Exist.ToString();
            label_main.Left = bar_MainView.Width/2 - 250;
        }

        private string taghvim()
        {
            string TghvmStr = "";

            string[] fasl = new string[12];
            fasl[0] = "فروردین";
            fasl[1] = "اردیبهشت";
            fasl[2] = "خرداد";
            fasl[3] = "تیر";
            fasl[4] = "مرداد";
            fasl[5] = "شهریور";
            fasl[6] = "مهر";
            fasl[7] = "آبان";
            fasl[8] = "آذر";
            fasl[9] = "دی";
            fasl[10] = "بهمن";
            fasl[11] = "اسفند";
            string[] rooz = new string[7];
            rooz[0] = "شنبه"; rooz[1] = "یکشنبه"; rooz[2] = "دوشنبه"; rooz[3] = "سه شنبه"; rooz[4] = "چهارشنبه"; rooz[5] = "پنج شنبه"; rooz[6] = "جمعه";

            PersianCalendar farsi = new PersianCalendar();
            int a;
            DayOfWeek dd;

            dd = farsi.GetDayOfWeek(DateTime.Now);
            switch (dd.ToString())
            {
                case "Saturday":
                    TghvmStr = rooz[0].ToString();
                    break;
                case "Sunday":
                    TghvmStr = rooz[1].ToString();
                    break;
                case "Monday":
                    TghvmStr = rooz[2].ToString();
                    break;
                case "Tuesday":
                    TghvmStr = rooz[3].ToString();
                    break;
                case "Wednesday":
                    TghvmStr = rooz[4].ToString();
                    break;
                case "Thursday":
                    TghvmStr = rooz[5].ToString();
                    break;
                case "Friday":
                    TghvmStr = rooz[6].ToString();
                    break;
            }
            string str;
            a = farsi.GetDayOfMonth(DateTime.Now);
            TghvmStr += " " + Convert.ToString(a);
            str = Convert.ToString(a);
            a = farsi.GetMonth(DateTime.Now);
            TghvmStr += " " + fasl[a - 1];
            str += "/" + Convert.ToString(a);
            a = farsi.GetYear(DateTime.Now);
            TghvmStr += " " + Convert.ToString(a);
            str += "/" + Convert.ToString(a);

            return TghvmStr;
        }
        #endregion

        
       
        
        
        

    }
}
