using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamental
{
    class LinqTest
    {
        List<Person> groupList = new List<Person>();

        internal void ExecuteLinqFunc()
        {
            InitializeTheListData();
            Console.WriteLine("The Current Group Id={0}", QueryThePerson());

        }

        private void InitializeTheListData()
        {
            groupList.Add(new Person { Name = "Mike", GroupId = Guid.NewGuid().ToString() });
            groupList.Add(new Person { Name = "Jackson", GroupId = Guid.NewGuid().ToString() });
        }

        private string QueryThePerson()
        {
            var queryItem = groupList.FirstOrDefault(p => p.Name.Equals("Mike"));

            var name = groupList.Find(p => p.Name.Equals("Yinxi"));

            if (ReferenceEquals(name, null))
                Console.WriteLine("The Name you search is null!");

            return queryItem?.GroupId;
        }


    }

    internal class Person
    {
        internal string Name { get; set; }
        internal string GroupId { get; set; }
    }
}
