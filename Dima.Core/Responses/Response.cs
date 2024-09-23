using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Dima.Core.Responses
{
    public class Response<TData>
    {
        private readonly int _code;

        [JsonConstructor]
        public Response()
            => _code = Configuration.DefaultStatusCode;

        public Response(TData data, int code = 200, string? message = null)
        {
            Data = data;
            Message = message;
            _code = Configuration.DefaultStatusCode;
        }
        public TData? Data { get; set; }
        public string? Message { get; set; }

        [JsonIgnore]
        public bool IsSuccess => _code >= 200 && _code <= 299;
    }
}