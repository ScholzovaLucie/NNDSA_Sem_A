﻿using Newtonsoft.Json;
using scholzova_sem_01.Graf;

namespace scholzova_sem_01.Path
{

    public class Paths<T>
    {
        [JsonProperty]
        public List<Path<T>> paths { get; set; }
        private int index = 1;
        private Graf<T> graphData;
        public List<Vertex<T>> InputVertices { get; private set; }
        public List<Vertex<T>> OutputVertices { get; private set; }

        public Paths(
            GraphProcessor<T> processor,
            Graf<T> graf
            )
        {
            this.graphData = graf;
            this.InputVertices = processor.getInputVertices();
            this.OutputVertices = processor.getOutputVertices();
            paths = new List<Path<T>>();
            FindPaths();
        }

        public void printList()
        {
            Console.WriteLine("Dostupné cesty:");
            foreach (var path in paths)
            {
                Console.WriteLine($"Cesta {path.Name}: {string.Join(" -> ", path.Vertices)}");
            }
        }

        public void FindPaths()
        {
            foreach (var inputVertex in InputVertices)
            {
                List<Vertex<T>> visited = new List<Vertex<T>>();
                DFS(inputVertex, visited);
            }
        }

        private void DFS(Vertex<T> currentVertex, List<Vertex<T>> visited)
        {
            visited.Add(currentVertex);
            if (containsByName(currentVertex.Name, OutputVertices)
                && visited.Count > 1
                && !PathAlreadyExists(visited))
            {
                paths.Add(new Path<T>(index++,
                    new LinkedList<Vertex<T>>(visited)));
            }


            foreach (var edge in currentVertex.Edges)
            {
                if (!visited.Contains(edge.EndVertex))
                {
                    DFS(edge.EndVertex, visited);
                }
            }

            foreach (var cross in graphData.Cross)
            {
                if (cross[0] == currentVertex
                    && !visited.Contains(cross[1])
                    && !visited.Contains(cross[2]))
                {
                    List<Vertex<T>> newVisited = new List<Vertex<T>>(visited);
                    newVisited.Add(cross[1]);
                    DFS(cross[2], newVisited);
                }
            }

            visited.Remove(currentVertex);
        }


        private bool containsByName(T name, List<Vertex<T>> list)
        {
            foreach (var vertex in list)
            {
                if (vertex.Name.Equals(name))
                {
                    return true;
                }
            }

            return false;
        }

        private bool PathAlreadyExists(List<Vertex<T>> newPath)
        {
            foreach (var path in paths)
            {
                if (path.Equals(newPath))
                {
                    return true;
                }
            }
            return false;
        }
    }
}