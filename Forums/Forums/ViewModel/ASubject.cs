using System;
using System.Collections.Generic;

namespace Forums.ViewModel
{
    [Serializable]
    public abstract class ASubject
    {
        protected List<IObserver> m_Observers = new List<IObserver>();

        public void Notify(Notification notification)
        {
            foreach (IObserver obs in m_Observers)
            {
                obs.Update(notification);
            }
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
