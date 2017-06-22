using Forums.ViewModel;
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
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private SubForum _currentSubForum;
        private Member _currentMember;

        public event PropertyChangedEventHandler PropertyChanged;
        public Forum CurrentForum { get; set; }
        public SubForum CurrentSubForum { get; set; }
        public Discussion CurrentDiscussion { get; set; }
        public Member CurrentMember { get; set; }

        public MainWindow()
        {
            this.DataContext = this;
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
            testSF.CreateDiscussion("Test Discussion 1", grandManager, "This is an opening message 1");
            testSF.CreateDiscussion("Test Discussion 2", grandManager, "This is an opening message 2");
            testSF.CreateDiscussion("Test Discussion 3", grandManager, "This is an opening message 3");
            testSF.CreateDiscussion("Test Discussion 4", grandManager, "This is an opening message 4");
            testSF.CreateDiscussion("Test Discussion 5", grandManager, "This is an opening message 5");
            Discussion testDiscussion = testSF.GetDiscussion(0);
            testDiscussion.AddMessage(grandManager, "This is a test message 1");
            testDiscussion.AddMessage(grandManager, "This is a test message 2");
            testDiscussion.AddMessage(grandManager, "This is a test message 3");
            testDiscussion.AddMessage(grandManager, "This is a test message 4");
            testDiscussion.AddMessage(grandManager, "This is a test message 5");
        }

        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            new RegisterWindow(this).ShowDialog();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            new LoginWindow(this).ShowDialog();
        }

        private void CreateSubForumButton_Click(object sender, RoutedEventArgs e)
        {
            new CreateSubForumWindow(this).ShowDialog();
        }

        private void SubForumsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                SubForum selectedSubForum = e.AddedItems[0] as SubForum;
                CurrentSubForum = CurrentForum.GetSubForum(selectedSubForum.Topic);
                Binding b = new Binding("CurrentSubForum.Discussions") { Source = this };
                DiscussionsListView.SetBinding(ItemsControl.ItemsSourceProperty, b);
                SubForumsListView.Visibility = Visibility.Hidden;
                DiscussionsListView.Visibility = Visibility.Visible;
                CreateDiscussionButton.Visibility = CurrentMember != null ? Visibility.Visible : Visibility.Hidden;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void DiscussionsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                int discussionID = DiscussionsListView.SelectedIndex;
                CurrentDiscussion = CurrentForum.GetDiscussion(CurrentSubForum.Topic, discussionID);
                Binding b = new Binding("CurrentDiscussion.Messages") { Source = this };
                MessagesListView.SetBinding(ItemsControl.ItemsSourceProperty, b);
                DiscussionsListView.Visibility = Visibility.Hidden;
                MessagesListView.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void MessagesListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Message selectedMessage = e.AddedItems[0] as Message;
            if (selectedMessage.HasReplies())
            {

            }
        }

        private void NotifyPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
