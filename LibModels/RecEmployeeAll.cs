using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAMSS.Data;
using System.ComponentModel;

namespace BAMTS.Internal
{
    public class RecEmployeeAll : RecordBase
    {
        [DisplayName("社員ID")]
        public string EMP_ID { get; set; }
        [DisplayName("社員名")]
        public string EMP_NAME { get; set; }
        [DisplayName("生年月日")]
        public DateTime BIRTH_DATE { get; set; }
        [DisplayName("入社年月日")]
        public DateTime JOINED_DATE { get; set; }
        [DisplayName("有給消費日数")]
        public int USED_PAID_HOLIDAY { get; set; }
        [DisplayName("性別")]
        public int GENDER { get; set; }
        [DisplayName("携帯電話番号")]
        public string CELLPHONE_NO { get; set; }
        [DisplayName("携帯電話メールアドレス")]
        public string CELLPHONE_MAIL_ADDRESS { get; set; }
        [DisplayName("PCメールアドレス")]
        public string PC_MAIL_ADDRESS { get; set; }
        [DisplayName("PCメールパスワード")]
        public string PC_MAIL_PASSWORD { get; set; }
        [DisplayName("備考")]
        public string NOTE { get; set; }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public RecEmployeeAll() { }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="list">レコード項目リスト</param>
        public RecEmployeeAll(IList<string> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                switch (i)
                {
                    case 0:
                        this.EMP_ID = list[i];
                        break;
                    case 1:
                        this.EMP_NAME = list[i];
                        break;
                    case 2:
                        this.BIRTH_DATE = DateTime.Parse(list[i]);
                        break;
                    case 3:
                        this.JOINED_DATE = DateTime.Parse(list[i]);
                        break;
                    case 4:
                        this.USED_PAID_HOLIDAY = int.Parse(list[i]);
                        break;
                    case 5:
                        this.GENDER = int.Parse(list[i]);
                        break;
                    case 6:
                        this.CELLPHONE_NO = list[i];
                        break;
                    case 7:
                        this.CELLPHONE_MAIL_ADDRESS = list[i];
                        break;
                    case 8:
                        this.PC_MAIL_ADDRESS = list[i];
                        break;
                    case 9:
                        this.PC_MAIL_PASSWORD = list[i];
                        break;
                    case 10:
                        this.NOTE = list[i];
                        break;
                    default:
                        return;
                }
            }
        }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="list">レコード項目リスト</param>
        public RecEmployeeAll(string[] list)
        {
            for (int i = 0; i < list.Count(); i++)
            {
                switch (i)
                {
                    case 0:
                        this.EMP_ID = list[i];
                        break;
                    case 1:
                        this.EMP_NAME = list[i];
                        break;
                    case 2:
                        this.BIRTH_DATE = DateTime.Parse(list[i]);
                        break;
                    case 3:
                        this.JOINED_DATE = DateTime.Parse(list[i]);
                        break;
                    case 4:
                        this.USED_PAID_HOLIDAY = int.Parse(list[i]);
                        break;
                    case 5:
                        this.GENDER = int.Parse(list[i]);
                        break;
                    case 6:
                        this.CELLPHONE_NO = list[i];
                        break;
                    case 7:
                        this.CELLPHONE_MAIL_ADDRESS = list[i];
                        break;
                    case 8:
                        this.PC_MAIL_ADDRESS = list[i];
                        break;
                    case 9:
                        this.PC_MAIL_PASSWORD = list[i];
                        break;
                    case 10:
                        this.NOTE = list[i];
                        break;
                    default:
                        return;
                }
            }
        }
        /// <summary>
        /// CSVヘッダレコード文字列取得(末尾改行コード付き)
        /// </summary>
        /// <returns></returns>
        public static string GetCSVHeader() => "\"社員ID\",\"社員名\",\"生年月日\",\"入社年月日\",\"有給消費日数\",\"性別\",\"携帯電話番号\",\"携帯電話メールアドレス\",\"PCメールアドレス\",\"PCメールパスワード\",\"備考\"\r\n";
        /// <summary>
        /// CSVデータレコード文字列取得(末尾改行コード付き)
        /// </summary>
        /// <returns></returns>
        public string GetCSVRecord() => $"\"{this.EMP_ID}\",\"{this.EMP_NAME}\",\"{this.BIRTH_DATE:yyyy/MM/dd}\",\"{this.JOINED_DATE:yyyy/MM/dd}\",\"{this.USED_PAID_HOLIDAY}\",\"{(int)this.GENDER}\",\"{this.CELLPHONE_NO}\",\"{this.CELLPHONE_MAIL_ADDRESS}\",\"{this.PC_MAIL_ADDRESS}\",\"{this.PC_MAIL_PASSWORD}\",\"{this.NOTE}\"\r\n";
    }
}
