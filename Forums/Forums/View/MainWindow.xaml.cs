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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Forums.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Forum CurrentForum { get; set; }
        public Member CurrentMember { get; set; }

        public MainWindow()
        {
            //this.DataContext = m_CurrentForum;
            InitializeComponent();
            this.CurrentForum = new Forum(null, null, "Food");
            UsernameTextBlock.Text = "Guest";
        }

        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            new RegisterWindow(this).ShowDialog();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            new LoginWindow(this).ShowDialog();
            UsernameTextBlock.Text = this.CurrentMember.Name;
        }
    }
}
