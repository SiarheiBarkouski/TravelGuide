using Android.App;
using Android.Views;
using TravelGuide.XamarinUI.Droid.CustomControls;
using TravelGuide.XamarinUI.Interfaces;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: Xamarin.Forms.Dependency(typeof(StatusBarRenderer))]
namespace TravelGuide.XamarinUI.Droid.CustomControls
{
    public class StatusBarRenderer : IStatusBar
    {
        public StatusBarRenderer()
        {
        }

        WindowManagerFlags _originalFlags;

        #region IStatusBar implementation

        public void HideStatusBar()
        {
            var activity = (Activity)Forms.Context;
            var attrs = activity.Window.Attributes;
            _originalFlags = attrs.Flags;
            attrs.Flags |= Android.Views.WindowManagerFlags.Fullscreen;
            activity.Window.Attributes = attrs;
        }

        public void ShowStatusBar()
        {
            var activity = (Activity)Forms.Context;
            var attrs = activity.Window.Attributes;
            attrs.Flags = _originalFlags;
            activity.Window.Attributes = attrs;
        }

        public void SetStatusBarColor(Color color)
        {
            var activity = (Activity)Forms.Context;
            activity.Window.SetStatusBarColor(color.ToAndroid());
        }

        #endregion
    }
}