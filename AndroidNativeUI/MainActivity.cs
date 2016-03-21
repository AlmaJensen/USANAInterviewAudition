
using Android.App;
using Android.OS;
using Android.Webkit;
using Android.Widget;
using AndroidNativeUI.Service;
using Plugin.Connectivity;
using System.Collections.Generic;
using System.Threading.Tasks;
using TNX.RssReader;
using Android.Support.V4.App;
namespace AndroidNativeUI
{
	[Activity(Label = "Alma's Android RSS Reader", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : FragmentActivity
	{
		private RssFeed rssFeed;
		private List<RssItem> feedItems = new List<RssItem>();
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
			{
				foreach (var item in rssFeed.Items)
					feedItems.Add(item);
				feedListView.Adapter = new Adapter.FeedAdapter(this, feedItems);
			}
				
		}

		private async void InitializeActivity()
		{

			feedListView = FindViewById<ListView>(Resource.Id.FeedListView);
			feedListView.FastScrollEnabled = true;
			feedListView.ItemClick += FeedListView_ItemClick;
		}

		private void FeedListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
		{
			
			var item = feedItems[e.Position];
			var fragMan = FragmentManager;
			var fragment = fragMan.FindFragmentById<DetailFragment>(Resource.Id.DetailFragment);
			if(fragment == null)
			{
				fragment = new DetailFragment();
				Bundle args = new Bundle();
				args.PutInt(DetailFragment.ARGNAME, e.Position);
				fragment.Arguments = args;
				var transaction = fragMan.BeginTransaction();
				transaction.Replace(Resource.Layout.DetailFragmentView, fragment);
				transaction.AddToBackStack(null);
				transaction.Commit();
				//fragment = DetailFragment.NewInstance();
				//fragment.FeedDetail = new WebView(this);
			}
			else
			{
				fragment.UpadateView(item.Description);
			}
			//var ft = FragmentManager.BeginTransaction();
			//ft.Replace(Resource.Id.DetailFragment, fragment);
			////ft.SetTransition(Android.Support.V4.App.FragmentTransaction.TransitFragmentFade);
			//ft.Commit();
			//fragment.FeedDetail.LoadData(item.Description, "text/html", null);
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

