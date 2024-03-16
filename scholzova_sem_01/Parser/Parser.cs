using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

using scholzova_sem_01.Graf;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scholzova_sem_01.Parser
{
    public class Parser<T, TVertexData, TRdgeData>
    {
        private Data<T, TVertexData, TRdgeData> data { get; set; }
        private List<Vertex<T, TVertexData, TRdgeData>> vertices { get; set; }

        public Parser(string filePath)
        {
            try
            {
                string jsonData = System.IO.File.ReadAllText(filePath);
                data = JsonConvert.DeserializeObject<Data<T, TVertexData, TRdgeData>>(jsonData);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Chyba při parsování dat ze souboru: " + ex.Message);
            }
        }

        public List<Vertex<T, TVertexData, TRdgeData>> ExtractVertices()
        {
            try
            {
                vertices = new List<Vertex<T, TVertexData, TRdgeData>>();
                foreach (T vertexName in data.Vertices)
                {
                    vertices.Add(new Vertex<T, TVertexData, TRdgeData>(vertexName));
                }
                return vertices;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Chyba při parsování dat ze souboru: " + ex.Message);
                return null;
            }

        }

        public List<Edge<T, TVertexData, TRdgeData>> ExtractEdges()
        {
            try
            {

                List<Edge<T, TVertexData, TRdgeData>> edges = new List<Edge<T, TVertexData, TRdgeData>>();
                foreach (T[] edgeArray in data.Edges)
                {
                    T fromVertexName = edgeArray[0];
                    T toVertexName = edgeArray[1];

                    Vertex<T, TVertexData, TRdgeData> fromVertex = vertices.Find(v => EqualityComparer<T>.Default.Equals(v.Name, fromVertexName));
                    Vertex<T, TVertexData, TRdgeData> toVertex = vertices.Find(v => EqualityComparer<T>.Default.Equals(v.Name, toVertexName));
                    T name = (T)Convert.ChangeType("E" + edges.Count.ToString(), typeof(T));

                    if (fromVertex != null && toVertex != null)
                    {
                        edges.Add(new Edge<T, TVertexData, TRdgeData>(name, fromVertex, toVertex));
                    }
                    else
                    {
                        throw new Exception("Nepodařilo se najít vrcholy pro hranu.");
                    }
                }
                return edges;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Chyba při parsování dat ze souboru: " + ex.Message);
                return null;
            }
        }

        public List<Vertex<T, TVertexData, TRdgeData>> ExtractInputVertices()
        {
            try
            {
                List<Vertex<T, TVertexData, TRdgeData>> inputVertices = new List<Vertex<T, TVertexData, TRdgeData>>();
                foreach (T inputVertexName in data.InputVertices)
                {
                    Vertex<T, TVertexData, TRdgeData> inputVertex = vertices.Find(v => EqualityComparer<T>.Default.Equals(v.Name, inputVertexName));
                    if (inputVertex != null)
                    {
                        inputVertices.Add(inputVertex);
                    }
                }
                return inputVertices;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Chyba při parsování dat ze souboru: " + ex.Message);
                return null;
            }
        }

        public List<Vertex<T, TVertexData, TRdgeData>> ExtractOutputVertices()
        {
            try
            {
                List<Vertex<T, TVertexData, TRdgeData>> outputVertices = new List<Vertex<T, TVertexData, TRdgeData>>();
                foreach (T outputVertexName in data.OutputVertices)
                {
                    Vertex<T, TVertexData, TRdgeData> outputVertex = vertices.Find(v => EqualityComparer<T>.Default.Equals(v.Name, outputVertexName));
                    if (outputVertex != null)
                    {
                        outputVertices.Add(outputVertex);
                    }
                }
                return outputVertices;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Chyba při parsování dat ze souboru: " + ex.Message);
                return null;
            }
        }

        public List<List<Vertex<T, TVertexData, TRdgeData>>> ExtractCross()
        {
            try
            {

                List<List<Vertex<T, TVertexData, TRdgeData>>> cross = new List<List<Vertex<T, TVertexData, TRdgeData>>>();
                foreach (T[] crossArray in data.Cross)
                {
                    List<Vertex<T, TVertexData, TRdgeData>> crossList = new List<Vertex<T, TVertexData, TRdgeData>>();
                    foreach (T crossItem in crossArray)
                    {
                        Vertex<T, TVertexData, TRdgeData> crossVertex = vertices.Find(v => EqualityComparer<T>.Default.Equals(v.Name, crossItem));
                        if (crossVertex != null)
                        {
                            crossList.Add(crossVertex);
                        }
                    }
                    cross.Add(crossList);
                }
                return cross;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Chyba při parsování dat ze souboru: " + ex.Message);
                return null;
            }
        }

    }
}
