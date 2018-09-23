using TravelGuide.Core.Common.Entities;
using TravelGuide.XamarinUI.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelGuide.XamarinUI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage(User user)
        {
            InitializeComponent();
            BindingContext = new ProfilePageViewModel(user, this);
        }
    }
}