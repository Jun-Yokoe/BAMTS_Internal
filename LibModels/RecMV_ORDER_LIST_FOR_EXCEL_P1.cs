using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAMSS.Data;
using System.ComponentModel;

namespace BAMTS.Internal
{
    public class RecMV_ORDER_LIST_FOR_EXCEL_P1 : RecordBase
    {
		public int STATUS { get; set; }
		public string STATUS_NAME { get; set; }
		public int ODR_PERIOD { get; set; }
		public string ODR_CATEGORY { get; set; }
		public string ODR_MONTH { get; set; }
		public int ODR_SEQ { get; set; }
		public DateTime? DLV_SUBMIT_DATE { get; set; }
		public DateTime? DLV_DEADLINE_DATE { get; set; }
		public DateTime? DLVREP_SUBMIT_DATE { get; set; }
		public DateTime? CMPREP_ISSUE_DATE { get; set; }
		public DateTime? CMPREP_DEADLINE_DATE { get; set; }
		public DateTime? CMPMAIL_ISSUE_DATE { get; set; }
		public DateTime? CMPMAIL_DEADLINE_DATE { get; set; }
		public string CNST_MANAGER_ID { get; set; }
		public string CNST_MANAGER_NAME { get; set; }
		public string TYPE { get; set; }
		public string TYPE_NAME { get; set; }
		public DateTime? REV_ISSUE_DATE { get; set; }
		public int REV_NO { get; set; }
		public DateTime? EST_ISSUE_DATE { get; set; }
		public int CUSTOMER_ID { get; set; }
		public string CUSTOMER_NAME { get; set; }
		public string ODR_NAME { get; set; }
		public DateTime? CNST_START_DATE { get; set; }
		public DateTime? CNST_END_DATE { get; set; }
		public DateTime? OPEN_DATE { get; set; }
		public string NOTE { get; set; }
		public string ESTREQ_NO_1 { get; set; }
		public string ESTREQ_NO_2 { get; set; }
		public string PRODUCT_NO { get; set; }
		public DateTime? REQ_DATE { get; set; }
		public string REQ_NO { get; set; }
		public DateTime? ODR_DATE { get; set; }
		public string ODR_NO { get; set; }
		public DateTime? ACCEPT_DATE { get; set; }
		public DateTime? ACCEPT_MONTH { get; set; }
		public DateTime? PAYMENT_MONTH { get; set; }
		public int ANS_NET_PRICE { get; set; }
		public int ANS_TAX_PRICE { get; set; }
		public int CALC_ANS_TAX_PRICE => (int)Math.Round((double)((decimal)this.ANS_NET_PRICE * ((decimal)this.TAX_RATE / (decimal)100)), MidpointRounding.AwayFromZero);
		public int CALC_ANS_TOTAL_PRICE => (int)((decimal)this.ANS_NET_PRICE + this.CALC_ANS_TAX_PRICE);
		public int CNST_NET_PRICE { get; set; }
		public int CNST_TAX_PRICE { get; set; }
		public int CALC_CNST_TAX_PRICE => (int)Math.Round((double)((decimal)this.CNST_NET_PRICE * ((decimal)this.TAX_RATE / (decimal)100)), MidpointRounding.AwayFromZero);
		public int CALC_CNST_TOTAL_PRICE => (int)((decimal)this.CNST_NET_PRICE + this.CALC_CNST_TAX_PRICE);
		public int STUP_NET_PRICE { get; set; }
		public int STUP_TAX_PRICE { get; set; }
		public int CALC_STUP_TAX_PRICE => (int)Math.Round((double)((decimal)this.STUP_NET_PRICE * ((decimal)this.TAX_RATE / (decimal)100)), MidpointRounding.AwayFromZero);
		public int CALC_STUP_TOTAL_PRICE => (int)((decimal)this.STUP_NET_PRICE + this.CALC_STUP_TAX_PRICE);
		public int ASSOCIATE_ID_1 { get; set; }
		public string ASSOCIATE_NAME_1 { get; set; }
		public string WORKER_NAME_1 { get; set; }
		public int NET_PRICE_1 { get; set; }
		public int TAX_PRICE_1 { get; set; }
		public int CALC_ASS1_TAX_PRICE => (int)Math.Round((double)((decimal)this.NET_PRICE_1 * ((decimal)this.TAX_RATE / (decimal)100)), MidpointRounding.AwayFromZero);
		public int CALC_ASS1_TOTAL_PRICE => (int)((decimal)this.NET_PRICE_1 + this.CALC_ASS1_TAX_PRICE);
		public DateTime? PAYMENT_MONTH_1 { get; set; }
		public int ASSOCIATE_ID_2 { get; set; }
		public string ASSOCIATE_NAME_2 { get; set; }
		public string WORKER_NAME_2 { get; set; }
		public int NET_PRICE_2 { get; set; }
		public int TAX_PRICE_2 { get; set; }
		public int CALC_ASS2_TAX_PRICE => (int)Math.Round((double)((decimal)this.NET_PRICE_2 * ((decimal)this.TAX_RATE / (decimal)100)), MidpointRounding.AwayFromZero);
		public int CALC_ASS2_TOTAL_PRICE => (int)((decimal)this.NET_PRICE_2 + this.CALC_ASS2_TAX_PRICE);
		public DateTime? PAYMENT_MONTH_2 { get; set; }
		public int ASSOCIATE_ID_3 { get; set; }
		public string ASSOCIATE_NAME_3 { get; set; }
		public string WORKER_NAME_3 { get; set; }
		public int NET_PRICE_3 { get; set; }
		public int TAX_PRICE_3 { get; set; }
		public int CALC_ASS3_TAX_PRICE => (int)Math.Round((double)((decimal)this.NET_PRICE_3 * ((decimal)this.TAX_RATE / (decimal)100)), MidpointRounding.AwayFromZero);
		public int CALC_ASS3_TOTAL_PRICE => (int)((decimal)this.NET_PRICE_3 + this.CALC_ASS3_TAX_PRICE);
		public DateTime? PAYMENT_MONTH_3 { get; set; }
		public int TAX_RATE { get; set; } = 10;
		public DateTime UPD_TIME { get; set; }
		public string UPD_USER { get; set; }
		public string UPD_NAME { get; set; }
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public RecMV_ORDER_LIST_FOR_EXCEL_P1() { }
		public RecMV_ORDER_LIST_FOR_EXCEL_P1 Copy() => (RecMV_ORDER_LIST_FOR_EXCEL_P1)this.MemberwiseClone();
	}
}
