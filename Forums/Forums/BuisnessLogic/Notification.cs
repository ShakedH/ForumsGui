using Forums.BuisnessLogic.ForumsAndGroups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forums.BuisnessLogic
{
    public class Notification
    {
        private List<Member> m_SentTo = new List<Member>();

        public Notification(Member sentTo)
        {
            m_SentTo.Add(sentTo);
        }

        public Message FindMessage(String messageID)
        {
            throw new NotImplementedException();
        }
    }
}
