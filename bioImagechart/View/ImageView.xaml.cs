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
    /// Interaction logic for ImageView.xaml
    /// </summary>
    public partial class ImageView : UserControl
    {
        Presenter _currentInstance;
        public ImageView()
        {
           InitializeComponent();
           _currentInstance = new Presenter();
           DataContext = _currentInstance;
          //  _currentInstance = (Presenter)this.Resources["check"];
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           //_currentInstance.verify_link();
           _currentInstance.updateImage();
         //  chartlogic.update();
        }
    }
}
