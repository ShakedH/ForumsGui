using Forums.ViewModel.ForumsAndGroups;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forums.ViewModel
{
    [Serializable]
    public class Message
    {
        private static int index = 1;

        public Member PublishedBy { get; set; }
        public Discussion Discussion { get; set; }
        public Message RepliesTo { get; set; }
        public ObservableCollection<Message> Replies { get; set; }
        public DateTime Published { get; set; }
        public string Content { get; set; }
        public string MessageID { get; set; }

        public Message(Discussion discussion, Member publishedBy, string content)
        {
            Replies = new ObservableCollection<Message>();
            Discussion = discussion;
            PublishedBy = publishedBy;
            Content = content;
            MessageID = index.ToString();
            index++;
        }

        public Message(Message repliesTo, Member publishedBy, string content)
        {
            Replies = new ObservableCollection<Message>();
            RepliesTo = repliesTo;
            PublishedBy = publishedBy;
            Content = content;
            Discussion = RepliesTo.getDiscussion();
            MessageID = index.ToString();
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

        // TODO BOM: New method
        public bool HasReplies()
        {
            return Replies.Count > 0;
        }

        public override string ToString()
        {
            return Content;
        }
    }
}
