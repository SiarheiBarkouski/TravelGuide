using Android.Content;
using Android.Content.Res;
using Android.Graphics.Drawables;
using Android.Text;
using TravelGuide.XamarinUI.CustomControls;
using TravelGuide.XamarinUI.Droid.CustomControls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(EntryNoUnderline), typeof(EntryNoUnderlineRenderer))]
namespace TravelGuide.XamarinUI.Droid.CustomControls
{
    public class EntryNoUnderlineRenderer : EntryRenderer
    {
        public EntryNoUnderlineRenderer(Context context) : base(context)
        {
        }


        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                GradientDrawable gd = new GradientDrawable();
                gd.SetColor(global::Android.Graphics.Color.Transparent);
                this.Control.SetBackgroundDrawable(gd);
                this.Control.SetRawInputType(InputTypes.TextFlagNoSuggestions);
                Control.SetHintTextColor(ColorStateList.ValueOf(global::Android.Graphics.Color.White));
            }
        }
    }
}
