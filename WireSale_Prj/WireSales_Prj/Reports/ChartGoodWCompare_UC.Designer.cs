namespace WireSales_Prj
{
    partial class ChartGoodWCompare_UC
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
            DevExpress.XtraCharts.XYDiagram xyDiagram2 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series4 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.Series series5 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.Series series6 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.XYDiagram xyDiagram3 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series7 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.Series series8 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.Series series9 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.XYDiagram xyDiagram4 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series10 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.Series series11 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.Series series12 = new DevExpress.XtraCharts.Series();
            this.chartControlCmp1 = new DevExpress.XtraCharts.ChartControl();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.PrintToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelExMain = new DevComponents.DotNetBar.PanelEx();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.expandableSplitter2 = new DevComponents.DotNetBar.ExpandableSplitter();
            this.chartControlCmp2 = new DevExpress.XtraCharts.ChartControl();
            this.expandableSplitter1 = new DevComponents.DotNetBar.ExpandableSplitter();
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.expandableSplitter3 = new DevComponents.DotNetBar.ExpandableSplitter();
            this.chartControlCmp4 = new DevExpress.XtraCharts.ChartControl();
            this.chartControlCmp3 = new DevExpress.XtraCharts.ChartControl();
            ((System.ComponentModel.ISupportInitialize)(this.chartControlCmp1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series3)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartControlCmp2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series6)).BeginInit();
            this.panelEx2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartControlCmp4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControlCmp3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series12)).BeginInit();
            this.SuspendLayout();
            // 
            // chartControlCmp1
            // 
            this.chartControlCmp1.ContextMenuStrip = this.contextMenuStrip;
            xyDiagram1.AxisX.Range.SideMarginsEnabled = true;
            xyDiagram1.AxisY.Range.SideMarginsEnabled = true;
            xyDiagram1.AxisY.NumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Number;
            xyDiagram1.AxisY.NumericOptions.Precision = 0;
            this.chartControlCmp1.Diagram = xyDiagram1;
            this.chartControlCmp1.Dock = System.Windows.Forms.DockStyle.Left;
            this.chartControlCmp1.Location = new System.Drawing.Point(0, 0);
            this.chartControlCmp1.Margin = new System.Windows.Forms.Padding(4);
            this.chartControlCmp1.Name = "chartControlCmp1";
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
            this.chartControlCmp1.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1,
        series2,
        series3};
            this.chartControlCmp1.SeriesTemplate.PointOptionsTypeName = "PointOptions";
            this.chartControlCmp1.Size = new System.Drawing.Size(576, 327);
            this.chartControlCmp1.TabIndex = 1;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PrintToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.contextMenuStrip.Size = new System.Drawing.Size(100, 28);
            // 
            // PrintToolStripMenuItem
            // 
            this.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem";
            this.PrintToolStripMenuItem.Size = new System.Drawing.Size(99, 24);
            this.PrintToolStripMenuItem.Text = "چاپ";
            this.PrintToolStripMenuItem.Click += new System.EventHandler(this.PrintToolStripMenuItem_Click);
            // 
            // panelExMain
            // 
            this.panelExMain.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelExMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelExMain.Font = new System.Drawing.Font("Tahoma", 14.26415F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.panelExMain.Location = new System.Drawing.Point(0, 0);
            this.panelExMain.Margin = new System.Windows.Forms.Padding(4);
            this.panelExMain.Name = "panelExMain";
            this.panelExMain.Size = new System.Drawing.Size(1095, 38);
            this.panelExMain.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelExMain.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelExMain.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelExMain.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelExMain.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelExMain.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelExMain.Style.GradientAngle = 90;
            this.panelExMain.TabIndex = 2;
            this.panelExMain.Text = "مقایسه";
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.Controls.Add(this.expandableSplitter2);
            this.panelEx1.Controls.Add(this.chartControlCmp2);
            this.panelEx1.Controls.Add(this.chartControlCmp1);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEx1.Location = new System.Drawing.Point(0, 38);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(1095, 327);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 3;
            this.panelEx1.Text = "panelEx1";
            // 
            // expandableSplitter2
            // 
            this.expandableSplitter2.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(45)))), ((int)(((byte)(150)))));
            this.expandableSplitter2.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter2.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandableSplitter2.ExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(45)))), ((int)(((byte)(150)))));
            this.expandableSplitter2.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter2.ExpandLineColor = System.Drawing.SystemColors.ControlText;
            this.expandableSplitter2.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandableSplitter2.GripDarkColor = System.Drawing.SystemColors.ControlText;
            this.expandableSplitter2.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandableSplitter2.GripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.expandableSplitter2.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.expandableSplitter2.HotBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(142)))), ((int)(((byte)(75)))));
            this.expandableSplitter2.HotBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(207)))), ((int)(((byte)(139)))));
            this.expandableSplitter2.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2;
            this.expandableSplitter2.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground;
            this.expandableSplitter2.HotExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(45)))), ((int)(((byte)(150)))));
            this.expandableSplitter2.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter2.HotExpandLineColor = System.Drawing.SystemColors.ControlText;
            this.expandableSplitter2.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandableSplitter2.HotGripDarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(45)))), ((int)(((byte)(150)))));
            this.expandableSplitter2.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter2.HotGripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.expandableSplitter2.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.expandableSplitter2.Location = new System.Drawing.Point(576, 0);
            this.expandableSplitter2.Name = "expandableSplitter2";
            this.expandableSplitter2.Size = new System.Drawing.Size(10, 327);
            this.expandableSplitter2.TabIndex = 3;
            this.expandableSplitter2.TabStop = false;
            // 
            // chartControlCmp2
            // 
            this.chartControlCmp2.ContextMenuStrip = this.contextMenuStrip;
            xyDiagram2.AxisX.Range.SideMarginsEnabled = true;
            xyDiagram2.AxisY.Range.SideMarginsEnabled = true;
            xyDiagram2.AxisY.NumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Number;
            xyDiagram2.AxisY.NumericOptions.Precision = 0;
            this.chartControlCmp2.Diagram = xyDiagram2;
            this.chartControlCmp2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartControlCmp2.Location = new System.Drawing.Point(576, 0);
            this.chartControlCmp2.Margin = new System.Windows.Forms.Padding(4);
            this.chartControlCmp2.Name = "chartControlCmp2";
            series4.Name = "Series 1";
            series4.LegendText = "موجودی";
            series4.ValueDataMembersSerializable = "WireAmount";
            series4.PointOptionsTypeName = "PointOptions";
            series5.Name = "Series 2";
            series5.LegendText = "خرید";
            series5.ValueDataMembersSerializable = "BuyAmount";
            series5.PointOptionsTypeName = "PointOptions";
            series6.Name = "Series 3";
            series6.LegendText = "فروش";
            series6.ValueDataMembersSerializable = "SaleAmount";
            series6.PointOptionsTypeName = "PointOptions";
            this.chartControlCmp2.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series4,
        series5,
        series6};
            this.chartControlCmp2.SeriesTemplate.PointOptionsTypeName = "PointOptions";
            this.chartControlCmp2.Size = new System.Drawing.Size(519, 327);
            this.chartControlCmp2.TabIndex = 2;
            // 
            // expandableSplitter1
            // 
            this.expandableSplitter1.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(45)))), ((int)(((byte)(150)))));
            this.expandableSplitter1.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandableSplitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.expandableSplitter1.ExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(45)))), ((int)(((byte)(150)))));
            this.expandableSplitter1.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.ExpandLineColor = System.Drawing.SystemColors.ControlText;
            this.expandableSplitter1.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandableSplitter1.GripDarkColor = System.Drawing.SystemColors.ControlText;
            this.expandableSplitter1.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandableSplitter1.GripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.expandableSplitter1.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.expandableSplitter1.HotBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(142)))), ((int)(((byte)(75)))));
            this.expandableSplitter1.HotBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(207)))), ((int)(((byte)(139)))));
            this.expandableSplitter1.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2;
            this.expandableSplitter1.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground;
            this.expandableSplitter1.HotExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(45)))), ((int)(((byte)(150)))));
            this.expandableSplitter1.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.HotExpandLineColor = System.Drawing.SystemColors.ControlText;
            this.expandableSplitter1.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandableSplitter1.HotGripDarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(45)))), ((int)(((byte)(150)))));
            this.expandableSplitter1.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.HotGripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.expandableSplitter1.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.expandableSplitter1.Location = new System.Drawing.Point(0, 365);
            this.expandableSplitter1.Name = "expandableSplitter1";
            this.expandableSplitter1.Size = new System.Drawing.Size(1095, 10);
            this.expandableSplitter1.TabIndex = 4;
            this.expandableSplitter1.TabStop = false;
            // 
            // panelEx2
            // 
            this.panelEx2.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx2.Controls.Add(this.expandableSplitter3);
            this.panelEx2.Controls.Add(this.chartControlCmp4);
            this.panelEx2.Controls.Add(this.chartControlCmp3);
            this.panelEx2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx2.Location = new System.Drawing.Point(0, 375);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Size = new System.Drawing.Size(1095, 518);
            this.panelEx2.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx2.Style.GradientAngle = 90;
            this.panelEx2.TabIndex = 5;
            this.panelEx2.Text = "panelEx2";
            // 
            // expandableSplitter3
            // 
            this.expandableSplitter3.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(45)))), ((int)(((byte)(150)))));
            this.expandableSplitter3.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter3.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandableSplitter3.ExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(45)))), ((int)(((byte)(150)))));
            this.expandableSplitter3.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter3.ExpandLineColor = System.Drawing.SystemColors.ControlText;
            this.expandableSplitter3.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandableSplitter3.GripDarkColor = System.Drawing.SystemColors.ControlText;
            this.expandableSplitter3.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandableSplitter3.GripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.expandableSplitter3.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.expandableSplitter3.HotBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(142)))), ((int)(((byte)(75)))));
            this.expandableSplitter3.HotBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(207)))), ((int)(((byte)(139)))));
            this.expandableSplitter3.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2;
            this.expandableSplitter3.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground;
            this.expandableSplitter3.HotExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(45)))), ((int)(((byte)(150)))));
            this.expandableSplitter3.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter3.HotExpandLineColor = System.Drawing.SystemColors.ControlText;
            this.expandableSplitter3.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandableSplitter3.HotGripDarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(45)))), ((int)(((byte)(150)))));
            this.expandableSplitter3.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter3.HotGripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.expandableSplitter3.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.expandableSplitter3.Location = new System.Drawing.Point(576, 0);
            this.expandableSplitter3.Name = "expandableSplitter3";
            this.expandableSplitter3.Size = new System.Drawing.Size(10, 518);
            this.expandableSplitter3.TabIndex = 3;
            this.expandableSplitter3.TabStop = false;
            // 
            // chartControlCmp4
            // 
            this.chartControlCmp4.ContextMenuStrip = this.contextMenuStrip;
            xyDiagram3.AxisX.Range.SideMarginsEnabled = true;
            xyDiagram3.AxisY.Range.SideMarginsEnabled = true;
            xyDiagram3.AxisY.NumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Number;
            xyDiagram3.AxisY.NumericOptions.Precision = 0;
            this.chartControlCmp4.Diagram = xyDiagram3;
            this.chartControlCmp4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartControlCmp4.Location = new System.Drawing.Point(576, 0);
            this.chartControlCmp4.Margin = new System.Windows.Forms.Padding(4);
            this.chartControlCmp4.Name = "chartControlCmp4";
            series7.Name = "Series 1";
            series7.LegendText = "موجودی";
            series7.ValueDataMembersSerializable = "WireAmount";
            series7.PointOptionsTypeName = "PointOptions";
            series8.Name = "Series 2";
            series8.LegendText = "خرید";
            series8.ValueDataMembersSerializable = "BuyAmount";
            series8.PointOptionsTypeName = "PointOptions";
            series9.Name = "Series 3";
            series9.LegendText = "فروش";
            series9.ValueDataMembersSerializable = "SaleAmount";
            series9.PointOptionsTypeName = "PointOptions";
            this.chartControlCmp4.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series7,
        series8,
        series9};
            this.chartControlCmp4.SeriesTemplate.PointOptionsTypeName = "PointOptions";
            this.chartControlCmp4.Size = new System.Drawing.Size(519, 518);
            this.chartControlCmp4.TabIndex = 2;
            // 
            // chartControlCmp3
            // 
            this.chartControlCmp3.ContextMenuStrip = this.contextMenuStrip;
            xyDiagram4.AxisX.Range.SideMarginsEnabled = true;
            xyDiagram4.AxisY.Range.SideMarginsEnabled = true;
            xyDiagram4.AxisY.NumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Number;
            xyDiagram4.AxisY.NumericOptions.Precision = 0;
            this.chartControlCmp3.Diagram = xyDiagram4;
            this.chartControlCmp3.Dock = System.Windows.Forms.DockStyle.Left;
            this.chartControlCmp3.Location = new System.Drawing.Point(0, 0);
            this.chartControlCmp3.Margin = new System.Windows.Forms.Padding(4);
            this.chartControlCmp3.Name = "chartControlCmp3";
            series10.Name = "Series 1";
            series10.LegendText = "موجودی";
            series10.ValueDataMembersSerializable = "WireAmount";
            series10.PointOptionsTypeName = "PointOptions";
            series11.Name = "Series 2";
            series11.LegendText = "خرید";
            series11.ValueDataMembersSerializable = "BuyAmount";
            series11.PointOptionsTypeName = "PointOptions";
            series12.Name = "Series 3";
            series12.LegendText = "فروش";
            series12.ValueDataMembersSerializable = "SaleAmount";
            series12.PointOptionsTypeName = "PointOptions";
            this.chartControlCmp3.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series10,
        series11,
        series12};
            this.chartControlCmp3.SeriesTemplate.PointOptionsTypeName = "PointOptions";
            this.chartControlCmp3.Size = new System.Drawing.Size(576, 518);
            this.chartControlCmp3.TabIndex = 1;
            // 
            // ChartGoodWCompare_UC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelEx2);
            this.Controls.Add(this.expandableSplitter1);
            this.Controls.Add(this.panelEx1);
            this.Controls.Add(this.panelExMain);
            this.Font = new System.Drawing.Font("Tahoma", 10.18868F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ChartGoodWCompare_UC";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(1095, 893);
            this.Load += new System.EventHandler(this.ChartGoodWCompare_UC_Load);
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControlCmp1)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            this.panelEx1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(xyDiagram2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControlCmp2)).EndInit();
            this.panelEx2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(xyDiagram3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControlCmp4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControlCmp3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraCharts.ChartControl chartControlCmp1;
        private DevComponents.DotNetBar.PanelEx panelExMain;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.ExpandableSplitter expandableSplitter2;
        public DevExpress.XtraCharts.ChartControl chartControlCmp2;
        private DevComponents.DotNetBar.ExpandableSplitter expandableSplitter1;
        private DevComponents.DotNetBar.PanelEx panelEx2;
        private DevComponents.DotNetBar.ExpandableSplitter expandableSplitter3;
        public DevExpress.XtraCharts.ChartControl chartControlCmp4;
        public DevExpress.XtraCharts.ChartControl chartControlCmp3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem PrintToolStripMenuItem;

    }
}
