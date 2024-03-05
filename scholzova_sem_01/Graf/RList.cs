﻿//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Newtonsoft.Json;
//using Path = scholzova_sem_01.Graf.Path;

//namespace scholzova_sem_01.Graf
//{
//    public class RList<T>
//    {
//        [JsonProperty]
//        public List<List<Path<T>>> List { get; set; }
//        public RList(LList<T> LList)
//        {
//            List = FindDisjointPaths(LList.List, new List<Path>(), new List<List<Path>>());
//        }

//        public void printList()
//        {
//            Console.WriteLine("Disjunktní množina cest: ");
//            foreach (var disjointSet in List)
//            {
//                foreach (var path in disjointSet)
//                {
//                    Console.Write(path.Name + ", ");
//                }
//                Console.WriteLine();
//            }
//        }

//        private static List<List<Path>> FindDisjointPaths(List<T> paths, List<T> currentSet, List<T> disjointPaths)
//        {
//            int count = 0;

//            if (disjointPaths.Count == 0)
//            {
//                for (int i = 0; i < paths.Count; i++)
//                {
//                    for (int j = 0; j < paths.Count; j++)
//                    {
//                        currentSet.Add(paths[i]);
//                        currentSet.Add(paths[j]);

//                        if (IsDisjointSet(currentSet) && !disjunktAlreadyExist(currentSet, disjointPaths))
//                        {
//                            disjointPaths.Add(new List<Path>(currentSet));
//                            count++;
//                        }
//                        currentSet.Clear();
//                    }

//                }
//            }
//            else
//            {
//                for (int i = 0; i < disjointPaths.Count; i++)
//                {
//                    for (int j = 0; j < paths.Count; j++)
//                    {
//                        for (int k = 0; k < disjointPaths[i].Count; k++)
//                        {
//                            currentSet.Add(disjointPaths[i][k]);
//                        }
//                        currentSet.Add(paths[j]);

//                        if (IsDisjointSet(currentSet) && !disjunktAlreadyExist(currentSet, disjointPaths))
//                        {
//                            disjointPaths.Add(new List<Path>(currentSet));
//                            count++;
//                        }
//                        currentSet.Clear();
//                    }

//                }
//            }

//            if (count > 0)
//            {
//                FindDisjointPaths(paths, currentSet, disjointPaths);
//            }


//            return disjointPaths;
//        }

//        private static bool disjunktAlreadyExist(List<Path> set, List<List<Path>> disjointPaths)
//        {
//            bool exist = false;

//            for (int i = 0; i < disjointPaths.Count; i++)
//            {
//                exist = set.OrderBy(t => t.Name).SequenceEqual(disjointPaths[i].OrderBy(t => t.Name));
//                if (exist)
//                {
//                    return true;
//                }
//            }
//            return false;
//        }

//        private static bool IsDisjointSet(List<Path> set)
//        {

//            for (int i = 0; i < set.Count - 1; i++)
//            {
//                for (int j = i + 1; j < set.Count; j++)
//                {
//                    if (!set[i].IsDisjoint(set[j]))
//                    {
//                        return false;
//                    }
//                }
//            }
//            return true;
//        }

//    }
//}
