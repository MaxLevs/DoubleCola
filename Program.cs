string[] actualQueue = { "Sheldon", "Leonard", "Penny", "Rajesh", "Howard" };

string DoubleCola(int n) => actualQueue[DoubleColaAnyQueue(actualQueue, n) - 1];

int DoubleColaAnyQueue(IReadOnlyCollection<string> queue, int n)
{
    if (n < 1) throw new ArgumentException("Position in queue must be in [1;+∞)", nameof(n));
    
    var k = Math.Pow(2, (int)Math.Ceiling(Math.Log2(Math.Ceiling((double)n / queue.Count) + 1)) - 1);
    return (int)Math.Ceiling((n - (k - 1) * queue.Count) / k);
}

//-----------------------
PrintStartupMessage();

while (true)
{
    Console.Write("Position in queue: ");

    try
    {
        var position = int.Parse(Console.ReadLine()!);
        var personInQueue = DoubleCola(position);

        Console.WriteLine($"Person: {personInQueue}");
    }

    catch (ArgumentNullException) { Console.WriteLine("It's not a number");}
    catch (FormatException) { Console.WriteLine("It's not a number");}
    catch (ArgumentException e) { Console.WriteLine(e.Message); }
    
    Console.WriteLine();
}
//-----------------------

void PrintStartupMessage()
{
    System.Text.StringBuilder builder = new("Initial queue: ");
    builder.Append('[').AppendJoin(", ", actualQueue).Append(']');
    builder.Append(" with length ").Append(actualQueue.Length);
    
    Console.WriteLine(builder);
}
