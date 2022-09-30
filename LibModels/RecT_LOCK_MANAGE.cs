using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAMSS.Data;

namespace BAMTS.Internal
{
    public class RecT_LOCK_MANAGE : RecordBase
    {
        public string LOCK_ID { get; set; }
        public string LOCK_NAME { get; set; }
        public string USER_ID { get; set; }
        public DateTime LOCK_TIME { get; set; }
        public string MESSAGE { get; set; }
        public DateTime UPD_TIME { get; set; }
        public string UPD_USER { get; set; }
    }
}
