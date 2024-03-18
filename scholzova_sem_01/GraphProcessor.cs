using scholzova_sem_01.Graf;
using scholzova_sem_01.Parser;


namespace scholzova_sem_01
{
    public class GraphProcessor<T>
    {
        private List<Vertex<T>> Vertices { get; set; }
        private List<Vertex<T>> InputVertices { get; set; }
        private List<Vertex<T>> OutputVertices { get; set; }
        private List<List<Vertex<T>>> Cross {  get; set; }
        private List<Edge<T>> edges { get; set; }


        public void ProcessGraph(string filePath)
        {
            Parser<T> parser = new Parser<T>(filePath);
            Vertices = parser.ExtractVertices();
            edges = parser.ExtractEdges();
            InputVertices = parser.ExtractInputVertices();
            OutputVertices = parser.ExtractOutputVertices();
            Cross = parser.ExtractCross();
        }

        public Graf<T> CreateGraf()
        {
            Graf<T> graf = new Graf<T>();

            foreach (Vertex<T> vertex in Vertices)
            {
                List<Edge<T>> currentEdges = findEdges(vertex, edges);
                foreach (var edge in currentEdges)
                {
                    vertex.Edges.Add(edge);
                }
                graf.AddVertex(vertex);

            }

            foreach (var item in Cross)
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
                if (edge.StartVertex.sameVertex(vertex)) currentEdges.Add(edge);
            }
            return currentEdges;
        }


        public List<Vertex<T>> getInputVertices()
        {
            return InputVertices;
        }

        public List<Vertex<T>> getOutputVertices()
        {
            return OutputVertices;
        }

        public List<Vertex<T>> GetVertices()
        {
            return Vertices;
        }

        public List<List<Vertex<T>>> getCross()
        {
            return Cross;
        }


    }


}
