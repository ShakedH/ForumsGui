﻿using Forums.ViewModel;
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
    /// Interaction logic for AddReplyWindow.xaml
    /// </summary>
    public partial class AddReplyWindow : Window
    {

        private Message messageToReplyTo;
        private MainWindow mainWindow;
        public AddReplyWindow(MainWindow window, Message msg)
        {
            mainWindow = window;
            InitializeComponent();
            this.messageToReplyTo = msg;
            OriginalMessageBlock.Text = messageToReplyTo.Content;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(ReplyTextBox.Text))
                {
                    System.Windows.Forms.MessageBox.Show("Please write your reply");
                    return;
                }
                messageToReplyTo.AddMessage(new Message(messageToReplyTo, mainWindow.CurrentMember, ReplyTextBox.Text));
                Close();
            }
            catch (Exception ex)
            {
                mainWindow.CurrentForum.ForumErrorLogger.WriteToLogger(ex.Message);
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }
    }
}
