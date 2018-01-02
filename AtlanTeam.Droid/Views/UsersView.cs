using Android.App;
using Android.OS;
using MvvmCross.Droid.Views;

namespace AtlanTeam.Droid.Views
{
    [Activity(Label = "Users")]
    public class UsersView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.UsersView);
        }
    }
}