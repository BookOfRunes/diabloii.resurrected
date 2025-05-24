using BookOfRunes.DiabloII.Resurrected.Api;
using BookOfRunes.DiabloII.Resurrected.Application.Contexts;
using BookOfRunes.DiabloII.Resurrected.Infrastructure;
using BookOfRunes.DiabloII.Resurrected.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using STrain;
using STrain.Core.Exceptions;

namespace BookOfRunes.DiabloII.Resurrected.Application.Performers
{
	public class UserDataPerformers : IQueryPerformer<HasUserDataQuery, bool>,
		ICommandPerformer<CreateUserCommand>,
		ICommandPerformer<SaveRunesCommand>,
		ICommandPerformer<SaveCharacterCommand>
	{
		private readonly DatabaseContext _database;
		private readonly IUserContext _user;
		private readonly ILogger<UserDataPerformers> _logger;

		public UserDataPerformers(DatabaseContext database, IUserContext user, ILogger<UserDataPerformers> logger)
		{
			_database = database;
			_user = user;
			_logger = logger;
		}

		public async Task<bool> PerformAsync(HasUserDataQuery query, CancellationToken cancellationToken)
		{
			_logger.LogDebug("Checking if user exists");
			return await _database.Users.AnyAsync(u => u.Id == _user.Id, cancellationToken);
		}

		public async Task PerformAsync(CreateUserCommand command, CancellationToken cancellationToken)
		{
			await using var transaction = await _database.Database.BeginTransactionAsync(cancellationToken);

			await _database.Users.AddAsync(new Infrastructure.Entities.UserEntity { Id = _user.Id }, cancellationToken);

			await _database.SaveChangesAsync(cancellationToken);
			await transaction.CommitAsync(cancellationToken);
		}

		public async Task PerformAsync(SaveRunesCommand command, CancellationToken cancellationToken)
		{
			await using var transaction = await _database.Database.BeginTransactionAsync(cancellationToken);

			var user = await _database.Users.SingleOrDefaultAsync(u => u.Id == _user.Id, cancellationToken: cancellationToken);
			if (user is null) throw new NotFoundException("User");

			foreach (var id in command.Runes)
			{
				var rune = await _database.Runes.SingleOrDefaultAsync(r => r.Id == id, cancellationToken: cancellationToken);
				if (rune is null) throw new NotFoundException("Rune");

				await _database.UserRunes.AddAsync(new Infrastructure.Entities.UserRuneEntity
				{
					User = user,
					Rune = rune
				}, cancellationToken);
			}

			await _database.SaveChangesAsync(cancellationToken);
			await transaction.CommitAsync(cancellationToken);
		}

		public async Task PerformAsync(SaveCharacterCommand command, CancellationToken cancellationToken)
		{
			await using var transaction = await _database.Database.BeginTransactionAsync(cancellationToken);

			var user = await _database.Users.SingleOrDefaultAsync(u => u.Id == _user.Id, cancellationToken);
			if (user is null) throw new NotFoundException("User");

			var @class = await _database.Classes.SingleOrDefaultAsync(c => c.Id == command.Class, cancellationToken);
			if (@class is null) throw new NotFoundException("Class");

			await _database.AddAsync(new CharacterEntity
			{
				User = user,
				Class = @class,
				Name = command.Name,
				Level = command.Level
			}, cancellationToken);

			await _database.SaveChangesAsync(cancellationToken);
			await transaction.CommitAsync(cancellationToken);
		}
	}
}
