namespace ShieldCompositon.Ships.Shields
{
    internal class ShieldTypes
    {
        public static readonly List<Shield> LargeShields =
        [
            new("Deflectors", 60, 450),
            new("Improved Deflectors", 80, 600),
            new("Shields", 100, 750),
            new("Advanced Shields", 140, 990),
            new("Hyper Shields", 180, 1320),
            new("Dark Matter Deflectors", 220, 1680),
            new("Psionic Shields", 300, 2160),
            new("Psionic Barrier", 0, 600),
            new("empty slot", 0, 0)
        ];

        public static readonly List<Shield> MediumShields =
        [
            new("Deflectors", 30, 190),
            new("Improved Deflectors", 40, 250),
            new("Shields", 50, 315),
            new("Advanced Shields", 70, 415),
            new("Hyper Shields", 90, 550),
            new("Dark Matter Deflectors", 110, 700),
            new("Psionic Shields", 150, 900),
            new("Psionic Barrier", 0, 250),
            new("empty slot", 0, 0)
        ];

        public static readonly List<Shield> SmallShields =
        [
            new("Deflectors", 15, 75),
            new("Improved Deflectors", 20, 100),
            new("Shields", 25, 125),
            new("Advanced Shields", 35, 165),
            new("Hyper Shields", 45, 220),
            new("Dark Matter Deflectors", 55, 280),
            new("Psionic Shields", 75, 360),
            new("Psionic Barrier", 0, 100),
            new("empty slot", 0, 0)
        ];
    }
}
