using ShieldCompositon;
using ShieldCompositon.Shields;

Console.OutputEncoding = System.Text.Encoding.Unicode;
Start:

int slots = 6;
var shields = DataService.Load();
int maxPower;

while (true)
{
    Utility.WriteCyanInCenter("-Check/uncheck avaliable shield types-\n");
    Utility.WriteShields(shields);
    Utility.WriteCyanInCenter("Press Enter when finish");

    var key = Utility.ReadKeyInsisibly();
    int index = key - ConsoleKey.D1;
    if (index >= 0 && index < shields.Count)
    {
        shields[index].Checked = !shields[index].Checked;
        if(shields[index] == shields[8])
        {
            shields[index].Checked = true;
        }
    }
    else if (key == ConsoleKey.Enter)
    {
        break;
    }
    Console.SetCursorPosition(0, 0);
}

DataService.Save(shields);
Console.Clear();
Utility.WriteShields(shields);

int inputLine = Console.CursorTop;
Console.Write("Avaliable amount of power: ");
while (!int.TryParse(Console.ReadLine(), out maxPower))
{
    Console.SetCursorPosition(0, inputLine);
    Console.Write(new string(' ', Console.WindowWidth));
    Console.SetCursorPosition(0, inputLine);
    Console.Write("Avaliable amount of power: ");
}
Console.WriteLine();

var availableShields = shields.Where(s => s.Checked).ToList();

if (availableShields.Count == 0)
{
    Console.WriteLine("No shields selected. Press any key to try again.");
    Console.ReadKey();
    Console.Clear();
    goto Start;
}

var bestCombination = Calculation.GetBestShieldCombination(availableShields, slots, maxPower);

if (bestCombination == null || bestCombination.Count == 0)
{
    Console.WriteLine("No valid combination found. Press any key to try again.");
    Console.ReadKey();
    Console.Clear();
    goto Start;
}
else
{
    Console.WriteLine("Best shield combination:");
    foreach (var shield in bestCombination)
    {
        Console.WriteLine($"{shield.Name} | Power: {shield.Power}, ShieldPoints: {shield.ShieldPoints}");
    }
    Console.WriteLine($"\nTotal Power: {bestCombination.Sum(s => s.Power)}");
    Console.WriteLine($"Total ShieldPoints: {bestCombination.Sum(s => s.ShieldPoints)}");
}
Console.WriteLine("\nPress any key to continue...");
Console.ReadKey();
Console.Clear();
goto Start;