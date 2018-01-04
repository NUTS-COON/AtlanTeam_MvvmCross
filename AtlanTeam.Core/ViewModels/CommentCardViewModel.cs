using MvvmCross.Core.ViewModels;
using AtlanTeam.Core.Services;
using AtlanTeam.Core.Repository;
using AtlanTeam.Core.Models;

namespace AtlanTeam.Core.ViewModels
{
    public class CommentCardViewModel : MvxViewModel
    {
        private IDataService _dataService;
        private ISQLiteRepository _repository;

        public CommentCardViewModel(IDataService DataService, ISQLiteRepository repository)
        {
            _dataService = DataService;
            _repository = repository;
            var comment = _repository.GetObject<Comment>();
            if(comment != null)
            {
                LoadPostTitle(comment.PostId);
                PostId = comment.PostId;
                CommentId = comment.Id;
                Name = comment.Name;
                UserEmail = comment.Email;
                Comment = comment.Body;
            }
            else
            {
                LoadData();
            }            
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

        private int _postId;
        public int PostId
        {
            get { return _postId; }
            set { _postId = value; }
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
            set
            {                
                SetProperty(ref _isLoading, value);
                if (!_isLoading) { SaveData(); }
            }
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
                    LoadPostTitle(result.PostId);
                    PostId = result.PostId;
                    Name = result.Name;
                    UserEmail = result.Email;
                    Comment = result.Body.Replace("\n", "/n");
                },
                error =>
                {
                    IsLoading = false;
                });
        }

        private void LoadPostTitle(int postId)
        {
            _dataService.LoadPost(postId,
                result =>
                {
                    PostTitle = result.Title;
                    IsLoading = (result.Id < -1);
                },
                error => { });
        }

        private void SaveData()
        {
            _repository.SaveObject<Comment>(new Comment
            {
                PostId = PostId,
                Id = CommentId,
                Name = Name,
                Email = UserEmail,
                Body = Comment
            });
        }

    }
}
