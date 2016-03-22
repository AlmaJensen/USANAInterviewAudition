using AndroidInterviewAudition.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndroidInterviewAudition.Services
{
	public class FileStorage
	{
		IFileStorage fileService = Xamarin.Forms.DependencyService.Get<IFileStorage>();
		public async Task<bool> Delete(string fileName)
		{
			try
			{
				return await fileService.Delete(Path.Combine(fileService.MyDocumentsPath, fileName));
			}
			catch
			{
				return false;
			}
		}
		public async Task<bool> Save(string fileName, string fileData)
		{
			try
			{
				return await fileService.Save(Path.Combine(fileService.MyDocumentsPath, fileName), fileData);

			}
			catch
			{
				return false;
			}
		}
		public async Task<string> Load(string fileName)
		{
			try
			{
				return await fileService.GetFileReadStream(Path.Combine(fileService.MyDocumentsPath, fileName));
			}
			catch
			{
				return null;
			}
		}
	}
}
