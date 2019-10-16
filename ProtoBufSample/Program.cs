using System;
using System.IO;
using ProtoBuf;
using ProtoBufSample.Proto;

namespace ProtoBufSample
{
    class Program
    {
        private static string s_path = "D://Working//dotnetcore//ProtoBufSample//person.bin";

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine("---------------------");


            var person = new Person()
            {
                Id = 10086,
                Name = "Robert",
                Address = new Address() { Line1 = "ZhongGuo", Line2 = "Zhejiang" }
            };

            using (var file = File.Create(s_path))
            {
                Serializer.Serialize(file, person);
            }


            using (var file2 = File.OpenRead(s_path))
            {
                var newPerson = Serializer.Deserialize<Person>(file2);

                Console.WriteLine(newPerson.Address.Line2 + "\n" + newPerson.Address.Line1 + "\n" + newPerson.Name + "\n" + newPerson.Id);
            }
        }
    }
}
