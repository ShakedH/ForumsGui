using System;
using System.Collections.Generic;
namespace Forums.BuisnessLogic.ForumsAndGroups
{
    public class FriendsGroup
    {
        private Forum m_Forum;
        private List<Member> m_members = new List<Member>();
        private List<FriendGroupMessage> m_FriendsGroupMessages = new List<FriendGroupMessage>();
        private string m_GroupID;


        public FriendsGroup(Forum forum, Member firstMember)
        {
            this.m_Forum = forum;
            if (!m_Forum.IsMember(firstMember))
                throw new Exception(string.Format("%s does not belong to forum %s", firstMember, forum));
            m_members.Add(firstMember);
        }

        public void AddNewFriendToGroup(Member member)
        {
            throw new NotImplementedException();
        }
    }
}