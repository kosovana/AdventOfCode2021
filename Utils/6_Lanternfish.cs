using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public class Lanternfish
    {
        public static int LanternfishCount(string input, int days)
        {
            List<int> fishSchool = new List<int>(10000);

            var initialFishSchool = input.Split(',');
            foreach (var fish in initialFishSchool)
            {
                fishSchool.Add(Convert.ToInt32(fish));
            }

            for (int i = 0; i < days; i++)
            {
                int currentFishSchoolCount = fishSchool.Count;
                for (int j = 0; j < currentFishSchoolCount; j++)
                {
                    if (fishSchool[j] == 0)
                    {
                        fishSchool[j] = 6;
                        fishSchool.Add(8);
                    }
                    else
                    {
                        fishSchool[j]--;
                    }
                }
            }

            return fishSchool.Count;
        }
    }

    public class Lanternfish2
    {
        public static Int64 LanternfishCount(string input, int days)
        {
            Int64[] fish = new Int64[9];

            var initialFishSchool = input.Split(',');
            foreach (var initialState in initialFishSchool)
            {
                int fishState = Convert.ToInt32(initialState);
                fish[fishState]++;
            }

            for (int i = 0; i < days; i++)
            {
                Int64 zeroState = fish[0];
                for (int j = 1; j < fish.Length; j++)
                {
                    fish[j - 1] = fish[j];
                }

                fish[6] += zeroState;
                fish[8] = zeroState;
            }

            Int64 fishTotalCount = 0;
            for (int i = 0; i < fish.Length; i++)
                fishTotalCount += fish[i];

            return fishTotalCount;
        }
    }
}
