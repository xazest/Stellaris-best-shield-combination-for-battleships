namespace ShieldCompositon.Ships.Shields
{
    internal class Shield
    {
        public string Name { get; set; }
        public int Power { get; set; }
        public int ShieldPoints { get; set; }
        public ConsoleColor Color { get; set; } 
        public Shield(string name, int power, int shieldPoints,
            ConsoleColor consoleColor = ConsoleColor.White)
        {
            Name = name;
            Power = power;
            ShieldPoints = shieldPoints;
            Color = consoleColor;
        }
    }
}
