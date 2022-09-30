using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAMSS.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BAMTS.Internal
{
	public class RecVV_ORDER_LIST_FOR_EXCEL_P1 : RecordBase
	{
		public int STATUS { get; set; }
		public string STATUS_NAME { get; set; }
		[Required(ErrorMessage = "受注番号の期を入力して下さい。")]
		[Range(1, 99, ErrorMessage = "受注番号の期は1～99です。")]
		public int ODR_PERIOD { get; set; }
		[Required(ErrorMessage = "受注番号のカテゴリ名を選択して下さい。")]
		public string ODR_CATEGORY { get; set; }
		[Required(ErrorMessage = "受注番号の月を選択して下さい。")]
		public string ODR_MONTH { get; set; }
		[Required(ErrorMessage = "受注番号のシーケンスを入力して下さい。")]
		[Range(1, 9999, ErrorMessage = "受注番号のシーケンスは1～9999です。")]
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
		[Range(0, 9999, ErrorMessage = "改訂番号は0～9999です。")]
		public int REV_NO { get; set; }
		public DateTime? EST_ISSUE_DATE { get; set; }
		public int CUSTOMER_ID { get; set; }
		public string CUSTOMER_NAME { get; set; }
		[Required(ErrorMessage = "名称を入力して下さい。")]
		[StringLength(256, ErrorMessage = "名称の最大文字数は256です。")]
		public string ODR_NAME { get; set; }
		public DateTime? CNST_START_DATE { get; set; }
		public DateTime? CNST_END_DATE { get; set; }
		public DateTime? OPEN_DATE { get; set; }
		[StringLength(512, ErrorMessage = "備考の最大文字数は512です。")]
		public string NOTE { get; set; }
		[StringLength(16, ErrorMessage = "見積依頼：依頼No.①の最大文字数は16です。")]
		public string ESTREQ_NO_1 { get; set; }
		[StringLength(16, ErrorMessage = "見積依頼：依頼No.②の最大文字数は16です。")]
		public string ESTREQ_NO_2 { get; set; }
		[StringLength(16, ErrorMessage = "見積依頼：製造番号の最大文字数は16です。")]
		public string PRODUCT_NO { get; set; }
		public DateTime? REQ_DATE { get; set; }
		[StringLength(16, ErrorMessage = "FF見積依頼：依頼No.の最大文字数は16です。")]
		public string REQ_NO { get; set; }
		public DateTime? ODR_DATE { get; set; }
		[StringLength(16, ErrorMessage = "FF見積依頼：注文No.の最大文字数は16です。")]
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
		[Required(ErrorMessage = "消費税率を入力して下さい。")]
		public int TAX_RATE { get; set; } = 10;
		public DateTime? UPD_TIME { get; set; } = DateTime.Now;
		public string UPD_USER { get; set; } = "Tool";
		public string UPD_NAME { get; set; }
		public static string CSVHeader
		{
			get 
			{
				var cdl = ",";
				var rdl = "\r\n";
				var sb = new StringBuilder();
				sb.Append($"状態{cdl}");
				sb.Append($"受注名称{cdl}");
				sb.Append($"納品先{cdl}");
				sb.Append($"改訂履歴-再発行日{cdl}");
				sb.Append($"改訂履歴-改訂番号{cdl}");
				sb.Append($"見積書発行日{cdl}");
				sb.Append($"受注番号(期){cdl}");
				sb.Append($"受注番号(種){cdl}");
				sb.Append($"受注番号(月){cdl}");
				sb.Append($"受注番号(番号){cdl}");
				sb.Append($"種類ID{cdl}");
				sb.Append($"種類名{cdl}");
				sb.Append($"受注合計金額{cdl}");
				sb.Append($"受注合計金額(税込){cdl}");
				sb.Append($"施工金額{cdl}");
				sb.Append($"施工金額(税込){cdl}");
				sb.Append($"セットアップ金額{cdl}");
				sb.Append($"セットアップ金額(税込){cdl}");
				sb.Append($"工事期間(自){cdl}");
				sb.Append($"工事期間(至){cdl}");
				sb.Append($"工事期間(OP){cdl}");
				sb.Append($"見積依頼-依頼No1{cdl}");
				sb.Append($"見積依頼-依頼No2{cdl}");
				sb.Append($"見積依頼-製造番号{cdl}");
				sb.Append($"EDI見積依頼-依頼日{cdl}");
				sb.Append($"EDI見積依頼-依頼No{cdl}");
				sb.Append($"EDI注文依頼-注文日{cdl}");
				sb.Append($"EDI注文依頼-注文No{cdl}");
				sb.Append($"検収日{cdl}");
				sb.Append($"検収月{cdl}");
				sb.Append($"入金月{cdl}");
				sb.Append($"EDI回答金額{cdl}");
				sb.Append($"EDI回答金額(税込){cdl}");
				sb.Append($"施工-会社名{cdl}");
				sb.Append($"施工-金額{cdl}");
				sb.Append($"施工-金額(税込){cdl}");
				sb.Append($"施工-請求月{cdl}");
				sb.Append($"セットアップ-会社名{cdl}");
				sb.Append($"セットアップ-金額{cdl}");
				sb.Append($"セットアップ-金額(税込){cdl}");
				sb.Append($"セットアップ-請求月{cdl}");
				sb.Append($"その他-会社名{cdl}");
				sb.Append($"その他-金額{cdl}");
				sb.Append($"その他-金額(税込){cdl}");
				sb.Append($"その他-請求月{cdl}");
				sb.Append($"納品書-提出日{cdl}");
				sb.Append($"納品書-期日{cdl}");
				sb.Append($"完了メール-配信日{cdl}");
				sb.Append($"完了メール-期日{cdl}");
				sb.Append($"完了報告書-発行日{cdl}");
				sb.Append($"完了報告書-期日{cdl}");
				sb.Append($"引渡報告書{cdl}");
				sb.Append($"担当者{cdl}");
				sb.Append($"最終更新-入力者{cdl}");
				sb.Append($"最終更新-日時{cdl}");
				sb.Append($"備考");
				sb.Append($"{rdl}");
				return sb.ToString();
			}
		}
		public string CSVRecord
		{
			get 
			{
				var cdl = ",";
				var rdl = "\r\n";
				var sb = new StringBuilder();
				sb.Append($"{this.STATUS_NAME}{cdl}");
				sb.Append($"{this.ODR_NAME}{cdl}");
				sb.Append($"{this.CUSTOMER_NAME}{cdl}");
				sb.Append($"{this.REV_ISSUE_DATE:yyyy/MM/dd}{cdl}");
				sb.Append($"{this.REV_NO}{cdl}");
				sb.Append($"{this.EST_ISSUE_DATE:yyyy/MM/dd}{cdl}");
				sb.Append($"{this.ODR_PERIOD}{cdl}");
				sb.Append($"{this.ODR_CATEGORY}{cdl}");
				sb.Append($"{this.ODR_MONTH}{cdl}");
				sb.Append($"{this.ODR_SEQ:0000}{cdl}");
				sb.Append($"{this.TYPE}{cdl}");
				sb.Append($"{this.TYPE_NAME}{cdl}");
				sb.Append($"{this.CNST_NET_PRICE + this.STUP_NET_PRICE}{cdl}");
				sb.Append($"{this.CNST_NET_PRICE + this.CALC_CNST_TAX_PRICE + this.STUP_NET_PRICE + this.CALC_STUP_TAX_PRICE}{cdl}");
				sb.Append($"{this.CNST_NET_PRICE}{cdl}");
				sb.Append($"{this.CNST_NET_PRICE + this.CALC_CNST_TAX_PRICE}{cdl}");
				sb.Append($"{this.STUP_NET_PRICE}{cdl}");
				sb.Append($"{this.STUP_NET_PRICE + this.CALC_STUP_TAX_PRICE}{cdl}");
				sb.Append($"{this.CNST_START_DATE:yyyy/MM/dd}{cdl}");
				sb.Append($"{this.CNST_END_DATE:yyyy/MM/dd}{cdl}");
				sb.Append($"{this.OPEN_DATE:yyyy/MM/dd}{cdl}");
				sb.Append($"{this.ESTREQ_NO_1}{cdl}");
				sb.Append($"{this.ESTREQ_NO_2}{cdl}");
				sb.Append($"{this.PRODUCT_NO}{cdl}");
				sb.Append($"{this.REQ_DATE:yyyy/MM/dd}{cdl}");
				sb.Append($"{this.REQ_NO}{cdl}");
				sb.Append($"{this.ODR_DATE:yyyy/MM/dd}{cdl}");
				sb.Append($"{this.ODR_NO}{cdl}");
				sb.Append($"{this.ACCEPT_DATE:yyyy/MM/dd}{cdl}");
				sb.Append($"{this.ACCEPT_MONTH:yyyy/MM}{cdl}");
				sb.Append($"{this.PAYMENT_MONTH:yyyy/MM}{cdl}");
				sb.Append($"{this.ANS_NET_PRICE}{cdl}");
				sb.Append($"{this.ANS_NET_PRICE + this.CALC_ANS_TAX_PRICE}{cdl}");
				sb.Append($"{this.ASSOCIATE_NAME_1}{cdl}");
				sb.Append($"{this.NET_PRICE_1}{cdl}");
				sb.Append($"{this.NET_PRICE_1 + this.CALC_ASS1_TAX_PRICE}{cdl}");
				sb.Append($"{this.PAYMENT_MONTH_1:yyyy/MM}{cdl}");
				sb.Append($"{this.ASSOCIATE_NAME_2}{cdl}");
				sb.Append($"{this.NET_PRICE_2}{cdl}");
				sb.Append($"{this.NET_PRICE_2 + this.CALC_ASS2_TAX_PRICE}{cdl}");
				sb.Append($"{this.PAYMENT_MONTH_2:yyyy/MM}{cdl}");
				sb.Append($"{this.ASSOCIATE_NAME_3}{cdl}");
				sb.Append($"{this.NET_PRICE_3}{cdl}");
				sb.Append($"{this.NET_PRICE_3 + this.CALC_ASS3_TAX_PRICE}{cdl}");
				sb.Append($"{this.PAYMENT_MONTH_3:yyyy/MM}{cdl}");
				sb.Append($"{this.DLV_SUBMIT_DATE:yyyy/MM/dd}{cdl}");
				sb.Append($"{this.DLV_DEADLINE_DATE:yyyy/MM/dd}{cdl}");
				sb.Append($"{this.CMPMAIL_ISSUE_DATE:yyyy/MM/dd}{cdl}");
				sb.Append($"{this.CMPMAIL_DEADLINE_DATE:yyyy/MM/dd}{cdl}");
				sb.Append($"{this.CMPREP_ISSUE_DATE:yyyy/MM/dd}{cdl}");
				sb.Append($"{this.CMPREP_DEADLINE_DATE:yyyy/MM/dd}{cdl}");
				sb.Append($"{this.DLVREP_SUBMIT_DATE:yyyy/MM/dd}{cdl}");
				sb.Append($"{this.CNST_MANAGER_NAME}{cdl}");
				sb.Append($"{(string.IsNullOrEmpty(this.UPD_NAME) ? this.UPD_USER : this.UPD_NAME)}{cdl}");
				if(this.UPD_TIME == null)
				{
					sb.Append($"{cdl}");
				}
				else if (this.UPD_TIME?.Date == DateTime.Now.Date)
				{
					sb.Append($"{this.UPD_TIME:HH:mm:ss}{cdl}");
				}
				else
				{
					sb.Append($"{this.UPD_TIME:yyyy/MM/dd}{cdl}");
				}
				sb.Append($"{this.NOTE}");
				sb.Append($"{rdl}");
				return sb.ToString();
			}
		}
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public RecVV_ORDER_LIST_FOR_EXCEL_P1() { }
		public RecVV_ORDER_LIST_FOR_EXCEL_P1(int taxRate) { this.TAX_RATE = taxRate; }
		public RecVV_ORDER_LIST_FOR_EXCEL_P1 Copy() => (RecVV_ORDER_LIST_FOR_EXCEL_P1)this.MemberwiseClone();
	}
}
