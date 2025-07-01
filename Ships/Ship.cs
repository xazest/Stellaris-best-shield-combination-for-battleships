using ShieldCompositon.Ships.Shields;

namespace ShieldCompositon.Ships
{
    internal class Ship
    {
        public string Name { get; set; }
        public int Slots { get; set; }
        public List<Shield> ShieldType { get; set; }
        public Ship(string name, int slots, List<Shield> shieldType)
        {
            Name = name;
            Slots = slots;
            ShieldType = shieldType;
        }
    }
}
