using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forums.BuisnessLogic.ForumsAndGroups
{
    public class Forum
    {
        private Dictionary<Member, ManagerStatus> m_ManagerStatus = new Dictionary<Member, ManagerStatus>();
        private List<Member> m_Members = new List<Member>();

        private List<SubForum> m_SubForumList = new List<SubForum>();
        private List<FriendsGroup> m_FriendsGroups = new List<FriendsGroup>();
        private List<Complaint> m_Complaints = new List<Complaint>();

        private EventLogger m_EventLogger;
        private ErrorLogger m_ErrorLogger;
        private Policy m_Policy;

        private string m_Topic;

        public Forum(Member manager, Policy policy, string topic)
        {
            m_EventLogger = new EventLogger(this);
            m_ErrorLogger = new ErrorLogger(this);
        }

    }
}
