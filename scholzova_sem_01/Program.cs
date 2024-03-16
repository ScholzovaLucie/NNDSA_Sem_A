using scholzova_sem_01;

class Program
{
    static void Main(string[] args)
    {
        GraphProcessor<string, string, string> graphProcessor = new GraphProcessor<string, string, string>();
        graphProcessor.ProcessGraph("../../../files/sem_01_velky.json");
    }
}