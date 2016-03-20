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
using TNX.RssReader;
using System.Threading.Tasks;
using System.IO;

namespace AndroidNativeUI.Service
{
	public class RSSService
	{
		private const string fileName = "feed.dat";
		public async Task<RssFeed> GetFeedFromInternet(string feedURL)
		{
			return await RssHelper.ReadFeedAsync(feedURL);
		}
		public async Task<RssFeed> LoadFeedFromStorage()
		{
			try
			{
				var storage = new FileStorage();
				var json = await storage.GetFileReadStream(Path.Combine(storage.MyDocumentsPath, fileName));
				return Newtonsoft.Json.JsonConvert.DeserializeObject<RssFeed>(json);
			}
			catch (Exception ex)
			{
				return null;
			}
		}
		public async Task<bool> SaveFeed(RssFeed feed)
		{
			try
			{
				var json = Newtonsoft.Json.JsonConvert.SerializeObject(feed);
				var storage = new FileStorage();
				return await storage.Save(Path.Combine(storage.MyDocumentsPath, fileName), json);
			}
			catch(Exception ex)
			{
				return false;
			}			
		}
	}
}