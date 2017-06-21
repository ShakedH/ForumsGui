using System;
using System.Collections.Generic;

namespace Forums.ViewModel.ForumsAndGroups
{
    public class Member : ASubject, IObserver
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
            return m_Friends;
        }

        public void AddMessage(Message message)
        {
            if (!m_Messages.Contains(message))
            {
                m_Messages.Add(message);
                string content = string.Format("Your friend {0} posted new message in {1}", m_UserName);
                Notification n = new Notification(content);
                Notify(n);
            }
        }

        public void setSuspensionPeriod(DateTime suspensionPeriod)
        {
            m_SuspensionPeriod = suspensionPeriod;
        }

        public void AddFriendGroup(FriendsGroup friendsGroup)
        {
            m_FriendsGroups.Add(friendsGroup);
        }

        public void AddComplaintWritten(Complaint complaint)
        {
            throw new NotImplementedException();
        }

        public void AddComplaintAbout(Member supervisor)
        {
            throw new NotImplementedException();
        }

        public void Update(Notification notification)
        {
            this.m_Notifications.Add(notification);
        }


    }
}