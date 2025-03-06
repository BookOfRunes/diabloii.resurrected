using AutoBogus;
using Bogus;
using RuneDex.DiabloII.Resurrected.WASM.Controls.Dialog;
using Xunit;

namespace RuneDex.DiabloII.Resurrected.Test.Unit.WASM.Services
{
	public class DialogServiceTest
	{
		private DialogService CreateSUT()
		{
			return new DialogService();
		}

		[Fact(DisplayName = "[UNIT][DLS-001] - Show Dialog")]
		[Trait("Feature", "DL - Dialog")]
		public void DialogService_Show_ShowDialog()
		{
			// Arrange
			var sut = CreateSUT();
			var key = new Faker().Random.String();

			// Act
			sut.Show(key);

			// Assert
			Assert.True(sut[key]);
		}

		[Fact(DisplayName = "[UNIT][DLS-002] - Dismiss Dialog")]
		[Trait("Feature", "DL - Dialog")]
		public void DialogService_Show_DismissDialog()
		{
			// Arrange
			var sut = CreateSUT();
			var key = new Faker().Random.String();

			sut.Show(key);

			// Act
			sut.Dismiss();

			// Assert
			Assert.False(sut[key]);
		}

		[Fact(DisplayName = "[UNIT][DLS-003] - Accept Dialog")]
		[Trait("Feature", "DL - Dialog")]
		public async Task DialogService_Show_AcceptDialog()
		{
			// Arrange
			var sut = CreateSUT();
			var key = new Faker().Random.String();

			sut.Show(key);

			// Act
			await sut.AcceptAsync<object>(null);

			// Assert
			Assert.False(sut[key]);
		}

		[Fact(DisplayName = "[UNIT][DLS-004] - Invoke Accepted")]
		[Trait("Feature", "DL - Dialog")]
		public async Task DialogService_Show_InvokeAccepted()
		{
			// Arrange
			var sut = CreateSUT();
			var invoked = false;
			var result = new AutoFaker<object>().Generate();

			sut.Accepted = (r) =>
			{
				invoked = r == result;
				return Task.CompletedTask;
			};

			// Act
			await sut.AcceptAsync(result);

			// Assert
			Assert.True(invoked);
		}
	}
}
