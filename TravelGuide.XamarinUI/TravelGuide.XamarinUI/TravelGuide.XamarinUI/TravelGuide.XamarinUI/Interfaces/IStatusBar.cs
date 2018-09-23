using Xamarin.Forms;

namespace TravelGuide.XamarinUI.Interfaces
{
    public interface IStatusBar
    {
        void HideStatusBar();
        void ShowStatusBar();
        void SetStatusBarColor(Color color);
    }
}
