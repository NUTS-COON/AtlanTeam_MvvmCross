using System;
using AtlanTeam.Core.Models;

namespace AtlanTeam.Core.Services
{
    public interface IDataService
    {
        void LoadPost(int id, Action<Post> success, Action<Exception> error);
        void LoadUser(int id, Action<User> success, Action<Exception> error);
        void LoadComment(int id, Action<Comment> success, Action<Exception> error);
        void LoadTODOs(int id, Action<TODOs> success, Action<Exception> error);
    }
}
