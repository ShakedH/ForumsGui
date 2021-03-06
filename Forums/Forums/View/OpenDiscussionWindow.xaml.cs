﻿using System;
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
    /// Interaction logic for OpenDiscussionWindow.xaml
    /// </summary>
    public partial class OpenDiscussionWindow : Window
    {
        private string _subForumTopic;
        private MainWindow _mainWindow;

        public OpenDiscussionWindow(MainWindow mainWindow, string topic)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
            _subForumTopic = topic;
            TopicTextBox.Text = string.Format("{0} Sub Forum", _subForumTopic);
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string topic = TopicTextBox.Text;
                string content = ContentTextBox.Text;
                if (string.IsNullOrEmpty(topic) || string.IsNullOrEmpty(content))
                    throw new Exception("Discussion topic and content can not be empty");
                _mainWindow.CurrentForum.OpenDiscussion(_mainWindow.CurrentSubForum.Topic, topic, content, _mainWindow.CurrentMember.Username);
                System.Windows.Forms.MessageBox.Show("Discussion was created successfully!");
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
