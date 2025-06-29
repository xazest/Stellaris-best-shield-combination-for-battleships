using ShieldCompositon.Shields;

namespace ShieldCompositon
{
    internal class Calculation
    {
        public static List<Shield> GetBestShieldCombination(List<Shield> shields, int slots, int maxPower)
        {
            List<Shield> bestCombo = null;
            int maxShieldPoints = 0;

            var allCombos = GetCombinationsWithRepetition(shields, slots);

            foreach (var combo in allCombos)
            {
                int totalPower = combo.Sum(s => s.Power);
                int totalShield = combo.Sum(s => s.ShieldPoints);

                if (totalPower <= maxPower && totalShield > maxShieldPoints)
                {
                    maxShieldPoints = totalShield;
                    bestCombo = combo;
                }
            }

            return bestCombo ?? new List<Shield>();
        }

        static IEnumerable<List<Shield>> GetCombinationsWithRepetition(List<Shield> items, int length)
        {
            int[] indices = new int[length];
            int count = (int)Math.Pow(items.Count, length);

            for (int i = 0; i < count; i++)
            {
                var combo = new List<Shield>();
                int num = i;
                for (int j = 0; j < length; j++)
                {
                    indices[j] = num % items.Count;
                    num /= items.Count;
                    combo.Add(items[indices[j]]);
                }
                yield return combo;
            }
        }
    }
}
