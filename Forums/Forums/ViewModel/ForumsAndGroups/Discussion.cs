﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forums.ViewModel.ForumsAndGroups
{
    public class Discussion : ASubject
    {
        private SubForum m_SubForum;
        private List<Message> m_Messages;
        private string m_Topic;
        private string m_DiscussionID;

        public Discussion(SubForum subForum, string topic, string openingMessage, Member writtenBy)
        {
            this.m_SubForum = subForum;
            this.m_Topic = topic;
            m_Messages = new List<Message>();
            m_Messages.Add(new Message(this, writtenBy, openingMessage));
        }

        public void AddMessage(Message message)
        {
            throw new NotImplementedException();
        }

        public Message AddMessage(Member member, string content)
        {
            throw new NotImplementedException();
        }

        public Message GetOpenMessage()
        {
            throw new NotImplementedException();
        }

        public Message GetMessage(string messageID)
        {
            throw new NotImplementedException();
        }

        public List<Message> GetDisMessages(string searchTerm)
        {
            throw new NotImplementedException();
        }

        public void AddToDMsgs(Message message)
        {
            throw new NotImplementedException();
        }

        public void SendOpenNotif()
        {
            throw new NotImplementedException();
        }

        public override void Notify()
        {
            string notifContent = string.Format("There is a new message in your discussion.\nCheck it out: {0}", m_DiscussionID);
            Notification notification = new Notification(notifContent);
            foreach (IObserver observer in m_Observers)
                observer.Update(notification);
        }
    }
}
