using BookOfRunes.DiabloII.Resurrected.Api;
using BookOfRunes.DiabloII.Resurrected.WASM.Controls.Dialog;
using BookOfRunes.DiabloII.Resurrected.WASM.Models;
using STrain;

namespace BookOfRunes.DiabloII.Resurrected.WASM.Services
{
	public interface IMigrationService
	{
		IEnumerable<ProcessStep> Steps { get; }

		event EventHandler<EventArgs>? ProgressChanged;
		Task MigrateAsync(CancellationToken cancellationToken);
	}

	public class MigrationService : IMigrationService
	{
		private readonly IRequestSender _requestSender;
		private readonly IRuneService _runeService;
		private readonly ICharacterService _characterService;
		private readonly IDialogService _dialogService;
		private readonly ILogger<MigrationService> _logger;
		public IEnumerable<ProcessStep> Steps { get; } = [
			new ProcessStep() { Message = "Create User" },
			new ProcessStep() { Message = "Save Runes" },
			new ProcessStep() { Message = "Save Characters" }
		];

		private ProcessStep CreateUser => Steps.ElementAt(0);
		private ProcessStep SaveRunes => Steps.ElementAt(1);
		private ProcessStep SaveCharacters => Steps.ElementAt(1);

		public event EventHandler<EventArgs>? ProgressChanged;

		public MigrationService(IRequestSender requestSender, IRuneService runeService, ICharacterService characterService, IDialogService dialogService, ILogger<MigrationService> logger)
		{
			_requestSender = requestSender;
			_runeService = runeService;
			_characterService = characterService;
			_dialogService = dialogService;
			_logger = logger;
		}


		public async Task MigrateAsync(CancellationToken cancellationToken)
		{
			_logger.LogDebug("Attempting to migrate user data");
			if (await _requestSender.GetAsync<HasUserDataQuery, bool>(new HasUserDataQuery(), cancellationToken))
			{
				_logger.LogDebug("User data has already been migrated");
				return;
			}

			_dialogService.Show("dlgMigration");

			_logger.LogDebug("Creating user");
			CreateUser.Start();
			ProgressChanged?.Invoke(this, EventArgs.Empty);
			await Task.Delay(10000);
			await _requestSender.SendAsync(new CreateUserCommand(), cancellationToken);
			CreateUser.Succedded();
			ProgressChanged?.Invoke(this, EventArgs.Empty);

			_logger.LogDebug("Saving runes");
			SaveRunes.Start();
			ProgressChanged?.Invoke(this, EventArgs.Empty);
			await _requestSender.SendAsync(new SaveRunesCommand { Runes = _runeService.Runes.Where(r => r.Selected).Select(r => r.Id).ToList() }, cancellationToken);
			SaveRunes.Succedded();
			ProgressChanged?.Invoke(this, EventArgs.Empty);

			SaveCharacters.Start();
			ProgressChanged?.Invoke(this, EventArgs.Empty);
			foreach (var character in _characterService.Characters)
			{
				_logger.LogDebug("Saving {Character} character", character.Name);
				await _requestSender.SendAsync(new SaveCharacterCommand { Name = character.Name, Level = character.Level, Class = (int)character.Class }, cancellationToken);
			}
			SaveCharacters.Succedded();
			ProgressChanged?.Invoke(this, EventArgs.Empty);

			_dialogService.Dismiss();
		}
	}
}
