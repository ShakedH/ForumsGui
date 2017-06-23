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
        private bool _registeredUsersButtonEnabled;
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
                NotifyPropertyChanged("CurrentSubForum");
                RegisteredUsersButtonEnabled = value != null && CurrentMember != null ? true : false;
                GoBackButtonVisibility = value != null ? Visibility.Visible : Visibility.Hidden;
            }
        }
        public Member CurrentMember
        {
            get { return _currentMember; }
            set
            {
                _currentMember = value;
                NewSubForumButtonVisibility = value != null && CurrentForum.IsManager(value.Username) ? Visibility.Visible : Visibility.Hidden;
                RegisteredUsersButtonEnabled = value != null && CurrentSubForum != null ? true : false;
            }
        }
        public bool RegisteredUsersButtonEnabled
        {
            get { return _registeredUsersButtonEnabled; }
            set { _registeredUsersButtonEnabled = value; NotifyPropertyChanged("RegisteredUsersButtonEnabled"); }
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
            LoadCurrentForum();
            //InitializeCurrentForum();
            InitializeComponent();
            UsernameTextBlock.Text = "Guest";
        }

        private void InitializeCurrentForum()
        {
            Member grandManager = new Member("a", "a", CurrentForum);
            Member anotherManager = new Member("admin", "admin", CurrentForum);
            CurrentForum = new Forum(grandManager, null, "Food");
            grandManager.SetAsManager(CurrentForum);
            anotherManager.SetAsManager(CurrentForum);
            CurrentForum.CreateSubForum("Italian Cuisine", grandManager.Username);
            CurrentForum.CreateSubForum("Israeli Cuisine", grandManager.Username);
            CurrentForum.CreateSubForum("Spanish Cuisine", anotherManager.Username);
            SubForum testSF = CurrentForum.GetSubForum("Italian Cuisine");
            testSF.CreateDiscussion("Pasta", grandManager, "Welcome! Let me hear your pasta recipes");
            testSF.CreateDiscussion("Wine", grandManager, "Welcome! Let me hear about your favorite wines");
            testSF.CreateDiscussion("Coffee", grandManager, "Welcome! Let me hear about espressos");
            testSF = CurrentForum.GetSubForum("Israeli Cuisine");
            testSF.CreateDiscussion("Falafel", grandManager, "Welcome! Let me hear your favorite falafel stands");
            testSF.CreateDiscussion("Hummus", grandManager, "Welcome! Let me hear about your favorite hummus toppings");
            testSF.CreateDiscussion("Burekas", grandManager, "Welcome! Let me hear the best burekas fillings");
            testSF = CurrentForum.GetSubForum("Spanish Cuisine");
            testSF.CreateDiscussion("Alfajores", grandManager, "Welcome! Let me hear how to make alfajores");
            testSF.CreateDiscussion("Currhos", grandManager, "Welcome! Let me hear how to make Churros");
            testSF.CreateDiscussion("Flan", grandManager, "Welcome! Let me hear how to make Flan");
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
                SubForumsListView.Visibility = Visibility.Hidden;
                DiscussionsTreeView.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                CurrentForum.ForumErrorLogger.WriteToLogger(ex.Message);
                System.Windows.Forms.MessageBox.Show(ex.Message);
                SubForumsListView.UnselectAll();
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
