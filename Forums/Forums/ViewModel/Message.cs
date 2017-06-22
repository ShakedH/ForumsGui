using Forums.ViewModel.ForumsAndGroups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forums.ViewModel
{
    [Serializable]
    public class Message
    {
        private static int index = 1;

        private Member PublishedBy { get; set; }
        private Discussion Discussion { get; set; }
        private Message RepliesTo { get; set; }
        private List<Message> Replies { get; set; }
        private string Content { get; set; }
        private DateTime Published { get; set; }
        public string MessageID { get; set; }

        public Message(Discussion discussion, Member publishedBy, string content)
        {
            this.Discussion = discussion;
            this.PublishedBy = publishedBy;
            this.Content = content;
            this.MessageID = index.ToString();
            index++;
        }

        public Message(Message repliesTo, Member publishedBy, string content)
        {
            this.RepliesTo = repliesTo;
            this.PublishedBy = publishedBy;
            this.Content = content;
            this.Discussion = RepliesTo.getDiscussion();
            this.MessageID = index.ToString();
            index++;
        }

        public void AddMessage(Message responeMessage)
        {
            this.Replies.Add(responeMessage);
        }

        public Member GetPublisher()
        {
            return PublishedBy;
        }

        public Discussion getDiscussion()
        {
            return Discussion;
        }

        public void SendOpenNotif()
        {
            throw new NotImplementedException();
        }

        public void SendNotification(Notification notification, Member friend)
        {
            throw new NotImplementedException();
        }
    }
}
