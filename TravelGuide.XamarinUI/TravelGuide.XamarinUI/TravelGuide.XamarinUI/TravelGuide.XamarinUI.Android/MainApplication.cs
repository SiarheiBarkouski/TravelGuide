using System;

using Android.App;
using Android.Runtime;
using TravelGuide.XamarinUI.Droid.AuthServices;
using TravelGuide.XamarinUI.Interfaces;
using VKontakte;
using Xamarin.Forms;
using Application = Android.App.Application;

namespace TravelGuide.XamarinUI.Droid
{
    [Application]
    public class MainApplication : Application
    {
        public MainApplication(IntPtr handle, JniHandleOwnership transer)
          :base(handle, transer)
        {
        }

        public override void OnCreate()
        {
            base.OnCreate();
            VKSdk.Initialize(this).WithPayments();

            DependencyService.Register<IPreLoadLoginHandler, PreLoadLoginHandler>();
            DependencyService.Register<IVkService, AndroidVkService>();
            DependencyService.Register<IGoogleService, AndroidGoogleService>();
            DependencyService.Register<IFacebookService, AndroidFacebookService>();
        }
    }
}