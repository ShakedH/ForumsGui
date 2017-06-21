using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forums.ViewModel.ForumsAndGroups
{
    public class Discussion
    {
        private static int index = 1;

        private SubForum m_SubForum;
        private List<Message> m_Messages;
        private string m_Topic;
        private string m_DiscussionID;

        public string ID
        {
            get
            {
                return m_DiscussionID;
            }

            private set
            {
                m_DiscussionID = value;
            }
        }

        public Discussion(SubForum subForum, string topic, string openingMessage, Member writtenBy)
        {
            this.m_SubForum = subForum;
            this.m_Topic = topic;
            this.ID = index.ToString();
            index++;
            m_Messages = new List<Message>();
            m_Messages.Add(new Message(this, writtenBy, openingMessage));
        }

        public void AddMessage(Message message)
        {
            if (message != null && !m_Messages.Contains(message))
                m_Messages.Add(message);
        }

        public Message AddMessage(Member member, string content)
        {
            Message msg = new Message(this, member, content);
            AddMessage(msg);
            return msg;
        }

        public Message GetOpenMessage()
        {
            if (m_Messages.Count == 0)
                throw new Exception(string.Format("Discussion {0} is empty", this.m_Topic));
            return m_Messages[0];
        }

        public Message GetMessage(string messageID)
        {
            foreach (Message msg in m_Messages)
            {
                if (msg.ID == messageID)
                    return msg;
            }
            throw new Exception(string.Format("Message #{0} not found in discussion {1}!", messageID, this.ID));
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
    }
}
