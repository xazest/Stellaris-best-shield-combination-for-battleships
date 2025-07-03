namespace ShieldCompositon.Ships.Shields
{
    internal static class ShieldTypes
    {
        public static readonly List<Shield> LargeShields =
        [
            new("Deflectors", 60, 450, ConsoleColor.DarkRed),
            new("Improved Deflectors", 80, 600, ConsoleColor.Red),
            new("Shields", 100, 750, ConsoleColor.DarkBlue),
            new("Advanced Shields", 140, 990, ConsoleColor.Blue),
            new("Hyper Shields", 180, 1320, ConsoleColor.DarkCyan),
            new("Dark Matter Deflectors", 220, 1680, ConsoleColor.DarkMagenta),
            new("Psionic Shields", 300, 2160, ConsoleColor.Magenta),
            new("Psionic Barrier", 0, 600, ConsoleColor.Magenta),
            new("empty slot", 0, 0)
        ];

        public static readonly List<Shield> MediumShields =
        [
            new("Deflectors", 30, 190, ConsoleColor.DarkRed),
            new("Improved Deflectors", 40, 250, ConsoleColor.Red),
            new("Shields", 50, 315, ConsoleColor.DarkBlue),
            new("Advanced Shields", 70, 415, ConsoleColor.Blue),
            new("Hyper Shields", 90, 550, ConsoleColor.DarkCyan),
            new("Dark Matter Deflectors", 110, 700, ConsoleColor.DarkMagenta),
            new("Psionic Shields", 150, 900, ConsoleColor.Magenta),
            new("Psionic Barrier", 0, 250, ConsoleColor.Magenta),
            new("empty slot", 0, 0)
        ];

        public static readonly List<Shield> SmallShields =
        [
            new("Deflectors", 15, 75, ConsoleColor.DarkRed),
            new("Improved Deflectors", 20, 100, ConsoleColor.Red),
            new("Shields", 25, 125, ConsoleColor.DarkBlue),
            new("Advanced Shields", 35, 165, ConsoleColor.Blue),
            new("Hyper Shields", 45, 220, ConsoleColor.DarkCyan),
            new("Dark Matter Deflectors", 55, 280, ConsoleColor.DarkMagenta),
            new("Psionic Shields", 75, 360, ConsoleColor.Magenta),
            new("Psionic Barrier", 0, 100, ConsoleColor.Magenta),
            new("empty slot", 0, 0)
        ];
    }
}
