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

namespace bioImagechart.View
{
    /// <summary>
    /// Interaction logic for PhaseView.xaml
    /// </summary>

    public partial class PhaseView : UserControl
    {
        chartlogic phasebound = chartlogic.GetInstance();
        public PhaseView()
        {
            InitializeComponent();
            DataContext = phasebound;
        }
    }
}
