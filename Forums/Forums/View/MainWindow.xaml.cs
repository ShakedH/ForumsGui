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
        private string _currentForumPath;
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
            InitializeComponent();
            UsernameTextBlock.Text = "Guest";
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
                if (e.AddedItems.Count == 0)    // Case of 'SubForumsListView.UnselectAll()'
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
            using (Stream stream = new FileStream(_currentForumPath, FileMode.Create))
            {
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, CurrentForum);
            }
        }

        private void LoadCurrentForum()
        {
            try
            {
                string currentLocation = Environment.CurrentDirectory;
                string fileName = "CurrentForum.bin";
                while (!File.Exists(currentLocation + @"\" + fileName))
                {
                    currentLocation = Directory.GetParent(currentLocation).FullName;
                    if (currentLocation == null)
                        throw new Exception($"File {fileName} not found");
                }
                _currentForumPath = currentLocation + @"\" + fileName;

                using (Stream stream = File.Open(_currentForumPath, FileMode.Open))
                {
                    IFormatter formatter = new BinaryFormatter();
                    CurrentForum = (Forum)formatter.Deserialize(stream);
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void NotifyPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
