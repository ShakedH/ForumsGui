using Forums.BuisnessLogic.ForumsAndGroups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forums.BuisnessLogic.Rules
{
    public class ComplaintsRule
    {
        private String m_Content;

        public ComplaintsRule(String content)
        {
            m_Content = content;
        }

        public Boolean CheckComplaintIsValid(DateTime date, String content, Member supervisor, Member member)
        {
            throw new NotImplementedException();
        }
    }
}
