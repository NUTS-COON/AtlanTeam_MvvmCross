using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;

namespace AtlanTeam.Core.ViewModels
{
    public class MainViewModel : MvxViewModel
    {

        public MainViewModel()
        {
            _postCardViewModel = Mvx.IocConstruct<PostCardViewModel>();
            _commentCardViewModel = Mvx.IocConstruct <CommentCardViewModel>();
            _usersCardViewModel = Mvx.IocConstruct<UsersCardViewModel>();
            _photoCardViewModel = Mvx.IocConstruct<PhotoCardViewModel>();
            _TODOsCardViewModel = Mvx.IocConstruct<TODOsViewModel>();
        }

        private PostCardViewModel _postCardViewModel;
        public PostCardViewModel PostCardViewModel { get { return _postCardViewModel; } }

        private CommentCardViewModel _commentCardViewModel;
        public CommentCardViewModel CommentCardViewModel { get { return _commentCardViewModel; } }

        private UsersCardViewModel _usersCardViewModel;
        public UsersCardViewModel UsersCardViewModel { get { return _usersCardViewModel; } }

        private PhotoCardViewModel _photoCardViewModel;
        public PhotoCardViewModel PhotoCardViewModel { get { return _photoCardViewModel; } }

        private TODOsViewModel _TODOsCardViewModel;
        public TODOsViewModel TODOsCardViewModel { get { return _TODOsCardViewModel; } }
    }
}