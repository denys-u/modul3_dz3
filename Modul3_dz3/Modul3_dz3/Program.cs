namespace Modul3_dz3
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;

    public class Program
    {
        private const string Path = "text.txt";

        public static void Main(string[] args)
        {
            var result = MethodAsync().GetAwaiter().GetResult();
            Console.WriteLine(result);
        }

        public static async Task<string> MethodAsync()
        {
            var list = new List<Task<string>>();

            list.Add(Task.Run(() => "World"));
            list.Add(Task.Run(() => File.ReadAllTextAsync(Path)));

            var result = await Task.WhenAll(list);
            return string.Join(" ", result);
        }
    }
}
