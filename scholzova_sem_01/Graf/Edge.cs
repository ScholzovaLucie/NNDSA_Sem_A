using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scholzova_sem_01.Graf
{
    public class Edge<T, TVertexData, TRdgeData>
    {
        public T Name { get; set; }
        public Vertex<T, TVertexData, TRdgeData> StartVertex { get; set; }
        public Vertex<T, TVertexData, TRdgeData> EndVertex { get; set; }

        public Edge(T name, Vertex<T, TVertexData, TRdgeData> startVertex, Vertex<T, TVertexData, TRdgeData> endVertex)
        {
            Name = name;
            StartVertex = startVertex;
            EndVertex = endVertex;
        }

        public override string ToString()
        {
            return Name + ": " + StartVertex + ", " + EndVertex;
        }

        public bool sameEdge(Edge<T, TVertexData, TRdgeData> other)
        {
            return StartVertex.Name.Equals(other.StartVertex.Name) && EndVertex.Name.Equals(other.EndVertex.Name);
        }
    }
}
