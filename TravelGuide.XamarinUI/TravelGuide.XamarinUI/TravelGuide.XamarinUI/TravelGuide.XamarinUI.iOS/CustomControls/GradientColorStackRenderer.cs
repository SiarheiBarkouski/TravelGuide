using CoreAnimation;
using CoreGraphics;
using TravelGuide.XamarinUI.CustomControls;
using TravelGuide.XamarinUI.iOS.CustomControls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(GradientColorStack), typeof(GradientColorStackRenderer))]

namespace TravelGuide.XamarinUI.iOS.CustomControls
{
    public class GradientColorStackRenderer : VisualElementRenderer<StackLayout>
    {
        public override void Draw(CGRect rect)
        {
            base.Draw(rect);
            GradientColorStack stack = (GradientColorStack)this.Element;
            CGColor startColor = stack.StartColor.ToCGColor();

            CGColor endColor = stack.EndColor.ToCGColor();

            var gradientLayer = new CAGradientLayer();

            if (stack.GradientOrientation == GradientOrientation.Horizontal)
            {
                gradientLayer = new CAGradientLayer
                {
                    StartPoint = new CGPoint(0, 0.5),
                    EndPoint = new CGPoint(1, 0.5),
                    Frame = rect,
                    Colors = new[] { startColor, endColor }
                };
            }
            NativeView.Layer.InsertSublayer(gradientLayer, 0);
        }
    }
}