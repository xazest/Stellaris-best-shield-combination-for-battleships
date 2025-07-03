using ShieldCompositon;
using ShieldCompositon.Data;
using ShieldCompositon.Ships;

Console.OutputEncoding = System.Text.Encoding.Unicode;

Start:
List<Ship> shiptype;
Ship selectedShip;
var selectedShields = new List<SelectedShield>();
int avaliablePower;

Utility.SelectShipType(out shiptype);

Utility.SelectShip(shiptype, out selectedShip);

Utility.SelectShields(out selectedShields);

Utility.PrintChoices(selectedShields, selectedShip);

Utility.GetAvaliablePower(out avaliablePower);

var availableShields = selectedShip.ShieldType
    .Where(shield => selectedShields.Any(sel => sel.Checked && sel.Name == shield.Name))
    .ToList();

var bestCombination = Calculation.GetBestShieldCombination(availableShields,
    selectedShip.Slots, avaliablePower);

if (bestCombination == null || bestCombination.Count == 0)
{
    Console.WriteLine("No valid combination found. Press any key to try again.");
    Console.ReadKey(true);
    Console.Clear();
    goto Start;
}

else
{
    Utility.WriteLineInCenter("Best shield combination:\n\n");
    Utility.PrintTableResult(bestCombination);
    Utility.WriteLineInCenter($"Used Power: {bestCombination.Sum(s => s.Power)}",
        ConsoleColor.Yellow);

    Utility.WriteLineInCenter($"Total ShieldPoints: {bestCombination.Sum(s => s.ShieldPoints)}");
}
Utility.WriteLineInCenter("Press any key to repeat...", ConsoleColor.Gray);
Console.ReadKey(true);
Console.Clear();
goto Start;