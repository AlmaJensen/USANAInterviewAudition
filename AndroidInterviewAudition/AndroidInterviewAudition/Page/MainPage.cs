using AndroidInterviewAudition.PageModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AndroidInterviewAudition.Page
{
	
	public class MainPage : ContentPage
	{
		Button androidFeed, appleTop25, appleTop25PodCasts;
		public MainPage()
		{
			InitializeControls();
			SetBindings();
			Content = CreateLayout();
			BindingContext = new MainPageModel(this);
		}

		private View CreateLayout()
		{
			var mainLayout = new StackLayout
			{
				Children =
				{
					androidFeed, appleTop25, appleTop25PodCasts
				}
			};
			return mainLayout;
		}

		private void SetBindings()
		{
			androidFeed.SetBinding(Button.CommandProperty, nameof(MainPageModel.AndroidCentralButton));
			appleTop25.SetBinding(Button.CommandProperty, nameof(MainPageModel.AppleTopAppsButton));
			appleTop25PodCasts.SetBinding(Button.CommandProperty, nameof(MainPageModel.AppleTopPodcastsButton));
		}

		private void InitializeControls()
		{
			androidFeed = new Button
			{
				Text = "Android Central"
			};
			appleTop25 = new Button
			{
				Text = "Top 25 Apple Apps"
			};
			appleTop25PodCasts = new Button
			{
				Text = "Top 25 Apple Podcasts"
			};
		}
	}
}
