using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeehiveManagementSystem
{
    internal class NectarCollector : Bee
    {
        public NectarCollector() : base("Nectar Collector") { }
        public override float CostPerShift { get { return 1.95f; } }

        public override void DoJob()
        {

        }
    }
}
