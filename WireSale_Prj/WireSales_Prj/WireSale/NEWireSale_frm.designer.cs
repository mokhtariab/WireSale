namespace WireSales_Prj
{
    partial class NEWireSale_frm
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NEWireSale_frm));
            this.ribbonBar_NEHouse = new DevComponents.DotNetBar.RibbonBar();
            this.buttonItem_OK = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem_OkNext = new DevComponents.DotNetBar.ButtonItem();
            this.groupPanel_Main = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.panel_Date = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_Year1 = new System.Windows.Forms.ComboBox();
            this.comboBox_day1 = new System.Windows.Forms.ComboBox();
            this.comboBox_Month1 = new System.Windows.Forms.ComboBox();
            this.label_Date = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox_Stock = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label_FN = new System.Windows.Forms.Label();
            this.textBox_WireCode = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnWireName = new Janus.Windows.EditControls.UIButton();
            this.textBox_WireName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.groupPanel_Main.SuspendLayout();
            this.panel_Date.SuspendLayout();
            this.SuspendLayout();
            // 
            // ribbonBar_NEHouse
            // 
            this.ribbonBar_NEHouse.AutoOverflowEnabled = true;
            this.ribbonBar_NEHouse.AutoScroll = true;
            this.ribbonBar_NEHouse.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ribbonBar_NEHouse.Font = new System.Drawing.Font("Tahoma", 10.18868F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ribbonBar_NEHouse.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonItem_OK,
            this.buttonItem_OkNext});
            this.ribbonBar_NEHouse.Location = new System.Drawing.Point(0, 223);
            this.ribbonBar_NEHouse.Margin = new System.Windows.Forms.Padding(4);
            this.ribbonBar_NEHouse.Name = "ribbonBar_NEHouse";
            this.ribbonBar_NEHouse.Size = new System.Drawing.Size(434, 68);
            this.ribbonBar_NEHouse.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005;
            this.ribbonBar_NEHouse.TabIndex = 19;
            // 
            // 
            // 
            this.ribbonBar_NEHouse.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.ribbonBar_NEHouse.TitleStyle.CornerTypeBottomLeft = DevComponents.DotNetBar.eCornerType.Rounded;
            this.ribbonBar_NEHouse.TitleStyle.CornerTypeBottomRight = DevComponents.DotNetBar.eCornerType.Rounded;
            this.ribbonBar_NEHouse.TitleStyle.CornerTypeTopLeft = DevComponents.DotNetBar.eCornerType.Rounded;
            this.ribbonBar_NEHouse.TitleStyle.CornerTypeTopRight = DevComponents.DotNetBar.eCornerType.Rounded;
            this.ribbonBar_NEHouse.TitleVisible = false;
            // 
            // buttonItem_OK
            // 
            this.buttonItem_OK.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem_OK.FixedSize = new System.Drawing.Size(200, 65);
            this.buttonItem_OK.HotFontBold = true;
            this.buttonItem_OK.Image = ((System.Drawing.Image)(resources.GetObject("buttonItem_OK.Image")));
            this.buttonItem_OK.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.Default;
            this.buttonItem_OK.ImagePaddingHorizontal = 8;
            this.buttonItem_OK.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonItem_OK.Name = "buttonItem_OK";
            this.buttonItem_OK.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F2);
            this.buttonItem_OK.SubItemsExpandWidth = 20;
            this.buttonItem_OK.Text = "تایید و بسته شدن";
            this.buttonItem_OK.Tooltip = "F2";
            this.buttonItem_OK.Click += new System.EventHandler(this.buttonItem_OK_Click);
            // 
            // buttonItem_OkNext
            // 
            this.buttonItem_OkNext.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem_OkNext.FixedSize = new System.Drawing.Size(150, 40);
            this.buttonItem_OkNext.HotFontBold = true;
            this.buttonItem_OkNext.Image = ((System.Drawing.Image)(resources.GetObject("buttonItem_OkNext.Image")));
            this.buttonItem_OkNext.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.Default;
            this.buttonItem_OkNext.ImagePaddingHorizontal = 8;
            this.buttonItem_OkNext.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonItem_OkNext.Name = "buttonItem_OkNext";
            this.buttonItem_OkNext.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F3);
            this.buttonItem_OkNext.SubItemsExpandWidth = 14;
            this.buttonItem_OkNext.Text = "تایید و بعدی";
            this.buttonItem_OkNext.Tooltip = "F3";
            this.buttonItem_OkNext.Click += new System.EventHandler(this.buttonItem_OkNext_Click);
            // 
            // groupPanel_Main
            // 
            this.groupPanel_Main.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel_Main.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel_Main.Controls.Add(this.btnWireName);
            this.groupPanel_Main.Controls.Add(this.textBox_WireName);
            this.groupPanel_Main.Controls.Add(this.panel_Date);
            this.groupPanel_Main.Controls.Add(this.label_Date);
            this.groupPanel_Main.Controls.Add(this.label9);
            this.groupPanel_Main.Controls.Add(this.textBox_Stock);
            this.groupPanel_Main.Controls.Add(this.label4);
            this.groupPanel_Main.Controls.Add(this.label1);
            this.groupPanel_Main.Controls.Add(this.label_FN);
            this.groupPanel_Main.Controls.Add(this.textBox_WireCode);
            this.groupPanel_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel_Main.Font = new System.Drawing.Font("Tahoma", 8.150944F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.groupPanel_Main.IsShadowEnabled = true;
            this.groupPanel_Main.Location = new System.Drawing.Point(0, 0);
            this.groupPanel_Main.MinimumSize = new System.Drawing.Size(230, 84);
            this.groupPanel_Main.Name = "groupPanel_Main";
            this.groupPanel_Main.Size = new System.Drawing.Size(434, 223);
            // 
            // 
            // 
            this.groupPanel_Main.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel_Main.Style.BackColorGradientAngle = 90;
            this.groupPanel_Main.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel_Main.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel_Main.Style.BorderBottomWidth = 1;
            this.groupPanel_Main.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel_Main.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel_Main.Style.BorderLeftWidth = 1;
            this.groupPanel_Main.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel_Main.Style.BorderRightWidth = 1;
            this.groupPanel_Main.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel_Main.Style.BorderTopWidth = 1;
            this.groupPanel_Main.Style.CornerDiameter = 4;
            this.groupPanel_Main.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel_Main.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel_Main.Style.TextColor = System.Drawing.Color.Black;
            this.groupPanel_Main.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            this.groupPanel_Main.TabIndex = 20;
            this.groupPanel_Main.Text = "فروش جدید کالا";
            // 
            // panel_Date
            // 
            this.panel_Date.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_Date.Controls.Add(this.label3);
            this.panel_Date.Controls.Add(this.label2);
            this.panel_Date.Controls.Add(this.comboBox_Year1);
            this.panel_Date.Controls.Add(this.comboBox_day1);
            this.panel_Date.Controls.Add(this.comboBox_Month1);
            this.panel_Date.Location = new System.Drawing.Point(96, 97);
            this.panel_Date.Name = "panel_Date";
            this.panel_Date.Size = new System.Drawing.Size(168, 31);
            this.panel_Date.TabIndex = 293;
            this.panel_Date.Leave += new System.EventHandler(this.panel_Date_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(60, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 16);
            this.label3.TabIndex = 17;
            this.label3.Text = "/";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(110, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 16);
            this.label2.TabIndex = 16;
            this.label2.Text = "/";
            // 
            // comboBox_Year1
            // 
            this.comboBox_Year1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Year1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox_Year1.Font = new System.Drawing.Font("Tahoma", 8.150944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.comboBox_Year1.ForeColor = System.Drawing.Color.Black;
            this.comboBox_Year1.IntegralHeight = false;
            this.comboBox_Year1.Items.AddRange(new object[] {
            "1383",
            "1384",
            "1385",
            "1386",
            "1387",
            "1388",
            "1389",
            "1390",
            "1391",
            "1392",
            "1393",
            "1394",
            "1395",
            "1396",
            "1397",
            "1398",
            "1399",
            "1400"});
            this.comboBox_Year1.Location = new System.Drawing.Point(3, 3);
            this.comboBox_Year1.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox_Year1.Name = "comboBox_Year1";
            this.comboBox_Year1.Size = new System.Drawing.Size(60, 22);
            this.comboBox_Year1.TabIndex = 2;
            // 
            // comboBox_day1
            // 
            this.comboBox_day1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_day1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox_day1.Font = new System.Drawing.Font("Tahoma", 8.150944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.comboBox_day1.ForeColor = System.Drawing.Color.Black;
            this.comboBox_day1.IntegralHeight = false;
            this.comboBox_day1.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31"});
            this.comboBox_day1.Location = new System.Drawing.Point(124, 3);
            this.comboBox_day1.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox_day1.Name = "comboBox_day1";
            this.comboBox_day1.Size = new System.Drawing.Size(39, 22);
            this.comboBox_day1.TabIndex = 0;
            // 
            // comboBox_Month1
            // 
            this.comboBox_Month1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Month1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox_Month1.Font = new System.Drawing.Font("Tahoma", 8.150944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.comboBox_Month1.ForeColor = System.Drawing.Color.Black;
            this.comboBox_Month1.IntegralHeight = false;
            this.comboBox_Month1.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.comboBox_Month1.Location = new System.Drawing.Point(71, 3);
            this.comboBox_Month1.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox_Month1.Name = "comboBox_Month1";
            this.comboBox_Month1.Size = new System.Drawing.Size(40, 22);
            this.comboBox_Month1.TabIndex = 1;
            // 
            // label_Date
            // 
            this.label_Date.AutoSize = true;
            this.label_Date.BackColor = System.Drawing.Color.Transparent;
            this.label_Date.Font = new System.Drawing.Font("Tahoma", 10.18868F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label_Date.ForeColor = System.Drawing.Color.Black;
            this.label_Date.Location = new System.Drawing.Point(279, 104);
            this.label_Date.Name = "label_Date";
            this.label_Date.Size = new System.Drawing.Size(90, 19);
            this.label_Date.TabIndex = 292;
            this.label_Date.Text = "تاریخ فروش:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Tahoma", 10.18868F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(64, 148);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 19);
            this.label9.TabIndex = 291;
            this.label9.Text = "متر";
            // 
            // textBox_Stock
            // 
            // 
            // 
            // 
            this.textBox_Stock.Border.Class = "TextBoxBorder";
            this.textBox_Stock.Font = new System.Drawing.Font("Tahoma", 10.18868F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Stock.ForeColor = System.Drawing.Color.Black;
            this.textBox_Stock.Location = new System.Drawing.Point(96, 145);
            this.textBox_Stock.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_Stock.MaxLength = 10;
            this.textBox_Stock.Name = "textBox_Stock";
            this.textBox_Stock.Size = new System.Drawing.Size(168, 26);
            this.textBox_Stock.TabIndex = 2;
            this.textBox_Stock.Text = "0";
            this.textBox_Stock.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_Stock.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Subbuild_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Tahoma", 10.18868F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(279, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 19);
            this.label4.TabIndex = 287;
            this.label4.Text = "نام کالا:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10.18868F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(279, 149);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 19);
            this.label1.TabIndex = 285;
            this.label1.Text = "مقدار فروش:";
            // 
            // label_FN
            // 
            this.label_FN.AutoSize = true;
            this.label_FN.BackColor = System.Drawing.Color.Transparent;
            this.label_FN.Font = new System.Drawing.Font("Tahoma", 10.18868F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label_FN.ForeColor = System.Drawing.Color.Black;
            this.label_FN.Location = new System.Drawing.Point(279, 14);
            this.label_FN.Name = "label_FN";
            this.label_FN.Size = new System.Drawing.Size(60, 19);
            this.label_FN.TabIndex = 42;
            this.label_FN.Text = "کد کالا:";
            // 
            // textBox_WireCode
            // 
            this.textBox_WireCode.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            // 
            // 
            // 
            this.textBox_WireCode.Border.Class = "TextBoxBorder";
            this.textBox_WireCode.Font = new System.Drawing.Font("Tahoma", 10.18868F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_WireCode.ForeColor = System.Drawing.Color.Black;
            this.textBox_WireCode.Location = new System.Drawing.Point(131, 11);
            this.textBox_WireCode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_WireCode.MaxLength = 20;
            this.textBox_WireCode.Name = "textBox_WireCode";
            this.textBox_WireCode.ReadOnly = true;
            this.textBox_WireCode.Size = new System.Drawing.Size(99, 26);
            this.textBox_WireCode.TabIndex = 0;
            this.textBox_WireCode.Text = "0";
            this.textBox_WireCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnWireName
            // 
            this.btnWireName.Location = new System.Drawing.Point(41, 53);
            this.btnWireName.Name = "btnWireName";
            this.btnWireName.Size = new System.Drawing.Size(49, 23);
            this.btnWireName.TabIndex = 298;
            this.btnWireName.Text = "...";
            this.btnWireName.Click += new System.EventHandler(this.btnWireName_Click);
            // 
            // textBox_WireName
            // 
            // 
            // 
            // 
            this.textBox_WireName.Border.Class = "TextBoxBorder";
            this.textBox_WireName.Font = new System.Drawing.Font("Tahoma", 10.18868F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_WireName.ForeColor = System.Drawing.Color.Black;
            this.textBox_WireName.Location = new System.Drawing.Point(96, 52);
            this.textBox_WireName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_WireName.MaxLength = 0;
            this.textBox_WireName.Name = "textBox_WireName";
            this.textBox_WireName.ReadOnly = true;
            this.textBox_WireName.Size = new System.Drawing.Size(168, 26);
            this.textBox_WireName.TabIndex = 297;
            this.textBox_WireName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // NEWireSale_frm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 291);
            this.Controls.Add(this.groupPanel_Main);
            this.Controls.Add(this.ribbonBar_NEHouse);
            this.Font = new System.Drawing.Font("Tahoma", 10.18868F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "NEWireSale_frm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "فروش کالا (سیم)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NEHouse_frm_FormClosing);
            this.groupPanel_Main.ResumeLayout(false);
            this.groupPanel_Main.PerformLayout();
            this.panel_Date.ResumeLayout(false);
            this.panel_Date.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.RibbonBar ribbonBar_NEHouse;
        private DevComponents.DotNetBar.ButtonItem buttonItem_OK;
        private DevComponents.DotNetBar.ButtonItem buttonItem_OkNext;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel_Main;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_FN;
        private DevComponents.DotNetBar.Controls.TextBoxX textBox_WireCode;
        private System.Windows.Forms.Label label9;
        private DevComponents.DotNetBar.Controls.TextBoxX textBox_Stock;
        private System.Windows.Forms.Panel panel_Date;
        public System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_Year1;
        private System.Windows.Forms.ComboBox comboBox_day1;
        private System.Windows.Forms.ComboBox comboBox_Month1;
        private System.Windows.Forms.Label label_Date;
        private Janus.Windows.EditControls.UIButton btnWireName;
        private DevComponents.DotNetBar.Controls.TextBoxX textBox_WireName;
    }

}