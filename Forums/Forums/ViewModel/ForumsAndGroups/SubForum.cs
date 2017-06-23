using Forums.ViewModel.UsersInformation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Forums.ViewModel.ForumsAndGroups
{
    [Serializable]
    public class SubForum
    {
        public Forum Forum { get; set; }
        public ObservableCollection<Discussion> Discussions { get; set; }
        public Dictionary<Member, MentorStatus> MentorStatus { get; set; }
        public string Topic { get; set; }

        public SubForum(Forum forum, Member mentor, string topic)
        {
            Discussions = new ObservableCollection<Discussion>();
            MentorStatus = new Dictionary<Member, UsersInformation.MentorStatus>();
            Forum = forum;
            Topic = topic;
            AddMentor(mentor, new MentorStatus(mentor, this));
        }

        public void AddMentor(Member mentor, MentorStatus mentorStatus)
        {
            this.MentorStatus.Add(mentor, mentorStatus);
        }

        public Discussion CreateDiscussion(string topic, Member member, string content)
        {
            Discussion discussion = new Discussion(this, topic, content, member);
            this.Discussions.Add(discussion);
            return discussion;
        }

        public void AddDiscussion(Discussion discussion)
        {
            this.Discussions.Add(discussion);
        }

        public Discussion GetDiscussion(int discussionID)
        {
            return Discussions[discussionID];
        }

        public Message AddReplyMessage(Discussion discussion, Member member, string content)
        {
            return discussion.AddMessage(member, content);
        }

        public List<Message> GetSFMessages(string searchTerm)
        {
            throw new NotImplementedException();
        }

        public void AddToSFMessages(List<Message> messages)
        {
            throw new NotImplementedException();
        }

        public void SendNotification(string discussionID)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return Topic;
        }
    }
}