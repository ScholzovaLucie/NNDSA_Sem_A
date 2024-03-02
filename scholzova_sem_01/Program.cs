using scholzova_sem_01;

class Program
{
    static void Main(string[] args)
    {
        GraphProcessor graphProcessor = new GraphProcessor();
        graphProcessor.ProcessGraph("sem_01_uvodni.json");
    }
}