using Xamarin.Forms;

namespace TravelGuide.XamarinUI.CustomControls
{
    public class GradientColorStack : StackLayout  
    {  
        public Color StartColor { get; set; }  
        public Color EndColor { get; set; }
        public GradientOrientation GradientOrientation { get; set; }
    }

    public enum GradientOrientation
    {
        Horizontal = 0,
        Vertical = 1
    }
}