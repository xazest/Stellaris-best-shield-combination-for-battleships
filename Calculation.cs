using ShieldCompositon.Ships.Shields;

namespace ShieldCompositon
{
    internal class Calculation
    {
        public static List<Shield> GetBestShieldCombination(List<Shield> shields, int slots, int maxPower)
        {
            var dp = new int[maxPower + 1, slots + 1];
            var usedShields = new List<Shield>[maxPower + 1, slots + 1];

            for (int i = 0; i <= maxPower; i++)
            {
                for (int j = 0; j <= slots; j++)
                {
                    usedShields[i, j] = new List<Shield>();
                }
            }

            for (int i = 0; i <= maxPower; i++)
            {
                for (int j = 0; j <= slots; j++)
                {
                    foreach (var shield in shields)
                    {
                        if (i + shield.Power <= maxPower &&
                            j + 1 <= slots &&
                            dp[i, j] + shield.ShieldPoints > dp[i + shield.Power, j + 1])
                        {
                            dp[i + shield.Power, j + 1] = dp[i, j] + shield.ShieldPoints;
                            usedShields[i + shield.Power, j + 1] = new List<Shield>(usedShields[i, j]) { shield };
                        }
                    }
                }
            }

            int maxShield = 0;
            int bestPower = 0;
            for (int i = 0; i <= maxPower; i++)
            {
                if (dp[i, slots] > maxShield)
                {
                    maxShield = dp[i, slots];
                    bestPower = i;
                }
            }

            List<Shield> result = usedShields[bestPower, slots];

            while(result.Count < slots)
            {
                result.Add(new Shield("empty slot", 0, 0));
            }

            return result;
        }
    }
}
