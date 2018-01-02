using Android.App;
using Android.OS;
using Android.Widget;
using AtlanTeam.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Droid.Views;
using AtlanTeam.Core.ValueConverters;
using Android.Support.V7.Widget;

namespace AtlanTeam.Droid.Views
{
    [Activity(Label = "AtlanTeam")]
    public class MainView : MvxActivity
    {

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.MainView);
            VisibilityValueConverter valueConverter = new VisibilityValueConverter();
            
            EditText et_post = FindViewById<EditText>(Resource.Id.et_post_number);
            TextView tv_post = FindViewById<TextView>(Resource.Id.tv_post_number);
            Button iv_edit_post = FindViewById<Button>(Resource.Id.edit_post);
            Button iv_done_post = FindViewById<Button>(Resource.Id.done_post);

            EditText et_comment = FindViewById<EditText>(Resource.Id.et_comment_number);
            TextView tv_comment = FindViewById<TextView>(Resource.Id.tv_comment_number);
            Button iv_edit_comment = FindViewById<Button>(Resource.Id.edit_comment);
            Button iv_done_comment = FindViewById<Button>(Resource.Id.done_comment);

            CardView cardView = FindViewById<CardView>(Resource.Id.users_cardview);

            var set = this.CreateBindingSet<MainView, MainViewModel>();
                        

            set.Bind(et_post).For(v => v.Visibility).To(vm => vm.PostCardViewModel.StartEdit).WithConversion(valueConverter);
            set.Bind(tv_post).For(v => v.Visibility).To(vm => vm.PostCardViewModel.EndEdit).WithConversion(valueConverter);
            set.Bind(iv_edit_post).For(v => v.Visibility).To(vm => vm.PostCardViewModel.EndEdit).WithConversion(valueConverter);
            set.Bind(iv_done_post).For(v => v.Visibility).To(vm => vm.PostCardViewModel.StartEdit).WithConversion(valueConverter);

            set.Bind(et_comment).For(v => v.Visibility).To(vm => vm.CommentCardViewModel.StartEdit).WithConversion(valueConverter);
            set.Bind(tv_comment).For(v => v.Visibility).To(vm => vm.CommentCardViewModel.EndEdit).WithConversion(valueConverter);
            set.Bind(iv_edit_comment).For(v => v.Visibility).To(vm => vm.CommentCardViewModel.EndEdit).WithConversion(valueConverter);
            set.Bind(iv_done_comment).For(v => v.Visibility).To(vm => vm.CommentCardViewModel.StartEdit).WithConversion(valueConverter);

            set.Apply();
            
        }
    }
}
