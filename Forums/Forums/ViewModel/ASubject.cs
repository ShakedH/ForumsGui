using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forums.ViewModel
{
    public abstract class ASubject
    {
        private List<IObserver> m_Observers = new List<IObserver>();

        public void Notify()
        {
            foreach (IObserver observer in m_Observers)
                observer.Update();
        }

        public void Subscribe(IObserver observer)
        {
            if (!m_Observers.Contains(observer))
                m_Observers.Add(observer);
        }

        public void Unsubscribe(IObserver observer)
        {
            m_Observers.Remove(observer);
        }
    }
}
