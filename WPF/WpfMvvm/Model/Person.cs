using System;

namespace WpfMvvm.Model
{
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime BirthDate { get; set; }
        public char Gender { get; set; }

        public string Message { get; set; }

        public void ComputeTheNameHashcode()
        {
            Name = "10086222";
        }

        public bool IsValid()
        {
            if (!string.IsNullOrEmpty(Message))
            {
                return true;
            }

            return false;
        }
    }
}
