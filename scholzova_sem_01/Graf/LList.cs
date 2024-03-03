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
                List<Vertex> visitedVertices = new List<Vertex>();
                DFS(graphData, startVertex, new Path(list), visitedVertices);
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

        private void DFS(GraphData graphData, Vertex currentVertex, Path currentPath, List<Vertex> visitedVertices)
        {
            IEnumerable<Edge> edges = graphData.Edges.Where(e => e.StartVertex.Name.Equals(currentVertex.Name));
            Console.WriteLine("nalezene hrany: " + edges.Count());
            foreach (var edge in edges)
            {
                Vertex nextVertex = edge.EndVertex;
                
                if (!visitedVertices.Contains(nextVertex))
                {
                    bool crossed = false;
                    if (containsByName(nextVertex.Name, graphData.Cross))
                    {
                        (currentVertex, currentPath, visitedVertices) = isCross(nextVertex, graphData, currentPath, currentVertex, visitedVertices);
                        DFS(graphData, currentVertex, currentPath, visitedVertices);
                        crossed = true;
                    }
                        

                    if (!containsByName(nextVertex.Name, graphData.OutputVertices) && crossed == false)
                    {
                        Path actualPath = currentPath.Copy();
                        actualPath.Vertices.AddLast(nextVertex);
                        visitedVertices.Add(currentVertex);
                        DFS(graphData, nextVertex, actualPath, visitedVertices);
                    }

                    lastVertex(nextVertex, graphData, currentPath, visitedVertices);

                }
            }

        }

        private void lastVertex(Vertex nextVertex, GraphData graphData, Path currentPath, List<Vertex> visitedVertices)
        {
            Edge exist = existNextPath(nextVertex.Name, graphData);
            if (containsByName(nextVertex.Name, graphData.OutputVertices) && exist != null)
            {
                currentPath.Vertices.AddLast(nextVertex);

                if (!PathAlreadyExists(currentPath))
                {
                    currentPath.setName(index++);
                    List.Add(currentPath);
                }

                Path newPath = currentPath.Copy();
                DFS(graphData, nextVertex, newPath, visitedVertices);
            }
            else if (containsByName(nextVertex.Name, graphData.OutputVertices))
            {
                currentPath.Vertices.AddLast(nextVertex);

                if (!PathAlreadyExists(currentPath))
                {
                    currentPath.setName(index++);
                    List.Add(currentPath);
                }

            }
        }

        private (Vertex, Path, List<Vertex>) isCross(Vertex nextVertex, GraphData graphData, Path currentPath, Vertex currentVertex, List<Vertex> visitedVertices)
        {
     
            currentPath.Vertices.AddLast(nextVertex);
            visitedVertices.Add(nextVertex);
            List<Edge> anotherNextVertex = getAnotherNextVertex(currentVertex, graphData);

            List<Edge> crossAnotherNextVertex = getAnotherNextVertex(nextVertex, graphData);
            Edge forbidenEdge = null;
            Edge edge = null;

            foreach (var another in anotherNextVertex)
            {
                foreach (var crossAnother in crossAnotherNextVertex)
                {
                    if (crossAnother.EndVertex.Name.Equals(another.EndVertex.Name))
                    {
                        forbidenEdge = crossAnother;
                        break;
                    }
                }
            if (forbidenEdge != null) break;
            }

            foreach (var crossAnother in crossAnotherNextVertex)
            {
                if(!crossAnother.sameEdge(forbidenEdge)) edge = crossAnother;
            }

            currentPath.Vertices.AddLast(edge.EndVertex);
            visitedVertices.Add(edge.EndVertex);
            return (edge.EndVertex, currentPath, visitedVertices);
              
        }

        private Edge findEdge(Vertex start, Vertex end, GraphData data)
        {
            if(start != null && end != null)
            {
            for (int i = 0; i < data.Edges.Count; i++)
            {
                if (data.Edges[i].StartVertex.sameVertex(start) && data.Edges[i].EndVertex.sameVertex(end)) return data.Edges[i]; 
            }
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
