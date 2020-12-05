using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json; // can also use NewtonSoft.Json package
using System.Threading.Tasks;

namespace ASPNET_Core_App.TempdataExtension
{
	/// <summary>
	/// An extension  class to contains the CLR object in Static extesion method
	/// This will store the CLR object in JSON Serializer form (Key/Value)
	/// {key:value}
	/// </summary>
	public static class TempDataExtension
	{
		/// <summary>
		/// Extension method to save data in TempData Dictionary
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="temp">The TempData object</param>
		/// <param name="key">the "key" of the TempDataDictionary to store and retrived the data</param>
		/// <param name="value">the  "value" stored in TempDataDicrtionary</param>
		public static void SetData<T>(this ITempDataDictionary temp, string key, T value) where T: class
		{

			// if using NewtonSoft.Json the use JsonConvert.SerializeObject(vaule)
			// serialize the data on JSON string and store TempData
			temp[key] = JsonSerializer.Serialize(value);
		}
		/// <summary>
		/// The extension method to read dara from TempDataDictionary
		/// </summary>
		/// <typeparam name="T">The Data to be read from TempDataDictionary</typeparam>
		/// <param name="temp">TempDataDIctionary Object</param>
		/// <param name="key">The "key" in TempDataDictionary</param>
		/// <returns></returns>
		public static T GetData<T>(this ITempDataDictionary temp, string key) where T: class
		{
			object obj;

			temp.TryGetValue(key, out obj);
			if (obj == null) return default(T);  // return the blank object instead of null
			return JsonSerializer.Deserialize<T>((string)obj); // deserialize the JSON string into object
		}
	}
}
