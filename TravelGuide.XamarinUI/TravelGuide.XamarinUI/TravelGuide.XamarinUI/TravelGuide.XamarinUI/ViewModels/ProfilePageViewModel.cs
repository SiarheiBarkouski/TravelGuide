using System.Windows.Input;
using TravelGuide.Core.Common.Entities;
using Xamarin.Forms;

namespace TravelGuide.XamarinUI.ViewModels
{
    public class ProfilePageViewModel : BaseViewModel
    {
        private User _user;
        private bool _isVisible;

        public ProfilePageViewModel(User user, Page page) : base(page)
        {
            _user = user;

            HistoryViewVisible = new Command(() => { IsHistoryVisible = true; });
            CardsViewVisible = new Command(() => { IsHistoryVisible = false; });
        }

        public ICommand HistoryViewVisible { get; }
        public ICommand CardsViewVisible { get; }
        

        public User User
        {
            get => _user;
            set
            {
                if (value != _user)
                {
                    _user = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool IsHistoryVisible
        {
            get => _isVisible;
            set
            {
                if (value != _isVisible)
                {
                    _isVisible = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(IsCardsVisible));
                }
            }
        }

        public bool IsCardsVisible => !_isVisible;
    }
}