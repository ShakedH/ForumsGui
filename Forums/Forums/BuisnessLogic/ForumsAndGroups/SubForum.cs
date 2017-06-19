using Forums.BuisnessLogic.UsersInformation;
using System;
using System.Collections.Generic;

namespace Forums.BuisnessLogic.ForumsAndGroups
{
    public class SubForum
    {
        private Forum m_Forum;
        private List<Discussion> m_Discussions = new List<Discussion>();
        private Dictionary<Member, MentorStatus> m_MentorStatus = new Dictionary<Member, MentorStatus>();
        private String m_Topic;

        public SubForum(Forum forum, Member mentor, String topic)
        {
            throw new NotImplementedException();
        }

        public void AddMentor(Member mentor, MentorStatus mentorStatus)
        {
            throw new NotImplementedException();
        }

        public Discussion CreateDiscussion(String topic, Member member, String content)
        {
            throw new NotImplementedException();
        }

        public void AddDiscussion(Discussion discussion)
        {
            throw new NotImplementedException();
        }

        public Discussion GetDiscussion(String discussionID)
        {
            throw new NotImplementedException();
        }

        public Message AddReplyMessage(Discussion discussion, Member member, String content)
        {
            throw new NotImplementedException();
        }

        public List<Message> GetSFMessages(String searchTerm)
        {
            throw new NotImplementedException();
        }

        public void AddToSFMessages(List<Message> messages)
        {
            throw new NotImplementedException();
        }

        public void SendNotification(String discussionID)
        {
            throw new NotImplementedException();
        }
    }

}