using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forums.ViewModel.Rules
{
    public class SecurityRule
    {
        private string m_Content;

        public SecurityRule(string content)
        {
            m_Content = content;
        }

        public bool ValidatePassword(string password)
        {
            throw new NotImplementedException();
        }
    }
}
