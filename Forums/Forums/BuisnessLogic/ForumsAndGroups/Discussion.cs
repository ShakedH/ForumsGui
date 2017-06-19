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
        private String m_Topic;
        private String m_DiscussionID;

        public Discussion(SubForum subForum, String topic, String openingMessage, Member writtenBy)
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

        public Message AddMessage(Member member, String content)
        {
            throw new NotImplementedException();
        }

        public Message GetOpenMessage()
        {
            throw new NotImplementedException();
        }

        public Message GetMessage(String messageID)
        {
            throw new NotImplementedException();
        }

        public List<Message> GetDisMessages(String searchTerm)
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
