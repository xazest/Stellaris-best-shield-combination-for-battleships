using ShieldCompositon.Ships.Shields;

namespace ShieldCompositon.Ships
{
    internal class ShipTypes
    {
        public static readonly List<Ship> Main =
        [
           new("Corvette", 3, ShieldTypes.SmallShields),
           new("Frigate", 4, ShieldTypes.SmallShields),
           new("Destroyer", 6, ShieldTypes.SmallShields),
           new("Cruiser", 8, ShieldTypes.MediumShields),
           new("Battleship", 6, ShieldTypes.LargeShields),
           new("Titan", 12, ShieldTypes.LargeShields),
           new("Juggernaut", 21, ShieldTypes.LargeShields)
        ];

        public static readonly List<Ship> Defensive =
        [
           new("Defense platform", 6, ShieldTypes.MediumShields),
           new("Ion Cannon", 8, ShieldTypes.LargeShields)
        ];

        public static readonly List<Ship> Ancient =
        [
           new("Riddle Escort", 6, ShieldTypes.MediumShields),
           new("Enigma Battlecruiser", 8, ShieldTypes.LargeShields),
           new("Paradox Titan", 20, ShieldTypes.LargeShields)
        ];
    }
}
