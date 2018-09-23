using System.Collections.Generic;
using System.Windows.Input;
using TravelGuide.Core.Common.Entities;
using TravelGuide.XamarinUI.WebApiClients;
using Xamarin.Forms;

namespace TravelGuide.XamarinUI.ViewModels
{
    public class RoutesPageViewModel : BaseViewModel
    {
        private RouteToggled _routeToggled = RouteToggled.New;

        public RoutesPageViewModel(User user, Page page) : base(page)
        {
            ClosestViewVisible = new Command(() => { RouteToggled = RouteToggled.Closest; });
            BestViewVisible = new Command(() => { RouteToggled = RouteToggled.Best; });
            NewViewVisible = new Command(() => { RouteToggled = RouteToggled.New; });
            RouteToggled = RouteToggled.Closest;

            Routes = GetRoutes();
        }

        public List<Route> Routes { get; set; }


        public ICommand ClosestViewVisible { get; }
        public ICommand BestViewVisible { get; }
        public ICommand NewViewVisible { get; }

        public RouteToggled RouteToggled
        {
            get => _routeToggled;
            set
            {
                if (_routeToggled != value)
                {
                    _routeToggled = value;
                    OnPropertyChanged();
                    Routes = GetRoutes();
                    OnPropertyChanged(nameof(Routes));
                    ToggleUnderline(_routeToggled);
                }
            }
        }

        #region Underline button toggle

        private bool _closestToggled;
        private bool _bestToggled;
        private bool _newToggled;

        public bool ClosestToggled
        {
            get => _closestToggled;
            set
            {
                if (_closestToggled != value)
                {
                    _closestToggled = value;
                    OnPropertyChanged();
                }
            }
        }
        public bool BestToggled
        {
            get => _bestToggled;
            set
            {
                if (_bestToggled != value)
                {
                    _bestToggled = value;
                    OnPropertyChanged();
                }
            }
        }
        public bool NewToggled
        {
            get => _newToggled;
            set
            {
                if (_newToggled != value)
                {
                    _newToggled = value;
                    OnPropertyChanged();
                }
            }
        }

        private void ToggleUnderline(RouteToggled route)
        {
            switch (route)
            {
                case RouteToggled.Closest:
                    {
                        ClosestToggled = true;
                        BestToggled = false;
                        NewToggled = false;
                        break;
                    }
                case RouteToggled.Best:
                    {
                        ClosestToggled = false;
                        BestToggled = true;
                        NewToggled = false;
                        break;
                    }
                case RouteToggled.New:
                    {
                        ClosestToggled = false;
                        BestToggled = false;
                        NewToggled = true;
                        break;
                    }
                default:
                    {
                        ClosestToggled = true;
                        BestToggled = false;
                        NewToggled = false;
                        break;
                    }
            }
        }

        #endregion


        private List<Route> GetRoutes()
        {
            using (var client = new WebApiClient())
            {
                return client.GetRoutes();
            }
        }

    }

    public enum RouteToggled
    {
        Closest = 0,
        Best = 1,
        New = 2
    }
}
