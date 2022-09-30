using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMTS.Internal
{
    public interface IDataAccessor
    {
        IList<RecEmployeeAll> GetEmployeeAll();
        void UpdateEmployeeAll(IList<RecEmployeeAll> list);
    }
}
