namespace BookOfRunes.DiabloII.Resurrected.WASM.Controls.LoadingScreen
{
	public interface ILoading : IDisposable
	{
		IDisposable Show();
		void Close();
	}

	public class Loading : ILoading
	{
		public bool Visible { get; private set; }

		public event EventHandler<EventArgs>? Changed;

		public void Close()
		{
			Visible = false;
			Changed?.Invoke(this, EventArgs.Empty);
		}

		public void Dispose()
		{
			Close();
		}

		public IDisposable Show()
		{
			Visible = true;
			Changed?.Invoke(this, EventArgs.Empty);
			return this;
		}
	}
}
