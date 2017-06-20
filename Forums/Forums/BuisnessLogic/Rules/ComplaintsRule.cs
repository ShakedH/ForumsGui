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
        private string m_Content;

        public ComplaintsRule(string content)
        {
            m_Content = content;
        }

        public bool CheckComplaintIsValid(DateTime date, string content, Member supervisor, Member member)
        {
            throw new NotImplementedException();
        }
    }
}
