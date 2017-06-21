using Forums.ViewModel.ForumsAndGroups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forums.ViewModel
{
    public class Message
    {
        private static int index = 1;

        private Member m_PublishedBy;
        private Discussion m_Discussion;
        private Message m_RepliesTo;
        private List<Message> m_Replies = new List<Message>();
        private string m_Content;
        private DateTime m_Published;
        private string m_MessageID;

        public string ID
        {
            get
            {
                return m_MessageID;
            }

            private set
            {
                m_MessageID = value;
            }
        }

        public Message(Discussion discussion, Member publishedBy, string content)
        {
            this.m_Discussion = discussion;
            this.m_PublishedBy = publishedBy;
            this.m_Content = content;
            this.ID = index.ToString();
            index++;
        }

        public Message(Message repliesTo, Member publishedBy, string content)
        {
            this.m_RepliesTo = repliesTo;
            this.m_PublishedBy = publishedBy;
            this.m_Content = content;
            this.m_Discussion = m_RepliesTo.getDiscussion();
            this.ID = index.ToString();
            index++;
        }

        public void AddMessage(Message responeMessage)
        {
            this.m_Replies.Add(responeMessage);
        }

        public Member GetPublisher()
        {
            return m_PublishedBy;
        }

        public Discussion getDiscussion()
        {
            return m_Discussion;
        }

        public void SendOpenNotif()
        {
            throw new NotImplementedException();
        }

        public void SendNotification(Notification notification, Member friend)
        {
            throw new NotImplementedException();
        }
    }

}
