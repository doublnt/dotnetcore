namespace CSharpFundamental
{
    public class AnonymousType
    {
        public void CreateAnonymousAndExecute()
        {
            var family = new[] {
                new {Name = "John",Age = 20},
                new {Name = "Robert",Age =19}
            };

            var totalAge = 0;
            foreach (var person in family)
            {
                totalAge += person.Age;
            }
            System.Console.WriteLine(totalAge);
        }
    }
}