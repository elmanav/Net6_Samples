using System.Diagnostics;

using var timer = new PeriodicTimer(TimeSpan.FromMilliseconds(1000));
var sw = Stopwatch.StartNew();
while (await timer.WaitForNextTickAsync()) // waiting callback 
    await NewFunction(sw);

async Task NewFunction(Stopwatch stopwatch)
{
    await Task.Delay(500); // do some application work 
    Console.WriteLine($"Elapsed time: {stopwatch.ElapsedMilliseconds}ms");
}