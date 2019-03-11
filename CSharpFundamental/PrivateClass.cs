namespace CSharpFundamental
{
    public class PrivateClass
    {

        public PrivateClass() { }
        public PrivateClass(string name, string version, string hashcode)
        {
            Name = name;
            Version = version;
            HashCode = hashcode;
        }

        public string Name { get; set; }
        public string Version { get; set; }
        public string HashCode { get; private set; }

    }
}