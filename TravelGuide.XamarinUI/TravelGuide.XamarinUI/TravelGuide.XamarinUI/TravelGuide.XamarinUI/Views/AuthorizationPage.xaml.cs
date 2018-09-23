using TravelGuide.XamarinUI.Interfaces;
using TravelGuide.XamarinUI.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelGuide.XamarinUI.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AuthorizationPage
	{
		public AuthorizationPage()
		{
			InitializeComponent ();
            BindingContext = new AuthorizationPageViewModel(this);

		    DependencyService.Get<IStatusBar>().HideStatusBar();
		}
	}
}