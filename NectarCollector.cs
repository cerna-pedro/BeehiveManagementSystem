﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeehiveManagementSystem
{
    internal class NectarCollector : Bee
    {
        private const float NECTAR_COLLECTED_PER_SHIFT = 33.25f;
        public NectarCollector() : base("Nectar Collector") { }
        public override float CostPerShift { get { return 1.95f; } }

        public override void DoJob()
        {
            HoneyVault.CollectNectar(NECTAR_COLLECTED_PER_SHIFT);

        }
    }
}
