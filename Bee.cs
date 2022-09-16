using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeehiveManagementSystem
{
    internal class Bee
    {
        protected string Job { get;  }

        public virtual float CostPerShift { get;  }
        public Bee(string job)
        {
            Job = job;
        }

        public virtual void DoJob()
        {

        }
        protected void WorkTheNextShift()
        {
            if (HoneyVault.ConsumeHoney(CostPerShift))
            {
                DoJob();
            }

        }
    }
}
