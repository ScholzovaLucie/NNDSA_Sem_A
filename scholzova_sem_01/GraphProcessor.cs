﻿using scholzova_sem_01.Graf;
using scholzova_sem_01.Parser;
using scholzova_sem_01.Path;
using System.Collections.Generic;


namespace scholzova_sem_01
{
    public class GraphProcessor<T>
    {
        public LList<T> LList { get; set; }
        public RList<T> DisjunktPaths { get; set; }


        public void ProcessGraph(string filePath)
        {
            Parser<T> parser = new Parser<T>(filePath);
            List<Vertex<T>> vertices = parser.ExtractVertices();
            List<Edge<T>> edges = parser.ExtractEdges();
            List<Vertex<T>> InputVertices = parser.ExtractInputVertices();
            List<Vertex<T>> OutputVertices = parser.ExtractOutputVertices();
            List<List<Vertex<T>>> cross = parser.ExtractCross();

            Graf<T> graphData = CreateGraf(vertices, edges, cross);

            LList = new LList<T>(graphData, InputVertices, OutputVertices);

            DisjunktPaths = new RList<T>(LList);

            LList.printList();
            DisjunktPaths.printList();

            Console.WriteLine("LList: "+LList.List.Count);
            Console.WriteLine("RList: " + DisjunktPaths.List.Count);
        }

        private Graf<T> CreateGraf(List<Vertex<T>> vertices, List<Edge<T>> edges, List<List<Vertex<T>>> cross)
        {
            Graf<T> graf = new Graf<T>();

            foreach (Vertex<T> vertex in vertices)
            {
                List<Edge<T>> currentEdges = findEdges(vertex, edges);
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

        private List<Edge<T>> findEdges(Vertex<T> vertex, List<Edge<T>> edges)
        {
            List<Edge<T>> currentEdges = new List<Edge<T>>();
            foreach (var edge in edges)
            {
                if(edge.StartVertex.sameVertex(vertex)) currentEdges.Add(edge);
            }
            return currentEdges;
        }
        


    }


}
