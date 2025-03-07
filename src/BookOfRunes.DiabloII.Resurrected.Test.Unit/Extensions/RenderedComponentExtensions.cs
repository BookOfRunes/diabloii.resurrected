using BookOfRunes.DiabloII.Resurrected.Test.Unit.Extensions;
using Bunit;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace BookOfRunes.DiabloII.Resurrected.Test.Unit.Extensions
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
