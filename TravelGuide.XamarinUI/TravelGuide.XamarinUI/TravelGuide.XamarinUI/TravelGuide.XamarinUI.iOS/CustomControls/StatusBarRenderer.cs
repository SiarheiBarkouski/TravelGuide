using TravelGuide.XamarinUI.iOS.CustomControls;
using TravelGuide.XamarinUI.Interfaces;
using UIKit;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(StatusBarRenderer))]
namespace TravelGuide.XamarinUI.iOS.CustomControls
{
    public class StatusBarRenderer : IStatusBar
    {
        public StatusBarRenderer()
        {
        }

        #region IStatusBar implementation

        public void HideStatusBar()
        {
            UIApplication.SharedApplication.StatusBarHidden = true;
        }

        public void ShowStatusBar()
        {
            UIApplication.SharedApplication.StatusBarHidden = false;
        }

        public void SetStatusBarColor(Color color)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}