using System;
using System.Collections.Generic;

namespace Utils
{
    public class Location
    {
        private const string _forward = "forward";

        private static Dictionary<string, int> _depthDict = new Dictionary<string, int>
        {
            { "down", 1},
            { "up", -1 }
        };

        private static Dictionary<string, int> _positionDict = new Dictionary<string, int>
        {
            { "forward", 1 }
        };

        public static int GetPosition(string[] lines)
        {
            int depth = 0;
            int horizPosition = 0;

            foreach (var line in lines)
            {
                if (string.IsNullOrEmpty(line))
                    continue;

                string[] command = line.Split(' ');
                int commandValue = Convert.ToInt32(command[1]);
                string commandDirection = command[0];
                if (commandDirection == _forward)
                {
                    horizPosition += commandValue * _positionDict[commandDirection];
                }
                else
                {
                    depth += commandValue * _depthDict[commandDirection];
                };
            }

            return depth * horizPosition;
        }
    }

    public class Location2
    {
        private const string _forward = "forward";
        private const string _up = "up";
        private const string _down = "down";

        public static int GetPosition(string[] lines)
        {
            int depth = 0;
            int horizPosition = 0;
            int aim = 0;

            foreach (var line in lines)
            {
                string[] command = line.Split(' ');
                int commandValue = Convert.ToInt32(command[1]);
                string commandDirection = command[0];

                switch (commandDirection)
                {
                    case _up:
                        aim -= commandValue;
                        break;
                    case _down:
                        aim += commandValue;
                        break;
                    case _forward:
                        horizPosition += commandValue;
                        depth += aim * commandValue;
                        break;
                }
            }

            return depth * horizPosition;
        }
    }
}
