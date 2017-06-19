using Forums.BuisnessLogic.ForumsAndGroups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forums.BuisnessLogic
{
    public class Message
    {
        private Member m_PublishedBy;
        private Discussion m_Discussion;
        private Message m_RepliesTo;
        private List<Message> m_Replies = new List<Message>();
        private String m_Content;
        private DateTime m_Published;
        private String m_MessageID;

        public Message(Discussion discussion, Member publishedBy, String content)
        {
            this.m_Discussion = discussion;
            this.m_PublishedBy = publishedBy;
            this.m_Content = content;
        }

        public Message(Message repliesTo, Member publishedBy, String content)
        {
            this.m_RepliesTo = repliesTo;
            this.m_PublishedBy = publishedBy;
            this.m_Content = content;
            this.m_Discussion = m_RepliesTo.getDiscussion();
        }

        public void AddMessage(Message responeMessage)
        {
            throw new NotImplementedException();
        }

        public Member GetPublisher()
        {
            throw new NotImplementedException();
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
