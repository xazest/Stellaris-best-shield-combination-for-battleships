namespace ShieldCompositon.Data
{
    internal class SelectedShields
    {
        public string Name { get; set; }
        public bool Checked { get; set; }
        public SelectedShields(string name, bool isChecked = false)
        {
            Name = name;
            Checked = isChecked;
        }
    }
}
