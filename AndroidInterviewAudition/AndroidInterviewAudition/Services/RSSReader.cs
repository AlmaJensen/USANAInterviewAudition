using AndroidInterviewAudition.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNX.RssReader;


namespace AndroidInterviewAudition.Services
{
	public class RSSReader
	{

		//private const string fileName = "feed.dat";
		public async Task<RssFeed> GetFeedFromInternet(string feedURL)
		{
			return await RssHelper.ReadFeedAsync(feedURL);
		}
		public async Task<RssFeed> LoadFeedFromStorage(string fileName)
		{
			try
			{
				var storage = new FileStorage();
				var fileservice = new FileStorage();
				var json = await fileservice.Load(fileName);
				//var json = await storage.GetFileReadStream(Path.Combine(storage.MyDocumentsPath, fileName));
				return Newtonsoft.Json.JsonConvert.DeserializeObject<RssFeed>(json);
			}
			catch (Exception ex)
			{
				return null;
			}
		}
		public async Task<bool> SaveFeed(string fileName, RssFeed feed)
		{
			try
			{
				var json = Newtonsoft.Json.JsonConvert.SerializeObject(feed);
				var storage = new FileStorage();
				return await storage.Save(fileName, json);
			}
			catch (Exception ex)
			{
				return false;
			}
		}
	}
}
