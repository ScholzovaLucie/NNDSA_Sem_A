﻿using scholzova_sem_01.Graf;

namespace scholzova_sem_01.Path
{
    public class Path<T>
    {
        public string Name { get; set; }
        public LinkedList<Vertex<T>> Vertices { get; set; }

        public Path(LinkedList<Vertex<T>> vertices)
        {
            Vertices = vertices;
        }

        public Path(int index, LinkedList<Vertex<T>> vertices)
        {
            Name = "A" + index;
            Vertices = vertices;
        }


        public void setName(int index)
        {
            Name = "A" + index;
        }

        public Path<T> Copy()
        {
            LinkedList<Vertex<T>> copiedVertices = new LinkedList<Vertex<T>>(Vertices);
            return new Path<T>(copiedVertices);
        }

        public Vertex<T> getFirst()
        {
            return Vertices.First();
        }

        public Vertex<T> getLast()
        {
            return Vertices.Last();
        }


        public bool Equals(Path<T> other)
        {
            if (Vertices.Count != other.Vertices.Count) return false;

            bool same = true;

            Vertex<T> aktual_this = Vertices.First();
            Vertex<T> aktual_other = other.Vertices.First();

            if (!aktual_this.Name.Equals(aktual_other.Name))
            {
                return false;
            }

            foreach (Vertex<T> s in Vertices)
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

        public bool IsDisjoint(Path<T> other)
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
