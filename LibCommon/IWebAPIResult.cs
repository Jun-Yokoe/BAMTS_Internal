using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMTS.Internal
{
    public interface IWebAPIResult<T>
    {
        int ResultCode { get; set; }
        Exception Exception { get; set; }
        T ResponsData { get; set; }
    }
}
