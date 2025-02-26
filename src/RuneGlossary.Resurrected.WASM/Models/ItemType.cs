using RuneGlossary.Resurrected.Api;

namespace RuneGlossary.Resurrected.WASM.Models
{
	public record ItemType : INotifyPropertyChanged
	{
		private bool selected;

		public bool Selected
		{
			get { return selected; }
			set { selected = value; PropertyChanged?.Invoke(this, EventArgs.Empty); }
		}
		public required int Id { get; init; }
		public required ItemClass Class { get; init; }
		public required string Name { get; init; }

		public event EventHandler<EventArgs> PropertyChanged;
	}
}
