using ShieldCompositon;
using ShieldCompositon.Data;
using ShieldCompositon.Ships;

Console.OutputEncoding = System.Text.Encoding.Unicode;

int avaliablePower;
Ship selectedShip;

Start:

Utility.WriteCyanInCenter("-Select ship-\n");
Utility.WriteShips();
while (true)
{
    var key = Utility.ReadKeyInvisibly();
    int index = key - ConsoleKey.D1;
    if (index >= 0 && index < ShipTypes.Main.Count)
    {
        selectedShip = ShipTypes.Main[index];
        break;
    }
}
Console.Clear();
Utility.WriteCyanInCenter($"-Selected ship: {selectedShip.Name}-");

var selectedShields = DataService.Load();
var consolePos = Console.GetCursorPosition();
while (true)
{
    Utility.WriteCyanInCenter("-Check/uncheck avaliable shield types-");
    Utility.WriteShields(selectedShields, 1);
    Utility.WriteCyanInCenter("Press Enter when finish");

    var key = Utility.ReadKeyInvisibly();
    int index = key - ConsoleKey.D1;
    if (index >= 0 && index < selectedShields.Count - 1)
    {
        selectedShields[index].Checked = !selectedShields[index].Checked;
    }
    else if (key == ConsoleKey.Enter)
    {
        break;
    }
    Console.SetCursorPosition(consolePos.Left, consolePos.Top);
}

DataService.Save(selectedShields);
Console.Clear();

Utility.WriteCyanInCenter($"-Selected ship: {selectedShip.Name}-");
Utility.WriteCyanInCenter($"-Selected shields-\n");
Utility.WriteShields(selectedShields);

int inputLine = Console.CursorTop;
Console.Write("Avaliable amount of power: ");
while (!int.TryParse(Console.ReadLine(), out avaliablePower))
{
    Console.SetCursorPosition(0, inputLine);
    Console.Write(new string(' ', Console.WindowWidth));
    Console.SetCursorPosition(0, inputLine);
    Console.Write("Avaliable amount of power: ");
}
Console.WriteLine();

var availableShields = selectedShip.ShieldType
    .Where(shield => selectedShields.Any(sel => sel.Checked && sel.Name == shield.Name))
    .ToList();

if (availableShields.Count == 0)
{
    Console.WriteLine("No shields selected. Press any key to try again.");
    Console.ReadKey();
    Console.Clear();
    goto Start;
}

var bestCombination = Calculation.GetBestShieldCombination(availableShields, selectedShip.Slots, avaliablePower);

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