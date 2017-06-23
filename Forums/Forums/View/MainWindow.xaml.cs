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
        private string currentForumPath = "CurrentForum.bin";

        public event PropertyChangedEventHandler PropertyChanged;
        public Forum CurrentForum { get; set; }
        public SubForum CurrentSubForum { get; set; }
        public Discussion CurrentDiscussion { get; set; }
        public Member CurrentMember { get; set; }
        public List<Message> CurrentMessage { get; set; }

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
            new OpenDiscussionWindow(this).ShowDialog();
        }

        private void SubForumsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                SubForum selectedSubForum = e.AddedItems[0] as SubForum;
                CurrentSubForum = CurrentForum.GetSubForum(selectedSubForum.Topic);
                Binding b = new Binding("CurrentSubForum.Discussions") { Source = this };
                DiscussionsTreeView.SetBinding(ItemsControl.ItemsSourceProperty, b);
                SubForumsListView.Visibility = Visibility.Hidden;
                DiscussionsTreeView.Visibility = Visibility.Visible;
                CreateDiscussionButton.Visibility = CurrentMember != null ? Visibility.Visible : Visibility.Hidden;
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
    }
}
