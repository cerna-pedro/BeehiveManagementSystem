using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeehiveManagementSystem
{
    internal class Queen : Bee
    {
        public Queen() : base("Queen") { }
        public override float CostPerShift { get { return 2.15f; } }

        public override void DoJob()
        {


        }
    }
}
