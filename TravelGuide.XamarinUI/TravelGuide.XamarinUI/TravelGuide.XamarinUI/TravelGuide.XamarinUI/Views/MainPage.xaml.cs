using TravelGuide.Core.Common.Entities;
using TravelGuide.XamarinUI.Interfaces;
using TravelGuide.XamarinUI.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;
using TabbedPage = Xamarin.Forms.TabbedPage;

namespace TravelGuide.XamarinUI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : TabbedPage
    {
        public MainPage(User user)
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel(user, this);

            Children.Add(new RoutesPage(user) { Title = "Routes", IconImageSource = "@drawable/routes" });
            Children.Add(new BonusPage { Title = "Bonus", IconImageSource = "@drawable/bonus" });
            Children.Add(new NotificationsPage { Title = "Notifications", IconImageSource = "@drawable/notifications" });
            Children.Add(new ProfilePage(user) { Title = "Profile", IconImageSource = "@drawable/profile" });

            On<Xamarin.Forms.PlatformConfiguration.Android>()
                .SetToolbarPlacement(ToolbarPlacement.Bottom)
                .SetBarItemColor(Color.LightGray)
                .SetBarSelectedItemColor(Color.White)
                .DisableSwipePaging();

            BarBackgroundColor = Color.FromHex("#D11515");

            DependencyService.Get<IStatusBar>().ShowStatusBar();
            DependencyService.Get<IStatusBar>().SetStatusBarColor(Color.FromHex("#6166DC"));
        }
    }
}