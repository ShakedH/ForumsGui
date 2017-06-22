using Forums.ViewModel.ForumsAndGroups;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public SubForum CurrentSubForum { get; set; }
        public Discussion CurrentDiscussion { get; set; }
        public Member CurrentMember { get; set; }

        public MainWindow()
        {
            InitializeCurrentForum();
            InitializeComponent();
            UsernameTextBlock.Text = "Guest";
        }

        private void InitializeCurrentForum()
        {
            Member grandManager = new Member("a", "a", CurrentForum);
            CurrentForum = new Forum(grandManager, null, "Food");
            grandManager.SetAsManager(CurrentForum);
            CurrentForum.CreateSubForum("Italian Cuisine", grandManager.Username);
            CurrentForum.CreateSubForum("Israeli Cuisine", grandManager.Username);
            CurrentForum.CreateSubForum("Spanish Cuisine", grandManager.Username);
            CurrentForum.CreateSubForum("Kosher Cuisine", grandManager.Username);
            CurrentForum.CreateSubForum("Arabic Cuisine", grandManager.Username);
            CurrentForum.CreateSubForum("General Diet", grandManager.Username);
            CurrentForum.CreateSubForum("Vegetarian Diet", grandManager.Username);
            CurrentForum.CreateSubForum("Vegan Diet", grandManager.Username);
            SubForum testSF = CurrentForum.GetSubForum("Italian Cuisine");
            testSF.CreateDiscussion("Test Discussion 1", grandManager, "This is a test");
            testSF.CreateDiscussion("Test Discussion 2", grandManager, "This is a test");
        }

        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            new RegisterWindow(this).ShowDialog();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            new LoginWindow(this).ShowDialog();
        }

        private void SubForumsListView_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ListViewItem selectedItem = sender as ListViewItem;
            string subForumTopic = selectedItem.Content.ToString();
            try
            {
                CurrentSubForum = CurrentForum.GetSubForum(subForumTopic);
                Binding b = new Binding("CurrentSubForum.Discussions") { Source = this };
                DiscussionsListView.SetBinding(ItemsControl.ItemsSourceProperty, b);
                SubForumsListView.Visibility = Visibility.Hidden;
                DiscussionsListView.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void DiscussionsListView_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ListViewItem selectedItem = sender as ListViewItem;
            int discussionID = DiscussionsListView.SelectedIndex;
            try
            {
                CurrentDiscussion = CurrentForum.GetDiscussion(CurrentSubForum.Topic, discussionID);
            }
            catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
    }
}
