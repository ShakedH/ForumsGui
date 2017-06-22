using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forums.ViewModel.ForumsAndGroups
{
    public class Forum
    {
        #region Static Methods & Fields
        private static List<Forum> AllForums = new List<Forum>();

        public static Forum GetForumByName(string forumName)
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
        #endregion

        private Dictionary<Member, ManagerStatus> ManagerStatus { get; set; }
        private List<Member> Members { get; set; }
        private List<SubForum> SubForumList { get; set; }
        private List<FriendsGroup> FriendsGroups { get; set; }
        private List<Complaint> Complaints { get; set; }
        private EventLogger EventLogger { get; set; }
        private ErrorLogger ErrorLogger { get; set; }
        private Policy Policy;
        private string Topic;

        public Forum(Member manager, Policy policy, string topic)
        {
            ManagerStatus = new Dictionary<Member, ForumsAndGroups.ManagerStatus>();
            Members = new List<Member>();
            SubForumList = new List<SubForum>();
            FriendsGroups = new List<FriendsGroup>();
            Complaints = new List<Complaint>();
            EventLogger = new EventLogger();
            ErrorLogger = new ErrorLogger();
            ManagerStatus ms = new ManagerStatus(manager, this);
            ManagerStatus.Add(manager, ms);
            Members.Add(manager);
            Policy = policy;
            Topic = topic;
        }

        #region Users methods
        public void AddManager(Member manager)
        {
            if (!ManagerStatus.ContainsKey(manager))
            {
                ManagerStatus.Add(manager, new ManagerStatus(manager, this));
                Members.Add(manager);
            }
        }

        public void AddMember(Member member)
        {
            Members.Add(member);
        }

        public Member GetMember(string name)
        {
            foreach (Member member in this.Members)
            {
                if (member.Username == name)
                    return member;
            }
            throw new Exception(string.Format("Member {0} not found in Forum!", name));
        }

        public Member GetManager(string name)
        {
            foreach (Member manager in this.ManagerStatus.Keys)
            {
                if (manager.Username == name)
                {
                    return manager;
                }
            }
            throw new Exception(string.Format("Manager {0} not found in Forum!", name));
        }

        public bool IsMember(Member member)
        {
            return Members.Contains(member);
        }

        public void CreateMember(string username, string password)
        {
            if (UserExists(username))
                throw new Exception("Sorry! Username already exists");
            Member member = new Member(username, password, this);
            AddMember(member);
        }

        public bool UserExists(string username)
        {
            foreach (Member member in Members)
                if (member.Username == username)
                    return true;
            return false;
        }

        public void SuspendMember(string username, DateTime suspensionPeriod)
        {
            throw new NotImplementedException();
        }

        public bool SignUpDetailsValidation(string username, string password)
        {
            return !UserExists(username) /*&& m_Policy.ValidatePassword(password)*/;
        }
        #endregion

        #region Sub-Forum methods
        public SubForum GetSubForum(string topic)
        {
            throw new NotImplementedException();
        }

        public void AddSubForum(SubForum subForum)
        {
            throw new NotImplementedException();
        }

        public void CreateSubForum(string topic, string managerName)
        {
            Member manager = GetManager(managerName);
            SubForum subforum = new SubForum(this, manager, topic);
            AddSubForum(subforum);
        }

        public bool SubForumExists(string topic)
        {
            throw new NotImplementedException();
        }

        public bool ValidateSubForumTopic(string topic)
        {
            throw new NotImplementedException();
        }
        #endregion

        public void OpenDiscussion(string subForumTopic, string topic, string content, string writtenBy)
        {
            Member member = GetMember(writtenBy);
            SubForum sf = GetSubForum(subForumTopic);
            Discussion dis = sf.CreateDiscussion(topic, member, content);
            Message msg = dis.GetOpenMessage();
            member.AddMessage(msg);

        }

        public void ReplyToMessage(Discussion discussion, SubForum subForum, Message message, Member member, string content)
        {
            Message replyMsg = subForum.AddReplyMessage(discussion, member, content);
            member.AddMessage(replyMsg);
            message.AddMessage(replyMsg);
        }

        public Message GetMessageToReply(string subForumTopic, string discussionID, string messageID)
        {
            throw new NotImplementedException();
        }

        #region FriendsGroup methods
        public List<Member> GetFriendsList(string username)
        {
            throw new NotImplementedException();
        }

        public void CreateFriendGroup(string username, List<Member> members)
        {
            throw new NotImplementedException();
        }

        public void AssociateFriendGroup(FriendsGroup friendsGroup)
        {
            throw new NotImplementedException();
        }
        #endregion

        public void SendNotification(string subForumTopic, string discussionID)
        {
            throw new NotImplementedException();
        }

        public void CreateNewComplaint(string username, string content, DateTime date, string supervisor)
        {
            throw new NotImplementedException();
        }

        public void AssociateComplaint(Complaint complaint)
        {
            throw new NotImplementedException();
        }

        public bool CheckComplaintIsValid(DateTime date, string content, Member supervisor, Member member)
        {
            throw new NotImplementedException();
        }

        public DateTime GetSuspensionPeriod(string cause)
        {
            throw new NotImplementedException();
        }

        public List<Message> SearchMessages(string searchTerm)
        {
            throw new NotImplementedException();
        }

        public void AddToMsgs(List<Message> messages)
        {
            throw new NotImplementedException();
        }
    }
}
