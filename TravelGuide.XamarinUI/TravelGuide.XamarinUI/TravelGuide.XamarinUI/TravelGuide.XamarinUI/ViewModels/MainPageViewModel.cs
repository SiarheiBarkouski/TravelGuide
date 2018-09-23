using TravelGuide.Core.Common.Entities;
using Xamarin.Forms;

namespace TravelGuide.XamarinUI.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private User _user;
        

        public User User
        {
            get => _user;
            set
            {
                if (_user != null && _user != value)
                    _user = value;
            }
        }

        public MainPageViewModel(User user, Page page) : base(page)
        {
            _user = user;
        }
    }
}
