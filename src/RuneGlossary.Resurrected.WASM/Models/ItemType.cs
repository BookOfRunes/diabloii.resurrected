using RuneGlossary.Resurrected.Api;

namespace RuneGlossary.Resurrected.WASM.Models
{
    public record ItemType : INotifyPropertyChanged
    {
        private bool _selected;
        public bool Selected
        {
            get => _selected;
            set { _selected = value; PropertyChanged?.Invoke(this, EventArgs.Empty); }
        }
        public required int Id { get; init; }
        public required ItemClass Class { get; init; }
        public required string Name { get; init; }

        public event EventHandler<EventArgs>? PropertyChanged;
    }
}
