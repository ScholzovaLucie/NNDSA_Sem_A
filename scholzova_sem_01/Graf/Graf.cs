using scholzova_sem_01.Graf;
using scholzova_sem_01.Path;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scholzova_sem_01.Graf
{
    public class Graf<T>
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

        public void RemoveVertex(Vertex<T> vertex)
        {
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
