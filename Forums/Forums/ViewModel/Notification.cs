using Forums.ViewModel.ForumsAndGroups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forums.ViewModel
{
    [Serializable]
    public class Notification
    {
        private string m_Content;

        public Notification(string content)
        {
            m_Content = content;
        }

        // TODO BOM: WTF?!
        public Message FindMessage(string messageID)
        {
            throw new NotImplementedException();
        }
    }
}
