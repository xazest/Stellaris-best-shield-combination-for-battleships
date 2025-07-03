namespace ShieldCompositon.Data
{
    internal class SelectedShield
    {
        public string Name { get; set; }
        public bool Checked { get; set; }
        public ConsoleColor Color { get; set; }
        public SelectedShield(string name, ConsoleColor consoleColor = ConsoleColor.White,
            bool isChecked = false)
        {
            Name = name;
            Checked = isChecked;
            Color = consoleColor;
        }
    }
}
