using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace CSharpFundamental
{
    [Serializable()]
    public class Serialize
    {
        public static List<String> AList = new List<string>() { "Mike", "Kevin", "Jack", "MARK" };

        [field: NonSerialized()]
        public String Name { get; set; }

        public static MemoryStream SerializeObject(Object objectGraph)
        {
            MemoryStream ms = new MemoryStream();
            BinaryFormatter binaryFormatter = new BinaryFormatter();

            binaryFormatter.Serialize(ms, objectGraph);

            return ms;
        }

        public static Object DeserializeFromMemory(Stream stream)
        {
            BinaryFormatter bf = new BinaryFormatter();

            return bf.Deserialize(stream);
        }

        public void ExecuteMemory()
        {
            var stream = SerializeObject(AList);

            stream.Position = 0;

            var list = (List<String>)DeserializeFromMemory(stream);

            Console.WriteLine(list.ToArray()[0]);
        }

        [OnSerializing]
        private void OnSerializing(StreamingContext context)
        {

        }

        [OnSerialized]
        private void OnSerialized(StreamingContext context)
        {

        }

        [OnDeserializing]
        private void OnDeserializing(StreamingContext context)
        {

        }

        [OnDeserialized]
        private void OnDeseralized(StreamingContext context)
        {

        }
    }
}
