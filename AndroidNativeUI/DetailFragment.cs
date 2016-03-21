using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Webkit;

namespace AndroidNativeUI
{
	public class DetailFragment : Android.App.Fragment
	{
		public const string ARGNAME = "position";
		public WebView FeedDetail { get; set; }
		public static DetailFragment NewInstance()
		{
			var frag = new DetailFragment
			{
				Arguments = new Bundle()
			};
			return frag;
		}
		public override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Create your fragment here
		}

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			// Use this to return your custom view for this Fragment
			var view = inflater.Inflate(Resource.Layout.DetailFragmentView, container, false);
			FeedDetail = Activity.FindViewById<WebView>(Resource.Id.FragmentWebView);
			return view;
		}
		public void UpadateView(string contentToDisplay)
		{
			if (FeedDetail == null)
				FeedDetail = new WebView(Activity);
			FeedDetail.LoadData(contentToDisplay, "text/html", null);
		}
	}
}