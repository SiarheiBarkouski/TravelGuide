using System;
using Android.Content;
using Android.Graphics;
using TravelGuide.XamarinUI.CustomControls;
using TravelGuide.XamarinUI.Droid.CustomControls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Color = Xamarin.Forms.Color;

[assembly: ExportRenderer(typeof(GradientColorStack), typeof(GradientColorStackRenderer))]

namespace TravelGuide.XamarinUI.Droid.CustomControls
{
    public class GradientColorStackRenderer : VisualElementRenderer<StackLayout>
    {
        public GradientColorStackRenderer(Context context) : base(context)
        {
        }

        private Color StartColor { get; set; }
        private Color EndColor { get; set; }
        private GradientOrientation GradientOrientation { get; set; }

        protected override void DispatchDraw(Canvas canvas)
        {
            var gradient = GradientOrientation == GradientOrientation.Horizontal ?
                new LinearGradient(0, 0, 0, Height,
                StartColor.ToAndroid(),
                EndColor.ToAndroid(),
                Shader.TileMode.Mirror) 
                :
                new LinearGradient(0, 0, Width, 0,
                StartColor.ToAndroid(),
                EndColor.ToAndroid(),
                Shader.TileMode.Mirror);

            var paint = new Paint
            {
                Dither = true
            };
            paint.SetShader(gradient);
            canvas.DrawPaint(paint);
            base.DispatchDraw(canvas);
        }

        protected override void OnElementChanged(ElementChangedEventArgs<StackLayout> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || Element == null)
            {
                return;
            }
            try
            {
                var stack = e.NewElement as GradientColorStack;
                StartColor = stack?.StartColor ?? Color.White;
                EndColor = stack?.EndColor ?? Color.White;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(@"ERROR:", ex.Message);
            }
        }
    }
}