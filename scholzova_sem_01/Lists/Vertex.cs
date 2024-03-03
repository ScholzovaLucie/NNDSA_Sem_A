using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scholzova_sem_01.Lists
{
    internal class Vertex
    {
        public string Name { get; set; }

        public Vertex(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }

        public bool sameVertex(Vertex other)
        {
            return this.Name.Equals(other.Name);
        }
    }
}
