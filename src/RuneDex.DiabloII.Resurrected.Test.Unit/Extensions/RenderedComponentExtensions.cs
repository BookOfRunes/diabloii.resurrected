using Bunit;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using RuneDex.DiabloII.Resurrected.Test.Unit.Extensions;

namespace RuneDex.DiabloII.Resurrected.Test.Unit.Extensions
{
	public static class RenderedComponentExtensions
	{
		public static async Task ClickAsync<TComponent>(this IRenderedComponent<TComponent> component, string id)
			where TComponent : IComponent
		{
			await component.Find($"[data-testid={id}]").ClickAsync(new MouseEventArgs());
		}
	}
}
