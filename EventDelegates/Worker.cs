using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDelegates
{
    public delegate void WorkPerformedHandler (int hours);

    class Worker
    {
        public event WorkPerformedHandler WorkPerformed;
        //user custom event args with a class that extent the EventArgs class with EventHandler<T>
        public event EventHandler<WorkPerformedEventArgs> WorkCompleted;
        public void DoWork(int hours)
        {
            for (int i = 0; i < hours; i++)
            {
                //raise event 
                OnWorkPerformed(i + 1);
            }
            //raise event
            OnWorkCompleted( hours);
        }

        protected virtual void OnWorkPerformed(int hours)
        {
            WorkPerformed?.Invoke(hours);
        }

        protected virtual void OnWorkCompleted(int  hours)
        {
            WorkPerformedEventArgs wpea = new WorkPerformedEventArgs {Hours = hours};
            WorkCompleted?.Invoke(this, wpea);
        }
    }
}
