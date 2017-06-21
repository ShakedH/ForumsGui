using Forums.ViewModel.Rules;
using System;
using System.Collections.Generic;

namespace Forums.ViewModel.ForumsAndGroups
{
    [Serializable]
    public class Policy
    {
        private List<ManagementRule> m_ManagementRules = new List<ManagementRule>();
        private List<ComplaintsRule> m_ComplaintsRules = new List<ComplaintsRule>();
        private List<SuspensionRule> m_SuspensionRules = new List<SuspensionRule>();
        private List<SecurityRule> m_SecurityRules = new List<SecurityRule>();

        public Policy(ManagementRule firstManagementRule, ComplaintsRule firstComplaintsRule,
                      SecurityRule firstSecurityRule, SuspensionRule firstSuspensionRule)
        {
            m_ManagementRules.Add(firstManagementRule);
            m_ComplaintsRules.Add(firstComplaintsRule);
            m_SecurityRules.Add(firstSecurityRule);
            m_SuspensionRules.Add(firstSuspensionRule);
        }

        public bool ValidatePassword(string password)
        {
            throw new NotImplementedException();
        }

        public SecurityRule GetPasswordRule()
        {
            throw new NotImplementedException();
        }

        public bool CheckComplaintIsValid(DateTime date, string content, Member supervisor, Member member)
        {
            throw new NotImplementedException();
        }

        public ComplaintsRule GetComplaintRule(DateTime date, string content)
        {
            throw new NotImplementedException();
        }

        public DateTime GetSuspensionPeriod(string cause)
        {
            throw new NotImplementedException();
        }

        public SuspensionRule GetSuspensioRule(string cause)
        {
            throw new NotImplementedException();
        }
    }
}