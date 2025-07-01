using ShieldCompositon.Data;
using ShieldCompositon.Ships;

namespace ShieldCompositon
{
    static internal class Utility
    {
        public static void WriteCyanInCenter(string text)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
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
        public static void WriteShields(List<SelectedShields> shields)
        {
            int currentLineLength = 0;
            foreach (var shield in shields)
            {
                if (shield == shields[8]) { continue; }
                Console.ForegroundColor = ConsoleColor.Blue;

                string display = $"\t{(shield.Checked ? shield.Name : "")}\t";
                if (currentLineLength + display.Length > Console.WindowWidth)
                {
                    Console.WriteLine("\n");
                    currentLineLength = 0;
                }
                Console.Write(display);
                currentLineLength += display.Length +15;
            }
            Console.WriteLine("\n");
            Console.ResetColor();
        }
        public static void WriteShields(List<SelectedShields> shields, int startIndex)
        {
            Console.WriteLine();
            const int cellWidth = 30;
            int idx = startIndex;

            for (int i = 0; i < shields.Count; i++)
            {
                if (i == 8) continue;

                var shield = shields[i];
                Console.ForegroundColor = shield.Checked ? ConsoleColor.Green : ConsoleColor.Red;

                string entry = $"({idx}) {shield.Name}";
                Console.Write(entry.PadRight(cellWidth));

                idx++;
            }
            Console.ResetColor();
            Console.WriteLine();
        }

        public static void WriteShips()
        {
            int currentLineLength = 0;
            int idx = 1;
            foreach (var ship in ShipTypes.Main)
            {
                string display = $"\t({idx}) {ship.Name}\t";
                if (currentLineLength + display.Length > Console.WindowWidth)
                {
                    Console.WriteLine("\n");
                    currentLineLength = 0;
                }
                Console.Write(display);
                currentLineLength += display.Length *2;
                idx++;
            }
            Console.WriteLine();
        }
    }
}
