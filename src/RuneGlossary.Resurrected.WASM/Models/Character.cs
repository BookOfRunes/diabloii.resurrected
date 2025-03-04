
namespace RuneGlossary.Resurrected.WASM.Models
{
    public enum Class
    {
        Amazon,
        Assassin,
        Barbarian,
        Druid,
        Necromancer,
        Paladin,
        Sorceress
    }

    public record Character : INotifyPropertyChanged
    {

        public required string Name { get; init; }
        public required Class Class { get; init; }
        private int _level;
        public required int Level
        {
            get => _level;
            set { _level = value; NotifyPropertyChanged(); }
        }
        public FilterData Filters { get; set; } = new FilterData();

        public event EventHandler<EventArgs>? PropertyChanged;

        private void NotifyPropertyChanged()
        {
            PropertyChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    public record FilterData
    {
        public IEnumerable<ItemType> ItemTypes { get; set; } = [];
        public int SocketFrom { get; set; } = 2;
        public int SocketTo { get; set; } = 6;
        public int Level { get; set; } = 99;
    }
}
