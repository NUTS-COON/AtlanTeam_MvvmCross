using AtlanTeam.Core.Models;
using MvvmCross.Core.ViewModels;
using System.Collections.Generic;

namespace AtlanTeam.Core.ViewModels
{
    public class UsersViewModel : MvxViewModel<List<User>>
    {
        private List<User> _users;
        public List<User> Users
        {
            get { return _users; }
            set { SetProperty(ref _users, value); }
        }

        public override void Prepare(List<User> parameter)
        {
            Users = parameter;
        }
    }
}
