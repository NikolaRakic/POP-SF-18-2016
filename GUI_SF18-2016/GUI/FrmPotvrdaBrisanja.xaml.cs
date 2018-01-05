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

namespace GUI_SF18_2016.GUI
{
    /// <summary>
    /// Interaction logic for FrmPotvrdaBrisanja.xaml
    /// </summary>
    public partial class FrmPotvrdaBrisanja : Window
    {
        public FrmPotvrdaBrisanja()
        {
            InitializeComponent();
        }

        private void btnNe_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnDa_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
