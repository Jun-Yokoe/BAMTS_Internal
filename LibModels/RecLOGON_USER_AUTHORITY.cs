using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAMSS.Data;
using System.ComponentModel;
//using System.ComponentModel.DataAnnotations;

namespace BAMTS.Internal
{
    public class RecLOGON_USER_AUTHORITY : RecordBase
    {
		public string ACCESS_FUNC_ID { get; set; }
		public string ACCESS_ITEM_ID { get; set; }
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public RecLOGON_USER_AUTHORITY() { }
		public RecLOGON_USER_AUTHORITY Copy() => (RecLOGON_USER_AUTHORITY)this.MemberwiseClone();
	}
}
