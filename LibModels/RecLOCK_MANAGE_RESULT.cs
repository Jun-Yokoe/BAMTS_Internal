using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAMSS.Data;

namespace BAMTS.Internal
{
    public class RecLOCK_MANAGE_RESULT : RecordBase
    {
        public string RESULT { get; set; }
        public string STAFF_ID { get; set; }
        public string STAFF_NAME { get; set; }
    }
}
