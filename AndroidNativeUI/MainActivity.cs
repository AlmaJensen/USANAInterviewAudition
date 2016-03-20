using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using TNX.RssReader;
using Plugin.Connectivity;
using AndroidNativeUI.Service;

namespace AndroidNativeUI
{
	[Activity(Label = "Alma's Android RSS Reader", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		RssFeed rssFeed;
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			//Button button = FindViewById<Button>(Resource.Id.MyButton);

			//button.Click += delegate { button.Text = string.Format("{0} clicks!", count++); };
		}

		private async void LoadFeed()
		{
			var rssTools = new RSSService();
			if (CrossConnectivity.Current.IsConnected)
			{
				rssFeed = await rssTools.GetFeedFromInternet(Constants.FeedURL);
			}
			else
			{
				rssFeed = await rssTools.LoadFeedFromStorage();
			}
		}

		private void LoadFeedFromStorage()
		{
			throw new NotImplementedException();
		}

		private void LoadFeedFromInternet()
		{
			throw new NotImplementedException();
		}

		private async void SaveFeed()
		{

		}
	}
}

