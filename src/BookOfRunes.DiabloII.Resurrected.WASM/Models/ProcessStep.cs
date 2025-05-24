namespace BookOfRunes.DiabloII.Resurrected.WASM.Models
{
	public enum ProcessStepState
	{
		NotStarted,
		InProgress,
		Succedded,
		Failed
	}

	public class ProcessStep
	{
		public ProcessStepState State { get; private set; } = ProcessStepState.NotStarted;
		public required string Message { get; init; }

		public void Start() => State = ProcessStepState.InProgress;
		public void Succedded() => State = ProcessStepState.Succedded;
		public void Failed() => State = ProcessStepState.Failed;
	}
}
