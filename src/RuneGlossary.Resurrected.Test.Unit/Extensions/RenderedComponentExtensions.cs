using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace Bunit
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
