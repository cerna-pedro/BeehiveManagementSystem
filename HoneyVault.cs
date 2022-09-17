using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeehiveManagementSystem
{
    internal static class HoneyVault
    {
        public const float NECTAR_CONVERSION_RATIO = .19f;
        public const float LOW_LEVEL_WARNING = 10f;

        public static string StatusReport
        {
            get
            {
                bool isLowHoney = honey < LOW_LEVEL_WARNING;
                bool isLowNectar = nectar < LOW_LEVEL_WARNING;
                string warning = "";
                if (isLowHoney)
                {
                    warning += "\nLOW HONEY - ADD A HONEY MANUFACTURER";
                }
                if (isLowNectar)
                {
                    warning += "\nLOW NECTAR - ADD A NECTAR COLLECTOR";
                }
                return $"Honey: {honey:0.0}\nNectar: {nectar:0.0}" + warning;

            }
        }
        private static float honey = 25f;
        private static float nectar = 100f;

        public static void ConvertNectarToHoney(float amount)
        {
            float nectarToConvert = amount;
            if (nectarToConvert > nectar)
            {
                nectarToConvert = nectar;
            }
            nectar -= nectarToConvert;
            honey += (nectarToConvert * NECTAR_CONVERSION_RATIO);

        }

        public static void CollectNectar(float amount)
        {
            if (amount > 0)
            {
                nectar += amount;
            }


        }

        public static bool ConsumeHoney(float amount)
        {
            if (amount <= honey)
            {
                honey -= amount;
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
