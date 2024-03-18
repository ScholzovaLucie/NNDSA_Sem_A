namespace scholzova_sem_01.Graf
{
    public class Graf<T>: IGraf<T>
    {
        private List<Vertex<T>> vertices;

        public List<Vertex<T>> Vertices { get { return vertices; } }
        private List<List<Vertex<T>>> cross;
        public List<List<Vertex<T>>> Cross { get { return cross; } }

        public int size { get { return vertices.Count; } }

        public Graf()
        {
            this.vertices = new List<Vertex<T>>();
            this.cross = new List<List<Vertex<T>>>();
        }

        public void AddVertex(Vertex<T> vertex)
        {
            vertices.Add(vertex);
        }

        public void UpdateVertex(Vertex<T> vertex)
        {
            for (int i = 0; i < vertices.Count; i++)
            {
                if (vertices[i].Name.Equals(vertex.Name)) vertices[i] = vertex;
            }

        }

        public void RemoveVertex(Vertex<T> vertex)
        {
            foreach (var v in vertices)
            {
                foreach (var edge in v.Edges.ToList())
                {
                    if (edge.EndVertex == vertex)
                    {
                        var nextVertex = vertices.FirstOrDefault(v => v.Edges.Any(e => e.StartVertex == vertex));
                        if (nextVertex != null)
                        {
                            edge.EndVertex = nextVertex;
                            nextVertex.Edges.Add(edge);
                        }
                        v.Edges.Remove(edge);
                    }
                }
            }
            vertices.Remove(vertex);
        }

        public bool HasVertex(Vertex<T> vertex)
        {
            return vertices.Contains(vertex);
        }

        public Vertex<T> findVertexByName(T name)
        {
            foreach (var item in vertices)
            {
                if (item.Name.Equals(name)) return item;
            }
            return null;
        }
    }
}
