using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;

namespace BAMSS.Data
{
    /// <summary>
    /// データベースレコードテーブルの基底クラス
    /// </summary>
    public class RecordBase
    {
        /// <summary>
        /// DataTable初期化処理
        /// </summary>
        /// <returns></returns>
        public DataTable InitializeDataTable()
        {
            var dt = new DataTable();
            var members = this.GetType().GetMembers(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            foreach (MemberInfo m in members.Where(c => c.MemberType == MemberTypes.Property)) 
            {
                dt.Columns.Add(m.Name, Type.GetType(this.NullableConvert(this.GetType().GetProperty(m.Name).PropertyType.FullName))); 
            }
            return dt;
        }
        /// <summary>
        /// DataSetがNullableに対応していないので、Nullable型を非Nullalbe型に変換する関数
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private string NullableConvert(string value)
        {
            if (value.Contains("System.Nullable")) 
            {   //null許容型への対応
                //if (value.Contains(typeof(short).ToString())) return typeof(short).ToString();
                //if (value.Contains(typeof(ushort).ToString())) return typeof(ushort).ToString();
                //if (value.Contains(typeof(int).ToString())) return typeof(int).ToString();
                //if (value.Contains(typeof(uint).ToString())) return typeof(uint).ToString();
                //if (value.Contains(typeof(long).ToString())) return typeof(long).ToString();
                //if (value.Contains(typeof(ulong).ToString())) return typeof(ulong).ToString();
                if (value.Contains(typeof(System.DateTime).ToString())) return typeof(System.DateTime).ToString();
                if (value.Contains(typeof(System.Boolean).ToString())) return typeof(System.Boolean).ToString();
                if (value.Contains(typeof(System.Char).ToString())) return typeof(System.Char).ToString();
                if (value.Contains(typeof(System.Byte).ToString())) return typeof(System.Byte).ToString();
                if (value.Contains(typeof(System.SByte).ToString())) return typeof(System.SByte).ToString();
                if (value.Contains(typeof(System.Int16).ToString())) return typeof(System.Int16).ToString();
                if (value.Contains(typeof(System.UInt16).ToString())) return typeof(System.UInt16).ToString();
                if (value.Contains(typeof(System.Int32).ToString())) return typeof(System.Int32).ToString();
                if (value.Contains(typeof(System.UInt32).ToString())) return typeof(System.UInt32).ToString();
                if (value.Contains(typeof(System.Int64).ToString())) return typeof(System.Int64).ToString();
                if (value.Contains(typeof(System.UInt64).ToString())) return typeof(System.UInt64).ToString();
                if (value.Contains(typeof(System.Single).ToString())) return typeof(System.Single).ToString();
                if (value.Contains(typeof(System.Double).ToString())) return typeof(System.Double).ToString();
                if (value.Contains(typeof(System.Decimal).ToString())) return typeof(System.Decimal).ToString();
            }
            return value;
        }

        //public void SetField(string fieldName, string value, Type dataType, bool emptyIsNullForText, object nullValue = null)
        //{
        //    var property = this.GetType().GetProperty(fieldName);
        //    if (property.CanWrite)
        //    {   //書込可能プロパテェのみ処理
        //        //文字以外の場合のみ、空文字の扱い変換：emptyIsNullなら、空文字をNullに変換する。
        //        //実際のNULL値(nullValue)のセットは最後。
        //        if ((dataType == typeof(char)) || (dataType == typeof(string)))
        //        {
        //            if ((emptyIsNullForText) && (value != null) && (value.Trim() == "")) value = null;
        //        }
        //        else
        //        {
        //            if ((value != null) && (value.Trim() == "")) value = null;
        //        }
        //        //数値
        //        if ((dataType == typeof(ushort)) || ((dataType == typeof(ushort?)) && (value != null)))
        //        {
        //            property.SetValue(this, ushort.Parse(value), null);
        //            return;
        //        }
        //        if ((dataType == typeof(short)) || ((dataType == typeof(short?)) && (value != null)))
        //        {
        //            property.SetValue(this, short.Parse(value), null);
        //            return;
        //        }
        //        if ((dataType == typeof(uint)) || ((dataType == typeof(uint?)) && (value != null)))
        //        {
        //            property.SetValue(this, uint.Parse(value), null);
        //            return;
        //        }
        //        if ((dataType == typeof(int)) || ((dataType == typeof(int?)) && (value != null)))
        //        {
        //            property.SetValue(this, int.Parse(value), null);
        //            return;
        //        }
        //        if ((dataType == typeof(ulong)) || ((dataType == typeof(ulong?)) && (value != null)))
        //        {
        //            property.SetValue(this, ulong.Parse(value), null);
        //            return;
        //        }
        //        if ((dataType == typeof(long)) || ((dataType == typeof(long?)) && (value != null)))
        //        {
        //            property.SetValue(this, long.Parse(value), null);
        //            return;
        //        }
        //        if ((dataType == typeof(float)) || ((dataType == typeof(float?)) && (value != null)))
        //        {
        //            property.SetValue(this, float.Parse(value), null);
        //            return;
        //        }
        //        if ((dataType == typeof(double)) || ((dataType == typeof(double?)) && (value != null)))
        //        {
        //            property.SetValue(this, double.Parse(value), null);
        //            return;
        //        }
        //        if ((dataType == typeof(decimal)) || ((dataType == typeof(decimal?)) && (value != null)))
        //        {
        //            property.SetValue(this, decimal.Parse(value), null);
        //            return;
        //        }
        //        //日付
        //        if ((dataType == typeof(DateTime)) || ((dataType == typeof(DateTime?)) && (value != null)))
        //        {
        //            property.SetValue(this, DateTime.Parse(value), null);
        //            return;
        //        }
        //        if (dataType == typeof(char))
        //        {
        //            if (value == null)
        //            {
        //                property.SetValue(this, nullValue, null);
        //            }
        //            else
        //            {
        //                property.SetValue(this, value.ToString(), null);
        //            }
        //            return;
        //        }
        //        else if (dataType == typeof(string))
        //        {
        //            if (value == null)
        //            {
        //                property.SetValue(this, nullValue, null);
        //            }
        //            else
        //            {
        //                property.SetValue(this, value, null);
        //            }
        //            return;
        //        }
        //        else if (value == null)
        //        {
        //            property.SetValue(this, nullValue, null);
        //            return;
        //        }
        //        throw new NotImplementedException(string.Format("型変換ができませんでした、この型への対応が未対応の場合、本ライブラリにて対応する必要があります。型名：[{0}]", dataType.FullName));
        //    }
        //}

        #region DataRow
        /// <summary>
        /// DataTableに自レコードをDataRow化して追加する
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public DataRow ToDataRow(DataTable dt)
        {
            var dr = dt.NewRow();
            var members = this.GetType().GetMembers();
            foreach (MemberInfo m in members.Where(c => c.MemberType == MemberTypes.Property))
            {   //処理対象＝プロパテェだけ
                try
                {
                    var property = this.GetType().GetProperty(m.Name);
                    if (property.CanRead)
                    {   //読込可能プロパテェのみ処理
                        var value = property.GetValue(this, null);
                        if (value == null)
                            dr[m.Name] = DBNull.Value;
                        else
                            dr[m.Name] = value;
                    }
                }
                catch { /*ドンマイエラー*/ }
            }
            dt.Rows.Add(dr);
            return dr;
        }
        /// <summary>
        /// DataRowから自レコードを生成する
        /// </summary>
        /// <param name="value"></param>
        public void BuildRecord(DataRow value)
        {
            var members = this.GetType().GetMembers();
            foreach (MemberInfo m in members.Where(c => c.MemberType == MemberTypes.Property))
            {   //処理対象＝プロパテェだけ
                try
                {
                    var property = this.GetType().GetProperty(m.Name);
                    if (property.CanWrite)
                    {   //書込可能プロパテェのみ処理
                        if (value[m.Name] == DBNull.Value)
                            property.SetValue(this, null, null);
                        else
                            property.SetValue(this, value[m.Name], null);
                    }
                }
                catch(Exception ex) { /*ドンマイエラー*/ var msg = ex.Message; }
            }
        }
        #endregion

        #region CSV
        /// <summary>
        /// 自レコードからCSV形式レコード文字列を出力する
        /// </summary>
        /// <param name="delimiter">区切り文字</param>
        /// <param name="terminator">レコード終端文字(列)</param>
        /// <returns></returns>
        public string ToCSV(char delimiter = ',', string terminator = "\r\n")
        {
            var members = this.GetType().GetMembers();
            var csv = string.Empty;
            foreach (MemberInfo m in members.Where(c => c.MemberType == MemberTypes.Property))
            {   //処理対象＝プロパテェだけ
                try
                {
                    var property = this.GetType().GetProperty(m.Name);
                    object outValue = null;
                    //MOD 2021/11/29 BAMTS Jun.Yokoe (Start)
                    //csv += string.Format("{0}{1}", (csv == string.Empty) ? string.Empty : delimiter.ToString(), property.GetValue(outValue));
                    csv += string.Format("{0}{1}", (csv == string.Empty) ? string.Empty : delimiter.ToString(), property.GetValue(this));
                    //MOD 2021/11/29 BAMTS Jun.Yokoe ( End )
                }
                catch { /*ドンマイエラー*/ }
            }
            return string.Format("{0}{1}", csv, terminator);
        }
        /// <summary>
        /// CSV形式レコード文字列から自レコードを生成する
        /// </summary>
        /// <param name="value">区切り形式データ</param>
        /// <param name="delimiter">区切り文字</param>
        public void BuildRecord(string value, char delimiter = ',')
        {
            var members = this.GetType().GetMembers();
            var items = value.Split(delimiter);
            var index = 0;
            foreach (MemberInfo m in members.Where(c => c.MemberType == MemberTypes.Property))
            {   //処理対象＝プロパテェだけ
                try
                {
                    var property = this.GetType().GetProperty(m.Name);
                    if (property.CanWrite)
                    {   //書込可能プロパテェのみ処理
                        property.SetValue(this, items[index], null);
                    }
                    index++;
                    if (items.Count() > index) break;
                }
                catch { /*ドンマイエラー*/ }
            }
        }
        #endregion
    }
}
