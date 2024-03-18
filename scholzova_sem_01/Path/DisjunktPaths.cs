using Newtonsoft.Json;

namespace scholzova_sem_01.Path
{
    public class DisjointPaths<T>
    {
        [JsonProperty]
        public List<HashSet<Path<T>>> DisjointPathSets { get; private set; }
        private int MaxTupleSize;

        public DisjointPaths(List<Path<T>> paths, int maxTupleSize)
        {
            DisjointPathSets = new List<HashSet<Path<T>>>();
            MaxTupleSize = maxTupleSize;
            GenerateDisjointSets(paths);
        }

        public List<HashSet<Path<T>>> getDisjonktPaths()
        {
            return DisjointPathSets;
        }

        public void printList()
        {
            Console.WriteLine("Disjunktní množina cest: ");
            foreach (var disjointSet in DisjointPathSets)
            {
                foreach (var path in disjointSet)
                {
                    Console.Write(path.Name + ", ");
                }
                Console.WriteLine();
            }
        }

        private void GenerateDisjointSets(List<Path<T>> paths)
        {
            var pairs = GenerateAllPairs(paths);

            foreach (var pair in pairs)
            {
                DisjointPathSets.Add(new HashSet<Path<T>>(pair));
            }

            for (int currentSize = 2; currentSize < MaxTupleSize; currentSize++)
            {
                var currentSets = DisjointPathSets.Where(s => s.Count == currentSize).ToList();
                var newSets = new List<HashSet<Path<T>>>();

                foreach (var set in currentSets)
                {
                    foreach (var path in paths)
                    {
                        if (set.All(s => s.IsDisjoint(path)) && !set.Contains(path))
                        {
                            var newSet = new HashSet<Path<T>>(set) { path };
                            if (!newSets.Any(ns => ns.SetEquals(newSet)))
                            {
                                newSets.Add(newSet);
                            }
                        }
                    }
                }

                DisjointPathSets.AddRange(newSets);
            }
        }

        private List<List<Path<T>>> GenerateAllPairs(List<Path<T>> paths)
        {
            var pairs = new List<List<Path<T>>>();

            for (int i = 0; i < paths.Count; i++)
            {
                for (int j = i + 1; j < paths.Count; j++)
                {
                    if (paths[i].IsDisjoint(paths[j]))
                    {
                        pairs.Add(new List<Path<T>> { paths[i], paths[j] });
                    }
                }
            }

            return pairs;
        }

    }
}
