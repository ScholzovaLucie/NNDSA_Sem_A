﻿using scholzova_sem_01.Graf;
using scholzova_sem_01.Parser;
using scholzova_sem_01.Path;
using System.Collections.Generic;


namespace scholzova_sem_01
{
    public class GraphProcessor<T, TVertexData, TRdgeData>
    {
        public Paths<T, TVertexData, TRdgeData> paths { get; set; }
        public DisjointPaths<T, TVertexData, TRdgeData> DisjointTuples { get; set; }

        public Graf<T, TVertexData, TRdgeData> graphData { get; set; }
        public List<Vertex<T, TVertexData, TRdgeData>> InputVertices { get; set; }
        public List<Vertex<T, TVertexData, TRdgeData>> OutputVertices { get; set; }
        public List<Edge<T, TVertexData, TRdgeData>> edges { get; set; }


        public void ProcessGraph(string filePath)
        {
            Parser<T, TVertexData, TRdgeData> parser = new Parser<T, TVertexData, TRdgeData>(filePath);
            List<Vertex<T, TVertexData, TRdgeData>> vertices = parser.ExtractVertices();
            edges = parser.ExtractEdges();
            InputVertices = parser.ExtractInputVertices();
            OutputVertices = parser.ExtractOutputVertices();
            List<List<Vertex<T, TVertexData, TRdgeData>>> cross = parser.ExtractCross();

            graphData = CreateGraf(vertices, edges, cross);

            paths = new Paths<T, TVertexData, TRdgeData>(graphData, InputVertices, OutputVertices);
            paths.printList();

            var maxTupleSize = Math.Min(InputVertices.Count, OutputVertices.Count);
            DisjointTuples = new DisjointPaths<T, TVertexData, TRdgeData>(paths.paths, maxTupleSize);

            // DisjointTuples.printList();

            Console.WriteLine("LList: " + paths.paths.Count);
            Console.WriteLine("RList: " + DisjointTuples.getDisjonktPaths().Count);
        }

        private Graf<T, TVertexData, TRdgeData> CreateGraf(List<Vertex<T, TVertexData, TRdgeData>> vertices, List<Edge<T, TVertexData, TRdgeData>> edges, List<List<Vertex<T, TVertexData, TRdgeData>>> cross)
        {
            Graf<T, TVertexData, TRdgeData> graf = new Graf<T, TVertexData, TRdgeData>();

            foreach (Vertex<T, TVertexData, TRdgeData> vertex in vertices)
            {
                List<Edge<T, TVertexData, TRdgeData>> currentEdges = findEdges(vertex, edges);
                foreach (var edge in currentEdges)
                {
                    vertex.Edges.Add(edge);
                }
                graf.AddVertex(vertex);

            }

            foreach (var item in cross)
            {
                graf.Cross.Add(item);
            }


            return graf;
        }

        private List<Edge<T, TVertexData, TRdgeData>> findEdges(Vertex<T, TVertexData, TRdgeData> vertex, List<Edge<T, TVertexData, TRdgeData>> edges)
        {
            List<Edge<T, TVertexData, TRdgeData>> currentEdges = new List<Edge<T, TVertexData, TRdgeData>>();
            foreach (var edge in edges)
            {
                if (edge.StartVertex.sameVertex(vertex)) currentEdges.Add(edge);
            }
            return currentEdges;
        }



    }


}
