using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Forums.ViewModel.ForumsAndGroups
{
    [Serializable]
    public class Member : ASubject, IObserver
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public Forum MemberIn { get; set; }
        public List<Notification> Notifications { get; set; }
        public List<Message> Messages { get; set; }
        public List<FriendsGroup> FriendsGroups { get; set; }
        public DateTime SuspensionPeriod { get; set; }
        public List<Member> Friends { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public Member(string userName, string password, Forum memberIn)
        {
            Username = userName;
            MemberIn = memberIn;
            Password = password;
            IsActive = true;
            Notifications = new List<Notification>();
            Messages = new List<Message>();
            FriendsGroups = new List<FriendsGroup>();
            SuspensionPeriod = new DateTime();
            Friends = new List<Member>();
        }

        public List<Member> GetListOfFriends()
        {
            return Friends;
        }

        public void AddMessage(Message message)
        {
            if (!Messages.Contains(message))
            {
                Messages.Add(message);
                string content = string.Format("Your friend {0} posted new message in Discussion with id: {1}", Username, message.getDiscussion().ID);
                Notification notification = new Notification(content);
                Notify(notification);
            }
        }

        public void SetSuspensionPeriod(DateTime suspensionPeriod)
        {
            SuspensionPeriod = suspensionPeriod;
        }

        public void AddFriendGroup(FriendsGroup friendsGroup)
        {
            FriendsGroups.Add(friendsGroup);
        }

        public void AddComplaintWritten(Complaint complaint)
        {
            throw new NotImplementedException();
        }

        public void AddComplaintAbout(Member supervisor)
        {
            throw new NotImplementedException();
        }

        // TODO BOM: New method!
        public void SetAsManager(Forum forum)
        {
            forum.AddManager(this);
            if (MemberIn == null)
                MemberIn = forum;
        }

        public void Update(Notification notification)
        {
            this.Notifications.Add(notification);
        }

        public override bool Equals(object obj)
        {
            Member m = obj as Member;
            return Username == m.Username;
        }
    }
}