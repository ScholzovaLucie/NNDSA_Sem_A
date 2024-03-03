using scholzova_sem_01.Graf;
using scholzova_sem_01.Parser;


namespace scholzova_sem_01
{
    public class GraphProcessor
    {
        public LList LList { get; set; }
        public RList RList { get; set; }
        

        public void ProcessGraph(string filePath)
        {
            Parser.Parser parser = new Parser.Parser();
            Data data = parser.loadData(filePath);
            GraphData graphData = new GraphData(data);

            LList = new LList(graphData);
            RList = new RList(LList);

            LList.printList();
            RList.printList();

            parser.saveData(RList, LList);
        }


    }


}
