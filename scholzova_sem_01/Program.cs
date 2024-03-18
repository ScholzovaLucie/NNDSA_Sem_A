using scholzova_sem_01;
using scholzova_sem_01.Path;
using scholzova_sem_01.Graf;

class Program
{
    static void Main(string[] args)
    {
        GraphProcessor<string> procesor = new GraphProcessor<string>();
        procesor.ProcessGraph("../../../files/sem_01_velky.json");

        Graf<string> graf = procesor.CreateGraf();

        Paths<string> paths = new Paths<string>(procesor, graf);
        paths.printList();

        int maxTupleSize = Math.Min(procesor.getInputVertices().Count, procesor.getOutputVertices().Count);
        DisjointPaths<string> DisjointTuples = new DisjointPaths<string>(paths.paths, maxTupleSize);

        // DisjointTuples.printList();

        Console.WriteLine("LList: " + paths.paths.Count);
        Console.WriteLine("RList: " + DisjointTuples.getDisjonktPaths().Count);
    }
}