namespace Forums.ViewModel.ForumsAndGroups
{

    public class ManagerStatus
    {
        public Member m_Member { get; set; }
        public Forum m_Forum { get; set; }
        public int m_Seniority { get; set; }
        public int m_SuspensionPeriod { get; set; }

        public ManagerStatus(Member member, Forum forum)
        {
            m_Member = member;
            m_Forum = forum;
        }
    }
}