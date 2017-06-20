using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forums.BuisnessLogic.ForumsAndGroups
{
    public class Discussion
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
    }
}
