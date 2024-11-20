using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dima.Api.common.Api
{
    public interface IEndpoint
    {
        static abstract void map(IEndpointRouteBuilder app);
    }
}