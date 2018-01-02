using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using MvvmCross.Platform.Platform;
using Newtonsoft.Json;

namespace AtlanTeam.Core.Services
{
    public class RestAPIService : IRestAPIService, IMvxTrace
    {

        public void MakeRequest<T>(string url, string method, Action<T> success, Action<Exception> error)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = method;
            request.Accept = "application/json";

            MakeRequest(
               request,
               (response) =>
               {
                   if (success != null)
                   {
                       T toReturn;
                       try
                       {
                           toReturn = Deserialize<T>(response);
                       }
                       catch (Exception ex)
                       {
                           error(ex);
                           return;
                       }
                       success(toReturn);
                   }
               },
               (err) =>
               {
                   error?.Invoke(err);
               }
            );
        }

        private void MakeRequest(HttpWebRequest request, Action<string> successAction, Action<Exception> errorAction)
        {
            request.BeginGetResponse(token =>
            {
                try
                {
                    using (var response = request.EndGetResponse(token))
                    {
                        using (var stream = response.GetResponseStream())
                        {
                            var reader = new StreamReader(stream);
                            successAction(reader.ReadToEnd());
                        }
                    }
                }
                catch (WebException ex)
                {
                    Trace(MvxTraceLevel.Error, "RestApi",
                        "ERROR: '{0}' when making {1} request to {2}", ex.Message, request.Method, request.RequestUri.AbsoluteUri);
                    errorAction(ex);
                }
            }, null);
        }

        private T Deserialize<T>(string responseBody)
        {
            var toReturn = JsonConvert.DeserializeObject<T>(responseBody);
            return toReturn;
        }

        public void Trace(MvxTraceLevel level, string tag, string message)
        {
            Debug.WriteLine(tag + ":" + level + ":" + message);
        }

        public void Trace(MvxTraceLevel level, string tag, Func<string> message)
        {
            //
        }

        public void Trace(MvxTraceLevel level, string tag, string message, params object[] args)
        {
            //
        }
    }
}
