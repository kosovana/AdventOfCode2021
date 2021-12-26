using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public static class DepthMeasurements
    {
        public static int GetDepthIncreaseCount(List<int> measurements)
        {
            int counter = 0;
            for (int i = 0; i < measurements.Count - 3; i++)
            {
                if ((measurements[i] + measurements[i + 1] + measurements[i + 2]) <
                    (measurements[i + 1] + measurements[i + 2] + measurements[i + 3]))
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}
