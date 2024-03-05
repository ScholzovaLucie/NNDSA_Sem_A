using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using scholzova_sem_01.Graf;


namespace scholzova_sem_01
{
    public class PathConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Path);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        //public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        //{
        //    if (value is Path<T> path)
        //    {
        //        JObject obj = new JObject();
        //        obj.Add("Name", path.Name);
        //        obj.WriteTo(writer);
        //    }
        //    else if (value is RList rList)
        //    {
        //        JArray array = new JArray();
        //        foreach (var paths in rList.List)
        //        {
        //            JObject obj = new JObject();
        //            obj.Add("Name", paths.First().Name);
        //            array.Add(obj);
        //        }
        //        array.WriteTo(writer);
        //    }
        //}
    }
}
