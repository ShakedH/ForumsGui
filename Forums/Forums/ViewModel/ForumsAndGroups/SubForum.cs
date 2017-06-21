using Forums.ViewModel.UsersInformation;
using System;
using System.Collections.Generic;

namespace Forums.ViewModel.ForumsAndGroups
{
    public class SubForum
    {
        private Forum m_Forum;
        private List<Discussion> m_Discussions = new List<Discussion>();
        private Dictionary<Member, MentorStatus> m_MentorStatus = new Dictionary<Member, MentorStatus>();
        private string m_Topic;

        public SubForum(Forum forum, Member mentor, string topic)
        {
            this.m_Forum = forum;
            this.m_Topic = topic;
            this.AddMentor(mentor, new MentorStatus(mentor, this));

        }

        public void AddMentor(Member mentor, MentorStatus mentorStatus)
        {
            this.m_MentorStatus.Add(mentor, mentorStatus);
        }

        public Discussion CreateDiscussion(string topic, Member member, string content)
        {
            Discussion discussion = new Discussion(this, topic, content, member);
            return discussion;
        }

        public void AddDiscussion(Discussion discussion)
        {
            this.m_Discussions.Add(discussion);
        }

        public Discussion GetDiscussion(string discussionID)
        {
            foreach(Discussion dis in this.m_Discussions){
                if (dis.ID == discussionID)
                {
                    return dis;
                }

            }
            throw new Exception(string.Format("Discussion {0} not found in sub-forum {1}!", discussionID, this.m_Topic));
        }

        public Message AddReplyMessage(Discussion discussion, Member member, string content)
        {
            return new Message(discussion, member, content);
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
    }

}