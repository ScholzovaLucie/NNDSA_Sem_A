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
    public class Parser<T>
    {
        public (List<Vertex<T>>, List<Edge<T>>, List<Vertex<T>>, List<Vertex<T>>, List<List<Vertex<T>>>) ParseDataFromFile<T>(string filePath)
        {
            try
            {
                string jsonData = System.IO.File.ReadAllText(filePath);
                Data<T> data = JsonConvert.DeserializeObject<Data<T>>(jsonData);

                List<Vertex<T>> vertices = new List<Vertex<T>>();
                List<Edge<T>> edges = new List<Edge<T>>();

                // Vytvoření vrcholů
                foreach (T vertexName in data.Vertices)
                {
                    vertices.Add(new Vertex<T>(vertexName));
                }

                // Vytvoření hran
                for (int i = 0; i < data.Edges.Length; i++)
                {
                    
                    T fromVertexName = data.Edges[i][0];
                    T toVertexName = data.Edges[i][1];

                    Vertex<T> fromVertex = vertices.Find(v => EqualityComparer<T>.Default.Equals(v.Name, fromVertexName));
                    Vertex<T> toVertex = vertices.Find(v => EqualityComparer<T>.Default.Equals(v.Name, toVertexName));
                    T name = (T)Convert.ChangeType("E" + i.ToString(), typeof(T));


                    if (fromVertex != null && toVertex != null)
                    {
                        edges.Add(new Edge<T>(name, fromVertex, toVertex));
                    }
                    else
                    {
                        throw new Exception("Nepodařilo se najít vrcholy pro hranu.");
                    }
                    
                }

                List<Vertex<T>> inputVertices = new List<Vertex<T>>();
                List<Vertex<T>> outputVertices = new List<Vertex<T>>();

                // Vytvoření seznamů vstupních a výstupních vrcholů
                foreach (T inputVertexName in data.InputVertices)
                {
                    Vertex<T> inputVertex = vertices.Find(v => EqualityComparer<T>.Default.Equals(v.Name, inputVertexName));
                    if (inputVertex != null)
                    {
                        inputVertices.Add(inputVertex);
                    }
                }

                foreach (T outputVertexName in data.OutputVertices)
                {
                    Vertex<T> outputVertex = vertices.Find(v => EqualityComparer<T>.Default.Equals(v.Name, outputVertexName));
                    if (outputVertex != null)
                    {
                        outputVertices.Add(outputVertex);
                    }
                }

                List<List<Vertex<T>>> cross = new List<List<Vertex<T>>>();

                // Vytvoření seznamu Cross
                foreach (T[] crossArray in data.Cross)
                {
                    List<Vertex<T>> crossList = new List<Vertex<T>>();
                    foreach (T crossItem in crossArray)
                    {
                        Vertex<T> crossVertex = vertices.Find(v => EqualityComparer<T>.Default.Equals(v.Name, crossItem));
                        if (crossVertex != null)
                        {
                            crossList.Add(crossVertex);
                        }
                    }
                    cross.Add(crossList);
                }

                return (vertices, edges, inputVertices, outputVertices, cross);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Chyba při parsování dat ze souboru: " + ex.Message);
                return (null, null, null, null, null);
            }
        }
    }
}
//public void saveData(RList<T> rlist, LList llist)
//{

//    var dataToSerialize = new
//    {
//        LList = llist.List.Select(path => new { PathName = path.Name, Vertices = path.Vertices.Select(v => v.Name).ToList() }),
//        RList = rlist.List.Select(path => new { DisjunktPaths = path })
//    };

//    // Převod na JSON formát
//    string json = JsonConvert.SerializeObject(dataToSerialize, Formatting.Indented, new PathConverter());

//    // Uložení do souboru
//    File.WriteAllText("../../../files/resultFile.json", json);
//}


