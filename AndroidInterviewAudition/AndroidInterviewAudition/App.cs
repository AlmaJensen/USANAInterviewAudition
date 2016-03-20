using AndroidInterviewAudition.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace AndroidInterviewAudition
{
	public class App : Application
	{
		public App()
		{
			// The root page of your application
			MainPage = new ContentPage
			{
				Content = new StackLayout
				{
					VerticalOptions = LayoutOptions.Center,
					Children = {
						new Label {
							XAlign = TextAlignment.Center,
							Text = "Welcome to Xamarin Forms!"
						}
					}
				}
			};
		}

		protected override void OnStart()
		{
			var rss = new RSSReader();
			rss.GetFeed(Constants.FeedURL);
			//var rssReader = new AndroidInterviewAudition.Services.RSSReader();
			//var items = rssReader.GetFeed(AndroidInterviewAudition.Constants.FeedURL);
			//foreach (var it in items)
			//	Debug.WriteLine(it.);
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
