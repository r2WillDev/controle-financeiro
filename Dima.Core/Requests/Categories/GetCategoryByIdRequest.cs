using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dima.Core.Requests.Categories
{
    public class GetCategoryByIdRequest : Request
    {
        public long Id { get; set; }
    }
}