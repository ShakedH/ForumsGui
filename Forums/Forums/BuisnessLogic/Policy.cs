using Forums.BuisnessLogic.Rules;
using System;
using System.Collections.Generic;

namespace Forums.BuisnessLogic.ForumsAndGroups
{
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

        public Boolean ValidatePassword(String password)
        {
            throw new NotImplementedException();
        }

        public SecurityRule GetPasswordRule()
        {
            throw new NotImplementedException();
        }

        public Boolean CheckComplaintIsValid(DateTime date, String content, Member supervisor, Member member)
        {
            throw new NotImplementedException();
        }

        public ComplaintsRule GetComplaintRule(DateTime date, String content)
        {
            throw new NotImplementedException();
        }

        public DateTime GetSuspensionPeriod(String cause)
        {
            throw new NotImplementedException();
        }

        public SuspensionRule GetSuspensioRule(String cause)
        {
            throw new NotImplementedException();
        }
    }
}