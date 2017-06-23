using Forums.ViewModel.ForumsAndGroups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forums.ViewModel.Logger
{
    [Serializable]
    public abstract class Logger
    {
        public void WriteToLogger(string eventinfo) { }
    }
}