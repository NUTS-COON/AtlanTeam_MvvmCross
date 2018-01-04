using AtlanTeam.Core.Models;
using AtlanTeam.Core.Services;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AtlanTeam.Core.ViewModels
{
    public class UsersCardViewModel : MvxViewModel
    {
        private IMvxNavigationService _navigationService;
        private IDataService _dataService;

        public UsersCardViewModel(IDataService dataService, IMvxNavigationService navigationService)
        {
            _dataService = dataService;
            _navigationService = navigationService;
        }

        private bool _isLoading = false;
        public bool IsLoading
        {
            get { return _isLoading; }
            set { SetProperty(ref _isLoading, value); }
        }

        public IMvxCommand ShowUsersCommand => new MvxCommand(ShowUsers);

        private async void ShowUsers()
        {
            IsLoading = true;
            var list = await LoadUserAsync();
            IsLoading = false;
            await _navigationService.Navigate<UsersViewModel, List<User>>(list);
        }

        private Task<List<User>> LoadUserAsync()
        {
            List<User> newList = new List<User>();
            bool errFlag = true;
            int attempt = 0;
            return Task.Run(() =>
            {
                for (int i = 1; i <= 10; i++)
                {
                    _dataService.LoadUser(i,
                        result =>
                        {
                            newList.Add(new User
                            {
                                Id = result.Id,
                                Name = result.Name,
                                Username = result.Username,
                                Email = result.Email,
                                Address = result.Address,
                                Phone = result.Phone.Substring(0, 12),
                                Website = result.Website,
                                Company = result.Company
                            });
                        },
                        error => { newList.Add(new User()); errFlag = false; });
                }
                while (true)
                {
                    attempt++;
                    if (newList.Count < 10 && attempt < 100 && errFlag) { Task.Delay(100).Wait(); }
                    else { break; }
                }
                newList.Sort((a, b) => a.Id.CompareTo(b.Id));
                return newList;
            });
        }
    }
}
