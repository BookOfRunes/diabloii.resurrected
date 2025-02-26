namespace RuneGlossary.Resurrected.WASM.Models
{
	public interface INotifyPropertyChanged
	{
		event EventHandler<EventArgs> PropertyChanged;
	}
}
