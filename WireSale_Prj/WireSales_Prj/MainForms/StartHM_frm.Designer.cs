﻿namespace WireSales_Prj
{
    partial class StartHM_frm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartHM_frm));
            this.panelEx_main = new DevComponents.DotNetBar.PanelEx();
            this.TinyWire = new AxTINYLib.AxTiny();
            this.pictureBox_Logo = new System.Windows.Forms.PictureBox();
            this.reflectionLabel_Name = new DevComponents.DotNetBar.Controls.ReflectionLabel();
            this.panel_main = new System.Windows.Forms.Panel();
            this.textBox_Pass = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.textBox_NUser = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX_NUser = new DevComponents.DotNetBar.LabelX();
            this.pictureBox_Pass = new System.Windows.Forms.PictureBox();
            this.buttonX_Exit = new DevComponents.DotNetBar.ButtonX();
            this.buttonX_OK = new DevComponents.DotNetBar.ButtonX();
            this.labelX_Pass = new DevComponents.DotNetBar.LabelX();
            this.panelEx_main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TinyWire)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Logo)).BeginInit();
            this.panel_main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Pass)).BeginInit();
            this.SuspendLayout();
            // 
            // panelEx_main
            // 
            this.panelEx_main.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx_main.Controls.Add(this.TinyWire);
            this.panelEx_main.Controls.Add(this.pictureBox_Logo);
            this.panelEx_main.Controls.Add(this.reflectionLabel_Name);
            this.panelEx_main.Controls.Add(this.panel_main);
            this.panelEx_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx_main.Location = new System.Drawing.Point(0, 0);
            this.panelEx_main.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelEx_main.Name = "panelEx_main";
            this.panelEx_main.Size = new System.Drawing.Size(469, 187);
            this.panelEx_main.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx_main.Style.BackColor1.Alpha = ((byte)(100));
            this.panelEx_main.Style.BackColor1.Color = System.Drawing.Color.Azure;
            this.panelEx_main.Style.BackColor2.Color = System.Drawing.Color.Navy;
            this.panelEx_main.Style.BackgroundImagePosition = DevComponents.DotNetBar.eBackgroundImagePosition.BottomRight;
            this.panelEx_main.Style.Border = DevComponents.DotNetBar.eBorderType.DoubleLine;
            this.panelEx_main.Style.BorderColor.Color = System.Drawing.Color.Purple;
            this.panelEx_main.Style.BorderWidth = 8;
            this.panelEx_main.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx_main.Style.GradientAngle = 90;
            this.panelEx_main.TabIndex = 0;
            // 
            // TinyWire
            // 
            this.TinyWire.Enabled = true;
            this.TinyWire.Location = new System.Drawing.Point(12, 12);
            this.TinyWire.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TinyWire.Name = "TinyWire";
            this.TinyWire.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("TinyWire.OcxState")));
            this.TinyWire.Size = new System.Drawing.Size(100, 50);
            this.TinyWire.TabIndex = 22;
            this.TinyWire.Visible = false;
            // 
            // pictureBox_Logo
            // 
            this.pictureBox_Logo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_Logo.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_Logo.Image")));
            this.pictureBox_Logo.Location = new System.Drawing.Point(272, 10);
            this.pictureBox_Logo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox_Logo.Name = "pictureBox_Logo";
            this.pictureBox_Logo.Size = new System.Drawing.Size(186, 168);
            this.pictureBox_Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_Logo.TabIndex = 4;
            this.pictureBox_Logo.TabStop = false;
            // 
            // reflectionLabel_Name
            // 
            this.reflectionLabel_Name.Font = new System.Drawing.Font("B Arshia", 18.33962F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.reflectionLabel_Name.Location = new System.Drawing.Point(15, 4);
            this.reflectionLabel_Name.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.reflectionLabel_Name.Name = "reflectionLabel_Name";
            this.reflectionLabel_Name.Padding = new System.Windows.Forms.Padding(0, 0, 9, 0);
            this.reflectionLabel_Name.Size = new System.Drawing.Size(247, 63);
            this.reflectionLabel_Name.TabIndex = 3;
            this.reflectionLabel_Name.Text = "<b><font color=\"#B02B2C\"><font size=\"+15\">   ســــــــیم </font></font><font size" +
                "=\"+7\">  افزار نرم    </font></b>";
            // 
            // panel_main
            // 
            this.panel_main.Controls.Add(this.textBox_Pass);
            this.panel_main.Controls.Add(this.textBox_NUser);
            this.panel_main.Controls.Add(this.labelX_NUser);
            this.panel_main.Controls.Add(this.pictureBox_Pass);
            this.panel_main.Controls.Add(this.buttonX_Exit);
            this.panel_main.Controls.Add(this.buttonX_OK);
            this.panel_main.Controls.Add(this.labelX_Pass);
            this.panel_main.Location = new System.Drawing.Point(10, 74);
            this.panel_main.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel_main.Name = "panel_main";
            this.panel_main.Size = new System.Drawing.Size(252, 102);
            this.panel_main.TabIndex = 0;
            // 
            // textBox_Pass
            // 
            // 
            // 
            // 
            this.textBox_Pass.Border.Class = "TextBoxBorder";
            this.textBox_Pass.Location = new System.Drawing.Point(36, 35);
            this.textBox_Pass.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_Pass.Name = "textBox_Pass";
            this.textBox_Pass.PasswordChar = '*';
            this.textBox_Pass.Size = new System.Drawing.Size(150, 22);
            this.textBox_Pass.TabIndex = 1;
            // 
            // textBox_NUser
            // 
            // 
            // 
            // 
            this.textBox_NUser.Border.Class = "TextBoxBorder";
            this.textBox_NUser.Location = new System.Drawing.Point(36, 7);
            this.textBox_NUser.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_NUser.Name = "textBox_NUser";
            this.textBox_NUser.Size = new System.Drawing.Size(150, 22);
            this.textBox_NUser.TabIndex = 0;
            // 
            // labelX_NUser
            // 
            this.labelX_NUser.Font = new System.Drawing.Font("B Homa", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.labelX_NUser.ForeColor = System.Drawing.Color.Lime;
            this.labelX_NUser.Location = new System.Drawing.Point(165, 3);
            this.labelX_NUser.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelX_NUser.Name = "labelX_NUser";
            this.labelX_NUser.Size = new System.Drawing.Size(80, 33);
            this.labelX_NUser.TabIndex = 3;
            this.labelX_NUser.Text = "نام کاربر:";
            // 
            // pictureBox_Pass
            // 
            this.pictureBox_Pass.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_Pass.Image")));
            this.pictureBox_Pass.Location = new System.Drawing.Point(5, 33);
            this.pictureBox_Pass.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox_Pass.Name = "pictureBox_Pass";
            this.pictureBox_Pass.Size = new System.Drawing.Size(28, 26);
            this.pictureBox_Pass.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_Pass.TabIndex = 9;
            this.pictureBox_Pass.TabStop = false;
            // 
            // buttonX_Exit
            // 
            this.buttonX_Exit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX_Exit.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.buttonX_Exit.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.buttonX_Exit.Image = ((System.Drawing.Image)(resources.GetObject("buttonX_Exit.Image")));
            this.buttonX_Exit.Location = new System.Drawing.Point(19, 66);
            this.buttonX_Exit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonX_Exit.Name = "buttonX_Exit";
            this.buttonX_Exit.Size = new System.Drawing.Size(88, 29);
            this.buttonX_Exit.TabIndex = 3;
            this.buttonX_Exit.Text = "خروج";
            this.buttonX_Exit.Click += new System.EventHandler(this.buttonX_Exit_Click);
            // 
            // buttonX_OK
            // 
            this.buttonX_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.buttonX_OK.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.buttonX_OK.Image = ((System.Drawing.Image)(resources.GetObject("buttonX_OK.Image")));
            this.buttonX_OK.Location = new System.Drawing.Point(121, 66);
            this.buttonX_OK.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonX_OK.Name = "buttonX_OK";
            this.buttonX_OK.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F2);
            this.buttonX_OK.Size = new System.Drawing.Size(88, 29);
            this.buttonX_OK.TabIndex = 2;
            this.buttonX_OK.Text = "تایید";
            this.buttonX_OK.Click += new System.EventHandler(this.buttonX_OK_Click);
            // 
            // labelX_Pass
            // 
            this.labelX_Pass.Font = new System.Drawing.Font("B Homa", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.labelX_Pass.ForeColor = System.Drawing.Color.Lime;
            this.labelX_Pass.Location = new System.Drawing.Point(178, 32);
            this.labelX_Pass.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelX_Pass.Name = "labelX_Pass";
            this.labelX_Pass.Size = new System.Drawing.Size(67, 28);
            this.labelX_Pass.TabIndex = 4;
            this.labelX_Pass.Text = "رمز ورود:";
            // 
            // StartHM_frm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 187);
            this.Controls.Add(this.panelEx_main);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "StartHM_frm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "نرم افزار سیم فروشی";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.StartHM_frm_Load);
            this.Shown += new System.EventHandler(this.StartHM_frm_Shown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.StartHM_frm_KeyPress);
            this.panelEx_main.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TinyWire)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Logo)).EndInit();
            this.panel_main.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Pass)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx_main;
        private DevComponents.DotNetBar.LabelX labelX_NUser;
        private DevComponents.DotNetBar.LabelX labelX_Pass;
        private DevComponents.DotNetBar.Controls.TextBoxX textBox_Pass;
        private DevComponents.DotNetBar.Controls.TextBoxX textBox_NUser;
        private System.Windows.Forms.Panel panel_main;
        private DevComponents.DotNetBar.ButtonX buttonX_Exit;
        private DevComponents.DotNetBar.ButtonX buttonX_OK;
        private System.Windows.Forms.PictureBox pictureBox_Pass;
        private DevComponents.DotNetBar.Controls.ReflectionLabel reflectionLabel_Name;
        private System.Windows.Forms.PictureBox pictureBox_Logo;
        public AxTINYLib.AxTiny TinyWire;
    }
}