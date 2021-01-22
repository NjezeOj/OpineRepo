using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Opine.Client.Helpers
{
    public class HttpResponseWrapper<T>
    {
        public T Response { get; set; }
        public bool Success { get; set; }
        public HttpResponseMessage HttpResponseMessage { get; set;}
        public async Task<string> GetBody()
        {
            return await HttpResponseMessage.Content.ReadAsStringAsync();

        }
        public HttpResponseWrapper(T response, bool success, HttpResponseMessage httpResponseMessage)
        {
            Response = response;
            Success = success;
            HttpResponseMessage = httpResponseMessage;
        }
    }
}
