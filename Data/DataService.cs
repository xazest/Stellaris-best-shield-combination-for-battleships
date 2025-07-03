using Newtonsoft.Json;

namespace ShieldCompositon.Data
{
    internal class DataService
    {
        private static readonly string _path = "SelectedShields.json";

        public static List<SelectedShield> Load()
        {
            if (!File.Exists(_path))
            {
                File.Create(_path).Close();
                File.WriteAllText(_path,
                    JsonConvert.SerializeObject(SelectedShieldsList.Selected,
                        Formatting.Indented));
            }

            string json = File.ReadAllText(_path);
            return JsonConvert.DeserializeObject<List<SelectedShield>>(json);
        }
        public static void Save(List<SelectedShield> selectedShields)
        {
            string json = JsonConvert.SerializeObject(selectedShields, Formatting.Indented);
            File.WriteAllText(_path, json);
        }
    }
}
