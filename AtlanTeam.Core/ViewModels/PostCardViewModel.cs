using AtlanTeam.Core.Services;
using MvvmCross.Core.ViewModels;

namespace AtlanTeam.Core.ViewModels
{
    public class PostCardViewModel : MvxViewModel
    {
        private IDataService _dataService;

        public PostCardViewModel(IDataService dataService)
        {
            _dataService = dataService;
            LoadData();
        }

        private int _postId = 1;
        public int PostId
        {
            get { return _postId; }
            set
            {
                if(value > 100) { PostId = 100; }
                else { SetProperty(ref _postId, value); }
            }
        }

        private string _user;
        public string User
        {
            get { return _user; }
            set { SetProperty(ref _user, value); }
        }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private string _body;
        public string Body
        {
            get { return _body; }
            set { SetProperty(ref _body, value); }
        }

        private bool _isLoading = false;
        public bool IsLoading
        {
            get { return _isLoading; }
            set { SetProperty(ref _isLoading, value); }
        }

        private bool _startEdit = false;
        public bool StartEdit
        {
            get { return _startEdit; }
            set { SetProperty(ref _startEdit, value); }
        }

        private bool _endEdit = true;
        public bool EndEdit
        {
            get { return _endEdit; }
            set { SetProperty(ref _endEdit, value); }
        }

        public IMvxCommand StartEditCommand => new MvxCommand(StartEditPost);
        public IMvxCommand EndEditCommand => new MvxCommand(EndEditPost);

        private void StartEditPost()
        {
            StartEdit = !StartEdit;
            EndEdit = !EndEdit;
        }

        private void EndEditPost()
        {
            LoadData();
            StartEdit = !StartEdit;
            EndEdit = !EndEdit;
        }


        private void LoadData()
        {
            IsLoading = true;

            _dataService.LoadPost(PostId,
                result =>
                {
                    LoadUserName(result.UserId);
                    Title = result.Title;
                    Body = result.Body.Replace("\n", "/n");
                },
                error =>
                {
                    IsLoading = false;
                }
                    );
        }

        private void LoadUserName(int userId)
        {
            _dataService.LoadUser(userId,
                result =>
                {
                    User = result.Username;
                    IsLoading = (result.Id < -1);
                },
                error => {});
        }

    }
}
