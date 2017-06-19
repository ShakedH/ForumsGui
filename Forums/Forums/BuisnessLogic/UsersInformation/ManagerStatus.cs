namespace Forums.BuisnessLogic.ForumsAndGroups
{
    public class ManagerStatus
    {
        private Member m_Member;
        private Forum m_Forum;
        private int m_Seniority;
        private int m_SuspensionPeriod;

        public ManagerStatus(Member member, Forum forum)
        {
            m_Member = member;
            m_Forum = forum;
        }
    }
}