namespace ShieldCompositon.Data
{
    internal static class SelectedShieldsList
    {
        public static List<SelectedShield> Selected =
        [
            new("Deflectors", ConsoleColor.DarkRed),
            new("Improved Deflectors", ConsoleColor.Red),
            new("Shields", ConsoleColor.DarkBlue),
            new("Advanced Shields", ConsoleColor.Blue),
            new("Hyper Shields", ConsoleColor.DarkCyan),
            new("Dark Matter Deflectors", ConsoleColor.DarkMagenta),
            new("Psionic Shields", ConsoleColor.Magenta),
            new("Psionic Barrier", ConsoleColor.Magenta),
            new("empty slot" , isChecked: true)
        ];
    }
}
