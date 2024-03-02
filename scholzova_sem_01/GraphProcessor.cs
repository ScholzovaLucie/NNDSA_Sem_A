using Microsoft.VisualBasic;
using scholzova_sem_01.Graf;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scholzova_sem_01
{
    internal class GraphProcessor
    {
        public LList LList { get; set; }
        public RList RList { get; set; }
        

        public void ProcessGraph(string filePath)
        {
            Parser parser = new Parser();
            Data data = parser.loadData(filePath);
            GraphData graphData = new GraphData(data);

            LList = new LList(graphData);
            RList = new RList(LList);

            LList.printList();
            RList.printList();


        }


    }


}
