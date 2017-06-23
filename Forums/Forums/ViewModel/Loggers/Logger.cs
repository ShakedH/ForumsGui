using Forums.ViewModel.ForumsAndGroups;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forums.ViewModel.Logger
{
    [Serializable]
    public abstract class Logger
    {
        protected string FilePath;
        public void WriteToLogger(string eventinfo)
        {
            using (StreamWriter writer = new StreamWriter(FilePath, append: true))
            {
                writer.WriteLine(string.Format("{0}: {1}", DateTime.Now, eventinfo));
            }
        }
    }
}