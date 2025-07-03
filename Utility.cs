using ShieldCompositon.Data;
using ShieldCompositon.Ships;
using ShieldCompositon.Ships.Shields;

namespace ShieldCompositon
{
    static internal class Utility
    {
        public static void WriteLineInCenter(string text, ConsoleColor color = ConsoleColor.Cyan)
        {
            Console.WriteLine();
            Console.ForegroundColor = color;
            int centerX = (Console.WindowWidth - text.Length) / 2;
            Console.SetCursorPosition(centerX, Console.CursorTop);
            Console.WriteLine(text);
        }

        public static ConsoleKey ReadKeyInvisibly()
        {
            Console.CursorVisible = false;
            var key = Console.ReadKey(true);
            Console.CursorVisible = true;
            return key.Key;
        }

        public static void PrintChoices(List<SelectedShield> selectedShields,
            Ship selectedShip)
        {
            WriteLineInCenter($"-Selected ship: {selectedShip.Name}-");
            WriteLineInCenter($"-Selected shields-\n");
            int currentLineLength = 0;
            foreach (var selectedShield in selectedShields)
            {
                if (selectedShield == selectedShields[8]) { continue; }

                Console.ForegroundColor = selectedShield.Color;
                string display = $"\t{(selectedShield.Checked ? selectedShield.Name : "")}\t";
                if (currentLineLength + display.Length > Console.WindowWidth)
                {
                    Console.WriteLine("\n");
                    currentLineLength = 0;
                }
                Console.Write(display);
                currentLineLength += display.Length + 15;
            }
            Console.WriteLine("\n");
            Console.ResetColor();
        }
        public static void PrintNumeratedShields(List<SelectedShield> selectedShields)
        {
            Console.WriteLine();
            const int cellWidth = 30;

            for (int i = 0; i < selectedShields.Count; i++)
            {
                if (i == 8) continue;

                Console.ForegroundColor = selectedShields[i].Checked ?
                    ConsoleColor.Green : ConsoleColor.Red;

                string entry = $"({i + 1}) {selectedShields[i].Name}";
                Console.Write(entry.PadRight(cellWidth));
            }
            Console.ResetColor();
            Console.WriteLine();
        }

        public static void PrintShips(List<Ship> shiptype)
        {
            int currentLineLength = 0;
            int idx = 1;
            foreach (var ship in shiptype)
            {
                string display = $"\t({idx}) {ship.Name}\t";
                if (currentLineLength + display.Length > Console.WindowWidth)
                {
                    Console.WriteLine("\n");
                    currentLineLength = 0;
                }
                Console.Write(display);
                currentLineLength += display.Length * 2;
                idx++;
            }
            Console.WriteLine();
        }

        public static void PrintTableResult(List<Shield> shields)
        {
            const int cellWidth = 30;
            for (int i = 0; i < shields.Count; i++)
            {
                Console.ForegroundColor = shields[i].Color;
                string entry = $"{shields[i].Name}";
                Console.Write(entry.PadRight(cellWidth));
            }
            Console.WriteLine("\n");
        }

        public static void GetAvaliablePower(out int avaliablePower)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            var text = "Avaliable amount of power: ";

            int centerX = (Console.WindowWidth - text.Length) / 2;
            Console.SetCursorPosition(centerX, Console.CursorTop);
            Console.Write(text);
            var (positionX, positionY) = Console.GetCursorPosition();

            while (!int.TryParse(Console.ReadLine(), out avaliablePower) ||
                avaliablePower <= 0 || avaliablePower > 14300)
            {
                Console.SetCursorPosition(positionX, positionY);
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(positionX, positionY);
            }
        }

        public static void SelectShields(out List<SelectedShield> selectedShields)
        {
            do
            {
                selectedShields = DataService.Load();
                var (positionX, positionY) = Console.GetCursorPosition();
                while (true)
                {
                    WriteLineInCenter("-Check/uncheck avaliable shield types-");
                    PrintNumeratedShields(selectedShields);
                    WriteLineInCenter("Press Enter when finish");

                    var key = ReadKeyInvisibly();
                    int index = key - ConsoleKey.D1;
                    if (index >= 0 && index < selectedShields.Count - 1)
                    {
                        selectedShields[index].Checked = !selectedShields[index].Checked;
                    }
                    else if (key == ConsoleKey.Enter)
                    {
                        break;
                    }
                    Console.SetCursorPosition(positionX, positionY);
                }
                DataService.Save(selectedShields);
                Console.Clear();
            } while (!selectedShields.Any(s => s.Checked && s.Name != "empty slot"));
        }
    }
}
