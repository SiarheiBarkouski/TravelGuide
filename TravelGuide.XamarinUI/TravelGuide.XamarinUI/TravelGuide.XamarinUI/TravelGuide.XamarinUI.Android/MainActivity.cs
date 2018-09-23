using System;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Gms.Auth.Api;
using Android.Gms.Auth.Api.SignIn;
using Android.OS;
using TravelGuide.Core.Common.Enums;
using VKontakte;
using Xamarin.Facebook;
using Xamarin.Facebook.AppEvents;
using Xamarin.Forms;

namespace TravelGuide.XamarinUI.Droid
{
    [Activity(Label = "TravelGuide", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        public static MainActivity Instance { get; private set; }

        protected override void OnCreate(Bundle bundle)
        {
            Instance = this;
            base.OnCreate(bundle);
            Forms.Init(this, bundle);

            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            FacebookSdk.SdkInitialize(ApplicationContext);

            LoadApplication(new App());
        }

        protected override void OnResume()
        {
            base.OnResume();
            AppEventsLogger.ActivateApp(Application);
        }

        protected override async void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            switch (requestCode)
            {
                case (int)RequestCode.Google:
                    {
                        GoogleSignInResult result = Auth.GoogleSignInApi.GetSignInResultFromIntent(data);
                        AndroidGoogleService.Instance.OnAuthCompleted(result);
                        break;
                    }

                case (int)RequestCode.Vkontakte:
                    {
                        try
                        {
                            var token = await VKSdk.OnActivityResultAsync(requestCode, resultCode, data);
                            AndroidVkService.Instance.SetUserToken(token);
                        }
                        catch (Exception e)
                        {
                            var vkException = e as VKException;
                            if (vkException == null || vkException.Error.ErrorCode != VKontakte.API.VKError.VkCanceled)
                                AndroidVkService.Instance.SetErrorResult(e.Message);
                            else
                                AndroidVkService.Instance.SetCanceledResult();
                        }
                        break;
                    }

                case (int)RequestCode.Facebook:
                    {
                        AndroidFacebookService.Instance.OnActivityResult(requestCode, (int)resultCode, data);
                        break;
                    }
            }
        }




    }
}