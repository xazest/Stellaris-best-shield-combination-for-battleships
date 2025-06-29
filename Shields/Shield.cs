namespace ShieldCompositon.Shields
{
    internal class Shield
    {
        public string Name { get; set; }
        public int Power { get; set; }
        public int ShieldPoints { get; set; }
        public bool Checked { get; set; }
        public Shield(string name, int power, int shieldPoints, bool isChecked = false )
        {
            Name = name;
            Power = power;
            ShieldPoints = shieldPoints;
            Checked = isChecked;
        }
    }
}
