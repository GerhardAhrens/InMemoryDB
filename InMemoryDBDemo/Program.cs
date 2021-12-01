namespace InMemoryDBDemo
{
    using InMemoryDB.Core;

    using System;

    public class Program
    {
        private static void Main(string[] args)
        {
            DemoClassShort dom = new DemoClassShort();
            dom.Id = Guid.NewGuid();
            dom.ClassName = "Test-1-A";

            InMemoryRepository<DemoClassShort> repository = new InMemoryRepository<DemoClassShort>();
            Console.WriteLine($"Count={repository.CountByType()}", ConsoleColor.Yellow);
            Console.WriteLine($"Add: {dom.ClassName}");
            repository.Add(dom);
            Console.WriteLine($"Count={repository.CountByType()}", ConsoleColor.Yellow);

            DemoClassShort dom2 = new DemoClassShort();
            dom2.Id = Guid.NewGuid();
            dom2.ClassName = "Test-2-A";
            Console.WriteLine($"Add: {dom2.ClassName}");
            repository.Add(dom2);
            Console.WriteLine($"Count={repository.CountByType()}", ConsoleColor.Yellow);

            /*
            repository.SaveContent(@"c:\temp\test.xml");

            repository.LoadContent(@"c:\temp\test.xml");
            */

            Console.WriteLine($"FindById: {dom.Id}");
            DemoClassShort result1 = repository.FindById(dom.Id);
            Console.WriteLine($"Result:{result1.ClassName};Id={result1.Id}");

            result1.ClassName = "Test-B";
            Console.WriteLine($"Update:{result1.ClassName};Id={result1.Id}");
            repository.Update(result1);
            Console.WriteLine($"Count={repository.CountByType()}", ConsoleColor.Yellow);
            DemoClassShort result2 = repository.FindById(result1.Id);
            Console.WriteLine($"Result:{result2.ClassName};Id={result2.Id}");

            /*repository.DeleteAllByType();*/

            Console.WriteLine($"Delete:{result2.ClassName};Id={result2.Id}");
            repository.Delete(result2);
            Console.WriteLine($"Count={repository.CountByType()}", ConsoleColor.Yellow);
            bool exist = repository.Exist(result2);
            Console.WriteLine($"Exist:{exist}");

            Console.ReadKey();
        }
    }
}
