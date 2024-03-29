﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scholzova_sem_01.Parser
{
    public class Data<T>
    {
        public T[] Vertices { get; set; }
        public T[] InputVertices { get; set; }
        public T[] OutputVertices { get; set; }
        public T[][] Cross { get; set; }
        public T[][] Edges { get; set; }
    }
}
