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
using System.Windows.Navigation;
using System.Windows.Shapes;
using bioImagechart.ViewModel;
using Abt.Controls.SciChart.Model.DataSeries;
using Abt.Controls.SciChart.Utility;
using Abt.Controls.SciChart.Visuals;
using Abt.Controls.SciChart.Rendering;

namespace bioImagechart.View
{
    /// <summary>
    /// Interaction logic for ChartView.xaml
    /// </summary>
    public partial class ChartView : UserControl
    {
       // chartlogic  _currInst;
        public ChartView()
        {
            InitializeComponent();
         //   _currInst = (chartlogic)this.Resources["chart"];
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        
        }

    }
}
