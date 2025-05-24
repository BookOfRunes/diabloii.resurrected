using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace BookOfRunes.DiabloII.Resurrected.Application.Contexts
{
	public interface IUserContext
	{
		public string Id { get; }
	}

	public class UserContext : IUserContext
	{
		private readonly ClaimsPrincipal _user;

		public string Id => GetHash(_user.Claims.Single(c => c.Type == "preferred_username").Value);

		public UserContext(IHttpContextAccessor context)
		{
			_user = context.HttpContext.User;
		}

		private string GetHash(string value)
		{
			return Convert.ToBase64String(SHA512.HashData(Encoding.UTF8.GetBytes(value.ToLower())));
		}
	}
}
