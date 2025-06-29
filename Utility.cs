using ShieldCompositon.Shields;

namespace ShieldCompositon
{
    static internal class Utility
    {
        public static void WriteCyanInCenter(string text)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            int centerX = (Console.WindowWidth - text.Length) / 2;
            Console.SetCursorPosition(centerX , Console.CursorTop);
            Console.WriteLine(text);
        }
        public static ConsoleKey ReadKeyInsisibly()
        {
            Console.CursorVisible = false;
            var key = Console.ReadKey(true);
            Console.CursorVisible = true;
            return key.Key;
        }
        public static void WriteShields(List<Shield> shields)
        {
            foreach (var shield in shields)
            {
                Console.ForegroundColor = shield.Checked ? ConsoleColor.Green : ConsoleColor.Red;
                Console.Write($"\t{shield.Name} {(shield.Checked ? "[√]" : "[×]")}\t");
                if (shield == shields[4]) { Console.WriteLine("\n"); }
            }
            Console.WriteLine("\n");
            Console.ResetColor();
        }
    }
}
