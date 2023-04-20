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
    public partial class ChartGoodWReg_UC : UserControl
    {
        public ChartGoodWReg_UC()
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
        public string _Title = "";

        private void ChartGoodWReg_UC_Load(object sender, EventArgs e)
        {
            LoadChart(_SelTypeChart, _AxAmountPercent, _SelSeries, _SortType, _Date1, _Date2, _WCode, _Title);
        }

        private void SetTitle(string TitleStr)
        {
            //DevExpress.XtraCharts.ChartTitle df = new DevExpress.XtraCharts.ChartTitle();
            //df.Text = TitleStr;
            //chartControlGdReg.Titles.Add(df);
            panelExMain.Text = TitleStr;

        }

        public void LoadChart(int ChartType, bool Amount_Percent, string SelSeries, int SortType, DateTime Date1, DateTime Date2, string WCodeStr, string TitleStr)
        {
            SetTitle(TitleStr);
            SetChartType(ChartType);
            
            if (ChartType != 3)
            {
                chartControlGdReg.Series[0].PointOptions.PointView = DevExpress.XtraCharts.PointView.Values;
                chartControlGdReg.Series[1].PointOptions.PointView = DevExpress.XtraCharts.PointView.Values;
                chartControlGdReg.Series[2].PointOptions.PointView = DevExpress.XtraCharts.PointView.Values;
            }
            else
            {
                chartControlGdReg.Series[0].PointOptions.PointView = DevExpress.XtraCharts.PointView.ArgumentAndValues;
                chartControlGdReg.Series[1].PointOptions.PointView = DevExpress.XtraCharts.PointView.ArgumentAndValues;
                chartControlGdReg.Series[2].PointOptions.PointView = DevExpress.XtraCharts.PointView.ArgumentAndValues;
                chartControlGdReg.Series[0].ShowInLegend = false;
                chartControlGdReg.Series[1].ShowInLegend = false;
                chartControlGdReg.Series[2].ShowInLegend = false;
            }


            //chartControlGdReg.Series[0].View.Color = Color.LawnGreen;
            //chartControlGdReg.Series[1].View.Color = Color.Beige;
            //chartControlGdReg.Series[2].View.Color = Color.MediumAquamarine;

            SetAmountPercent(Amount_Percent);
            //SortFunc(SortType);


            Data(SelSeries, Date1, Date2, WCodeStr);

        }

        private void SortFunc(int SortType)
        {
            if (SortType == 1)
            {
                chartControlGdReg.Series[0].SeriesPointsSorting = DevExpress.XtraCharts.SortingMode.Descending;
            }
            else
                if (SortType == 2)
                {
                    chartControlGdReg.Series[1].SeriesPointsSorting = DevExpress.XtraCharts.SortingMode.Descending;
                }
                else if (SortType == 3)
                {
                    chartControlGdReg.Series[2].SeriesPointsSorting = DevExpress.XtraCharts.SortingMode.Descending;
                }
        }

        private void SetAmountPercent(bool Amount_Percent)
        {
            if (Amount_Percent)
            {
                chartControlGdReg.Series[0].PointOptions.ValueNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Number;
                chartControlGdReg.Series[0].PointOptions.ValueNumericOptions.Precision = 0;
                //chartControlGdReg.Series[0].PointOptions.ArgumentNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.;
                //chartControlGdReg.Series[0].PointOptions.ArgumentNumericOptions.Precision = 0;

                chartControlGdReg.Series[1].PointOptions.ValueNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Number;
                chartControlGdReg.Series[1].PointOptions.ValueNumericOptions.Precision = 0;
                //chartControlGdReg.Series[1].PointOptions.ArgumentNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Percent;
                //chartControlGdReg.Series[1].PointOptions.ArgumentNumericOptions.Precision = 0;

                chartControlGdReg.Series[2].PointOptions.ValueNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Number;
                chartControlGdReg.Series[2].PointOptions.ValueNumericOptions.Precision = 0;
                //chartControlGdReg.Series[2].PointOptions.ArgumentNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Percent;
                //chartControlGdReg.Series[2].PointOptions.ArgumentNumericOptions.Precision = 0;
            }
            else
            {
                chartControlGdReg.Series[0].PointOptions.ValueNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Percent;
                chartControlGdReg.Series[0].PointOptions.ValueNumericOptions.Precision = 0;
                //chartControlGdReg.Series[0].PointOptions.ArgumentNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.;
                //chartControlGdReg.Series[0].PointOptions.ArgumentNumericOptions.Precision = 0;

                chartControlGdReg.Series[1].PointOptions.ValueNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Percent;
                chartControlGdReg.Series[1].PointOptions.ValueNumericOptions.Precision = 0;
                //chartControlGdReg.Series[1].PointOptions.ArgumentNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Percent;
                //chartControlGdReg.Series[1].PointOptions.ArgumentNumericOptions.Precision = 0;

                chartControlGdReg.Series[2].PointOptions.ValueNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Percent;
                chartControlGdReg.Series[2].PointOptions.ValueNumericOptions.Precision = 0;
                //chartControlGdReg.Series[2].PointOptions.ArgumentNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Percent;
                //chartControlGdReg.Series[2].PointOptions.ArgumentNumericOptions.Precision = 0;
            }
        }

        private void SetChartType(int ChartType)
        {
            if (ChartType == 1)
            {
                chartControlGdReg.Series[0].ChangeView(DevExpress.XtraCharts.ViewType.Bar);
                chartControlGdReg.Series[1].ChangeView(DevExpress.XtraCharts.ViewType.Bar);
                chartControlGdReg.Series[2].ChangeView(DevExpress.XtraCharts.ViewType.Bar);
            }
            else
                if (ChartType == 2)
                {
                    chartControlGdReg.Series[0].ChangeView(DevExpress.XtraCharts.ViewType.Line);
                    chartControlGdReg.Series[1].ChangeView(DevExpress.XtraCharts.ViewType.Line);
                    chartControlGdReg.Series[2].ChangeView(DevExpress.XtraCharts.ViewType.Line);
                }
                else
                    if (ChartType == 3)
                    {
                        chartControlGdReg.Series[0].ChangeView(DevExpress.XtraCharts.ViewType.Pie3D);
                        chartControlGdReg.Series[1].ChangeView(DevExpress.XtraCharts.ViewType.Pie3D);
                        chartControlGdReg.Series[2].ChangeView(DevExpress.XtraCharts.ViewType.Pie3D);
                    }
                    else
                        if (ChartType == 4)
                        {
                            chartControlGdReg.Series[0].ChangeView(DevExpress.XtraCharts.ViewType.ManhattanBar);
                            chartControlGdReg.Series[1].ChangeView(DevExpress.XtraCharts.ViewType.ManhattanBar);
                            chartControlGdReg.Series[2].ChangeView(DevExpress.XtraCharts.ViewType.ManhattanBar);
                        }
        }

        private void Data(string SelSeries, DateTime date1, DateTime date2, string WireCodeStr)
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
            try { WireCodeStr = WireCodeStr.Replace(";", ",").Remove(WireCodeStr.Length-1); }
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

            chartControlGdReg.DataSource = gk.Tables[0];


            //DataClasses_MainDataContext ds = new DataClasses_MainDataContext();
            //var gg = from gh in ds.Vw_ActionWireLists
            //         where gh.ActionDate >= date1 && gh.ActionDate <= date2 
            //         //group gh by new { gh.WireCode, gh.WireName } into gGroup
            //         select new
            //         {
            //             gh.WireCode,
            //             gh.WireName ,
            //             gh.Buy,
            //             gh.Sale,
            //             gh.Inventory
            //         };
            //{
            //             gGroup.Key,
            //             WireName = gGroup.Key.WireName,
            //             Buy = gGroup.Sum(gh => gh.Buy),
            //             Sale = gGroup.Sum(gh => gh.Sale),
            //             Inventory = gGroup.Sum(gh => gh.Inventory)
            //         };

            //if (WireCodeStr != "")
            //    gg = gg.Where(h => WireCodeStr.IndexOf(h.WireCode.ToString() + ";") >= 0);

            //chartControlGdReg.DataSource = gg;
            if (SelSeries.Contains("am;"))
            {
                chartControlGdReg.Series[0].DataSource = gk.Tables[0];//gg;
                chartControlGdReg.Series[0].ArgumentDataMember = "WireName";
                chartControlGdReg.Series[0].ValueDataMembers[0] = "Inventory";
            }
            if (SelSeries.Contains("by;"))
            {
                chartControlGdReg.Series[1].DataSource = gk.Tables[0];//gg;
                chartControlGdReg.Series[1].ArgumentDataMember = "WireName";
                chartControlGdReg.Series[1].ValueDataMembers[0] = "Buy";
            }
            if (SelSeries.Contains("sl;"))
            {
                chartControlGdReg.Series[2].DataSource = gk.Tables[0];//gg;
                chartControlGdReg.Series[2].ArgumentDataMember = "WireName";
                chartControlGdReg.Series[2].ValueDataMembers[0] = "Sale";
            }
        }

        private void PrintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chartControlGdReg.ShowPrintPreview(DevExpress.XtraCharts.Printing.PrintSizeMode.Stretch);
        }
    }
}
