using Forums.ViewModel;
using Forums.ViewModel.ForumsAndGroups;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
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
        private const string currentForumPath = "CurrentForum.bin";
        private bool _newDiscussionButtonEnabled;
        private Visibility _newSubForumButtonVisibility = Visibility.Hidden;
        private Visibility _goBackButtonVisibility = Visibility.Hidden;
        private Member _currentMember;
        private SubForum _currentSubForum;

        public event PropertyChangedEventHandler PropertyChanged;
        public Forum CurrentForum { get; set; }
        public SubForum CurrentSubForum
        {
            get { return _currentSubForum; }
            set
            {
                _currentSubForum = value;
                NewDiscussionButtonEnabled = value != null && CurrentMember != null ? true : false;
                GoBackButtonVisibility = value != null ? Visibility.Visible : Visibility.Hidden;
            }
        }
        public Discussion CurrentDiscussion { get; set; }
        public Member CurrentMember
        {
            get { return _currentMember; }
            set
            {
                _currentMember = value;
                NewSubForumButtonVisibility = value != null && CurrentForum.IsManager(value.Username) ? Visibility.Visible : Visibility.Hidden;
                NewDiscussionButtonEnabled = value != null && CurrentSubForum != null ? true : false;
            }
        }
        public List<Message> CurrentMessage { get; set; }
        public bool NewDiscussionButtonEnabled
        {
            get { return _newDiscussionButtonEnabled; }
            set { _newDiscussionButtonEnabled = value; NotifyPropertyChanged("NewDiscussionButtonEnabled"); }
        }
        public Visibility NewSubForumButtonVisibility
        {
            get { return _newSubForumButtonVisibility; }
            set { _newSubForumButtonVisibility = value; NotifyPropertyChanged("NewSubForumButtonVisibility"); }
        }
        public Visibility GoBackButtonVisibility
        {
            get { return _goBackButtonVisibility; }
            set { _goBackButtonVisibility = value; NotifyPropertyChanged("GoBackButtonVisibility"); }
        }

        public MainWindow()
        {
            this.DataContext = this;
            //LoadCurrentForum();
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
            Message OnePointOne = new Message(testDiscussion, grandManager, "This is reply message 1.1");
            testDiscussion.GetOpenMessage().AddMessage(OnePointOne);
            testDiscussion.GetOpenMessage().AddMessage(new Message(testDiscussion, grandManager, "This is reply message 1.2"));
            OnePointOne.AddMessage(new Message(testDiscussion, grandManager, "This is reply message 1.1.1"));
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

        private void CreateDiscussionButton_Click(object sender, RoutedEventArgs e)
        {
            new OpenDiscussionWindow(this, CurrentSubForum.Topic).ShowDialog();
        }

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            CurrentSubForum = null;
            SubForumsListView.UnselectAll();
            SubForumsListView.Visibility = Visibility.Visible;
            DiscussionsTreeView.Visibility = Visibility.Hidden;
        }

        private void SubForumsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (e.AddedItems.Count == 0)    // Case of 'UnselectAll()' in 'GoBackButton_Click' method
                    return;
                SubForum selectedSubForum = e.AddedItems[0] as SubForum;
                CurrentSubForum = CurrentForum.GetSubForum(selectedSubForum.Topic);
                Binding b = new Binding("CurrentSubForum.Discussions") { Source = this };
                DiscussionsTreeView.SetBinding(ItemsControl.ItemsSourceProperty, b);
                SubForumsListView.Visibility = Visibility.Hidden;
                DiscussionsTreeView.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                CurrentForum.ForumErrorLogger.WriteToLogger(ex.Message);
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void ReplyButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (DiscussionsTreeView.SelectedItem == null || DiscussionsTreeView.SelectedItem is Discussion)
                    throw new Exception("Please select a message to reply to");
                new AddReplyWindow(this, (Message)DiscussionsTreeView.SelectedItem).Show();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            SaveCurrentForum();
        }

        private void SaveCurrentForum()
        {
            using (Stream stream = new FileStream(currentForumPath, FileMode.Create))
            {
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, CurrentForum);
            }
        }

        private void LoadCurrentForum()
        {
            using (Stream stream = File.Open(currentForumPath, FileMode.Open))
            {
                IFormatter formatter = new BinaryFormatter();
                CurrentForum = (Forum)formatter.Deserialize(stream);
            }
        }

        private void NotifyPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
