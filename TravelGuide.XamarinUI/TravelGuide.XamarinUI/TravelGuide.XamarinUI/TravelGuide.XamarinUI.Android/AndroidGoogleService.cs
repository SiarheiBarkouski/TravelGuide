using System;
using System.Threading.Tasks;
using Android.Content;
using Android.Gms.Auth.Api;
using Android.Gms.Auth.Api.SignIn;
using Android.Gms.Common;
using Android.Gms.Common.Apis;
using Android.OS;
using TravelGuide.Core.Common.Entities;
using TravelGuide.Core.Common.Enums;
using TravelGuide.XamarinUI.Interfaces;
using Xamarin.Forms;

namespace TravelGuide.XamarinUI.Droid
{
    public class AndroidGoogleService : Java.Lang.Object, IGoogleService, GoogleApiClient.IConnectionCallbacks, GoogleApiClient.IOnConnectionFailedListener
    {
        public static GoogleApiClient _googleApiClient { get; set; }
        public static AndroidGoogleService Instance => DependencyService.Get<IGoogleService>() as AndroidGoogleService;

        TaskCompletionSource<LoginResult> _completionSource;
        LoginResult _loginResult;

        public AndroidGoogleService()
        {
            GoogleSignInOptions gso = new GoogleSignInOptions.Builder(GoogleSignInOptions.DefaultSignIn)
                                                             .RequestEmail()
                                                             .Build();

            _googleApiClient = new GoogleApiClient.Builder(((MainActivity)Forms.Context).ApplicationContext)
                .AddConnectionCallbacks(this)
                .AddOnConnectionFailedListener(this)
                .AddApi(Auth.GOOGLE_SIGN_IN_API, gso)
                .AddScope(new Scope(Scopes.Profile))
                .Build();
        }

        public Task<LoginResult> Login()
        {
            _completionSource = new TaskCompletionSource<LoginResult>();
            Intent signInIntent = Auth.GoogleSignInApi.GetSignInIntent(_googleApiClient);
            ((MainActivity)Forms.Context).StartActivityForResult(signInIntent, (int)RequestCode.Google); _googleApiClient.Connect();
            return _completionSource.Task;
        }

        public void Logout()
        {
            _googleApiClient.Disconnect();
        }

        public void OnAuthCompleted(GoogleSignInResult result)
        {
            if (result.IsSuccess)
            {
                var account = result.SignInAccount;
                if (account != null)
                    _loginResult = new LoginResult
                    {
                        UserId = account.Id,
                        FirstName = account.DisplayName,
                        Email = account.Email,
                        ImageUrl = new Uri(account.PhotoUrl != null
                            ? $"{account.PhotoUrl}"
                            : "https://autisticdating.net/imgs/profile-placeholder.jpg").ToString(),
                        Token = account.IdToken,
                        LoginSource = LoginSource.Google,
                        LoginState = LoginState.Success
                    };
                SetResult(_loginResult);
            }
            else
            {
                SetResult(new LoginResult { LoginState = LoginState.Failed, ErrorString = "An error occured!" });
            }
        }

        public void OnConnected(Bundle connectionHint)
        {
        }

        public void OnConnectionSuspended(int cause)
        {
            SetResult(new LoginResult { LoginState = LoginState.Canceled });
        }

        public void OnConnectionFailed(ConnectionResult result)
        {
            SetResult(new LoginResult { LoginState = LoginState.Failed, ErrorString = result.ErrorMessage });
        }

        void SetResult(LoginResult result)
        {
            _completionSource?.TrySetResult(result);
            _loginResult = null;
            _completionSource = null;
        }
    }
}
