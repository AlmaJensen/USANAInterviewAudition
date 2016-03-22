using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace AndroidInterviewAudition.Page
{
	public class RSSPage : ContentPage
	{
		ListView rssFeed;
		WebView rssDetail;
		public RSSPage(string FeedType)
		{
			Content = new StackLayout
			{
				Children = {
					new Label { Text = "Hello ContentPage" }
				}
			};
		}
	}
}
