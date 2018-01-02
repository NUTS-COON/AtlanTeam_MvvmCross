using Android.App;
using Android.Content.PM;
using MvvmCross.Droid.Views;

namespace AtlanTeam.Droid
{
    [Activity(
        Label = "AtlanTeam.Droid"
        , MainLauncher = true
        , Icon = "@drawable/splash"
        , Theme = "@style/Theme.Splash"
        , NoHistory = true
        , ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashScreen : MvxSplashScreenActivity
    {
        public SplashScreen()
            : base(Resource.Layout.SplashScreen)
        {
        }
    }
}
