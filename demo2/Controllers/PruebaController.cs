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

namespace demo2.Controllers
{
    public class PruebaController : Controller
    {
        // GET: Prueba
        public ActionResult Index()
        {
            ViewBag.grafico = SplineUpdateEachSecond(1);
            ViewBag.grafico2 = SplineUpdateEachSecond(2);
            return View();
        }


        public Highcharts SplineUpdateEachSecond(int id)
        {
            List<object> points = new List<object>(20);
            DateTime now = DateTime.Now;
            Random rand = new Random();
            for (int i = -19; i <= 0; i++)
                points.Add(new { X = now.AddSeconds(i), Y = rand.NextDouble() });

            Highcharts chart = new Highcharts("chart_"+id)
                .SetOptions(new GlobalOptions { Global = new Global { UseUTC = false } })
                .InitChart(new Chart
                {
                    DefaultSeriesType = ChartTypes.Spline,
                    MarginRight = 10,
                    Events = new ChartEvents
                    {
                        Load = "ChartEventsLoad_" + id
                    }
                })
                .AddJavascripFunction("ChartEventsLoad_" + id,
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