namespace InMemoryDBDemo
{
    using InMemoryDB.Core;

    using InMemoryDBDemo.Repository;

    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class Program
    {
        private static void Main(string[] args)
        {
            DemoClassShort dom = new DemoClassShort();
            dom.Id = Guid.NewGuid();
            dom.ClassName = "Test-1-A";
            dom.TextContent = new string[] { "Text-A", "Text-B" };

            DemoClassShortRepository repository = new DemoClassShortRepository();
            Console.WriteLine($"Count={repository.CountByType()}", ConsoleColor.Yellow);
            Console.WriteLine($"Add: {dom.ClassName}");
            repository.Add(dom);
            Console.WriteLine($"Count={repository.CountByType()}", ConsoleColor.Yellow);

            DemoClassShort dom2 = new DemoClassShort();
            dom2.Id = Guid.NewGuid();
            dom2.ClassName = "Test-2-A";
            dom2.TextContent = new string[] { "Text-C", "Text-D" };
            Console.WriteLine($"Add: {dom2.ClassName}");
            repository.Add(dom2);
            Console.WriteLine($"Count={repository.CountByType()}", ConsoleColor.Yellow);

            int tryCount = repository.FindAll().ToList().TryCount();

            IEnumerable<DemoClassShort> itemAll = repository.FindAll();
            Console.WriteLine($"Count in List={itemAll.TryCount()}", ConsoleColor.Yellow);

            IEnumerable<DemoClassShort> itemBy = repository.FindBy(f => f.ClassName == "Test-2-A");

            repository.SaveContent(@"c:\temp\test.xml");
            repository.DeleteAllByType();
            //repository.LoadContent(@"c:\temp\test.xml");
            FileInfo fi = new FileInfo(@"c:\temp\test.xml");
            repository.LoadContentEvent += Repository_LoadContentEvent;
            repository.LoadContent(fi);


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

        private static void Repository_LoadContentEvent(object sender, LoadContentEventArgs<DemoClassShort> e)
        {
            e.MemorySource = (List<SerializableKeyValuePair<Type, DemoClassShort>>)e.XmlSerializer.Deserialize(e.TextReader);
        }
    }
}
