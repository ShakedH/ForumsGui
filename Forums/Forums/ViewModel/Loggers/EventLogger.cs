using System;

namespace Forums.ViewModel.ForumsAndGroups
{
    [Serializable]
    public class EventLogger : Logger.Logger
    {
        private static EventLogger instance;

        private EventLogger()
        {
            FilePath = "EventLog.txt";
        }

        public static EventLogger Instance
        {
            get
            {
                if (instance == null)
                    instance = new EventLogger();
                return instance;
            }
        }
    }
}