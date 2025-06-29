using Newtonsoft.Json;

namespace ShieldCompositon.Shields
{
    internal class DataService
    {
        private static readonly string _path = "shields.json";

        public static List<Shield> Load()
        {
            if (!File.Exists(_path))
            {
                File.Create(_path).Close();
                File.WriteAllText(_path,
                    JsonConvert.SerializeObject(ShieldTypes.Shields,
                        Formatting.Indented));
            }

            string json = File.ReadAllText(_path);
            return JsonConvert.DeserializeObject<List<Shield>>(json);
        }
        public static void Save(List<Shield> shields)
        {
            string json = JsonConvert.SerializeObject(shields, Formatting.Indented);
            File.WriteAllText(_path, json);
        }
    }
}
