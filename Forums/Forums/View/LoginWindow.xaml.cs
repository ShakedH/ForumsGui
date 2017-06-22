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
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private MainWindow _mainWindow;
        private Forum _currentForum;

        public LoginWindow(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
            _currentForum = _mainWindow.CurrentForum;
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordTextBox.Password;
            if (_currentForum.UserExists(username) && _currentForum.GetMember(username).Password == password)
            {
                _mainWindow.CurrentMember = new Member(username, password, _currentForum);
                _mainWindow.UsernameTextBlock.Text = _mainWindow.CurrentMember.Username;
                System.Windows.Forms.MessageBox.Show("Logged in successfully!");
                _mainWindow.CreateSubForumButton.Visibility = _currentForum.IsAdmin(_mainWindow.CurrentMember.Username) ? Visibility.Visible : Visibility.Hidden;
                Close();
            }
            else
                System.Windows.Forms.MessageBox.Show("Username or password are incorrect.");
        }
    }
}
