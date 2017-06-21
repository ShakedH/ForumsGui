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
            throw new NotImplementedException();
        }

        public void AddMentor(Member mentor, MentorStatus mentorStatus)
        {
            throw new NotImplementedException();
        }

        public Discussion CreateDiscussion(string topic, Member member, string content)
        {
            throw new NotImplementedException();
        }

        public void AddDiscussion(Discussion discussion)
        {
            throw new NotImplementedException();
        }

        public Discussion GetDiscussion(string discussionID)
        {
            throw new NotImplementedException();
        }

        public Message AddReplyMessage(Discussion discussion, Member member, string content)
        {
            throw new NotImplementedException();
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