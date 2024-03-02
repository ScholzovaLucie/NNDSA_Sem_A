using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using scholzova_sem_01.Lists;
using Path = scholzova_sem_01.Lists.Path;

namespace scholzova_sem_01.Graf
{
    internal class LList
    {
        public List<Path> List { get; set; }
        private int index = 1;

        public LList(GraphData graphData)
        {
            List = new List<Path>();
            createLList(graphData);
        }


        private void createLList(GraphData graphData)
        {
            foreach (var startVertex in graphData.InputVertices)
            {
                LinkedList<Vertex> list = new LinkedList<Vertex>();
                list.AddFirst(startVertex);
                DFS(graphData, startVertex, new Path(list));
            }
        }


        public void printList()
        {
            Console.WriteLine("Dostupné cesty:");
            foreach (var path in List)
            {
                Console.WriteLine($"Cesta {path.Name}: {string.Join(" -> ", path.Vertices)}");
            }
        }

        private void DFS(GraphData graphData, Vertex currentVertex, Path currentPath, Vertex beforeVertex = null)
        {
            foreach (var edge in graphData.Edges.Where(e => e.StartVertex.Name.Equals(currentVertex.Name)))
            {
                Vertex nextVertex = edge.EndVertex;
                Edge exist = existNextPath(nextVertex.Name, graphData);
                bool cross = isCross(nextVertex, graphData, beforeVertex, currentPath, currentVertex);

                if (!containsByName(nextVertex.Name, graphData.OutputVertices) && exist != null && !cross)
                    {
                        Path actualPath = currentPath.Copy();
                        actualPath.Vertices.AddLast(nextVertex);
                        DFS(graphData, nextVertex, actualPath);
                    }

                if (!cross) lastVertex(nextVertex, graphData, beforeVertex, currentPath, currentVertex, exist);


            }

        }

        private void lastVertex(Vertex nextVertex, GraphData graphData, Vertex beforeVertex, Path currentPath, Vertex currentVertex, Edge exist)
        {
            if (containsByName(nextVertex.Name, graphData.OutputVertices) && exist != null)
            {
                currentPath.Vertices.AddLast(nextVertex);

                if (!PathAlreadyExists(currentPath))
                {
                    currentPath.setName(index++);
                    List.Add(currentPath);
                }

                Path newPath = currentPath.Copy();
                DFS(graphData, nextVertex, newPath);
            }
            else if (containsByName(nextVertex.Name, graphData.OutputVertices))
            {
                currentPath.Vertices.AddLast(nextVertex);

                if (!PathAlreadyExists(currentPath))
                {
                    currentPath.setName(index++);
                    List.Add(currentPath);
                }

                LinkedList<Vertex> list = new LinkedList<Vertex>();
                list.AddFirst(currentVertex);
                Path newPath = new Path(list);
                newPath.Vertices.AddLast(nextVertex);
            }
        }

        private bool isCross(Vertex nextVertex, GraphData graphData, Vertex beforeVertex, Path currentPath, Vertex currentVertex)
        {
            if (containsByName(nextVertex.Name, graphData.Cross))
            {
                beforeVertex = currentVertex;
                currentPath.Vertices.AddLast(nextVertex);
                DFS(graphData, nextVertex, currentPath, beforeVertex);
                return true;
            }

            if (containsByName(currentVertex.Name, graphData.Cross) && beforeVertex != null)
            {
                List<Edge> anotherNextVertex = getAnotherNextVertex(beforeVertex, graphData);
                if (anotherNextVertex.Count > 1)
                {
                    for (int i = 0; i < anotherNextVertex.Count; i++)
                    {
                        for (int j = 0; j < graphData.Edges.Count; j++)
                        {
                            Edge edge = findEdge(graphData.Edges[j].StartVertex, graphData.Edges[j].EndVertex, graphData);

                            if (edge.StartVertex.Name.Equals(currentVertex.Name) && edge.EndVertex.Name.Equals(nextVertex.Name))
                            {
                                currentPath.Vertices.AddLast(edge.EndVertex);
                                DFS(graphData, edge.EndVertex, currentPath);
                                return true;
                            }
                        }
                    }
                   
                }

                else if (!nextVertex.Name.Equals(anotherNextVertex[0].EndVertex.Name))
                {
                    currentPath.Vertices.AddLast(nextVertex);
                    DFS(graphData, nextVertex, currentPath);
                    return true;
                }

            }
            
            return false;
        }

        private Edge findEdge(Vertex start, Vertex end, GraphData data)
        {
            for (int i = 0; i < data.Edges.Count; i++)
            {
                if (data.Edges[i].StartVertex.Name.Equals(start.Name) && data.Edges[i].EndVertex.Name.Equals(end.Name)) return data.Edges[i]; 
            }
            return null;
        }

        private List<Edge> getAnotherNextVertex(Vertex actual, GraphData data)
        {
            List<Edge> list = new List<Edge>();
            for (int i = 0; i < data.Edges.Count; i++)
            {
                if (data.Edges[i].StartVertex.Name.Equals(actual.Name) && !containsByName(data.Edges[i].EndVertex.Name, data.Cross))
                {
                    list.Add(data.Edges[i]);
                }
            }
            return list;
        }

        private bool containsByName(string name, List<Vertex> list)
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

        private Edge existNextPath(string name, GraphData graphData)
        {
            foreach (var edge in graphData.Edges)
            {
                if (edge.StartVertex.Name.Equals(name))
                {
                    return edge;
                }

            }
            return null;
        }

        private bool PathAlreadyExists(Path newPath)
        {
            foreach (var path in List)
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
