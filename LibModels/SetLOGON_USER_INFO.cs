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
    public class SetLOGON_USER_INFO
    {
		//public bool IsValid => this.USER_PRIMARY_INFO.IsValid;
		public RecLOGON_USER_PRIMARY USER_PRIMARY_INFO { get; set; } = new RecLOGON_USER_PRIMARY();
		public List<RecLOGON_USER_AUTHORITY> USER_AUTHORITY { get; set; } = new List<RecLOGON_USER_AUTHORITY>();
		public SetLOGON_USER_INFO() 
		{
			this.USER_PRIMARY_INFO = new RecLOGON_USER_PRIMARY();
			this.USER_AUTHORITY = new List<RecLOGON_USER_AUTHORITY>();
		}
		public SetLOGON_USER_INFO Copy() => (SetLOGON_USER_INFO)this.MemberwiseClone();
		public void Logoff()
		{
			this.USER_PRIMARY_INFO = new RecLOGON_USER_PRIMARY();
			this.USER_AUTHORITY = new List<RecLOGON_USER_AUTHORITY>();
		}
	}
}
