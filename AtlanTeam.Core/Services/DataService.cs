using System;
using AtlanTeam.Core.Models;

namespace AtlanTeam.Core.Services
{
    public class DataService : IDataService
    {
        private IRestAPIService _restApi;

        public DataService(IRestAPIService restAPIService)
        {
            _restApi = restAPIService;
        }

        public void LoadPost(int id, Action<Post> success, Action<Exception> error)
        {
            string url = string.Format("http://jsonplaceholder.typicode.com/posts/{0}", id.ToString());
            _restApi.MakeRequest<Post>(url, "GET", success, error);
        }

        public void LoadUser(int id, Action<User> success, Action<Exception> error)
        {
            string url = string.Format("http://jsonplaceholder.typicode.com/users/{0}", id.ToString());
            _restApi.MakeRequest<User>(url, "GET", success, error);
        }

        public void LoadComment(int id, Action<Comment> success, Action<Exception> error)
        {
            string url = string.Format("http://jsonplaceholder.typicode.com/comments/{0}", id.ToString());
            _restApi.MakeRequest<Comment>(url, "GET", success, error);
        }

        public void LoadTODOs(int id, Action<TODOs> success, Action<Exception> error)
        {
            string url = string.Format("http://jsonplaceholder.typicode.com/todos/{0}", id.ToString());
            _restApi.MakeRequest<TODOs>(url, "GET", success, error);
        }
    }
}
