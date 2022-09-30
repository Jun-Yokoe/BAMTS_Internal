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
    public class RecLOGON_USER_PRIMARY : RecordBase
    {
		public string STAFF_ID { get; set; }
		public string STAFF_NAME { get; set; }
		public string STAFF_DISP_NAME => (string.IsNullOrEmpty(this.NICK_NAME)) ? this.STAFF_NAME : this.NICK_NAME;
		public string NICK_NAME { get; set; }
		public string PASS_WORD { get; set; }
		public int DEPARTMENT_ID { get; set; }
		public string DEPARTMENT_NAME { get; set; }
		public int ACCESS_GROUP_ID { get; set; }
		public string ACCESS_GROUP_NAME { get; set; }
		public DateTime? LoginTime { get; set; } = DateTime.Now;
		public string InputSTAFF_ID { get; set; }
		public string InputPASS_WORD { get; set; }
		public bool IsValid => (!string.IsNullOrEmpty(this.InputSTAFF_ID)) && (this.STAFF_ID == this.InputSTAFF_ID) && (this.PASS_WORD == this.InputPASS_WORD);
		public string DISPLAY_NAME => string.IsNullOrEmpty(this.NICK_NAME.Trim()) ? this.STAFF_NAME : this.NICK_NAME;
		public void SetLogin(string staffID, string passWord)
		{
			this.InputSTAFF_ID = staffID;
			this.InputPASS_WORD = passWord;
		}
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public RecLOGON_USER_PRIMARY() { }
		public RecLOGON_USER_PRIMARY Copy() => (RecLOGON_USER_PRIMARY)this.MemberwiseClone();
	}
}
