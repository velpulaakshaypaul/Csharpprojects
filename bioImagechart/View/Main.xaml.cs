using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using bioImagechart.ViewModel;

namespace bioImagechart.View
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    
    public partial class Main : Window
    {
        ViewUpdater timer;
        public Main()
        {
            DateTime start;
            TimeSpan time;
            start = DateTime.Now;

            timer = new ViewUpdater();
            
            InitializeComponent();
            time = DateTime.Now - start;
         //   Presenter P2 = new Presenter();
        //    P2.StartCalculation();
        //    P2.updateImage();
            timer.starttimer();

           // MessageBox.Show(time.Milliseconds.ToString().PadLeft(5, '0'));
        }
    }
}
