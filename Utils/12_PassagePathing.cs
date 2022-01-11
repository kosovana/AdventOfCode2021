using System.Collections.Generic;
using System.Linq;

namespace Utils
{
    public class PassagePathing
    {
        private static Dictionary<string, List<string>> _map = new Dictionary<string, List<string>>();
        private static string START = "start";
        private static string END = "end";

        public static int GetPathsCount(string[] input)
        {
            ReadData(input);

            HashSet<string> visitedSmallCaves = new HashSet<string>();
            var result = CheckCave(START, visitedSmallCaves);

            return result;
        }

        private static int CheckCave(string cave, HashSet<string> visitedSmallCaves)
        {
            int result = 0;
            if (cave == END)
                return 1;

            if (char.IsLower(cave[0]))
                visitedSmallCaves.Add(cave);

            foreach (var connectedCave in _map[cave])
            {
                if (char.IsLower(connectedCave[0]) && visitedSmallCaves.Contains(connectedCave))
                {
                    continue;
                }

                result += CheckCave(connectedCave, visitedSmallCaves);
            }

            if (char.IsLower(cave[0]))
                visitedSmallCaves.Remove(cave);
            return result;
        }

        private static void ReadData(string[] input)
        {
            foreach (string line in input)
            {
                string[] lineParts = line.Split('-');
                if (_map.ContainsKey(lineParts[0]))
                    _map[lineParts[0]].Add(lineParts[1]);
                else
                    _map.Add(lineParts[0], new List<string> { lineParts[1] });

                if (_map.ContainsKey(lineParts[1]))
                    _map[lineParts[1]].Add(lineParts[0]);
                else
                    _map.Add(lineParts[1], new List<string> { lineParts[0] });
            }
        }
    }

    public class PassagePathing2
    {
        private static Dictionary<string, List<Cave>> _map = new Dictionary<string, List<Cave>>();
        private static string START = "start";
        private static string END = "end";

        private class Cave
        {
            public Cave(string name)
            {
                Name = name;
                SmallCave = char.IsLower(name[0]);
            }
            public string Name { get; private set; }
            public int VisitsCount { get; set; }
            public bool SmallCave { get; private set; }
            public bool VisitedTwice { get { return VisitsCount == 2; } }

            public override bool Equals(object obj) => this.Equals(obj as Cave);

            public bool Equals(Cave cave)
            {
                return Name == cave.Name;
            }

            public override int GetHashCode() => Name.GetHashCode();
            public override string ToString() { return Name + ", " + VisitsCount; }
        }

        public static int GetPathsCount(string[] input)
        {
            ReadData(input);

            HashSet<Cave> visitedSmallCaves = new HashSet<Cave>();
            var result = CheckCave(new Cave(START), visitedSmallCaves);

            return result;
        }

        private static int CheckCave(Cave cave, HashSet<Cave> visitedSmallCaves)
        {
            int result = 0;
            if (cave.Name == END)
                return 1;

            if (cave.SmallCave)
            {
                if (!visitedSmallCaves.Contains(cave))
                    visitedSmallCaves.Add(cave);
                cave.VisitsCount++;
                if (cave.VisitsCount > 2)
                    throw new System.Exception();
            }

            foreach (Cave connectedCave in _map[cave.Name])
            {
                if (visitedSmallCaves.Contains(connectedCave) && visitedSmallCaves.Any(x => x.VisitedTwice))
                {
                    continue;
                }

                result += CheckCave(connectedCave, visitedSmallCaves);
            }

            if (cave.SmallCave)
            {
                cave.VisitsCount--;
                if (cave.VisitsCount == 0)
                    visitedSmallCaves.Remove(cave);
            }
            return result;
        }

        private static void ReadData(string[] input)
        {
            Dictionary<string, Cave> temp = new Dictionary<string, Cave>();
            foreach (string line in input)
            {
                string[] lineParts = line.Split('-');

                var cave1Name = lineParts[0];
                var cave2Name = lineParts[1];
                if (!temp.ContainsKey(cave1Name))
                    temp.Add(cave1Name, new Cave(cave1Name));
                if (!temp.ContainsKey(cave2Name))
                    temp.Add(cave2Name, new Cave(cave2Name));

                if (cave1Name == START)
                    AddCaveToMap(temp, cave1Name, cave2Name);
                else if (cave2Name == START)
                    AddCaveToMap(temp, cave2Name, cave1Name);
                else if (cave1Name == END)
                    AddCaveToMap(temp, cave2Name, cave1Name);
                else if (cave2Name == END)
                    AddCaveToMap(temp, cave1Name, cave2Name);
                else
                {
                    AddCaveToMap(temp, cave1Name, cave2Name);
                    AddCaveToMap(temp, cave2Name, cave1Name);
                }
            }
        }

        private static void AddCaveToMap(Dictionary<string, Cave> temp, string mapKey, string cave)
        {
            if (_map.ContainsKey(mapKey))
                _map[mapKey].Add(temp[cave]);
            else
                _map.Add(mapKey, new List<Cave> { temp[cave] });
        }
    }
}
