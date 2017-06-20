using System;
using System.Collections.Generic;

namespace Forums.BuisnessLogic.ForumsAndGroups
{
    public class Member
    {
        private string m_UserName;
        private string m_Password;
        private bool m_IsActive;
        private Forum m_MemberIn;
        private List<Notification> m_Notifications = new List<Notification>();
        private List<Message> m_Messages = new List<Message>();
        private List<FriendsGroup> m_FriendsGroups = new List<FriendsGroup>();
        private DateTime m_SuspensionPeriod;
        private List<Member> m_Friends = new List<Member>();

        public Member(string userName, string password, Forum memberIn)
        {
            m_UserName = userName;
            m_MemberIn = memberIn;
            m_Password = password;
        }

        public List<Member> GetListOfFriends()
        {
            throw new NotImplementedException();
        }

        public void AddMessage(Message message)
        {
            throw new NotImplementedException();
        }

        public void setSuspensionPeriod(DateTime suspensionPeriod)
        {
            throw new NotImplementedException();
        }

        public void AddFriendGroup(FriendsGroup friendsGroup)
        {
            throw new NotImplementedException();
        }

        public void AddComplaintWritten(Complaint complaint)
        {
            throw new NotImplementedException();
        }

        public void AddComplaintAbout(Member supervisor)
        {
            throw new NotImplementedException();
        }
    }

}