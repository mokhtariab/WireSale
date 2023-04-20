namespace WireSales_Prj.MainForms
{
    partial class SelectWire_frm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelEx_Users = new DevComponents.DotNetBar.PanelEx();
            this.textBox_WireCode = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.textBox_WireName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.dataGridView_SelectWire = new System.Windows.Forms.DataGridView();
            this.WireCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WireName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelEx_Users.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_SelectWire)).BeginInit();
            this.SuspendLayout();
            // 
            // panelEx_Users
            // 
            this.panelEx_Users.CanvasColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panelEx_Users.Controls.Add(this.textBox_WireCode);
            this.panelEx_Users.Controls.Add(this.textBox_WireName);
            this.panelEx_Users.Controls.Add(this.dataGridView_SelectWire);
            this.panelEx_Users.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx_Users.Location = new System.Drawing.Point(0, 0);
            this.panelEx_Users.Margin = new System.Windows.Forms.Padding(0);
            this.panelEx_Users.Name = "panelEx_Users";
            this.panelEx_Users.Padding = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.panelEx_Users.ShowFocusRectangle = true;
            this.panelEx_Users.Size = new System.Drawing.Size(381, 488);
            this.panelEx_Users.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx_Users.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.panelEx_Users.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.CustomizeText;
            this.panelEx_Users.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx_Users.Style.BorderColor.Color = System.Drawing.Color.Olive;
            this.panelEx_Users.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx_Users.Style.GradientAngle = 90;
            this.panelEx_Users.TabIndex = 3;
            // 
            // textBox_WireCode
            // 
            this.textBox_WireCode.BackColor = System.Drawing.Color.Azure;
            // 
            // 
            // 
            this.textBox_WireCode.Border.Class = "TextBoxBorder";
            this.textBox_WireCode.ForeColor = System.Drawing.Color.Black;
            this.textBox_WireCode.Location = new System.Drawing.Point(201, 12);
            this.textBox_WireCode.Name = "textBox_WireCode";
            this.textBox_WireCode.Size = new System.Drawing.Size(142, 22);
            this.textBox_WireCode.TabIndex = 14;
            this.textBox_WireCode.TextChanged += new System.EventHandler(this.textBox_WireCode_TextChanged);
            // 
            // textBox_WireName
            // 
            this.textBox_WireName.BackColor = System.Drawing.Color.Azure;
            // 
            // 
            // 
            this.textBox_WireName.Border.Class = "TextBoxBorder";
            this.textBox_WireName.ForeColor = System.Drawing.Color.Black;
            this.textBox_WireName.Location = new System.Drawing.Point(53, 12);
            this.textBox_WireName.Name = "textBox_WireName";
            this.textBox_WireName.Size = new System.Drawing.Size(142, 22);
            this.textBox_WireName.TabIndex = 13;
            this.textBox_WireName.TextChanged += new System.EventHandler(this.textBox_WireCode_TextChanged);
            // 
            // dataGridView_SelectWire
            // 
            this.dataGridView_SelectWire.AllowUserToAddRows = false;
            this.dataGridView_SelectWire.AllowUserToDeleteRows = false;
            this.dataGridView_SelectWire.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_SelectWire.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.150944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_SelectWire.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_SelectWire.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_SelectWire.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.WireCode,
            this.WireName});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.471698F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_SelectWire.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView_SelectWire.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridView_SelectWire.Location = new System.Drawing.Point(27, 41);
            this.dataGridView_SelectWire.Margin = new System.Windows.Forms.Padding(0);
            this.dataGridView_SelectWire.Name = "dataGridView_SelectWire";
            this.dataGridView_SelectWire.ReadOnly = true;
            this.dataGridView_SelectWire.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridView_SelectWire.RowHeadersVisible = false;
            this.dataGridView_SelectWire.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_SelectWire.Size = new System.Drawing.Size(327, 422);
            this.dataGridView_SelectWire.TabIndex = 10;
            this.dataGridView_SelectWire.DoubleClick += new System.EventHandler(this.dataGridView_SelectWire_DoubleClick);
            // 
            // WireCode
            // 
            this.WireCode.DataPropertyName = "WireCode";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.WireCode.DefaultCellStyle = dataGridViewCellStyle2;
            this.WireCode.HeaderText = "کد کالا";
            this.WireCode.Name = "WireCode";
            this.WireCode.ReadOnly = true;
            this.WireCode.Width = 151;
            // 
            // WireName
            // 
            this.WireName.DataPropertyName = "WireName";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.WireName.DefaultCellStyle = dataGridViewCellStyle3;
            this.WireName.HeaderText = "نام کالا";
            this.WireName.Name = "WireName";
            this.WireName.ReadOnly = true;
            this.WireName.Width = 152;
            // 
            // SelectWire_frm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 488);
            this.Controls.Add(this.panelEx_Users);
            this.Font = new System.Drawing.Font("Tahoma", 8.150944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.MaximizeBox = false;
            this.Name = "SelectWire_frm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.Text = "انتخاب کالا";
            this.Load += new System.EventHandler(this.SelectWire_frm_Load);
            this.panelEx_Users.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_SelectWire)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx_Users;
        private DevComponents.DotNetBar.Controls.TextBoxX textBox_WireCode;
        private DevComponents.DotNetBar.Controls.TextBoxX textBox_WireName;
        private System.Windows.Forms.DataGridView dataGridView_SelectWire;
        private System.Windows.Forms.DataGridViewTextBoxColumn WireCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn WireName;
    }
}