using Newtonsoft.Json;
using scholzova_sem_01.Graf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scholzova_sem_01
{
    internal class Parser
    {
        public Data loadData(string filePath)
        {
            string jsonText = File.ReadAllText(filePath);
            Data data = JsonConvert.DeserializeObject<Data>(jsonText);
            return data;
        }

        public void saveData(RList rlist, LList llist)
        {

        }
    }
}
