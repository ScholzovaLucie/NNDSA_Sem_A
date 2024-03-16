using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scholzova_sem_01.Graf
{
    public class Vertex<T, TVertexData, TRdgeData>
    {
        public T Name
        {
            get { return name; }
            set { name = value; }
        }

        public TVertexData data { get; set; }

        private T name;

        public List<Edge<T, TVertexData, TRdgeData>> Edges
        {
            get { return edges; }
            set { edges = value; }
        }

        private List<Edge<T, TVertexData, TRdgeData>> edges;

        public Vertex(T name)
        {
            this.name = name;
            edges = new List<Edge<T, TVertexData, TRdgeData>>();
        }


        public bool sameVertex(Vertex<T, TVertexData, TRdgeData> other)
        {
            return Name.Equals(other.Name);
        }

        public override string ToString()
        {
            return Convert.ToString(Name);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + (Name != null ? Name.GetHashCode() : 0);
                return hash;
            }
        }


    }
}
