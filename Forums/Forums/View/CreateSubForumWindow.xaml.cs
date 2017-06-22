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

namespace Forums.View
{
    /// <summary>
    /// Interaction logic for CreateSubForumWindow.xaml
    /// </summary>
    public partial class CreateSubForumWindow : Window
    {
        private MainWindow _mainWindow;

        public CreateSubForumWindow(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
