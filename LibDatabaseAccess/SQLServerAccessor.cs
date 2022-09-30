using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAMSS.Data;

namespace BAMTS.Internal
{
    public class SQLServerAccessor : IDataAccessor
    {
        private string _connectionString = null;
        public SQLServerAccessor(string connectionString)
        {
            this._connectionString = connectionString;
        }
        public IList<RecEmployeeAll> GetEmployeeAll()
        {
            var sp = new StoredProcessor(this._connectionString);
            return sp.P_Get_T_EMPLOYEE_ALL();
        }

        public void UpdateEmployeeAll(IList<RecEmployeeAll> list)
        {
            var sp = new StoredProcessor(this._connectionString);
            sp.P_Replace_T_EMPLOYEE_ALL(list);
        }
    }
}
