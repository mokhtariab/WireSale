namespace WireSales_Prj
{
    partial class ChartDateWReg_UC
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
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraCharts.XYDiagram xyDiagram1 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.Series series2 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.Series series3 = new DevExpress.XtraCharts.Series();
            this.chartControlReg = new DevExpress.XtraCharts.ChartControl();
            this.contextMenuStripPrint = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.PrintToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelExMain = new DevComponents.DotNetBar.PanelEx();
            ((System.ComponentModel.ISupportInitialize)(this.chartControlReg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series3)).BeginInit();
            this.contextMenuStripPrint.SuspendLayout();
            this.SuspendLayout();
            // 
            // chartControlReg
            // 
            this.chartControlReg.ContextMenuStrip = this.contextMenuStripPrint;
            xyDiagram1.AxisX.Range.SideMarginsEnabled = true;
            xyDiagram1.AxisY.Range.SideMarginsEnabled = true;
            xyDiagram1.AxisY.NumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Number;
            xyDiagram1.AxisY.NumericOptions.Precision = 0;
            this.chartControlReg.Diagram = xyDiagram1;
            this.chartControlReg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartControlReg.Location = new System.Drawing.Point(0, 49);
            this.chartControlReg.Name = "chartControlReg";
            series1.Name = "Series 1";
            series1.LegendText = "موجودی";
            series1.ValueDataMembersSerializable = "WireAmount";
            series1.PointOptionsTypeName = "PointOptions";
            series2.Name = "Series 2";
            series2.LegendText = "خرید";
            series2.ValueDataMembersSerializable = "BuyAmount";
            series2.PointOptionsTypeName = "PointOptions";
            series3.Name = "Series 3";
            series3.LegendText = "فروش";
            series3.ValueDataMembersSerializable = "SaleAmount";
            series3.PointOptionsTypeName = "PointOptions";
            this.chartControlReg.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1,
        series2,
        series3};
            this.chartControlReg.SeriesTemplate.PointOptionsTypeName = "PointOptions";
            this.chartControlReg.Size = new System.Drawing.Size(573, 389);
            this.chartControlReg.TabIndex = 1;
            // 
            // contextMenuStripPrint
            // 
            this.contextMenuStripPrint.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PrintToolStripMenuItem});
            this.contextMenuStripPrint.Name = "contextMenuStripPrint";
            this.contextMenuStripPrint.Size = new System.Drawing.Size(102, 26);
            // 
            // PrintToolStripMenuItem
            // 
            this.PrintToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 8.830189F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem";
            this.PrintToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
            this.PrintToolStripMenuItem.Text = "چاپ";
            this.PrintToolStripMenuItem.Click += new System.EventHandler(this.PrintToolStripMenuItem_Click);
            // 
            // panelExMain
            // 
            this.panelExMain.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelExMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelExMain.Font = new System.Drawing.Font("Tahoma", 10.86792F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.panelExMain.Location = new System.Drawing.Point(0, 0);
            this.panelExMain.Margin = new System.Windows.Forms.Padding(4);
            this.panelExMain.Name = "panelExMain";
            this.panelExMain.Size = new System.Drawing.Size(573, 49);
            this.panelExMain.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelExMain.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelExMain.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelExMain.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelExMain.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelExMain.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelExMain.Style.GradientAngle = 90;
            this.panelExMain.TabIndex = 3;
            this.panelExMain.Text = "گزارشات آماری دوره زمانی";
            // 
            // ChartDateWReg_UC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chartControlReg);
            this.Controls.Add(this.panelExMain);
            this.Name = "ChartDateWReg_UC";
            this.Size = new System.Drawing.Size(573, 438);
            this.Load += new System.EventHandler(this.ChartDateWReg_UC_Load);
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControlReg)).EndInit();
            this.contextMenuStripPrint.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraCharts.ChartControl chartControlReg;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripPrint;
        private System.Windows.Forms.ToolStripMenuItem PrintToolStripMenuItem;
        public DevComponents.DotNetBar.PanelEx panelExMain;

    }
}
