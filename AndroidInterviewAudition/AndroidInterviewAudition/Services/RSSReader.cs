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
		public async void GetFeed(string feedURL)
		{
			var feed = await RssHelper.ReadFeedAsync(feedURL);
			foreach (var f in feed.Items)
				Debug.WriteLine(f.Description);
		}
	}
}
