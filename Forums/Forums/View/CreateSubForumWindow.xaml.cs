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
    /// Interaction logic for CreateSubForumWindow.xaml
    /// </summary>
    public partial class CreateSubForumWindow : Window
    {
        private MainWindow _mainWindow;
        private Forum _currentForum;

        public CreateSubForumWindow(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
            _currentForum = _mainWindow.CurrentForum;
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string topic = TopicTextBox.Text;
                string mentorUsername = MentorTextBox.Text;
                if (_currentForum.SubForumExists(topic))
                    throw new Exception("Oops! There is already a sub forum with that name");
                if (!_currentForum.IsManager(mentorUsername))
                    throw new Exception(string.Format("Oops! {0} is not a manager in the forum", mentorUsername));
                _currentForum.CreateSubForum(topic, mentorUsername);
                System.Windows.Forms.MessageBox.Show(string.Format("Sub forum \"{0}\" created successfully!", topic));
                Close();
            }
            catch (Exception ex)
            {
                _mainWindow.CurrentForum.ForumErrorLogger.WriteToLogger(ex.Message);
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
    }
}
