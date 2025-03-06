namespace RuneDex.DiabloII.Resurrected.WASM.Controls.Dialog
{
	public interface IDialogService
	{
		void Show(string key);
		Task AcceptAsync<T>(T? result);
		void Dismiss();
	}

	public class DialogService : IDialogService
	{
		private string? _visibleKey;

		public Func<object?, Task> Accepted { get; set; } = (_) => Task.CompletedTask;

		public bool this[string key]
		{
			get { return _visibleKey == key; }
		}

		public event EventHandler<EventArgs>? Changed;

		public async Task AcceptAsync<T>(T? result)
		{
			_visibleKey = null;
			Changed?.Invoke(this, EventArgs.Empty);
			await Accepted(result);
		}

		public void Dismiss()
		{
			_visibleKey = null;
			Changed?.Invoke(this, EventArgs.Empty);
		}

		public void Show(string key)
		{
			_visibleKey = key;
			Changed?.Invoke(this, EventArgs.Empty);
		}
	}
}
