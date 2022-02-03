using JetBrains.Annotations;

namespace Linq;

[UsedImplicitly]
public class OperationBySample
{
    private static void Main(string[] args)
    {
        var aircrafts = new []
        {
            new Aircraft("Boeing 737", new DateOnly(1967, 01, 17), "USA"),
            new Aircraft("Boeing 747", new DateOnly(1969, 02, 9), "USA"),
            new Aircraft("Airbus 320", new DateOnly(1987, 02, 22), "France"),
            new Aircraft("Tupolev 154", new DateOnly(1968, 10, 3), "USSR"),
        };
        
        var oldest = aircrafts.MinBy(aircraft => aircraft.BirthDate);
        Console.WriteLine($"The oldest aircraft is {oldest}");

        var youngest = aircrafts.MaxBy(aircraft => aircraft.BirthDate);
        Console.WriteLine($"The youngest aircraft is {youngest}");

        Console.WriteLine($"Distinct aircrafts by country:");
        var distinct = aircrafts.DistinctBy(aircraft => aircraft.Country);
        foreach (var aircraft in distinct)
        {
            Console.WriteLine(aircraft);
        }

    }

    private record Aircraft(string Name, DateOnly BirthDate, string Country);
}