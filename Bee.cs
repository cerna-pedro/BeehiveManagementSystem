using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeehiveManagementSystem
{
    internal abstract class Bee :IWorker
    {
        public string Job { get;  }

        public abstract float CostPerShift { get;  }
        public Bee(string job)
        {
            Job = job;
        }

        public abstract void DoJob();
        public void WorkTheNextShift()
        {
            if (HoneyVault.ConsumeHoney(CostPerShift))
            {
                DoJob();
            }

        }
    }
}
