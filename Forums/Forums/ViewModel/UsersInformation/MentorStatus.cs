﻿using Forums.ViewModel.ForumsAndGroups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forums.ViewModel.UsersInformation
{
    [Serializable]
    public class MentorStatus
    {
        private Member m_Member;
        private SubForum m_SubForum;
        private int m_Seniority;
        private int m_SuspensionPeriod;

        public MentorStatus(Member member, SubForum subForum)
        {
            m_Member = member;
            m_SubForum = subForum;
        }
    }
}
