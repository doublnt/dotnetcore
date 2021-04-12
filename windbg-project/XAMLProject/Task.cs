using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XAMLProject
{
    public class Task
    {
        public string TaskName { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        public TaskType Type { get; set; }

        public override string ToString()
        {
            return TaskName.ToString(); 
        }
    }

    public enum TaskType
    {
        Home = 0,
        Work = 1
    }
}
