using AndroidInterviewAudition.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AndroidInterviewAudition.PageModel
{
	public class RSSPageModel : ViewModel
	{
		public ObservableCollection<string> RSSFeed { get; set; }
		public RSSPageModel(ContentPage page) : base(page)
		{
		}
	}
}
