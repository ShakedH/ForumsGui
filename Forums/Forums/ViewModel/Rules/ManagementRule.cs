﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forums.ViewModel.Rules
{
    [Serializable]
    public class ManagementRule
    {
        private string m_Content;

        public ManagementRule(string content)
        {
            m_Content = content;
        }
    }
}
