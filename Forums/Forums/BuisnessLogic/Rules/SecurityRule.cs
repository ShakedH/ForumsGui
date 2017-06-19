using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forums.BuisnessLogic.Rules
{
    public class SecurityRule
    {
        private String m_Content;

        public SecurityRule(String content)
        {
            m_Content = content;
        }

        public Boolean ValidatePassword(String password)
        {
            throw new NotImplementedException();
        }
    }
}
