using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forums.BuisnessLogic.ForumsAndGroups
{
    public class Forum
    {
        //region Static Methods & Fields
        private static List<Forum> AllForums = new List<Forum>();

        public static Forum GetForumByName(String forumName)
        {
            throw new NotImplementedException();
        }

        public static void AddForum(Forum forum)
        {
            throw new NotImplementedException();
        }

        public static List<Forum> getAllForums()
        {
            return AllForums;
        }
        //endregion

        private Dictionary<Member, ManagerStatus> m_ManagerStatus = new Dictionary<Member, ManagerStatus>();
        private List<Member> m_Members = new List<Member>();

        private List<SubForum> m_SubForumList = new List<SubForum>();
        private List<FriendsGroup> m_FriendsGroups = new List<FriendsGroup>();
        private List<Complaint> m_Complaints = new List<Complaint>();
        private EventLogger m_EventLogger = new EventLogger();
        private ErrorLogger m_ErrorLogger = new ErrorLogger();
        private Policy m_Policy;

        private String m_Topic;

        public Forum(Member manager, Policy policy, String topic)
        {
            throw new NotImplementedException();
        }

        //region Users methods
        public void AddManager(Member manager)
        {
            if (!m_ManagerStatus.ContainsKey(manager))
                m_ManagerStatus.Add(manager, new ManagerStatus(manager, this));
        }

        public void AddMember(Member member)
        {
            throw new NotImplementedException();
        }

        public Member GetMember(String name)
        {
            throw new NotImplementedException();
        }

        public Member GetManager(String name)
        {
            throw new NotImplementedException();
        }

        public Boolean IsMember(Member member)
        {
            return m_ManagerStatus.ContainsKey(member);
        }

        public void CreateMember(String username, String password)
        {
            throw new NotImplementedException();
        }

        public Boolean UserExists(String username)
        {
            throw new NotImplementedException();
        }

        public void SuspendMember(String username, DateTime suspensionPeriod)
        {
            throw new NotImplementedException();
        }

        public Boolean SignUpDetailsValidation(String username, String password)
        {
            throw new NotImplementedException();
        }
        //endregion

        //region Sub-Forum methods
        public SubForum GetSubForum(String topic)
        {
            throw new NotImplementedException();
        }

        public void AddSubForum(SubForum subForum)
        {
            throw new NotImplementedException();
        }

        public void CreateSubForum(String topic, String managerName)
        {
            throw new NotImplementedException();
        }

        public Boolean SubForumExists(String topic)
        {
            throw new NotImplementedException();
        }

        public Boolean ValidateSubForumTopic(String topic)
        {
            throw new NotImplementedException();
        }
        //endregion

        public void OpenDiscussion(String subForumTopic, String topic, String content, String writtenBy)
        {
            throw new NotImplementedException();
        }

        public void ReplyToMessage(Discussion discussion, SubForum subForum, Message message, Member member, String content)
        {
            throw new NotImplementedException();
        }

        public Message GetMessageToReply(String subForumTopic, String discussionID, String messageID)
        {
            throw new NotImplementedException();
        }

        //region FriendsGroup methods
        public List<Member> GetFriendsList(String username)
        {
            throw new NotImplementedException();
        }

        public void CreateFriendGroup(String username, List<Member> members)
        {
            throw new NotImplementedException();
        }

        public void AssociateFriendGroup(FriendsGroup friendsGroup)
        {
            throw new NotImplementedException();
        }
        //endregion

        public void SendNotification(String subForumTopic, String discussionID)
        {
            throw new NotImplementedException();
        }

        public void CreateNewComplaint(String username, String content, DateTime date, String supervisor)
        {
            throw new NotImplementedException();
        }

        public void AssociateComplaint(Complaint complaint)
        {
            throw new NotImplementedException();
        }

        public Boolean CheckComplaintIsValid(DateTime date, String content, Member supervisor, Member member)
        {
            throw new NotImplementedException();
        }

        public DateTime GetSuspensionPeriod(String cause)
        {
            throw new NotImplementedException();
        }

        public List<Message> SearchMessages(String searchTerm)
        {
            throw new NotImplementedException();
        }

        public void AddToMsgs(List<Message> messages)
        {
            throw new NotImplementedException();
        }
    }
}
