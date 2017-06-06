using Android.App;
using Android.Graphics.Drawables;
using iDelivery.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Color = Android.Graphics.Color;

[assembly: ExportRenderer(typeof(NavigationPage), typeof(CustomNavigationRenderer))]
namespace iDelivery.Droid
{
    public class CustomNavigationRenderer : NavigationRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<NavigationPage> e)
        {
            base.OnElementChanged(e);

            RemoveAppIconFromActionBar();
        }
        void RemoveAppIconFromActionBar()
        {
            var actionBar = ((Activity)Context).ActionBar;
            actionBar.SetIcon(new ColorDrawable(Color.White));
        }
    }
}