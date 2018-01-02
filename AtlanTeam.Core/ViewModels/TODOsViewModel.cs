using AtlanTeam.Core.Services;
using MvvmCross.Core.ViewModels;
using System;

namespace AtlanTeam.Core.ViewModels
{
    public class TODOsViewModel : MvxViewModel
    {
        private IDataService _dataService;

        public TODOsViewModel(IDataService dataService)
        {
            _dataService = dataService;
            LoadData(Random(200));
        }

        private int _number;
        public int Number
        {
            get { return _number; }
            set { SetProperty(ref _number, value); }
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

        private bool _comleted;
        public bool Comleted
        {
            get { return _comleted; }
            set { SetProperty(ref _comleted, value); }
        }

        private bool _isLoading = false;
        public bool IsLoading
        {
            get { return _isLoading; }
            set { SetProperty(ref _isLoading, value); }
        }

        private void LoadData(int id)
        {
            IsLoading = true;
            _dataService.LoadTODOs(id,
                result =>
                {
                    Number = result.Id;
                    LoadUserName(result.UserId);
                    Title = result.Title;
                    Comleted = result.Completed;
                },
                error => { IsLoading = false; });
        }

        private void LoadUserName(int userId)
        {
            _dataService.LoadUser(userId,
                result =>
                {
                    User = result.Username;
                    IsLoading = (result.Id < -1);
                },
                error => { });
        }

        private readonly Random _random = new Random(DateTime.Now.Millisecond);
        protected int Random(int count)
        {
            return _random.Next(1, count);
        }
    }
}
