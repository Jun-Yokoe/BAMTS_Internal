using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using BAMSS.Data;

namespace BAMTS.Internal
{
    public class StoredProcessor
    {
        public IsolationLevel TipicalIsolationLevel { get; set; } = IsolationLevel.Snapshot;
        public string ConnectionString { get; set; } = null;
        public int MaxRetryCount { get; set; } = 30;
        public int RetryIntervalMS { get; set; } = 100;
        public StoredProcessor(string connectionString)
        {
            this.ConnectionString = connectionString;
        }
        public List<RecMV_ORDER_LIST_FOR_EXCEL_P1> P_Get_OrderList_ForLegacyExcel(
              bool DEFAULT = true
            , int? ODR_PERIOD = null
            , string ODR_CATEGORY = null
            , string ODR_MONTH = null
            , int? ODR_SEQ = null
            , int? STATUS = null
            , string CNST_MANAGER_ID = null
            , string CUSTOMER_NAME = null
            , string ODR_NAME = null
            , string REQ_DATE_FROM = null
            , string REQ_DATE_TO = null
            , string REQ_NO = null
            , string ODR_DATE_FROM = null
            , string ODR_DATE_TO = null
            , string ODR_NO = null
            , string ACCEPT_DATE_FROM = null
            , string ACCEPT_DATE_TO = null
            , string ACCEPT_MONTH_FROM = null
            , string ACCEPT_MONTH_TO = null
            , string PAYMENT_MONTH_FROM = null
            , string PAYMENT_MONTH_TO = null
            , int? ANS_NET_PRICE_FROM = null
            , int? ANS_NET_PRICE_TO = null
            , string ASSOCIATE_NAME_1 = null
            , int? NET_PRICE_1_FROM = null
            , int? NET_PRICE_1_TO = null
            , string PAYMENT_MONTH_1_FROM = null
            , string PAYMENT_MONTH_1_TO = null
            , string ASSOCIATE_NAME_2 = null
            , int? NET_PRICE_2_FROM = null
            , int? NET_PRICE_2_TO = null
            , string PAYMENT_MONTH_2_FROM = null
            , string PAYMENT_MONTH_2_TO = null
            , string ASSOCIATE_NAME_3 = null
            , int? NET_PRICE_3_FROM = null
            , int? NET_PRICE_3_TO = null
            , string PAYMENT_MONTH_3_FROM = null
            , string PAYMENT_MONTH_3_TO = null
        )
        {
            var result = new List<RecMV_ORDER_LIST_FOR_EXCEL_P1>();
            for (int tryCount = 0; tryCount <= this.MaxRetryCount; tryCount++)
            {
                using (SQLServerAccessMethods db = new SQLServerAccessMethods(this.ConnectionString))
                {
                    db.Open();
                    try
                    {
                        DateTime? dtREQ_DATE_FROM = null;
                        DateTime? dtREQ_DATE_TO = null;
                        DateTime? dtODR_DATE_FROM = null;
                        DateTime? dtODR_DATE_TO = null;
                        DateTime? dtACCEPT_DATE_FROM = null;
                        DateTime? dtACCEPT_DATE_TO = null;
                        DateTime? dtACCEPT_MONTH_FROM = null;
                        DateTime? dtACCEPT_MONTH_TO = null;
                        DateTime? dtPAYMENT_MONTH_FROM = null;
                        DateTime? dtPAYMENT_MONTH_TO = null;
                        DateTime? dtPAYMENT_MONTH_1_FROM = null;
                        DateTime? dtPAYMENT_MONTH_1_TO = null;
                        DateTime? dtPAYMENT_MONTH_2_FROM = null;
                        DateTime? dtPAYMENT_MONTH_2_TO = null;
                        DateTime? dtPAYMENT_MONTH_3_FROM = null;
                        DateTime? dtPAYMENT_MONTH_3_TO = null;
                        if (REQ_DATE_FROM != null)
                        {
                            dtREQ_DATE_FROM = DateTime.Parse(REQ_DATE_FROM).Date;
                        }
                        if (REQ_DATE_TO != null)
                        {
                            dtREQ_DATE_TO = DateTime.Parse(REQ_DATE_TO).Date.AddDays(1).Date.AddMilliseconds(-1);
                        }
                        if (ODR_DATE_FROM != null)
                        {
                            dtODR_DATE_FROM = DateTime.Parse(ODR_DATE_FROM).Date;
                        }
                        if (ODR_DATE_TO != null)
                        {
                            dtODR_DATE_TO = DateTime.Parse(ODR_DATE_TO).Date.AddDays(1).Date.AddMilliseconds(-1);
                        }
                        if (ACCEPT_DATE_FROM != null)
                        {
                            dtACCEPT_DATE_FROM = DateTime.Parse(ACCEPT_DATE_FROM).Date;
                        }
                        if (ACCEPT_DATE_TO != null)
                        {
                            dtACCEPT_DATE_TO = DateTime.Parse(ACCEPT_DATE_TO).Date.AddDays(1).Date.AddMilliseconds(-1);
                        }
                        if (ACCEPT_MONTH_FROM != null)
                        {
                            var day = DateTime.Parse(ACCEPT_MONTH_FROM).Date;
                            dtACCEPT_MONTH_FROM = new DateTime(day.Year, day.Month, 1);
                        }
                        if (ACCEPT_MONTH_TO != null)
                        {
                            var day = DateTime.Parse(ACCEPT_MONTH_TO).Date;
                            var days = DateTime.DaysInMonth(day.Year, day.Month);
                            dtACCEPT_MONTH_TO = (new DateTime(day.Year, day.Month, days)).AddDays(1).Date.AddMilliseconds(-1);
                        }
                        if (PAYMENT_MONTH_FROM != null)
                        {
                            var day = DateTime.Parse(PAYMENT_MONTH_FROM).Date;
                            dtPAYMENT_MONTH_FROM = new DateTime(day.Year, day.Month, 1);
                        }
                        if (PAYMENT_MONTH_TO != null)
                        {
                            var day = DateTime.Parse(PAYMENT_MONTH_TO).Date;
                            var days = DateTime.DaysInMonth(day.Year, day.Month);
                            dtPAYMENT_MONTH_TO = (new DateTime(day.Year, day.Month, days)).AddDays(1).Date.AddMilliseconds(-1);
                        }
                        if (PAYMENT_MONTH_1_FROM != null)
                        {
                            var day = DateTime.Parse(PAYMENT_MONTH_1_FROM).Date;
                            dtPAYMENT_MONTH_1_FROM = new DateTime(day.Year, day.Month, 1);
                        }
                        if (PAYMENT_MONTH_1_TO != null)
                        {
                            var day = DateTime.Parse(PAYMENT_MONTH_1_TO).Date;
                            var days = DateTime.DaysInMonth(day.Year, day.Month);
                            dtPAYMENT_MONTH_1_TO = (new DateTime(day.Year, day.Month, days)).AddDays(1).Date.AddMilliseconds(-1);
                        }
                        if (PAYMENT_MONTH_2_FROM != null)
                        {
                            var day = DateTime.Parse(PAYMENT_MONTH_2_FROM).Date;
                            dtPAYMENT_MONTH_2_FROM = new DateTime(day.Year, day.Month, 1);
                        }
                        if (PAYMENT_MONTH_2_TO != null)
                        {
                            var day = DateTime.Parse(PAYMENT_MONTH_2_TO).Date;
                            var days = DateTime.DaysInMonth(day.Year, day.Month);
                            dtPAYMENT_MONTH_2_TO = (new DateTime(day.Year, day.Month, days)).AddDays(1).Date.AddMilliseconds(-1);
                        }
                        if (PAYMENT_MONTH_3_FROM != null)
                        {
                            var day = DateTime.Parse(PAYMENT_MONTH_3_FROM).Date;
                            dtPAYMENT_MONTH_3_FROM = new DateTime(day.Year, day.Month, 1);
                        }
                        if (PAYMENT_MONTH_3_TO != null)
                        {
                            var day = DateTime.Parse(PAYMENT_MONTH_3_TO).Date;
                            var days = DateTime.DaysInMonth(day.Year, day.Month);
                            dtPAYMENT_MONTH_3_TO = (new DateTime(day.Year, day.Month, days)).AddDays(1).Date.AddMilliseconds(-1);
                        }
                        SqlCommand cmd = (SqlCommand)db.GetCommand(false);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "P_Get_OrderList_ForLegacyExcel";
                        cmd.Parameters.Add("@ODR_PERIOD", SqlDbType.Int).Value = ODR_PERIOD ?? (object)DBNull.Value;
                        cmd.Parameters.Add("@ODR_CATEGORY", SqlDbType.VarChar).Value = ODR_CATEGORY ?? (object)DBNull.Value;
                        cmd.Parameters.Add("@ODR_MONTH", SqlDbType.VarChar).Value = ODR_MONTH ?? (object)DBNull.Value;
                        cmd.Parameters.Add("@ODR_SEQ", SqlDbType.Int).Value = ODR_SEQ ?? (object)DBNull.Value;
                        cmd.Parameters.Add("@STATUS", SqlDbType.Int).Value = STATUS ?? (object)DBNull.Value;
                        cmd.Parameters.Add("@CNST_MANAGER_ID", SqlDbType.VarChar).Value = CNST_MANAGER_ID ?? (object)DBNull.Value;
                        cmd.Parameters.Add("@CUSTOMER_NAME", SqlDbType.VarChar).Value = CUSTOMER_NAME ?? (object)DBNull.Value;
                        cmd.Parameters.Add("@ODR_NAME", SqlDbType.VarChar).Value = ODR_NAME ?? (object)DBNull.Value;

                        cmd.Parameters.Add("@REQ_DATE_FROM", SqlDbType.DateTime).Value = dtREQ_DATE_FROM ?? (object)DBNull.Value;
                        cmd.Parameters.Add("@REQ_DATE_TO", SqlDbType.DateTime).Value = dtREQ_DATE_TO ?? (object)DBNull.Value;
                        cmd.Parameters.Add("@REQ_NO", SqlDbType.VarChar).Value = REQ_NO ?? (object)DBNull.Value;
                        cmd.Parameters.Add("@ODR_DATE_FROM", SqlDbType.DateTime).Value = dtODR_DATE_FROM ?? (object)DBNull.Value;
                        cmd.Parameters.Add("@ODR_DATE_TO", SqlDbType.DateTime).Value = dtODR_DATE_TO ?? (object)DBNull.Value;
                        cmd.Parameters.Add("@ODR_NO", SqlDbType.VarChar).Value = ODR_NO ?? (object)DBNull.Value;

                        cmd.Parameters.Add("@ACCEPT_DATE_FROM", SqlDbType.DateTime).Value = dtACCEPT_DATE_FROM ?? (object)DBNull.Value;
                        cmd.Parameters.Add("@ACCEPT_DATE_TO", SqlDbType.DateTime).Value = dtACCEPT_DATE_TO ?? (object)DBNull.Value;
                        cmd.Parameters.Add("@ACCEPT_MONTH_FROM", SqlDbType.DateTime).Value = dtACCEPT_MONTH_FROM ?? (object)DBNull.Value;
                        cmd.Parameters.Add("@ACCEPT_MONTH_TO", SqlDbType.DateTime).Value = dtACCEPT_MONTH_TO ?? (object)DBNull.Value;
                        cmd.Parameters.Add("@PAYMENT_MONTH_FROM", SqlDbType.DateTime).Value = dtPAYMENT_MONTH_FROM ?? (object)DBNull.Value;
                        cmd.Parameters.Add("@PAYMENT_MONTH_TO", SqlDbType.DateTime).Value = dtPAYMENT_MONTH_TO ?? (object)DBNull.Value;
                        cmd.Parameters.Add("@ANS_NET_PRICE_FROM", SqlDbType.Int).Value = ANS_NET_PRICE_FROM ?? (object)DBNull.Value;
                        cmd.Parameters.Add("@ANS_NET_PRICE_TO", SqlDbType.Int).Value = ANS_NET_PRICE_TO ?? (object)DBNull.Value;
                        cmd.Parameters.Add("@ASSOCIATE_NAME_1", SqlDbType.VarChar).Value = ASSOCIATE_NAME_1 ?? (object)DBNull.Value;
                        cmd.Parameters.Add("@NET_PRICE_1_FROM", SqlDbType.Int).Value = NET_PRICE_1_FROM ?? (object)DBNull.Value;
                        cmd.Parameters.Add("@NET_PRICE_1_TO", SqlDbType.Int).Value = NET_PRICE_1_TO ?? (object)DBNull.Value;
                        cmd.Parameters.Add("@PAYMENT_MONTH_1_FROM", SqlDbType.DateTime).Value = dtPAYMENT_MONTH_1_FROM ?? (object)DBNull.Value;
                        cmd.Parameters.Add("@PAYMENT_MONTH_1_TO", SqlDbType.DateTime).Value = dtPAYMENT_MONTH_1_TO ?? (object)DBNull.Value;
                        cmd.Parameters.Add("@ASSOCIATE_NAME_2", SqlDbType.VarChar).Value = ASSOCIATE_NAME_2 ?? (object)DBNull.Value;
                        cmd.Parameters.Add("@NET_PRICE_2_FROM", SqlDbType.Int).Value = NET_PRICE_2_FROM ?? (object)DBNull.Value;
                        cmd.Parameters.Add("@NET_PRICE_2_TO", SqlDbType.Int).Value = NET_PRICE_2_TO ?? (object)DBNull.Value;
                        cmd.Parameters.Add("@PAYMENT_MONTH_2_FROM", SqlDbType.DateTime).Value = dtPAYMENT_MONTH_2_FROM ?? (object)DBNull.Value;
                        cmd.Parameters.Add("@PAYMENT_MONTH_2_TO", SqlDbType.DateTime).Value = dtPAYMENT_MONTH_2_TO ?? (object)DBNull.Value;
                        cmd.Parameters.Add("@ASSOCIATE_NAME_3", SqlDbType.VarChar).Value = ASSOCIATE_NAME_3 ?? (object)DBNull.Value;
                        cmd.Parameters.Add("@NET_PRICE_3_FROM", SqlDbType.Int).Value = NET_PRICE_3_FROM ?? (object)DBNull.Value;
                        cmd.Parameters.Add("@NET_PRICE_3_TO", SqlDbType.Int).Value = NET_PRICE_3_TO ?? (object)DBNull.Value;
                        cmd.Parameters.Add("@PAYMENT_MONTH_3_FROM", SqlDbType.DateTime).Value = dtPAYMENT_MONTH_3_FROM ?? (object)DBNull.Value;
                        cmd.Parameters.Add("@PAYMENT_MONTH_3_TO", SqlDbType.DateTime).Value = dtPAYMENT_MONTH_3_TO ?? (object)DBNull.Value;
                        cmd.Parameters.Add("@DEFAULT", SqlDbType.Int).Value = DEFAULT ? 1 : 0;
                        var ds = db.GetDataSet(cmd, false);
                        {
                            var dt = ds.Tables[0];
                            for (var i = 0; i < dt.Rows.Count; i++)
                            {
                                var rec = new RecMV_ORDER_LIST_FOR_EXCEL_P1();
                                rec.BuildRecord(dt.Rows[i]);
                                result.Add(rec);
                            }
                        }
                        break;
                    }
                    catch (Exception ex)
                    {
                        if (tryCount >= this.MaxRetryCount) throw;
                        System.Threading.Thread.Sleep(this.RetryIntervalMS);
                    }
                }
            }
            return result;
        }
        public void P_Delete_OrderItem_ForApp1(int ODR_PERIOD, string ODR_CATEGORY, string ODR_MONTH, int ODR_SEQ)
        {
            for (int tryCount = 0; tryCount <= this.MaxRetryCount; tryCount++)
            {
                using (SQLServerAccessMethods db = new SQLServerAccessMethods(this.ConnectionString))
                {
                    db.Open();
                    db.BeginTrans(this.TipicalIsolationLevel);
                    try
                    {
                        SqlCommand cmd = (SqlCommand)db.GetCommand(true);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "P_Delete_OrderItem_ForApp1";
                        cmd.Parameters.Add("@ODR_PERIOD", SqlDbType.Int).Value = ODR_PERIOD;
                        cmd.Parameters.Add("@ODR_CATEGORY", SqlDbType.VarChar).Value = ODR_CATEGORY ?? "";
                        cmd.Parameters.Add("@ODR_MONTH", SqlDbType.VarChar).Value = ODR_MONTH ?? "";
                        cmd.Parameters.Add("@ODR_SEQ", SqlDbType.Int).Value = ODR_SEQ;
                        var ds = db.GetDataSet(cmd, true);
                        {
                            var dt = ds.Tables[0];
                            var rec = new RecRESULT_MESSAGE();
                            rec.BuildRecord(dt.Rows[0]);
                            if (!string.IsNullOrEmpty(rec.RESULT_MESSAGE))
                            {
                                throw new Exception(rec.RESULT_MESSAGE);
                            }
                            else
                            {
                                db.CommitTrans();
                                return;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        db.RollbackTrans();
                        if (tryCount >= this.MaxRetryCount)
                        {
                            throw;
                        }
                        System.Threading.Thread.Sleep(this.RetryIntervalMS);
                    }
                }
            }
        }
        public List<SelectorItem> P_Get_T_PROGRAM_Parameters1(string PROGRAM, string PROCESS = null, string ITEM_ID = null, string KEY_ID = null)
        {
            var result = new List<SelectorItem>();
            for (int tryCount = 0; tryCount <= this.MaxRetryCount; tryCount++)
            {
                using (SQLServerAccessMethods db = new SQLServerAccessMethods(this.ConnectionString))
                {
                    db.Open();
                    try
                    {
                        SqlCommand cmd = (SqlCommand)db.GetCommand(false);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "P_Get_T_PROGRAM_Parameters1";
                        cmd.Parameters.Add("@PROGRAM", SqlDbType.VarChar).Value = PROGRAM ?? (object)DBNull.Value;
                        cmd.Parameters.Add("@PROCESS", SqlDbType.VarChar).Value = PROCESS ?? (object)DBNull.Value;
                        cmd.Parameters.Add("@ITEM_ID", SqlDbType.VarChar).Value = ITEM_ID ?? (object)DBNull.Value;
                        cmd.Parameters.Add("@KEY_ID", SqlDbType.VarChar).Value = KEY_ID ?? (object)DBNull.Value;
                        var ds = db.GetDataSet(cmd, false);
                        {
                            var dt = ds.Tables[0];
                            for (var i = 0; i < dt.Rows.Count; i++)
                            {
                                var rec = new SelectorItem();
                                rec.BuildRecord(dt.Rows[i]);
                                result.Add(rec);
                            }
                        }
                        break;
                    }
                    catch (Exception ex)
                    {
                        if (tryCount >= this.MaxRetryCount) throw;
                        System.Threading.Thread.Sleep(this.RetryIntervalMS);
                    }
                }
            }
            return result;
        }
        public List<SelectorItem> P_Get_T_STAFF_Selector1()
        {
            var result = new List<SelectorItem>();
            for (int tryCount = 0; tryCount <= this.MaxRetryCount; tryCount++)
            {
                using (SQLServerAccessMethods db = new SQLServerAccessMethods(this.ConnectionString))
                {
                    db.Open();
                    try
                    {
                        SqlCommand cmd = (SqlCommand)db.GetCommand(false);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "P_Get_T_STAFF_Selector1";
                        var ds = db.GetDataSet(cmd, false);
                        {
                            var dt = ds.Tables[0];
                            for (var i = 0; i < dt.Rows.Count; i++)
                            {
                                var rec = new SelectorItem();
                                rec.BuildRecord(dt.Rows[i]);
                                result.Add(rec);
                            }
                        }
                        break;
                    }
                    catch (Exception ex)
                    {
                        if (tryCount >= this.MaxRetryCount) throw;
                        System.Threading.Thread.Sleep(this.RetryIntervalMS);
                    }
                }
            }
            return result;
        }
        public List<SelectorItem> P_Get_T_ASSOCIATE_Selector1()
        {
            var result = new List<SelectorItem>();
            for (int tryCount = 0; tryCount <= this.MaxRetryCount; tryCount++)
            {
                using (SQLServerAccessMethods db = new SQLServerAccessMethods(this.ConnectionString))
                {
                    db.Open();
                    try
                    {
                        SqlCommand cmd = (SqlCommand)db.GetCommand(false);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "P_Get_T_ASSOCIATE_Selector1";
                        var ds = db.GetDataSet(cmd, false);
                        {
                            var dt = ds.Tables[0];
                            for (var i = 0; i < dt.Rows.Count; i++)
                            {
                                var rec = new SelectorItem();
                                rec.BuildRecord(dt.Rows[i]);
                                result.Add(rec);
                            }
                        }
                        break;
                    }
                    catch (Exception ex)
                    {
                        if (tryCount >= this.MaxRetryCount) throw;
                        System.Threading.Thread.Sleep(this.RetryIntervalMS);
                    }
                }
            }
            return result;
        }
        public List<SelectorItem> P_Get_T_CUSTOMER_Selector1()
        {
            var result = new List<SelectorItem>();
            for (int tryCount = 0; tryCount <= this.MaxRetryCount; tryCount++)
            {
                using (SQLServerAccessMethods db = new SQLServerAccessMethods(this.ConnectionString))
                {
                    db.Open();
                    try
                    {
                        SqlCommand cmd = (SqlCommand)db.GetCommand(false);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "P_Get_T_CUSTOMER_Selector1";
                        var ds = db.GetDataSet(cmd, false);
                        {
                            var dt = ds.Tables[0];
                            for (var i = 0; i < dt.Rows.Count; i++)
                            {
                                var rec = new SelectorItem();
                                rec.BuildRecord(dt.Rows[i]);
                                result.Add(rec);
                            }
                        }
                        break;
                    }
                    catch (Exception ex)
                    {
                        if (tryCount >= this.MaxRetryCount) throw;
                        System.Threading.Thread.Sleep(this.RetryIntervalMS);
                    }
                }
            }
            return result;
        }
        public List<SelectorItem> P_Get_ListMonth_Selector1()
        {
            var result = new List<SelectorItem>();
            for (int tryCount = 0; tryCount <= this.MaxRetryCount; tryCount++)
            {
                using (SQLServerAccessMethods db = new SQLServerAccessMethods(this.ConnectionString))
                {
                    db.Open();
                    try
                    {
                        SqlCommand cmd = (SqlCommand)db.GetCommand(false);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "P_Get_ListMonth_Selector1";
                        var ds = db.GetDataSet(cmd, false);
                        {
                            var dt = ds.Tables[0];
                            for (var i = 0; i < dt.Rows.Count; i++)
                            {
                                var rec = new SelectorItem();
                                rec.BuildRecord(dt.Rows[i]);
                                result.Add(rec);
                            }
                        }
                        break;
                    }
                    catch (Exception ex)
                    {
                        if (tryCount >= this.MaxRetryCount) throw;
                        System.Threading.Thread.Sleep(this.RetryIntervalMS);
                    }
                }
            }
            return result;
        }
        public List<SelectorItem> P_Get_ListOrderCategory_Selector1()
        {
            var result = new List<SelectorItem>();
            for (int tryCount = 0; tryCount <= this.MaxRetryCount; tryCount++)
            {
                using (SQLServerAccessMethods db = new SQLServerAccessMethods(this.ConnectionString))
                {
                    db.Open();
                    try
                    {
                        SqlCommand cmd = (SqlCommand)db.GetCommand(false);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "P_Get_ListOrderCategory_Selector1";
                        var ds = db.GetDataSet(cmd, false);
                        {
                            var dt = ds.Tables[0];
                            for (var i = 0; i < dt.Rows.Count; i++)
                            {
                                var rec = new SelectorItem();
                                rec.BuildRecord(dt.Rows[i]);
                                result.Add(rec);
                            }
                        }
                        break;
                    }
                    catch (Exception ex)
                    {
                        if (tryCount >= this.MaxRetryCount) throw;
                        System.Threading.Thread.Sleep(this.RetryIntervalMS);
                    }
                }
            }
            return result;
        }
        public List<SelectorItem> P_Get_ListOrderStatus_Selector1()
        {
            var result = new List<SelectorItem>();
            for (int tryCount = 0; tryCount <= this.MaxRetryCount; tryCount++)
            {
                using (SQLServerAccessMethods db = new SQLServerAccessMethods(this.ConnectionString))
                {
                    db.Open();
                    try
                    {
                        SqlCommand cmd = (SqlCommand)db.GetCommand(false);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "P_Get_ListOrderStatus_Selector1";
                        var ds = db.GetDataSet(cmd, false);
                        {
                            var dt = ds.Tables[0];
                            for (var i = 0; i < dt.Rows.Count; i++)
                            {
                                var rec = new SelectorItem();
                                rec.BuildRecord(dt.Rows[i]);
                                result.Add(rec);
                            }
                        }
                        break;
                    }
                    catch (Exception ex)
                    {
                        if (tryCount >= this.MaxRetryCount) throw;
                        System.Threading.Thread.Sleep(this.RetryIntervalMS);
                    }
                }
            }
            return result;
        }
        public List<SelectorItem> P_Get_ListOrderType_Selector1()
        {
            var result = new List<SelectorItem>();
            for (int tryCount = 0; tryCount <= this.MaxRetryCount; tryCount++)
            {
                using (SQLServerAccessMethods db = new SQLServerAccessMethods(this.ConnectionString))
                {
                    db.Open();
                    try
                    {
                        SqlCommand cmd = (SqlCommand)db.GetCommand(false);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "P_Get_ListOrderType_Selector1";
                        var ds = db.GetDataSet(cmd, false);
                        {
                            var dt = ds.Tables[0];
                            for (var i = 0; i < dt.Rows.Count; i++)
                            {
                                var rec = new SelectorItem();
                                rec.BuildRecord(dt.Rows[i]);
                                result.Add(rec);
                            }
                        }
                        break;
                    }
                    catch (Exception ex)
                    {
                        if (tryCount >= this.MaxRetryCount) throw;
                        System.Threading.Thread.Sleep(this.RetryIntervalMS);
                    }
                }
            }
            return result;
        }
        public List<SelectorItem> P_Get_NextOrderNoItems()
        {
            var result = new List<SelectorItem>();
            for (int tryCount = 0; tryCount <= this.MaxRetryCount; tryCount++)
            {
                using (SQLServerAccessMethods db = new SQLServerAccessMethods(this.ConnectionString))
                {
                    db.Open();
                    try
                    {
                        SqlCommand cmd = (SqlCommand)db.GetCommand(false);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "P_Get_NextOrderNoItems";
                        var ds = db.GetDataSet(cmd, false);
                        {
                            var dt = ds.Tables[0];
                            for (var i = 0; i < dt.Rows.Count; i++)
                            {
                                var rec = new SelectorItem();
                                rec.BuildRecord(dt.Rows[i]);
                                result.Add(rec);
                            }
                        }
                        break;
                    }
                    catch (Exception ex)
                    {
                        if (tryCount >= this.MaxRetryCount) throw;
                        System.Threading.Thread.Sleep(this.RetryIntervalMS);
                    }
                }
            }
            return result;
        }
        public SetLOGON_USER_INFO P_Get_LoginUserInfo(string STAFF_ID)
        {
            var result = new SetLOGON_USER_INFO();
            for (int tryCount = 0; tryCount <= this.MaxRetryCount; tryCount++)
            {
                using (SQLServerAccessMethods db = new SQLServerAccessMethods(this.ConnectionString))
                {
                    db.Open();
                    try
                    {
                        SqlCommand cmd = (SqlCommand)db.GetCommand(false);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "P_Get_LoginUserInfo";
                        cmd.Parameters.Add("@STAFF_ID", SqlDbType.VarChar).Value = STAFF_ID ?? (object)DBNull.Value;
                        var ds = db.GetDataSet(cmd, false);
                        {
                            {
                                var dt = ds.Tables[0];
                                if (dt.Rows.Count > 0)
                                {
                                    var rec = new RecLOGON_USER_PRIMARY();
                                    rec.BuildRecord(dt.Rows[0]);
                                    result.USER_PRIMARY_INFO = rec;
                                }
                            }
                            {
                                var dt = ds.Tables[1];
                                for (var i = 0; i < dt.Rows.Count; i++)
                                {
                                    var rec = new RecLOGON_USER_AUTHORITY();
                                    rec.BuildRecord(dt.Rows[i]);
                                    result.USER_AUTHORITY.Add(rec);
                                }
                            }
                        }
                        break;
                    }
                    catch (Exception ex)
                    {
                        if (tryCount >= this.MaxRetryCount) throw;
                        System.Threading.Thread.Sleep(this.RetryIntervalMS);
                    }
                }
            }
            return result;
        }
        public List<RecLOGON_USER_PRIMARY> P_Get_AllUserInfo()
        {
            var result = new List<RecLOGON_USER_PRIMARY>();
            for (int tryCount = 0; tryCount <= this.MaxRetryCount; tryCount++)
            {
                using (SQLServerAccessMethods db = new SQLServerAccessMethods(this.ConnectionString))
                {
                    db.Open();
                    try
                    {
                        SqlCommand cmd = (SqlCommand)db.GetCommand(false);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "P_Get_LoginUserInfo";
                        cmd.Parameters.Add("@STAFF_ID", SqlDbType.VarChar).Value = (object)DBNull.Value;
                        var ds = db.GetDataSet(cmd, false);
                        {
                            var dt = ds.Tables[0];
                            for (var i = 0; i < dt.Rows.Count; i++)
                            {
                                var rec = new RecLOGON_USER_PRIMARY();
                                rec.BuildRecord(dt.Rows[i]);
                                result.Add(rec);
                            }
                        }
                        break;
                    }
                    catch (Exception ex)
                    {
                        if (tryCount >= this.MaxRetryCount) throw;
                        System.Threading.Thread.Sleep(this.RetryIntervalMS);
                    }
                }
            }
            return result;
        }
        public void P_Import_OrderList_ForLegacyExcel(string userID, IList<RecMV_ORDER_LIST_FOR_EXCEL_P1> list)
        {
            int maxRetryCount = 0;  // this.MaxRetryCount;
            for (int tryCount = 0; tryCount <= maxRetryCount; tryCount++)
            {
                using (SQLServerAccessMethods db = new SQLServerAccessMethods(this.ConnectionString))
                {
                    db.Open();
                    db.BeginTrans(this.TipicalIsolationLevel);
                    try
                    {
                        SqlCommand cmd = (SqlCommand)db.GetCommand(true);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "P_Import_OrderList_ForLegacyExcel";
                        cmd.Parameters.Add("@userID", SqlDbType.VarChar).Value = userID ?? (object)DBNull.Value;
                        cmd.Parameters.Add("@recList", SqlDbType.Structured);
                        cmd.Parameters["@recList"].Direction = ParameterDirection.Input;
                        cmd.Parameters["@recList"].TypeName = "S_Import_OrderList_ForLegacyExcel";
                        cmd.Parameters["@recList"].Value = list.BuildDataTable();
                        var ds = db.GetDataSet(cmd, true);
                        {
                            var dt = ds.Tables[0];
                            var rec = new RecRESULT_MESSAGE();
                            rec.BuildRecord(dt.Rows[0]);
                            if (!string.IsNullOrEmpty(rec.RESULT_MESSAGE))
                            {
                                throw new Exception(rec.RESULT_MESSAGE);
                            }
                            else
                            {
                                db.CommitTrans();
                                return;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        db.RollbackTrans();
                        if (tryCount >= maxRetryCount)
                        {
                            throw;
                        }
                        System.Threading.Thread.Sleep(this.RetryIntervalMS);
                    }
                }
            }
        }
        public void P_Import_OrderList_ForAppEdit1(int UpdateMode, int ForceWrite, IList<RecMV_ORDER_LIST_FOR_EXCEL_P1> list)
        {
            for (int tryCount = 0; tryCount <= this.MaxRetryCount; tryCount++)
            {
                using (SQLServerAccessMethods db = new SQLServerAccessMethods(this.ConnectionString))
                {
                    db.Open();
                    db.BeginTrans(this.TipicalIsolationLevel);
                    try
                    {
                        SqlCommand cmd = (SqlCommand)db.GetCommand(true);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "P_Import_OrderList_ForAppEdit1";
                        cmd.Parameters.Add("@UpdateMode", SqlDbType.Int).Value = UpdateMode;
                        cmd.Parameters.Add("@ForceWrite", SqlDbType.Int).Value = ForceWrite;
                        cmd.Parameters.Add("@recList", SqlDbType.Structured);
                        cmd.Parameters["@recList"].Direction = ParameterDirection.Input;
                        cmd.Parameters["@recList"].TypeName = "S_Import_OrderList_ForLegacyExcel";
                        cmd.Parameters["@recList"].Value = list.BuildDataTable();
                        var ds = db.GetDataSet(cmd, true);
                        {
                            var dt = ds.Tables[0];
                            var rec = new RecRESULT_MESSAGE();
                            rec.BuildRecord(dt.Rows[0]);
                            if (!string.IsNullOrEmpty(rec.RESULT_MESSAGE))
                            {
                                throw new Exception(rec.RESULT_MESSAGE);
                            }
                            else
                            {
                                db.CommitTrans();
                                return;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        db.RollbackTrans();
                        if (tryCount >= this.MaxRetryCount)
                        {
                            throw;
                        }
                        System.Threading.Thread.Sleep(this.RetryIntervalMS);
                    }
                }
            }
        }
        public List<RecEmployeeAll> P_Get_T_EMPLOYEE_ALL()
        {
            var result = new List<RecEmployeeAll>();
            for (int tryCount = 0; tryCount <= this.MaxRetryCount; tryCount++)
            {
                using (SQLServerAccessMethods db = new SQLServerAccessMethods(this.ConnectionString))
                {
                    db.Open();
                    try
                    {
                        SqlCommand cmd = (SqlCommand)db.GetCommand(false);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "P_Get_X_EMPLOYEE_ALL";
                        //cmd.Parameters.Add("@PLANT_CD", SqlDbType.VarChar).Value = PLANT_CD ?? (object)DBNull.Value;
                        var ds = db.GetDataSet(cmd, false);
                        {
                            var dt = ds.Tables[0];
                            for (var i = 0; i < dt.Rows.Count; i++)
                            {
                                var rec = new RecEmployeeAll();
                                rec.BuildRecord(dt.Rows[i]);
                                result.Add(rec);
                            }
                        }
                        break;
                    }
                    catch (Exception ex)
                    {
                        if (tryCount >= this.MaxRetryCount) throw;
                        System.Threading.Thread.Sleep(this.RetryIntervalMS);
                    }
                }
            }
            return result;
        }
        public List<RecEmployeeAll> SQL_Get_T_EMPLOYEE_ALL()
        {
            var result = new List<RecEmployeeAll>();
            for (int tryCount = 0; tryCount <= this.MaxRetryCount; tryCount++)
            {
                using (SQLServerAccessMethods db = new SQLServerAccessMethods(this.ConnectionString))
                {
                    db.Open();
                    try
                    {
                        var SQL = new StringBuilder("select EMP_ID ,EMP_NAME ,BIRTH_DATE ,JOINED_DATE ,USED_PAID_HOLIDAY ,GENDER ,CELLPHONE_NO ,CELLPHONE_MAIL_ADDRESS ,PC_MAIL_ADDRESS ,PC_MAIL_PASSWORD ,NOTE from X_EMPLOYEE");
                        var cmd = (SqlCommand)db.GetCommand(false);
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = SQL.ToString();
                        //cmd.Parameters.Add("@PLANT_CD", SqlDbType.VarChar).Value = PLANT_CD ?? (object)DBNull.Value;
                        var ds = db.GetDataSet(cmd, false);
                        {
                            var dt = ds.Tables[0];
                            for (var i = 0; i < dt.Rows.Count; i++)
                            {
                                var rec = new RecEmployeeAll();
                                rec.BuildRecord(dt.Rows[i]);
                                result.Add(rec);
                            }
                        }
                        break;
                    }
                    catch (Exception ex)
                    {
                        if (tryCount >= this.MaxRetryCount) throw;
                        System.Threading.Thread.Sleep(this.RetryIntervalMS);
                    }
                }
            }
            return result;
        }
        public void P_Replace_T_EMPLOYEE_ALL(IList<RecEmployeeAll> list)
        {
            for (int tryCount = 0; tryCount <= this.MaxRetryCount; tryCount++)
            {
                using (SQLServerAccessMethods db = new SQLServerAccessMethods(this.ConnectionString))
                {
                    db.Open();
                    db.BeginTrans(this.TipicalIsolationLevel);
                    try
                    {
                        SqlCommand cmd = (SqlCommand)db.GetCommand(true);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "P_Replace_X_EMPLOYEE_ALL";
                        cmd.Parameters.Add("@recList", SqlDbType.Structured);
                        cmd.Parameters["@recList"].Direction = ParameterDirection.Input;
                        cmd.Parameters["@recList"].TypeName = "S_T_EMPLOYEE";
                        var test = list.BuildDataTable();
                        cmd.Parameters["@recList"].Value = list.BuildDataTable();
                        var ds = db.GetDataSet(cmd, true);
                        {
                            var dt = ds.Tables[0];
                            var rec = new RecRESULT_MESSAGE();
                            rec.BuildRecord(dt.Rows[0]);
                            if (!string.IsNullOrEmpty(rec.RESULT_MESSAGE))
                            {
                                throw new Exception(rec.RESULT_MESSAGE);
                            }
                            else
                            {
                                db.CommitTrans();
                                return;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        db.RollbackTrans();
                        if (tryCount >= this.MaxRetryCount)
                        {
                            throw;
                        }
                        System.Threading.Thread.Sleep(this.RetryIntervalMS);
                    }
                }
            }
        }
        public RecT_LOCK_MANAGE_EX1 P_GET_T_LOCK_MANAGE(string LOCK_ID)
        {
            var result = new RecT_LOCK_MANAGE_EX1();
            for (int tryCount = 0; tryCount <= this.MaxRetryCount; tryCount++)
            {
                using (SQLServerAccessMethods db = new SQLServerAccessMethods(this.ConnectionString))
                {
                    db.Open();
                    try
                    {
                        SqlCommand cmd = (SqlCommand)db.GetCommand(false);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "P_GET_T_LOCK_MANAGE";
                        cmd.Parameters.Add("@LOCK_ID", SqlDbType.VarChar).Value = (LOCK_ID == null) ? (object)DBNull.Value : LOCK_ID;
                        var ds = db.GetDataSet(cmd, false);
                        {
                            var dt = ds.Tables[1];
                            var rec = new RecRESULT_MESSAGE();
                            rec.BuildRecord(dt.Rows[0]);
                            if (!string.IsNullOrEmpty(rec.RESULT_MESSAGE))
                            {
                                throw new Exception(rec.RESULT_MESSAGE);
                            }
                        }
                        {
                            var dt = ds.Tables[0];
                            result.BuildRecord(dt.Rows[0]);
                        }
                        break;
                    }
                    catch (Exception ex)
                    {
                        if (tryCount >= this.MaxRetryCount) throw;
                        System.Threading.Thread.Sleep(this.RetryIntervalMS);
                    }
                }
            }
            return result;
        }
        public RecLOCK_MANAGE_RESULT P_LOCK_T_LOCK_MANAGE(string LOCK_ID, string USER_ID, string MESSAGE)
        {
            var result = new RecLOCK_MANAGE_RESULT();
            for (int tryCount = 0; tryCount <= this.MaxRetryCount; tryCount++)
            {
                using (SQLServerAccessMethods db = new SQLServerAccessMethods(this.ConnectionString))
                {
                    db.Open();
                    db.BeginTrans(this.TipicalIsolationLevel);
                    try
                    {
                        SqlCommand cmd = (SqlCommand)db.GetCommand(true);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "P_LOCK_T_LOCK_MANAGE";
                        cmd.Parameters.Add("@LOCK_ID", SqlDbType.VarChar).Value = (LOCK_ID == null) ? (object)DBNull.Value : LOCK_ID;
                        cmd.Parameters.Add("@USER_ID", SqlDbType.VarChar).Value = (USER_ID == null) ? (object)DBNull.Value : USER_ID;
                        cmd.Parameters.Add("@MESSAGE", SqlDbType.VarChar).Value = (MESSAGE == null) ? (object)DBNull.Value : MESSAGE;
                        var ds = db.GetDataSet(cmd, true);
                        {
                            var dt = ds.Tables[1];
                            var rec = new RecRESULT_MESSAGE();
                            rec.BuildRecord(dt.Rows[0]);
                            if (!string.IsNullOrEmpty(rec.RESULT_MESSAGE))
                            {
                                throw new Exception(rec.RESULT_MESSAGE);
                            }
                            else
                            {
                                db.CommitTrans();
                            }
                        }
                        {
                            var dt = ds.Tables[0];
                            result.BuildRecord(dt.Rows[0]);
                        }
                    }
                    catch (Exception ex)
                    {
                        db.RollbackTrans();
                        if (tryCount >= this.MaxRetryCount)
                        {
                            throw;
                        }
                        System.Threading.Thread.Sleep(this.RetryIntervalMS);
                    }
                }
            }
            return result;
        }
        public RecLOCK_MANAGE_RESULT P_UNLOCK_T_LOCK_MANAGE(string LOCK_ID, string USER_ID)
        {
            var result = new RecLOCK_MANAGE_RESULT();
            for (int tryCount = 0; tryCount <= this.MaxRetryCount; tryCount++)
            {
                using (SQLServerAccessMethods db = new SQLServerAccessMethods(this.ConnectionString))
                {
                    db.Open();
                    db.BeginTrans(this.TipicalIsolationLevel);
                    try
                    {
                        SqlCommand cmd = (SqlCommand)db.GetCommand(true);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "P_UNLOCK_T_LOCK_MANAGE";
                        cmd.Parameters.Add("@LOCK_ID", SqlDbType.VarChar).Value = (LOCK_ID == null) ? (object)DBNull.Value : LOCK_ID;
                        cmd.Parameters.Add("@USER_ID", SqlDbType.VarChar).Value = (USER_ID == null) ? (object)DBNull.Value : USER_ID;
                        var ds = db.GetDataSet(cmd, true);
                        {
                            var dt = ds.Tables[1];
                            var rec = new RecRESULT_MESSAGE();
                            rec.BuildRecord(dt.Rows[0]);
                            if (!string.IsNullOrEmpty(rec.RESULT_MESSAGE))
                            {
                                throw new Exception(rec.RESULT_MESSAGE);
                            }
                            else
                            {
                                db.CommitTrans();
                            }
                        }
                        {
                            var dt = ds.Tables[0];
                            result.BuildRecord(dt.Rows[0]);
                        }
                    }
                    catch (Exception ex)
                    {
                        db.RollbackTrans();
                        if (tryCount >= this.MaxRetryCount)
                        {
                            throw;
                        }
                        System.Threading.Thread.Sleep(this.RetryIntervalMS);
                    }
                }
            }
            return result;
        }
    }
}
