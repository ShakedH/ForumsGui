using Forums.ViewModel.ForumsAndGroups;
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
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        private MainWindow _mainWindow;

        public RegisterWindow(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
        }

        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordTextBox.Password;
            try
            {
                _mainWindow.CurrentForum.CreateMember(username, password);
                _mainWindow.CurrentMember = new Member(username, password, _mainWindow.CurrentForum);
                _mainWindow.UsernameTextBlock.Text = _mainWindow.CurrentMember.Username;
                System.Windows.Forms.MessageBox.Show("Signed up successfully!");
                Close();
            }
            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show("Oops! Username already exists.\nTry a different one");
            }
        }
    }
}
