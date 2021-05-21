using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDelegates
{
    public delegate void WorkPerformedHandler (object sender,int hours);

    class Worker
    {
        public event WorkPerformedHandler WorkPerformed;
        //user custom event args with a class that extent the EventArgs class with EventHandler<T>
        // this one actually the exact same as the above (WorkPerformedHandler) but without a delegate so behind the scene the compiler creates the delegate itself
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
            WorkPerformed?.Invoke(this,hours);
        }

        protected virtual void OnWorkCompleted(int  hours)
        {
            WorkPerformedEventArgs wpea = new WorkPerformedEventArgs {Hours = hours};
            WorkCompleted?.Invoke(this, wpea);
        }
    }
}
