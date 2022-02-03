using JetBrains.Annotations;

namespace Linq;

[UsedImplicitly]
public class TryGetNonEnumeratedCountSample
{
    private static void Main(string[] args)
    {
        var databaseItems = new[] { "DB_Item1", "DB_Item2" };
        var serviceItems = new[] { "Service_Item1", "Service_Item2" };
        var memoryItems = new[] { "Memory_Item1", "Memory_Item2" };

        WriteCountItems(databaseItems.Concat(serviceItems).Concat(memoryItems));
        WriteCountItems(databaseItems.Where(s => s.Contains("Item2")));

        void WriteCountItems(IEnumerable<string> enumerable)
        {
            if (enumerable.TryGetNonEnumeratedCount(out var count))
                Console.WriteLine($"The count is {count}");
            else
                Console.WriteLine("Could not get a count of items without enumerating the collection");
        }
    }
}