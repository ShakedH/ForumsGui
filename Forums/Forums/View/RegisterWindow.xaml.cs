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
        private MainWindow m_MainWindow;

        public RegisterWindow(MainWindow mainWindow)
        {
            InitializeComponent();
            this.m_MainWindow = mainWindow;
        }

        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordTextBox.Password;
            try
            {
                this.m_MainWindow.CurrentForum.CreateMember(username, password);
                this.m_MainWindow.CurrentMember = new Member(username, password, this.m_MainWindow.CurrentForum);
                this.m_MainWindow.UsernameTextBlock.Text = this.m_MainWindow.CurrentMember.Name;
            }
            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show("Sorry! Username already exists.\nTry a different one");
            }
        }
    }
}
