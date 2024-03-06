using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace scholzova_sem_01.Path
{
    public class RList<T>
    {
        [JsonProperty]
        public List<List<Path<T>>> List { get; set; }

        public RList(LList<T> LList)
        {
            List = FindDisjointPaths(LList.List, new List<Path<T>>(), new List<List<Path<T>>>());
        }

        public void printList()
        {
            Console.WriteLine("Disjunktní množina cest: ");
            foreach (var disjointSet in List)
            {
                foreach (var path in disjointSet)
                {
                    Console.Write(path.Name + ", ");
                }
                Console.WriteLine();
            }
        }

        private static List<List<Path<T>>> FindDisjointPaths(List<Path<T>> paths, List<Path<T>> currentSet, List<List<Path<T>>> disjointPaths)
        {
            int count = 0;
            if (disjointPaths.Count == 0)
            {
                for (int i = 0; i < paths.Count; i++)
                {
                    for (int j = 0; j < paths.Count; j++)
                    {
                        if (paths[i].Vertices.First.Value.sameVertex(paths[j].Vertices.First.Value)) break;
                        if (paths[i].Vertices.Last.Value.sameVertex(paths[j].Vertices.Last.Value)) break;
                        currentSet.Add(paths[i]);
                        currentSet.Add(paths[j]);

                        if (IsDisjointSet(currentSet) && !disjunktAlreadyExist(currentSet, disjointPaths))
                        {
                            disjointPaths.Add(new List<Path<T>>(currentSet));
                            count++;
                        }
                        currentSet.Clear();
                    }
                }
            }
            else
            {
                for (int i = 0; i < disjointPaths.Count; i++)
                {
                    for (int j = 0; j < paths.Count; j++)
                    {
                        
                        for (int k = 0; k < disjointPaths[i].Count; k++)
                        {
                            currentSet.Add(disjointPaths[i][k]);
                        }
                        currentSet.Add(paths[j]);

                        if (IsDisjointSet(currentSet) && !disjunktAlreadyExist(currentSet, disjointPaths))
                        {
                            disjointPaths.Add(new List<Path<T>>(currentSet));
                            count++;
                        }
                        currentSet.Clear();
                    }

                }
            }
            if (count > 0)
            {
                FindDisjointPaths(paths, currentSet, disjointPaths);
            }

            return disjointPaths;
        }

        private static bool disjunktAlreadyExist(List<Path<T>> set, List<List<Path<T>>> disjointPaths)
        {
            bool exist = false;

            for (int i = 0; i < disjointPaths.Count; i++)
            {
                exist = set.OrderBy(t => t.Name).SequenceEqual(disjointPaths[i].OrderBy(t => t.Name));
                if (exist)
                {
                    return true;
                }
            }
            return false;
        }

        private static bool IsDisjointSet(List<Path<T>> set)
        {

            for (int i = 0; i < set.Count - 1; i++)
            {
                for (int j = i + 1; j < set.Count; j++)
                {
                    if (set[i].Name == set[j].Name)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

    }
}
