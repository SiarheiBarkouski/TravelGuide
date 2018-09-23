using TravelGuide.Core.Common.Entities;
using TravelGuide.XamarinUI.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelGuide.XamarinUI.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RoutesPage : ContentPage
	{
		public RoutesPage (User user)
		{
			InitializeComponent ();
		    BindingContext = new RoutesPageViewModel(user, this);
		}
	}
}