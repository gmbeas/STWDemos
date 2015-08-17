using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DotNet.Highcharts;
using DotNet.Highcharts.Enums;
using DotNet.Highcharts.Helpers;
using DotNet.Highcharts.Options;
using Point = DotNet.Highcharts.Options.Point;

namespace Demos.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //Create Series 1
            var series1 = new Series();
            series1.Name = "Area Series 1";
            Point[] series1Points =
                {
                    new Point() {X = 0.0, Y = 0.0},
                    new Point() {X = 10.0, Y = 0.0},
                    new Point() {X = 10.0, Y = 10.0},
                    new Point() {X = 0.0, Y = 10.0}
                };
            series1.Data = new Data(series1Points);

            //Create Series 2
            var series2 = new Series();
            series2.Name = "Area Series 1";
            Point[] series2Points =
                {
                    new Point() {X = 5.0, Y = 5.0},
                    new Point() {X = 15.0, Y =5.0},
                    new Point() {X = 15.0, Y = 15.0},
                    new Point() {X = 5.0, Y = 15.0}
                };
            series2.Data = new Data(series2Points);

            //Create List of Series and Add both series to the collection
            var chartSeries = new List<Series>();
            chartSeries.Add(series1);
            chartSeries.Add(series2);

            //Create chart Model
            var chart1 = new Highcharts("Chart1");
            chart1
                .InitChart(new Chart() { DefaultSeriesType = ChartTypes.Area })
                .SetTitle(new Title() { Text = "Chart1" })
                .SetSeries(chartSeries.ToArray());

            //pass Chart1Model using ViewBag
            ViewBag.Chart1Model = chart1;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

           

            return View();
        }


        public Highcharts SplineUpdateEachSecond()
        {
            List<object> points = new List<object>(20);
            DateTime now = DateTime.Now;
            Random rand = new Random();
            for (int i = -19; i <= 0; i++)
                points.Add(new { X = now.AddSeconds(i), Y = rand.NextDouble() });

            Highcharts chart = new Highcharts("chart")
                .SetOptions(new GlobalOptions { Global = new Global { UseUTC = false } })
                .InitChart(new Chart
                {
                    DefaultSeriesType = ChartTypes.Spline,
                    MarginRight = 10,
                    Events = new ChartEvents
                    {
                        Load = "ChartEventsLoad"
                    }
                })
                .AddJavascripFunction("ChartEventsLoad",
                    @"// set up the updating of the chart each second
                                       var series = this.series[0];
                                       setInterval(function() {
                                          var x = (new Date()).getTime(), // current time
                                             y = Math.random();
                                          series.addPoint([x, y], true, true);
                                       }, 1000);")
                .SetTitle(new Title { Text = "Live random data" })
                .SetXAxis(new XAxis
                {
                    Type = AxisTypes.Datetime,
                    TickPixelInterval = 150
                })
                .SetYAxis(new YAxis
                {
                    Title = new YAxisTitle { Text = "Value" },
                    PlotLines = new[]
                    {
                        new YAxisPlotLines
                        {
                            Value = 0,
                            Width = 1,
                            Color = ColorTranslator.FromHtml("#808080")
                        }
                    }
                })
                .SetTooltip(new Tooltip { Formatter = "TooltipFormatter" })
                .AddJavascripFunction("TooltipFormatter",
                    @"return '<b>'+ this.series.name +'</b><br/>'+
                                       Highcharts.dateFormat('%Y-%m-%d %H:%M:%S', this.x) +'<br/>'+ 
                                       Highcharts.numberFormat(this.y, 2);")
                .SetLegend(new Legend { Enabled = false })
                .SetExporting(new Exporting { Enabled = false })
                .SetSeries(new Series
                {
                    Name = "Random data",
                    Data = new Data(points.ToArray())
                });

            return chart;
        }
    }
}