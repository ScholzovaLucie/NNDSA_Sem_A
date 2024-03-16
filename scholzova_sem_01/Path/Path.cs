using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using scholzova_sem_01.Graf;

namespace scholzova_sem_01.Path
{
    public class Path<T, TVertexData, TRdgeData>
    {
        public string Name { get; set; }
        public LinkedList<Vertex<T, TVertexData, TRdgeData>> Vertices { get; set; }

        public Path(LinkedList<Vertex<T, TVertexData, TRdgeData>> vertices)
        {
            Vertices = vertices;
        }

        public Path(int index, LinkedList<Vertex<T, TVertexData, TRdgeData>> vertices)
        {
            Name = "A" + index;
            Vertices = vertices;
        }


        public void setName(int index)
        {
            Name = "A" + index;
        }

        public Path<T, TVertexData, TRdgeData> Copy()
        {
            LinkedList<Vertex<T, TVertexData, TRdgeData>> copiedVertices = new LinkedList<Vertex<T, TVertexData, TRdgeData>>(Vertices);
            return new Path<T, TVertexData, TRdgeData>(copiedVertices);
        }

        public Vertex<T, TVertexData, TRdgeData> getFirst()
        {
            return Vertices.First();
        }

        public Vertex<T, TVertexData, TRdgeData> getLast()
        {
            return Vertices.Last();
        }


        public bool Equals(Path<T, TVertexData, TRdgeData> other)
        {
            if (Vertices.Count != other.Vertices.Count) return false;

            bool same = true;

            Vertex<T, TVertexData, TRdgeData> aktual_this = Vertices.First();
            Vertex<T, TVertexData, TRdgeData> aktual_other = other.Vertices.First();

            if (!aktual_this.Name.Equals(aktual_other.Name))
            {
                return false;
            }

            foreach (Vertex<T, TVertexData, TRdgeData> s in Vertices)
            {
                if (Vertices.Find(aktual_this).Next == null)
                {
                    if (!aktual_this.Name.Equals(aktual_other.Name))
                    {
                        return false;
                    }
                    return same;
                }

                aktual_this = Vertices.Find(aktual_this).Next.Value;
                aktual_other = other.Vertices.Find(aktual_other).Next.Value;

                if (!aktual_this.Name.Equals(aktual_other.Name))
                {
                    return false;
                }

            }
            return same;
        }

        public bool IsDisjoint(Path<T, TVertexData, TRdgeData> other)
        {
            foreach (var vertex in Vertices)
            {
                foreach (var vertex1 in other.Vertices)
                {
                    if (vertex1.Name.Equals(vertex.Name))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }

}
