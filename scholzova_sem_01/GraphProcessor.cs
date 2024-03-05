using scholzova_sem_01.Graf;
using scholzova_sem_01.Parser;
using System.Collections.Generic;


namespace scholzova_sem_01
{
    public class GraphProcessor<T>
    {
        public LList<T> LList { get; set; }
        //public RList RList { get; set; }


        public void ProcessGraph(string filePath)
        {
            (
                List<Vertex<T>> vertices, 
                List<Edge<T>> edges,
                List<Vertex<T>>  InputVertices,
                List<Vertex<T>>  OutputVertices, 
                List<List<Vertex<T>>> cross
                ) = new Parser<T>().ParseDataFromFile<T>(filePath);

            Graf<T> graphData = CreateGraf(vertices, edges, cross);

            LList = new LList<T>(graphData, InputVertices, OutputVertices);

            //RList = new RList(LList);

           // LList.printList();
           // RList.printList();

           // parser.saveData(RList, LList);
        }

        private Graf<T> CreateGraf(List<Vertex<T>> vertices, List<Edge<T>> edges, List<List<Vertex<T>>> cross)
        {
            Graf<T> graf = new Graf<T>();

            foreach (Vertex<T> vertex in vertices)
            {
                List<Edge<T>> currentEdges = findEdges(vertex, edges);
                foreach (var edge in currentEdges)
                {
                    vertex.Edges.Add(edge);
                }
                graf.AddVertex(vertex);
                
            }

            foreach (var item in cross)
            {
                graf.Cross.Add(item);
            }


            return graf;
        }

        private List<Edge<T>> findEdges(Vertex<T> vertex, List<Edge<T>> edges)
        {
            List<Edge<T>> currentEdges = new List<Edge<T>>();
            foreach (var edge in edges)
            {
                if(edge.StartVertex.sameVertex(vertex)) currentEdges.Add(edge);
            }
            return currentEdges;
        }
        


    }


}
