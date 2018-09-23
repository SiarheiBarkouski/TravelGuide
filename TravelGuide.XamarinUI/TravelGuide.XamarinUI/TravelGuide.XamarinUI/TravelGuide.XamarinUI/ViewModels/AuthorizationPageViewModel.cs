using System;
using System.Threading.Tasks;
using System.Windows.Input;
using TravelGuide.Core.Common.Entities;
using TravelGuide.Core.Common.Enums;
using TravelGuide.XamarinUI.Interfaces;
using TravelGuide.XamarinUI.Views;
using TravelGuide.XamarinUI.WebApiClients;
using Xamarin.Forms;

namespace TravelGuide.XamarinUI.ViewModels
{
    public class AuthorizationPageViewModel : BaseViewModel
    {
        private User _user;

        public ICommand VkLoginCommand { get; }
        public ICommand FacebookLoginCommand { get; }
        public ICommand GoogleLoginCommand { get; }


        public AuthorizationPageViewModel(Page page)
            : base(page)
        {
            _user = new User();

            VkLoginCommand = new Command(async () => { await Login(typeof(IVkService)); });
            FacebookLoginCommand = new Command(async () => { await Login(typeof(IFacebookService)); });
            GoogleLoginCommand = new Command(async () => { await Login(typeof(IGoogleService)); });
        }

        private async Task Login(Type type)
        {
            LoginResult result;
            if (type == typeof(IVkService))
                result = await DependencyService.Get<IVkService>().Login();
            else if (type == typeof(IGoogleService))
                result = await DependencyService.Get<IGoogleService>().Login();
            else result = await DependencyService.Get<IFacebookService>().Login();
            OnLoginComplete(result);
        }

        private void OnLoginComplete(LoginResult result)
        {
            if (result.LoginState == LoginState.Success)
            {
                _user.SocialId = result.UserId;
                _user.Name = (result.FirstName + " " + result.LastName).Trim();
                _user.Email = result.Email;
                _user.Picture = result.ImageUrl;
                _user.IsLoggedIn = true;
                _user.IsOnline = true;
                _user.Token = result.Token;
                _user.LoginSource = result.LoginSource;

                DependencyService.Get<IPreLoadLoginHandler>().UpdateLoginInformation(_user);
                using (var client = new WebApiClient())
                {
                    var response = client.AddUser(_user);
                }
                
                var mainPage = new MainPage(_user);
                Application.Current.MainPage = mainPage;
            }
            else CurrentPage.DisplayAlert("Alert", "Failed to authorize", "OK");
        }
    }
}