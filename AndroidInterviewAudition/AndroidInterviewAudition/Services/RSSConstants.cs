using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndroidInterviewAudition.Services
{
	public class RSSConstants
	{
		public enum RSSFeeds
		{
			AndroidCentral, iOSTop25Apps, iOSTop25Podcasts
		}
		public Dictionary<string, string> RSSFeedURLS = new Dictionary<string, string>
		{
			{ RSSFeeds.AndroidCentral.ToString(), "http://feeds.feedburner.com/androidcentral?format=xml" },
			{ RSSFeeds.iOSTop25Apps.ToString(), "http://ax.itunes.apple.com/WebObjects/MZStoreServices.woa/ws/RSS/topfreeapplications/limit=25/xml" },
			{ RSSFeeds.iOSTop25Podcasts.ToString(), "http://feeds.feedburner.com/androidcentral?format=xml" },
		};
	}
}
