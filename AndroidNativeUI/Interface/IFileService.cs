using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Threading.Tasks;

namespace AndroidNativeUI.Interface
{
	public interface IFileService
	{
		string MyDocumentsPath { get; }
		Task<bool> Delete(string path);
		Task<bool> Save(string filePath, string stringToSave);
		Task<string> GetFileReadStream(string path);
	}
}