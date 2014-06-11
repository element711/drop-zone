using System;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using DropZone.Annotations;
using Xamarin;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace DropZone.Droid
{
    /// <summary>
    /// Main activity.
    /// </summary>
    [Activity(Label = "Drop Zone", 
              MainLauncher = true, 
              ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, 
              Icon = "@drawable/ParachuteIcon")]
    public class MainActivity : AndroidActivity
    {
        private Action<int, Result, Intent> _activityResultCallback;

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

        /// <summary>
        /// Configures the callback that will be called when OnActivityResult is raised.
        /// </summary>
        public void ConfigureActivityResultCallback([NotNull] Action<int, Result, Intent> callback)
        {
            if (callback == null) throw new ArgumentNullException("callback");

            _activityResultCallback = callback;
        }

        /// <summary>
        /// Called when an activity you launched exits, giving you the requestCode
        /// you started it with, the resultCode it returned, and any additional
        /// data from it.
        /// </summary>
        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            if (_activityResultCallback != null)
            {
                _activityResultCallback.Invoke(requestCode, resultCode, data);
                _activityResultCallback = null;
            }
        }
    }
}

