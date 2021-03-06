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
using Java.Lang;
using TNX.RssReader;

namespace AndroidNativeUI.Adapter
{
	public class FeedAdapter : BaseAdapter<RssItem>
	{
		List<RssItem> items;
		Activity context;
		public FeedAdapter(Activity context, List<RssItem> feed)
		{
			items = feed;
			this.context = context;
		}
		public override int Count
		{
			get
			{
				return items.Count();
			}
		}

		//public override Java.Lang.Object GetItem(int position)
		//{
		//	return items[position];
		//}

		public override long GetItemId(int position)
		{
			return position;
		}
		public override RssItem this[int position]
		{
			get { return items[position]; }
		}
		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			View view = convertView; // re-use an existing view, if one is available
			if (view == null)  // otherwise create a new one
				view = context.LayoutInflater.Inflate(Resource.Layout.FeedRowView, null);
			view.FindViewById<TextView>(Resource.Id.ShortDescriptionTextView).Text = items[position].Title;
			view.FindViewById<TextView>(Resource.Id.DateTextView).Text = items[position].PublicationUtcTime.Date.ToString();
			return view;
		}
	}
}