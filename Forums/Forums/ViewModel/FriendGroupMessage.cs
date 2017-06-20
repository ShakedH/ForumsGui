using Forums.ViewModel.ForumsAndGroups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forums.ViewModel
{
    public class FriendGroupMessage
    {
        private FriendsGroup m_FriendsGroup;
        private Member m_Author;
        private string m_Content;

        public FriendGroupMessage(FriendsGroup friendsGroup, Member author)
        {
            m_FriendsGroup = friendsGroup;
            m_Author = author;
        }
    }
}
