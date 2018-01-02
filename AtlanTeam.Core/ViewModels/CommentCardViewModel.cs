using MvvmCross.Core.ViewModels;
using AtlanTeam.Core.Services;

namespace AtlanTeam.Core.ViewModels
{
    public class CommentCardViewModel : MvxViewModel
    {
        private IDataService _dataService;

        public CommentCardViewModel(IDataService DataService)
        {
            _dataService = DataService;
            LoadData();
        }

        private int _commentId = 1;
        public int CommentId
        {
            get { return _commentId; }
            set
            {
                if (value > 500) { CommentId = 500; }
                else { SetProperty(ref _commentId, value); }
            }
        }


        private string _postTitle;
        public string PostTitle
        {
            get { return _postTitle; }
            set { SetProperty(ref _postTitle, value); }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        private string _userEmail;
        public string UserEmail
        {
            get { return _userEmail; }
            set { SetProperty(ref _userEmail, value); }
        }

        private string _comment;
        public string Comment
        {
            get { return _comment; }
            set { SetProperty(ref _comment, value); }
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
            _dataService.LoadComment(CommentId,
                result =>
                {
                    LoadPost(result.PostId);
                    Name = result.Name;
                    UserEmail = result.Email;
                    Comment = result.Body.Replace("\n", "/n");
                },
                error =>
                {
                    IsLoading = false;
                });
        }

        private void LoadPost(int postId)
        {
            _dataService.LoadPost(postId,
                result =>
                {
                    PostTitle = result.Title;
                    IsLoading = (result.Id < -1);
                },
                error => { });
        }

    }
}
