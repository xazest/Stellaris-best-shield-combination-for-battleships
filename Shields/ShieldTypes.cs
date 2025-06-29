namespace ShieldCompositon.Shields
{
    internal class ShieldTypes
    {
        public static readonly List<Shield> Shields = new List<Shield>()
        {
            new Shield("(1) lvl 1", 60, 450),
            new Shield("(2) lvl 2", 80, 600),
            new Shield("(3) lvl 3", 100, 750),
            new Shield("(4) lvl 4", 140, 990),
            new Shield("(5) lvl 5", 180, 1320),
            new Shield("(6) Dark Matter Deflectors", 220, 1680),
            new Shield("(7) Psionic Shields", 300, 2160),
            new Shield("(8) Psionic Barrier", 0, 600),
            new Shield("empty slot", 0, 0, true)
        };
    }
}
