using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioRick.Helpers
{
	public static class SessionExtensions
	{
		/// <summary>
		///     Set object as json
		/// </summary>
		/// <param name="session">Session object</param>
		/// <param name="key">Sesson key</param>
		/// <param name="value">Object value</param>
		public static void SetObjectAsJson(this ISession session, string key, object value)
		{
			session.SetString(key, JsonConvert.SerializeObject(value));
		}

		/// <summary>
		///     Get object from json
		/// </summary>
		/// <typeparam name="T">Session object</typeparam>
		/// <param name="session">Session object</param>
		/// <param name="key">key of session</param>
		/// <returns></returns>
		public static T GetObjectFromJson<T>(this ISession session, string key)
		{
			var value = session.GetString(key);

			return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
		}

	}
}
