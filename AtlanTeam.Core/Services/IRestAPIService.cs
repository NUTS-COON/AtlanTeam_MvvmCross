using System;

namespace AtlanTeam.Core.Services
{
    public interface IRestAPIService
    {
        void MakeRequest<T>(string url, string method, Action<T> success, Action<Exception> error);
    }
}
