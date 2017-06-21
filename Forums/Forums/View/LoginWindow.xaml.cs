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
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private MainWindow m_MainWindow;

        public LoginWindow(MainWindow mainWindow)
        {
            InitializeComponent();
            this.m_MainWindow = mainWindow;
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordTextBox.Password;
            //if (this.m_MainWindow.CurrentForum.)
            //try
            //{
            //    this.m_MainWindow.CurrentForum.CreateMember(username, password);
            //}
            //catch (Exception)
            //{
            //    System.Windows.Forms.MessageBox.Show("Sorry! Username already exists.\nTry a different one");
            //}
        }
    }
}
