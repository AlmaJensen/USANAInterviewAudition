using AndroidInterviewAudition.Helpers;
using AndroidInterviewAudition.Page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AndroidInterviewAudition.PageModel
{
	public class MainPageModel : ViewModel
	{
		public ICommand AndroidCentralButton
		{
			get
			{
				return new Command(async () =>
				{
					await Navigation.PushAsync(new RSSPage());
				});
			}
		}
		public ICommand AppleTopAppsButton
		{
			get
			{
				return new Command(async () =>
				{

				});
			}
		}
		public ICommand AppleTopPodcastsButton
		{
			get
			{
				return new Command(async () =>
				{

				});
			}
		}
		public MainPageModel(ContentPage page) : base(page)
        {
        }

	}
}
