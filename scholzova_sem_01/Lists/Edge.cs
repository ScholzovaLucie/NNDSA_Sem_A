﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scholzova_sem_01.Lists
{
    internal class Edge
    {
        public string Name { get; set; }
        public Vertex StartVertex { get; set; }
        public Vertex EndVertex { get; set; }

        public Edge(string name, Vertex startVertex, Vertex endVertex)
        {
            Name = name;
            StartVertex = startVertex;
            EndVertex = endVertex;
        }

        public override string ToString()
        {
            return Name + ": " + StartVertex + ", " + EndVertex;
        }
    }
}
