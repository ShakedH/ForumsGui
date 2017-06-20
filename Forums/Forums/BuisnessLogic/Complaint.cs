using System;

namespace Forums.BuisnessLogic.ForumsAndGroups
{
    public class Complaint
    {
        private Forum m_Forum;
        private Member m_Author, m_About;
        private DateTime m_DateTime;
        private string m_Content;

        public Complaint(Member author, Member about, Forum forum)
        {
            this.m_Author = author;
            this.m_About = about;
            this.m_Forum = forum;
        }

        public void DefineWriterOfComplaint(Member member)
        {
            throw new NotImplementedException();
        }

        public void DefineComplaintAbout(Member member)
        {
            throw new NotImplementedException();
        }
    }
}