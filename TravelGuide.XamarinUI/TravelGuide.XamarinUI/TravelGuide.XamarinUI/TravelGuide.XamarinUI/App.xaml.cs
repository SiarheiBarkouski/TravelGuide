using System;
using TravelGuide.Core.Common.Entities;
using TravelGuide.XamarinUI.Interfaces;
using TravelGuide.XamarinUI.Views;
using TravelGuide.XamarinUI.WebApiClients;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace TravelGuide.XamarinUI
{
    public partial class App : Application
    {
        private readonly IPreLoadLoginHandler _loginInfoHandler = DependencyService.Get<IPreLoadLoginHandler>();

        public App()
        {
            InitializeComponent();
            //MainPage = new AuthorizationPage();
        }

        public User CurrentUserLoginInfo { get; set; }

        protected override void OnStart()
        {
            using (var client = new WebApiClient())
            {
                User user;
                try
                {
                    var info = _loginInfoHandler.GetLoginInformation();
                    user = !string.IsNullOrEmpty(info.SocialId) ? client.GetUserLoginInfo(info.SocialId) : null;
                    CurrentUserLoginInfo = user;
                }
                catch (Exception ex)
                {
                    user = null;
                }


                if (user != null)
                {
                    MainPage = new MainPage(user);
                }
                else
                    MainPage = new AuthorizationPage();
            }
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

    }
}