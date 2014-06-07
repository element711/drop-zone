using Android.App;
using Android.OS;
using Xamarin;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace DropZone.Droid
{
    /// <summary>
    /// Main activity.
    /// </summary>
    [Activity(Label = "DropZone", MainLauncher = true, Icon = "@drawable/ParachuteIcon")] // Theme = "@android:style/Theme.Holo.Light"
    public class MainActivity : AndroidActivity
    {
        /// <summary>
        /// Called when the activity is created.
        /// </summary>
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            Forms.Init(this, bundle);
            FormsMaps.Init(this, bundle);

            Page mainPage = App.CreateMainPage();
            SetPage(mainPage);
        }
    }
}

