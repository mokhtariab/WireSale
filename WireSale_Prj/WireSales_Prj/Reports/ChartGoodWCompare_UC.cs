using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WireSales_Prj
{
    public partial class ChartGoodWCompare_UC: UserControl
    {
        public ChartGoodWCompare_UC()
        {
            InitializeComponent();
        }

        public string _WCode = "";
        public bool _AxAmountPercent = true;
        public int _SortType = 1;
        public string _SelSeries = "";
        public DateTime _Date1;
        public DateTime _Date2;
        public int _SelTypeChart = 1;
        public string _Title = "", _Title1 = "", _Title2 = "", _Title3 = "";

        private void ChartGoodWCompare_UC_Load(object sender, EventArgs e)
        {
            LoadChart(chartControlCmp1, _SelTypeChart, _AxAmountPercent, _SelSeries, _SortType, _Date1, _Date2, _WCode, _Title);
            LoadChart(chartControlCmp2, _SelTypeChart, _AxAmountPercent, _SelSeries, _SortType, _Date1.AddYears(-1), _Date2.AddYears(-1), _WCode, _Title1);
            LoadChart(chartControlCmp3, _SelTypeChart, _AxAmountPercent, _SelSeries, _SortType, _Date1.AddYears(-2), _Date2.AddYears(-2), _WCode, _Title2);
            LoadChart(chartControlCmp4, _SelTypeChart, _AxAmountPercent, _SelSeries, _SortType, _Date1.AddYears(-3), _Date2.AddYears(-3), _WCode, _Title3);
        }

        private void SetTitle(DevExpress.XtraCharts.ChartControl Chart, string TitleStr)
        {
            DevExpress.XtraCharts.ChartTitle df = new DevExpress.XtraCharts.ChartTitle();
            df.Font = new Font("Tahoma", 10.18868F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            df.Text = TitleStr;
            Chart.Titles.Add(df);
        }

        public void LoadChart(DevExpress.XtraCharts.ChartControl Chart, int ChartType, bool Amount_Percent, string SelSeries, int SortType, DateTime Date1, DateTime Date2, string WCodeStr, string TitleStr)
        {
            SetTitle(Chart, TitleStr);
            SetChartType(Chart, ChartType);
            
            
            Chart.Series[0].ShowInLegend = true;
            Chart.Series[1].ShowInLegend = true;
            Chart.Series[2].ShowInLegend = true;

            if (ChartType != 3)
            {
                Chart.Series[0].PointOptions.PointView = DevExpress.XtraCharts.PointView.Values;
                Chart.Series[1].PointOptions.PointView = DevExpress.XtraCharts.PointView.Values;
                Chart.Series[2].PointOptions.PointView = DevExpress.XtraCharts.PointView.Values;
            }
            else {
                Chart.Series[0].PointOptions.PointView = DevExpress.XtraCharts.PointView.ArgumentAndValues;
                Chart.Series[1].PointOptions.PointView = DevExpress.XtraCharts.PointView.ArgumentAndValues;
                Chart.Series[2].PointOptions.PointView = DevExpress.XtraCharts.PointView.ArgumentAndValues;
                Chart.Series[0].ShowInLegend = false;
                Chart.Series[1].ShowInLegend = false;
                Chart.Series[2].ShowInLegend = false;
            }


            //Chart.Series[0].View.Color = Color.LawnGreen;
            //Chart.Series[1].View.Color = Color.Beige;
            //Chart.Series[2].View.Color = Color.MediumAquamarine;

            SetAmountPercent(Chart, Amount_Percent);
            //SortFunc(Chart, SortType);


            Data(Chart, SelSeries, Date1, Date2, WCodeStr);

        }

        private void SortFunc(DevExpress.XtraCharts.ChartControl Chart, int SortType)
        {
            if (SortType == 1)
            {
                Chart.Series[0].SeriesPointsSorting = DevExpress.XtraCharts.SortingMode.Descending;
            }
            else
                if (SortType == 2)
                {
                    Chart.Series[1].SeriesPointsSorting = DevExpress.XtraCharts.SortingMode.Descending;
                }
                else if (SortType == 3)
                {
                    Chart.Series[2].SeriesPointsSorting = DevExpress.XtraCharts.SortingMode.Descending;
                }
        }

        private void SetAmountPercent(DevExpress.XtraCharts.ChartControl Chart, bool Amount_Percent)
        {
            if (Amount_Percent)
            {
                Chart.Series[0].PointOptions.ValueNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Number;
                Chart.Series[0].PointOptions.ValueNumericOptions.Precision = 0;
                //Chart.Series[0].PointOptions.ArgumentNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.;
                //Chart.Series[0].PointOptions.ArgumentNumericOptions.Precision = 0;

                Chart.Series[1].PointOptions.ValueNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Number;
                Chart.Series[1].PointOptions.ValueNumericOptions.Precision = 0;
                //Chart.Series[1].PointOptions.ArgumentNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Percent;
                //Chart.Series[1].PointOptions.ArgumentNumericOptions.Precision = 0;

                Chart.Series[2].PointOptions.ValueNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Number;
                Chart.Series[2].PointOptions.ValueNumericOptions.Precision = 0;
                //Chart.Series[2].PointOptions.ArgumentNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Percent;
                //Chart.Series[2].PointOptions.ArgumentNumericOptions.Precision = 0;
            }
            else
            {
                Chart.Series[0].PointOptions.ValueNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Percent;
                Chart.Series[0].PointOptions.ValueNumericOptions.Precision = 0;
                //Chart.Series[0].PointOptions.ArgumentNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.;
                //Chart.Series[0].PointOptions.ArgumentNumericOptions.Precision = 0;

                Chart.Series[1].PointOptions.ValueNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Percent;
                Chart.Series[1].PointOptions.ValueNumericOptions.Precision = 0;
                //Chart.Series[1].PointOptions.ArgumentNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Percent;
                //Chart.Series[1].PointOptions.ArgumentNumericOptions.Precision = 0;

                Chart.Series[2].PointOptions.ValueNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Percent;
                Chart.Series[2].PointOptions.ValueNumericOptions.Precision = 0;
                //Chart.Series[2].PointOptions.ArgumentNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Percent;
                //Chart.Series[2].PointOptions.ArgumentNumericOptions.Precision = 0;
            }
        }

        private void SetChartType(DevExpress.XtraCharts.ChartControl Chart, int ChartType)
        {
            if (ChartType == 1)
            {
                Chart.Series[0].ChangeView(DevExpress.XtraCharts.ViewType.Bar);
                Chart.Series[1].ChangeView(DevExpress.XtraCharts.ViewType.Bar);
                Chart.Series[2].ChangeView(DevExpress.XtraCharts.ViewType.Bar);
            }
            else
                if (ChartType == 2)
                {
                    Chart.Series[0].ChangeView(DevExpress.XtraCharts.ViewType.Line);
                    Chart.Series[1].ChangeView(DevExpress.XtraCharts.ViewType.Line);
                    Chart.Series[2].ChangeView(DevExpress.XtraCharts.ViewType.Line);
                }
                else
                    if (ChartType == 3)
                    {
                        Chart.Series[0].ChangeView(DevExpress.XtraCharts.ViewType.Pie3D);
                        Chart.Series[1].ChangeView(DevExpress.XtraCharts.ViewType.Pie3D);
                        Chart.Series[2].ChangeView(DevExpress.XtraCharts.ViewType.Pie3D);
                    }
                    else
                        if (ChartType == 4)
                        {
                            Chart.Series[0].ChangeView(DevExpress.XtraCharts.ViewType.ManhattanBar);
                            Chart.Series[1].ChangeView(DevExpress.XtraCharts.ViewType.ManhattanBar);
                            Chart.Series[2].ChangeView(DevExpress.XtraCharts.ViewType.ManhattanBar);
                        }
        }

        private void Data(DevExpress.XtraCharts.ChartControl Chart, string SelSeries, DateTime date1, DateTime date2, string WireCodeStr)
        {
            string Order = "";
            if (_SortType == 1)
                Order = " Order By Inventory desc ";
            else if (_SortType == 2)
                Order = " Order By Buy desc ";
            else if (_SortType == 3)
                Order = " Order By Sale desc ";
            

            
            SqlConnection SqlConn = new SqlConnection(Global_Cls.ConnectionStr);
            SqlCommand SqlCmd = new SqlCommand();
            try { WireCodeStr = WireCodeStr.Replace(";", ",").Remove(WireCodeStr.Length - 1); }
            catch { }
            SqlCmd.CommandText =
                "SELECT  WireCode, WireName, ActionDate, Buy, sale, inventory into #tmp " +
                "FROM     dbo.Vw_ActionWireList " +
                "where ActionDate>='" + date1.ToShortDateString() + "' and ActionDate<='" + date2.ToShortDateString() + "'";
            if (WireCodeStr != "")
                SqlCmd.CommandText += " and wirecode in (" + WireCodeStr + ")";
            SqlCmd.CommandText += " ORDER BY WireCode,ActionDate " +
                " select dbo.CalculateInventory(WireCode,ActionDate) as Inventory, WireCode as WireCodet  into #tp from #tmp";


            SqlCmd.CommandText += " select WireCode, WireName, sum(sale) Sale,sum(buy) Buy, " +
                                " (select top 1 Inventory from #tp where WireCodet = WireCode) As Inventory   " +
                                " into #tmpFinal from #tmp " +
                                " group by WireCode, WireName " +
                                " order by WireCode, WireName ";

            if (_AxAmountPercent)
                SqlCmd.CommandText += " select WireCode, WireName, Sale, Buy, Inventory  from #tmpFinal ";
            else SqlCmd.CommandText += " select WireCode, WireName, round(Sale/(Sale+Buy+Inventory),2) as Sale, round(Buy/(Sale+Buy+Inventory),2) Buy, round(Inventory/(Sale+Buy+Inventory),2) Inventory  from #tmpFinal ";

            SqlCmd.CommandText += Order + " drop table #tmp, #tp, #tmpFinal ";

            SqlCmd.CommandType = CommandType.Text;
            SqlCmd.Connection = SqlConn;
            SqlConn.Open();

            SqlDataAdapter adapter = new SqlDataAdapter(SqlCmd);

            DataSet gk = new DataSet();
            adapter.Fill(gk);

            Chart.DataSource = gk.Tables[0];

            //DataClasses_MainDataContext ds = new DataClasses_MainDataContext();
            //var gg = from gh in ds.Vw_ActionWireLists
            //         where gh.ActionDate >= date1 && gh.ActionDate <= date2
            //         group gh by new { gh.WireCode, gh.WireName } into gGroup
            //         select new
            //         {
            //             gGroup.Key,
            //             WireName = gGroup.Key.WireName,
            //             Buy = gGroup.Sum(gh => gh.Buy),
            //             Sale = gGroup.Sum(gh => gh.Sale),
            //             Inventory = gGroup.Sum(gh => gh.Inventory)
            //         };
            //{
            //             gGroup.Key,
            //             WireName = gGroup.Key.WireName,
            //             Buy = gGroup.Sum(gh => gh.Buy),
            //             Sale = gGroup.Sum(gh => gh.Sale),
            //             Inventory = gGroup.Sum(gh => gh.Inventory)
            //         };

            //if (WireCodeStr != "")
            //    gg = gg.Where(h => WireCodeStr.IndexOf(h.Key.WireCode.ToString() + ";") >= 0);

            //Chart.DataSource = gg;
            if (SelSeries.Contains("am;"))
            {
                Chart.Series[0].DataSource = gk.Tables[0]; //gg;
                Chart.Series[0].ArgumentDataMember = "WireName";
                Chart.Series[0].ValueDataMembers[0] = "Inventory";
            }
            if (SelSeries.Contains("by;"))
            {
                Chart.Series[1].DataSource = gk.Tables[0]; //gg;
                Chart.Series[1].ArgumentDataMember = "WireName";
                Chart.Series[1].ValueDataMembers[0] = "Buy";
            }
            if (SelSeries.Contains("sl;"))
            {
                Chart.Series[2].DataSource = gk.Tables[0]; //gg;
                Chart.Series[2].ArgumentDataMember = "WireName";
                Chart.Series[2].ValueDataMembers[0] = "Sale";
            }
        }

        private void PrintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (chartControlCmp1.Focused)
                chartControlCmp1.ShowPrintPreview(DevExpress.XtraCharts.Printing.PrintSizeMode.Stretch);
            else if (chartControlCmp2.Focused)
                chartControlCmp2.ShowPrintPreview(DevExpress.XtraCharts.Printing.PrintSizeMode.Stretch);
            else if (chartControlCmp3.Focused)
                chartControlCmp3.ShowPrintPreview(DevExpress.XtraCharts.Printing.PrintSizeMode.Stretch);
            else if (chartControlCmp4.Focused)
                chartControlCmp4.ShowPrintPreview(DevExpress.XtraCharts.Printing.PrintSizeMode.Stretch);
        }
    }
}
