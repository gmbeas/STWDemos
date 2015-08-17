using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Hardcodet.Wpf.TaskbarNotification;
using Application = System.Windows.Application;

namespace NotificacionArriendo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TaskbarIcon tbi = new TaskbarIcon();
        public MainWindow()
        {
           
            //var i = new Icon(Application.GetResourceStream(new Uri("/program_defaults.ico", UriKind.Relative)).Stream);

            InitializeComponent();
            
            //tbi.Icon = i;
            
            //string title = "WPF NotifyIcon";
            //string text = "This is a standard balloon";

            ////show balloon with built-in icon
            //tbi.ShowBalloonTip(title, text, BalloonIcon.Error);

            ////show balloon with custom icon
            //tbi.ShowBalloonTip(title, text, tbi.Icon);


            ////hide balloon
            //tbi.HideBalloonTip();

            ////tbi.Visibility = Visibility.Collapsed;


        }

        //private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        //{
        //    FancyBalloon balloon = new FancyBalloon();

            
        //    //show balloon and close it after 4 seconds
        //    tbi.ShowCustomBalloon(balloon, PopupAnimation.Slide, 4000);
        //}
    }
}
