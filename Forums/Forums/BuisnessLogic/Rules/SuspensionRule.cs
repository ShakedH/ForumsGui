using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forums.BuisnessLogic.Rules
{
    public class SuspensionRule
    {
        private string m_Content;

        public SuspensionRule(string content)
        {
            m_Content = content;
        }

        public DateTime getPeriod()
        {
            throw new NotImplementedException();
        }
    }
}
