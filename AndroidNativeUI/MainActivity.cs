
using Android.App;
using Android.OS;
using Android.Widget;
using AndroidNativeUI.Service;
using Plugin.Connectivity;
using System.Threading.Tasks;
using TNX.RssReader;

namespace AndroidNativeUI
{
	[Activity(Label = "Alma's Android RSS Reader", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		private RssFeed rssFeed;
		private ListView feedListView;
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);
			InitializeActivity();
		}

		protected override void OnResume()
		{
			base.OnResume();
			LoadFeed();
		}

		private async Task LoadFeed()
		{
			var feedLoaded = await GetFeed();
			if (feedLoaded)
				feedListView.Adapter = new Adapter.FeedAdapter(this, rssFeed);
		}

		private async void InitializeActivity()
		{

			feedListView = FindViewById<ListView>(Resource.Id.FeedListView);
			feedListView.FastScrollEnabled = true;
		}

		private async Task<bool> GetFeed()
		{
			var rssTools = new RSSService();
			if (CrossConnectivity.Current.IsConnected)
			{
				rssFeed = await rssTools.GetFeedFromInternet(Constants.FeedURL);
				if (rssFeed != null)
					return true;
				else
					return false;
			}
			else
			{
				rssFeed = await rssTools.LoadFeedFromStorage();
				if (rssFeed != null)
					return true;
				else
					return false;
			}
		}

		private async void SaveFeed()
		{

		}
	}
}

