using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeehiveManagementSystem
{
    internal class Queen : Bee
    {
        private const float EGGS_PER_SHIFT = 0.45f;
        private const float HONEY_PER_UNASSIGNED_WORKER = 0.5f;
        private Bee[] workers = new Bee[0];
        private float eggs = 0f;
        private float unassignedWorkers = 3f;
        public Queen() : base("Queen")
        {
            AssignBee("Egg Care");
            AssignBee("Honey Manufacturer");
            AssignBee("Nectar Collector");
        }
        public override float CostPerShift { get { return 2.15f; } }

        public override void DoJob()
        {
            eggs += EGGS_PER_SHIFT;
            foreach (Bee bee in workers)
            {
                bee.WorkTheNextShift();
            }
            HoneyVault.ConsumeHoney(unassignedWorkers* HONEY_PER_UNASSIGNED_WORKER);



        }
        /// <summary>
        /// Resizes workers array while decrementing from unsassigned workers.
        /// </summary>
        /// <param name="worker">Worker to add to the workers array.</param>
        private void AddWorker(Bee worker)
        {
            if (unassignedWorkers >= 1)
            {
                unassignedWorkers--;
                Array.Resize(ref workers, workers.Length + 1);
                workers[workers.Length - 1] = worker;
            }
        }

        public void AssignBee(string job)
        {
            switch (job)
            {
                case "Egg Care":
                    AddWorker(new EggCare(this));
                    break;
                case "Nectar Collector":
                    AddWorker(new NectarCollector());
                    break;
                case "Honey Manufacturer":
                    AddWorker(new HoneyManufacturer());
                    break;
                default:
                    break;
            }
        }
        public void CareForEggs(float eggsToConvert)
        {
            if (eggs >= eggsToConvert)
            {
                eggs -= eggsToConvert;
                unassignedWorkers += eggsToConvert;
            }
        }

        public string UpdateStatusReport()
        {
            int nectarCount = 0;
            int honeyCount = 0;
            int eggCount = 0;
            for (int i = 0; i < workers.Length; i++)
            {
                if (workers[i].Job == "Egg Care")
                {
                    eggCount++;

                }
                if (workers[i].Job == "Nectar Collector")
                {
                    nectarCount++;

                }
                if (workers[i].Job == "Honey Manufacturer")
                {
                    honeyCount++;

                }

            }

            string report = HoneyVault.StatusReport;
            string update = $"\n\nEgg count: {eggs:0.0}\nUnassigned workers: {unassignedWorkers:0.0}\n\n{nectarCount} Nectar Collector bee{(nectarCount > 1 ? "s" : "")}\n{honeyCount} Honey Manufacturer bee{(honeyCount > 1 ? "s" : "")}\n{eggCount} Egg Care bee{(eggCount > 1 ? "s" : "")}\n\nTOTAL WORKERS: {workers.Length}";
            return report + update;
        }
    }
}
