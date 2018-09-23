using TravelGuide.XamarinUI.CustomControls;
using TravelGuide.XamarinUI.iOS.CustomControls;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(EntryNoUnderline), typeof(EntryNoUnderlineRenderer))]
namespace TravelGuide.XamarinUI.iOS.CustomControls
{
    public class EntryNoUnderlineRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {

                Control.BorderStyle = UITextBorderStyle.None;
                Control.Layer.CornerRadius = 10;
                Control.TextColor = UIColor.White;

            }
        }
    }
}