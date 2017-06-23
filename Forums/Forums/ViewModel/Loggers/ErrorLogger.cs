using System;
namespace Forums.ViewModel.ForumsAndGroups
{
    [Serializable]
    public class ErrorLogger : Logger.Logger
    {
        private static ErrorLogger instance;

        private ErrorLogger()
        {
            FilePath = "ErrorLog.txt";
        }

        public static ErrorLogger Instance
        {
            get
            {
                if (instance == null)
                    instance = new ErrorLogger();
                return instance;
            }
        }
    }
}