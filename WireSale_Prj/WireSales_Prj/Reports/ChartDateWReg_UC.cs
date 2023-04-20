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
    public partial class ChartDateWReg_UC : UserControl
    {
        public ChartDateWReg_UC()
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
        public int _DateType = 0;
        public string _Title = "";

        private void ChartDateWReg_UC_Load(object sender, EventArgs e)
        {
            LoadChart(_SelTypeChart, _AxAmountPercent, _SelSeries, _SortType, _Date1, _Date2, _DateType,_WCode, _Title);
        }

        private void SetTitle(string TitleStr)
        {
            //DevExpress.XtraCharts.ChartTitle df = new DevExpress.XtraCharts.ChartTitle();
            //df.Text = TitleStr;
            //chartControlReg.Titles.Add(df);
            panelExMain.Text = TitleStr;
        }

        public void LoadChart(int ChartType, bool Amount_Percent, string SelSeries, int SortType, DateTime Date1, DateTime Date2, int DateType, string WCodeStr, string TitleStr)
        {
            SetTitle(TitleStr);
            SetChartType(ChartType);

            if (ChartType != 3)
            {
                chartControlReg.Series[0].PointOptions.PointView = DevExpress.XtraCharts.PointView.Values;
                chartControlReg.Series[1].PointOptions.PointView = DevExpress.XtraCharts.PointView.Values;
                chartControlReg.Series[2].PointOptions.PointView = DevExpress.XtraCharts.PointView.Values;
            }
            else
            {
                chartControlReg.Series[0].PointOptions.PointView = DevExpress.XtraCharts.PointView.ArgumentAndValues;
                chartControlReg.Series[1].PointOptions.PointView = DevExpress.XtraCharts.PointView.ArgumentAndValues;
                chartControlReg.Series[2].PointOptions.PointView = DevExpress.XtraCharts.PointView.ArgumentAndValues;
                chartControlReg.Series[0].ShowInLegend = false;
                chartControlReg.Series[1].ShowInLegend = false;
                chartControlReg.Series[2].ShowInLegend = false;
            }


            //chartControlReg.Series[0].View.Color = Color.LawnGreen;
            //chartControlReg.Series[1].View.Color = Color.Beige;
            //chartControlReg.Series[2].View.Color = Color.MediumAquamarine;

            SetAmountPercent(Amount_Percent);
            //SortFunc(SortType);


            Data(SelSeries, Date1, Date2, DateType, WCodeStr);

        }

        private void SortFunc(int SortType)
        {
            //if (SortType == 1)
            //{
            //    chartControlReg.Series[0].SeriesPointsSorting = DevExpress.XtraCharts.SortingMode.Descending;
            //}
            //else
            //    if (SortType == 2)
            //    {
            //        chartControlReg.Series[1].SeriesPointsSorting = DevExpress.XtraCharts.SortingMode.Descending;
            //    }
            //    else if (SortType == 3)
            //    {
            //        chartControlReg.Series[2].SeriesPointsSorting = DevExpress.XtraCharts.SortingMode.Descending;
            //    }
        }

        private void SetAmountPercent(bool Amount_Percent)
        {
            if (Amount_Percent)
            {
                chartControlReg.Series[0].PointOptions.ValueNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Number;
                chartControlReg.Series[0].PointOptions.ValueNumericOptions.Precision = 0;
                //chartControlReg.Series[0].PointOptions.ArgumentNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.;
                //chartControlReg.Series[0].PointOptions.ArgumentNumericOptions.Precision = 0;

                chartControlReg.Series[1].PointOptions.ValueNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Number;
                chartControlReg.Series[1].PointOptions.ValueNumericOptions.Precision = 0;
                //chartControlReg.Series[1].PointOptions.ArgumentNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Percent;
                //chartControlReg.Series[1].PointOptions.ArgumentNumericOptions.Precision = 0;

                chartControlReg.Series[2].PointOptions.ValueNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Number;
                chartControlReg.Series[2].PointOptions.ValueNumericOptions.Precision = 0;
                //chartControlReg.Series[2].PointOptions.ArgumentNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Percent;
                //chartControlReg.Series[2].PointOptions.ArgumentNumericOptions.Precision = 0;
            }
            else
            {
                chartControlReg.Series[0].PointOptions.ValueNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Percent;
                chartControlReg.Series[0].PointOptions.ValueNumericOptions.Precision = 0;
                //chartControlReg.Series[0].PointOptions.ArgumentNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.;
                //chartControlReg.Series[0].PointOptions.ArgumentNumericOptions.Precision = 0;

                chartControlReg.Series[1].PointOptions.ValueNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Percent;
                chartControlReg.Series[1].PointOptions.ValueNumericOptions.Precision = 0;
                //chartControlReg.Series[1].PointOptions.ArgumentNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Percent;
                //chartControlReg.Series[1].PointOptions.ArgumentNumericOptions.Precision = 0;

                chartControlReg.Series[2].PointOptions.ValueNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Percent;
                chartControlReg.Series[2].PointOptions.ValueNumericOptions.Precision = 0;
                //chartControlReg.Series[2].PointOptions.ArgumentNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Percent;
                //chartControlReg.Series[2].PointOptions.ArgumentNumericOptions.Precision = 0;
            }
        }

        private void SetChartType(int ChartType)
        {
            if (ChartType == 1)
            {
                chartControlReg.Series[0].ChangeView(DevExpress.XtraCharts.ViewType.Bar);
                chartControlReg.Series[1].ChangeView(DevExpress.XtraCharts.ViewType.Bar);
                chartControlReg.Series[2].ChangeView(DevExpress.XtraCharts.ViewType.Bar);
            }
            else
                if (ChartType == 2)
                {
                    chartControlReg.Series[0].ChangeView(DevExpress.XtraCharts.ViewType.Line);
                    chartControlReg.Series[1].ChangeView(DevExpress.XtraCharts.ViewType.Line);
                    chartControlReg.Series[2].ChangeView(DevExpress.XtraCharts.ViewType.Line);
                }
                else
                    if (ChartType == 3)
                    {
                        chartControlReg.Series[0].ChangeView(DevExpress.XtraCharts.ViewType.Pie3D);
                        chartControlReg.Series[1].ChangeView(DevExpress.XtraCharts.ViewType.Pie3D);
                        chartControlReg.Series[2].ChangeView(DevExpress.XtraCharts.ViewType.Pie3D);
                    }
                    else
                        if (ChartType == 4)
                        {
                            chartControlReg.Series[0].ChangeView(DevExpress.XtraCharts.ViewType.ManhattanBar);
                            chartControlReg.Series[1].ChangeView(DevExpress.XtraCharts.ViewType.ManhattanBar);
                            chartControlReg.Series[2].ChangeView(DevExpress.XtraCharts.ViewType.ManhattanBar);
                        }
        }

        private void Data(string SelSeries, DateTime date1, DateTime date2, int DateType, string WireCodeStr)
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

            if (DateType == 0)
            {
                SqlCmd.CommandText =
                    "SELECT  ActionDate, Buy, sale, inventory into #tmp " +
                    "FROM     dbo.Vw_ActionWireList " +
                    "where ActionDate>='" + date1.ToShortDateString() + "' and ActionDate<='" + date2.ToShortDateString() + "'";
                if (WireCodeStr != "")
                    SqlCmd.CommandText += " and wirecode=" + WireCodeStr.Replace(";", "");
                SqlCmd.CommandText += " ORDER BY ActionDate ";

                if (WireCodeStr != "")
                    SqlCmd.CommandText += " select Inventory, dbo.MiladiToShamsi(ActionDate) ActionD into #tp from #tmp ";
                else SqlCmd.CommandText += " select dbo.CalculateAllInventory(ActionDate) as Inventory, dbo.MiladiToShamsi(ActionDate) ActionD into #tp from #tmp ";

                SqlCmd.CommandText += " select dbo.MiladiToShamsi(ActionDate) ActionDate, sum(sale) Sale,sum(buy) Buy, " +
                                    " (select top 1 Inventory from #tp where ActionD=dbo.MiladiToShamsi(ActionDate)) As Inventory " +
                                    " into #tmpFinal from #tmp " +
                                    " group by dbo.MiladiToShamsi(ActionDate) ";
                if (_AxAmountPercent)
                    SqlCmd.CommandText += " select ActionDate, Sale, Buy, Inventory  from #tmpFinal ";
                else SqlCmd.CommandText += " select ActionDate, round(Sale/(Sale+Buy+Inventory),2) as Sale, round(Buy/(Sale+Buy+Inventory),2) Buy, round(Inventory/(Sale+Buy+Inventory),2) Inventory  from #tmpFinal ";

                SqlCmd.CommandText += Order + " drop table #tmp, #tp, #tmpFinal ";

                SqlCmd.CommandType = CommandType.Text;
                SqlCmd.Connection = SqlConn;
                SqlConn.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(SqlCmd);

                DataSet gk = new DataSet();
                adapter.Fill(gk);

                chartControlReg.DataSource = gk.Tables[0];



                //DataClasses_MainDataContext ds = new DataClasses_MainDataContext();

                //var gg = from gh in ds.Vw_ActionWireLists
                //         where gh.ActionDate >= date1 && gh.ActionDate <= date2
                //         //group gh by new { gh.ActionDate } into gGroup
                //         select new
                //         {
                //             //gGroup.Key,
                //             ActionDate = Global_Cls.MiladiDateToShamsi(gh.ActionDate.Value),
                //             gh.WireCode,
                //             gh.Buy,
                //             gh.Sale,
                //             gh.Inventory
                //};
                // {
                //    gGroup.Key,
                //    ActionDate = Global_Cls.MiladiDateToShamsi(gGroup.Key.ActionDate.Value),
                //    WireCode = gGroup.Max(gh => gh.WireCode),
                //    Buy = gGroup.Sum(gh => gh.Buy),
                //    Sale = gGroup.Sum(gh => gh.Sale),
                //    Inventory = gGroup.Sum(gh => gh.Inventory)
                //};
                //chartControlReg.DataSource = gg;
                if (SelSeries.Contains("am;"))
                {
                    chartControlReg.Series[0].DataSource = gk.Tables[0]; //gg;
                    chartControlReg.Series[0].ArgumentDataMember = "ActionDate";
                    chartControlReg.Series[0].ValueDataMembers[0] = "Inventory";
                }
                if (SelSeries.Contains("by;"))
                {
                    chartControlReg.Series[1].DataSource = gk.Tables[0]; //gg;
                    chartControlReg.Series[1].ArgumentDataMember = "ActionDate";
                    chartControlReg.Series[1].ValueDataMembers[0] = "Buy";
                }
                if (SelSeries.Contains("sl;"))
                {
                    chartControlReg.Series[2].DataSource = gk.Tables[0]; //gg;
                    chartControlReg.Series[2].ArgumentDataMember = "ActionDate";
                    chartControlReg.Series[2].ValueDataMembers[0] = "Sale";
                }
            }
            else
                if (DateType == 1)
                {
                    SqlCmd.CommandText =
                        "SELECT  ActionDate, Buy, sale, inventory into #tmp " +
                        "FROM     dbo.Vw_ActionWireList " +
                        "where ActionDate>='" + date1.ToShortDateString() + "' and ActionDate<='" + date2.ToShortDateString() + "'";
                    if (WireCodeStr != "")
                        SqlCmd.CommandText += " and wirecode=" + WireCodeStr.Replace(";", "");
                    SqlCmd.CommandText += " ORDER BY ActionDate ";

                    if (WireCodeStr != "")
                        SqlCmd.CommandText += " select Inventory, substring(dbo.MiladiToShamsi(ActionDate),1,7) ActionD into #tp from #tmp ";
                    else SqlCmd.CommandText += " select dbo.CalculateAllInventory(ActionDate) as Inventory, substring(dbo.MiladiToShamsi(ActionDate),1,7) ActionD into #tp from #tmp ";

                    SqlCmd.CommandText += " select substring(dbo.MiladiToShamsi(ActionDate),1,7) ActionMonth, sum(sale) Sale,sum(buy) Buy, " +
                                        " (select top 1 Inventory from #tp where ActionD=substring(dbo.MiladiToShamsi(ActionDate),1,7) )  As Inventory " +
                                        " into #tmpFinal from #tmp " +
                                        " group by substring(dbo.MiladiToShamsi(ActionDate),1,7) ";

                    if (_AxAmountPercent)
                        SqlCmd.CommandText += " select ActionMonth, Sale, Buy, Inventory  from #tmpFinal ";
                    else SqlCmd.CommandText += " select ActionMonth, round(Sale/(Sale+Buy+Inventory),2) as Sale, round(Buy/(Sale+Buy+Inventory),2) Buy, round(Inventory/(Sale+Buy+Inventory),2) Inventory  from #tmpFinal ";

                    SqlCmd.CommandText += Order + " drop table #tmp, #tp, #tmpFinal ";

                    SqlCmd.CommandType = CommandType.Text;
                    SqlCmd.Connection = SqlConn;
                    SqlConn.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter(SqlCmd);

                    DataSet gk = new DataSet();
                    adapter.Fill(gk);

                    chartControlReg.DataSource = gk.Tables[0];
                    if (SelSeries.Contains("am;"))
                    {
                        chartControlReg.Series[0].DataSource = gk.Tables[0];
                        chartControlReg.Series[0].ArgumentDataMember = "ActionMonth";
                        chartControlReg.Series[0].ValueDataMembers[0] = "Inventory";
                    }
                    if (SelSeries.Contains("by;"))
                    {
                        chartControlReg.Series[1].DataSource = gk.Tables[0];
                        chartControlReg.Series[1].ArgumentDataMember = "ActionMonth";
                        chartControlReg.Series[1].ValueDataMembers[0] = "Buy";
                    }
                    if (SelSeries.Contains("sl;"))
                    {
                        chartControlReg.Series[2].DataSource = gk.Tables[0];
                        chartControlReg.Series[2].ArgumentDataMember = "ActionMonth";
                        chartControlReg.Series[2].ValueDataMembers[0] = "Sale";
                    }
                    SqlConn.Close();

                }
                else
                    if (DateType == 2)
                    {
                        SqlCmd.CommandText =
                             "SELECT  ActionDate, Buy, sale, inventory into #tmp " +
                             "FROM     dbo.Vw_ActionWireList " +
                             "where ActionDate>='" + date1.ToShortDateString() + "' and ActionDate<='" + date2.ToShortDateString() + "'";
                        if (WireCodeStr != "")
                            SqlCmd.CommandText += " and wirecode=" + WireCodeStr.Replace(";", "");
                        SqlCmd.CommandText += " ORDER BY ActionDate ";

                        if (WireCodeStr != "")
                            SqlCmd.CommandText += " select Inventory, substring(dbo.MiladiToShamsi(ActionDate),1,4) ActionD into #tp from #tmp ";
                        else SqlCmd.CommandText += " select dbo.CalculateAllInventory(ActionDate) as Inventory, substring(dbo.MiladiToShamsi(ActionDate),1,4) ActionD into #tp from #tmp ";

                        SqlCmd.CommandText += " select substring(dbo.MiladiToShamsi(ActionDate),1,4) ActionYear, sum(sale) Sale,sum(buy) Buy, " +
                                            " (select top 1 Inventory from #tp where ActionD=substring(dbo.MiladiToShamsi(ActionDate),1,4) )  As Inventory " +
                                            " into #tmpFinal from #tmp " +
                                            " group by substring(dbo.MiladiToShamsi(ActionDate),1,4) ";

                        if (_AxAmountPercent)
                            SqlCmd.CommandText += " select ActionYear, Sale, Buy, Inventory  from #tmpFinal ";
                        else SqlCmd.CommandText += " select ActionYear, round(Sale/(Sale+Buy+Inventory),2) as Sale, round(Buy/(Sale+Buy+Inventory),2) Buy, round(Inventory/(Sale+Buy+Inventory),2) Inventory  from #tmpFinal ";

                        SqlCmd.CommandText += Order + " drop table #tmp, #tp, #tmpFinal ";

                        SqlCmd.CommandType = CommandType.Text;
                        SqlCmd.Connection = SqlConn;
                        SqlConn.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(SqlCmd);

                        DataSet gm = new DataSet();
                        adapter.Fill(gm);


                        chartControlReg.DataSource = gm.Tables[0];
                        if (SelSeries.Contains("am;"))
                        {
                            chartControlReg.Series[0].DataSource = gm.Tables[0];
                            chartControlReg.Series[0].ArgumentDataMember = "ActionYear";
                            chartControlReg.Series[0].ValueDataMembers[0] = "Inventory";
                        }
                        if (SelSeries.Contains("by;"))
                        {
                            chartControlReg.Series[1].DataSource = gm.Tables[0];
                            chartControlReg.Series[1].ArgumentDataMember = "ActionYear";
                            chartControlReg.Series[1].ValueDataMembers[0] = "Buy";
                        }
                        if (SelSeries.Contains("sl;"))
                        {
                            chartControlReg.Series[2].DataSource = gm.Tables[0];
                            chartControlReg.Series[2].ArgumentDataMember = "ActionYear";
                            chartControlReg.Series[2].ValueDataMembers[0] = "Sale";
                        }


                        SqlConn.Close();

                    }
        }

        private void PrintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chartControlReg.ShowPrintPreview(DevExpress.XtraCharts.Printing.PrintSizeMode.Stretch);
        }

    }
}
