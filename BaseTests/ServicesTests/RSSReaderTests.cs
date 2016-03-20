using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace BaseTests
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestFeedRetrieval()
		{
			var rssReader = new AndroidInterviewAudition.Services.RSSReader();
			var items = rssReader.GetFeed(AndroidInterviewAudition.Constants.FeedURL);
			foreach (var it in items)
				Debug.WriteLine(it.Content);
			Assert.IsNotNull(items);
		}
	}
}
