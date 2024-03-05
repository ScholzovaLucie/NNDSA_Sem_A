using scholzova_sem_01;

class Program
{
    static void Main(string[] args)
    {
        GraphProcessor<string> graphProcessor = new GraphProcessor<string>();
        graphProcessor.ProcessGraph("../../../files/sem_01_uvodni.json");
    }
}