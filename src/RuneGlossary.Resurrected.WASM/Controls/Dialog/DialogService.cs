namespace RuneGlossary.Resurrected.WASM.Controls
{
	public interface IDialogService
	{
		void Show();
		Task AcceptAsync<T>(T? result);
		void Dismiss();
	}

	public class DialogService : IDialogService
	{
		private bool _visible;

		public Func<object?, Task> Accepted { get; set; } = (_) => Task.CompletedTask;

		public bool Visible
		{
			get { return _visible; }
			set { _visible = value; Changed?.Invoke(this, EventArgs.Empty); }
		}

		public event EventHandler<EventArgs>? Changed;

		public async Task AcceptAsync<T>(T? result)
		{
			Visible = false;
			await Accepted(result);
		}

		public void Dismiss()
		{
			Visible = false;
		}

		public void Show()
		{
			Visible = true;
		}
	}
}
