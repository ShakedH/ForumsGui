using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Forums.ViewModel.ForumsAndGroups
{
    public class Discussion : ASubject
    {
        private static int index = 1;

        public SubForum SubForum { get; set; }
        public ObservableCollection<Message> Messages { get; set; }
        public string Topic { get; set; }
        public string DiscussionID { get; set; }
        public int ID { get; set; }

        public Discussion(SubForum subForum, string topic, string openingMessage, Member writtenBy)
        {
            SubForum = subForum;
            Topic = topic;
            ID = index;
            index++;
            Messages = new ObservableCollection<Message>();
            Messages.Add(new Message(this, writtenBy, openingMessage));
        }

        public void AddMessage(Message message)
        {
            if (message != null && !Messages.Contains(message))
                Messages.Add(message);
        }

        public Message AddMessage(Member member, string content)
        {
            Message msg = new Message(this, member, content);
            AddMessage(msg);
            SendOpenNotif();
            return msg;
        }

        public Message GetOpenMessage()
        {
            if (Messages.Count == 0)
                throw new Exception(string.Format("Discussion {0} is empty", this.Topic));
            return Messages[0];
        }

        public Message GetMessage(string messageID)
        {
            foreach (Message msg in Messages)
                if (msg.ID == messageID)
                    return msg;
            throw new Exception(string.Format("Message #{0} not found in discussion {1}", messageID, ID));
        }

        public List<Message> GetDisMessages(string searchTerm)
        {
            // Related to search - not needed
            throw new NotImplementedException();
        }

        public void AddToDMsgs(Message message)
        {
            // Related to search - not needed
            throw new NotImplementedException();
        }

        public void SendOpenNotif()
        {
            // Doesn't match the Sequence Diagrams in order to fit with Observer Desing Pattern
            // ToDo delete this?
            string notifContent = string.Format("There is a new message in your discussion.\nCheck it out: {0}", DiscussionID);
            Notification notification = new Notification(notifContent);
            Notify(notification);
        }

        public override string ToString()
        {
            return Topic;
        }

        public override bool Equals(object obj)
        {
            Discussion d = obj as Discussion;
            return ID == d.ID;
        }
    }
}
