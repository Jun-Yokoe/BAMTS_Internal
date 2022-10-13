using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using BAMTS.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace BAMTS_Internal_WebAPIService.Controllers
{
    [ApiController]
    public class DatabaseAccessController : ControllerBase
    {
        private static string _TARGET_INFO_TEXT = Common.TARGET_DATABASE_CONNECTION_SETTINGS;
        private StoredProcessor _storedProcessor;
        public DatabaseAccessController() => this._storedProcessor = new StoredProcessor(DatabaseAccessController._TARGET_INFO_TEXT);
        [HttpGet]
        //[Route("api/DatabaseAccessController/P_Get_OrderList_ForLegacyExcel/Search/{ODR_PERIOD}/{ODR_CATEGORY}/{ODR_MONTH}/{ODR_SEQ}/{STATUS}/{CNST_MANAGER_ID}/{CUSTOMER_NAME}/{ODR_NAME}/{ACCEPT_DATE_FROM}/{ACCEPT_DATE_TO}/{ACCEPT_MONTH_FROM}/{ACCEPT_MONTH_TO}/{PAYMENT_MONTH_FROM}/{PAYMENT_MONTH_TO}/{ANS_NET_PRICE_FROM}/{ANS_NET_PRICE_TO}/{ASSOCIATE_NAME_1}/{NET_PRICE_1_FROM}/{NET_PRICE_1_TO}/{PAYMENT_MONTH_1_FROM}/{PAYMENT_MONTH_1_TO}/{ASSOCIATE_NAME_2}/{NET_PRICE_2_FROM}/{NET_PRICE_2_TO}/{PAYMENT_MONTH_2_FROM}/{PAYMENT_MONTH_2_TO}/{ASSOCIATE_NAME_3}/{NET_PRICE_3_FROM}/{NET_PRICE_3_TO}/{PAYMENT_MONTH_3_FROM}/{PAYMENT_MONTH_3_TO}")]
        [Route("api/DatabaseAccessController/P_Get_OrderList_ForLegacyExcel/Search/P0/{ODR_PERIOD}/{ODR_CATEGORY}/{ODR_MONTH}/{ODR_SEQ}/{STATUS}/{CNST_MANAGER_ID}/{CUSTOMER_NAME}/{ODR_NAME}/{ACCEPT_DATE_FROM}/{ACCEPT_DATE_TO}/{ACCEPT_MONTH_FROM}/{ACCEPT_MONTH_TO}/{PAYMENT_MONTH_FROM}/{PAYMENT_MONTH_TO}")]
        public IList<RecMV_ORDER_LIST_FOR_EXCEL_P1> P_Get_OrderList_ForLegacyExcel(
            string ODR_PERIOD,
            string ODR_CATEGORY,
            string ODR_MONTH,
            string ODR_SEQ,
            string STATUS,
            string CNST_MANAGER_ID,
            string CUSTOMER_NAME,
            string ODR_NAME,
            string ACCEPT_DATE_FROM,
            string ACCEPT_DATE_TO,
            string ACCEPT_MONTH_FROM,
            string ACCEPT_MONTH_TO,
            string PAYMENT_MONTH_FROM,
            string PAYMENT_MONTH_TO
        ) => this._storedProcessor.P_Get_OrderList_ForLegacyExcel(
            DEFAULT: false,
            (ODR_PERIOD == Common.API_PARAM_NULL) ? null : int.Parse(ODR_PERIOD),
            (ODR_CATEGORY == Common.API_PARAM_NULL) ? null : ODR_CATEGORY,
            (ODR_MONTH == Common.API_PARAM_NULL) ? null : ODR_MONTH,
            (ODR_SEQ == Common.API_PARAM_NULL) ? null : int.Parse(ODR_SEQ),
            (STATUS == Common.API_PARAM_NULL) ? null : int.Parse(STATUS),
            (CNST_MANAGER_ID == Common.API_PARAM_NULL) ? null : CNST_MANAGER_ID,
            (CUSTOMER_NAME == Common.API_PARAM_NULL) ? null : CUSTOMER_NAME,
            (ODR_NAME == Common.API_PARAM_NULL) ? null : ODR_NAME,
            (ACCEPT_DATE_FROM == Common.API_PARAM_NULL) ? null : ACCEPT_DATE_FROM,
            (ACCEPT_DATE_TO == Common.API_PARAM_NULL) ? null : ACCEPT_DATE_TO,
            (ACCEPT_MONTH_FROM == Common.API_PARAM_NULL) ? null : ACCEPT_MONTH_FROM,
            (ACCEPT_MONTH_TO == Common.API_PARAM_NULL) ? null : ACCEPT_MONTH_TO,
            (PAYMENT_MONTH_FROM == Common.API_PARAM_NULL) ? null : PAYMENT_MONTH_FROM,
            (PAYMENT_MONTH_TO == Common.API_PARAM_NULL) ? null : PAYMENT_MONTH_TO
        );
        [HttpGet]
        [Route("api/DatabaseAccessController/P_Get_OrderList_ForLegacyExcel/Search/P1/{PARAMS}")]
        public IList<RecMV_ORDER_LIST_FOR_EXCEL_P1> P_Get_OrderList_ForLegacyExcel(string PARAMS)
        {
            var paramList = PARAMS.Split(Common.API_PARAM_SEPARATER);
            string ODR_PERIOD = paramList[0];
            string ODR_CATEGORY = paramList[1];
            string ODR_MONTH = paramList[2];
            string ODR_SEQ = paramList[3];
            string STATUS = paramList[4];
            string CNST_MANAGER_ID = paramList[5];
            string CUSTOMER_NAME = paramList[6];
            string ODR_NAME = paramList[7];
            string REQ_DATE_FROM = paramList[8];
            string REQ_DATE_TO = paramList[9];
            string REQ_NO = paramList[10];
            string ODR_DATE_FROM = paramList[11];
            string ODR_DATE_TO = paramList[12];
            string ODR_NO = paramList[13];
            string ACCEPT_DATE_FROM = paramList[14];
            string ACCEPT_DATE_TO = paramList[15];
            string ACCEPT_MONTH_FROM = paramList[16];
            string ACCEPT_MONTH_TO = paramList[17];
            string PAYMENT_MONTH_FROM = paramList[18];
            string PAYMENT_MONTH_TO = paramList[19];
            string ANS_NET_PRICE_FROM = paramList[20];
            string ANS_NET_PRICE_TO = paramList[21];
            string ASSOCIATE_NAME_1 = paramList[22];
            string NET_PRICE_1_FROM = paramList[23];
            string NET_PRICE_1_TO = paramList[24];
            string PAYMENT_MONTH_1_FROM = paramList[25];
            string PAYMENT_MONTH_1_TO = paramList[26];
            string ASSOCIATE_NAME_2 = paramList[27];
            string NET_PRICE_2_FROM = paramList[28];
            string NET_PRICE_2_TO = paramList[29];
            string PAYMENT_MONTH_2_FROM = paramList[30];
            string PAYMENT_MONTH_2_TO = paramList[31];
            string ASSOCIATE_NAME_3 = paramList[32];
            string NET_PRICE_3_FROM = paramList[33];
            string NET_PRICE_3_TO = paramList[34];
            string PAYMENT_MONTH_3_FROM = paramList[35];
            string PAYMENT_MONTH_3_TO = paramList[36];
            return this._storedProcessor.P_Get_OrderList_ForLegacyExcel(
                DEFAULT: false,
                (ODR_PERIOD == Common.API_PARAM_NULL) ? null : int.Parse(ODR_PERIOD),
                (ODR_CATEGORY == Common.API_PARAM_NULL) ? null : ODR_CATEGORY,
                (ODR_MONTH == Common.API_PARAM_NULL) ? null : ODR_MONTH,
                (ODR_SEQ == Common.API_PARAM_NULL) ? null : int.Parse(ODR_SEQ),
                (STATUS == Common.API_PARAM_NULL) ? null : int.Parse(STATUS),
                (CNST_MANAGER_ID == Common.API_PARAM_NULL) ? null : CNST_MANAGER_ID,
                (CUSTOMER_NAME == Common.API_PARAM_NULL) ? null : CUSTOMER_NAME,
                (ODR_NAME == Common.API_PARAM_NULL) ? null : ODR_NAME,
                (REQ_DATE_FROM == Common.API_PARAM_NULL) ? null : REQ_DATE_FROM,
                (REQ_DATE_TO == Common.API_PARAM_NULL) ? null : REQ_DATE_TO,
                (REQ_NO == Common.API_PARAM_NULL) ? null : REQ_NO,
                (ODR_DATE_FROM == Common.API_PARAM_NULL) ? null : ODR_DATE_FROM,
                (ODR_DATE_TO == Common.API_PARAM_NULL) ? null : ODR_DATE_TO,
                (ODR_NO == Common.API_PARAM_NULL) ? null : ODR_NO,
                (ACCEPT_DATE_FROM == Common.API_PARAM_NULL) ? null : ACCEPT_DATE_FROM,
                (ACCEPT_DATE_TO == Common.API_PARAM_NULL) ? null : ACCEPT_DATE_TO,
                (ACCEPT_MONTH_FROM == Common.API_PARAM_NULL) ? null : ACCEPT_MONTH_FROM,
                (ACCEPT_MONTH_TO == Common.API_PARAM_NULL) ? null : ACCEPT_MONTH_TO,
                (PAYMENT_MONTH_FROM == Common.API_PARAM_NULL) ? null : PAYMENT_MONTH_FROM,
                (PAYMENT_MONTH_TO == Common.API_PARAM_NULL) ? null : PAYMENT_MONTH_TO,
                (ANS_NET_PRICE_FROM == Common.API_PARAM_NULL) ? null : int.Parse(ANS_NET_PRICE_FROM),
                (ANS_NET_PRICE_TO == Common.API_PARAM_NULL) ? null : int.Parse(ANS_NET_PRICE_TO),
                (ASSOCIATE_NAME_1 == Common.API_PARAM_NULL) ? null : ASSOCIATE_NAME_1,
                (NET_PRICE_1_FROM == Common.API_PARAM_NULL) ? null : int.Parse(NET_PRICE_1_FROM),
                (NET_PRICE_1_TO == Common.API_PARAM_NULL) ? null : int.Parse(NET_PRICE_1_TO),
                (PAYMENT_MONTH_1_FROM == Common.API_PARAM_NULL) ? null : PAYMENT_MONTH_1_FROM,
                (PAYMENT_MONTH_1_TO == Common.API_PARAM_NULL) ? null : PAYMENT_MONTH_1_TO,
                (ASSOCIATE_NAME_2 == Common.API_PARAM_NULL) ? null : ASSOCIATE_NAME_2,
                (NET_PRICE_2_FROM == Common.API_PARAM_NULL) ? null : int.Parse(NET_PRICE_2_FROM),
                (NET_PRICE_2_TO == Common.API_PARAM_NULL) ? null : int.Parse(NET_PRICE_2_TO),
                (PAYMENT_MONTH_2_FROM == Common.API_PARAM_NULL) ? null : PAYMENT_MONTH_2_FROM,
                (PAYMENT_MONTH_2_TO == Common.API_PARAM_NULL) ? null : PAYMENT_MONTH_2_TO,
                (ASSOCIATE_NAME_3 == Common.API_PARAM_NULL) ? null : ASSOCIATE_NAME_3,
                (NET_PRICE_3_FROM == Common.API_PARAM_NULL) ? null : int.Parse(NET_PRICE_3_FROM),
                (NET_PRICE_3_TO == Common.API_PARAM_NULL) ? null : int.Parse(NET_PRICE_3_TO),
                (PAYMENT_MONTH_3_FROM == Common.API_PARAM_NULL) ? null : PAYMENT_MONTH_3_FROM,
                (PAYMENT_MONTH_3_TO == Common.API_PARAM_NULL) ? null : PAYMENT_MONTH_3_TO
            );
        }
        [HttpDelete]
        [Route("api/DatabaseAccessController/P_Delete_OrderItem_ForApp1/Delete/{ODR_PERIOD}/{ODR_CATEGORY}/{ODR_MONTH}/{ODR_SEQ}")]
        public ActionResult P_Delete_OrderItem_ForApp1(string ODR_PERIOD, string ODR_CATEGORY, string ODR_MONTH, string ODR_SEQ)
        {
            try
            {
                this._storedProcessor.P_Delete_OrderItem_ForApp1(int.Parse(ODR_PERIOD), ODR_CATEGORY, ODR_MONTH, int.Parse(ODR_SEQ));
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("api/DatabaseAccessController/P_Get_OrderList_ForLegacyExcel")]
        public IList<RecMV_ORDER_LIST_FOR_EXCEL_P1> P_Get_OrderList_ForLegacyExcel() => this._storedProcessor.P_Get_OrderList_ForLegacyExcel();
        [HttpGet]
        [Route("api/DatabaseAccessController/P_Get_T_STAFF_Selector1")]
        public IList<SelectorItem> P_Get_T_STAFF_Selector1() => this._storedProcessor.P_Get_T_STAFF_Selector1();
        [HttpGet]
        [Route("api/DatabaseAccessController/P_Get_T_PROGRAM_Parameters1/{PROGRAM}")]
        public IList<SelectorItem> P_Get_T_PROGRAM_Parameters1(string PROGRAM) => this._storedProcessor.P_Get_T_PROGRAM_Parameters1(PROGRAM);
        [HttpGet]
        [Route("api/DatabaseAccessController/P_Get_T_PROGRAM_Parameters1/{PROGRAM}/{PROCESS}")]
        public IList<SelectorItem> P_Get_T_PROGRAM_Parameters1(string PROGRAM, string PROCESS) => this._storedProcessor.P_Get_T_PROGRAM_Parameters1(PROGRAM, PROCESS);
        [HttpGet]
        [Route("api/DatabaseAccessController/P_Get_T_PROGRAM_Parameters1/{PROGRAM}/{PROCESS}/{ITEM_ID}")]
        public IList<SelectorItem> P_Get_T_PROGRAM_Parameters1(string PROGRAM, string PROCESS, string ITEM_ID) => this._storedProcessor.P_Get_T_PROGRAM_Parameters1(PROGRAM, PROCESS, ITEM_ID);
        [HttpGet]
        [Route("api/DatabaseAccessController/P_Get_T_PROGRAM_Parameters1/{PROGRAM}/{PROCESS}/{ITEM_ID}/{KEY_ID}")]
        public IList<SelectorItem> P_Get_T_PROGRAM_Parameters1(string PROGRAM, string PROCESS, string ITEM_ID, string KEY_ID) => this._storedProcessor.P_Get_T_PROGRAM_Parameters1(PROGRAM, PROCESS, ITEM_ID, KEY_ID);
        [HttpGet]
        [Route("api/DatabaseAccessController/P_Get_T_ASSOCIATE_Selector1")]
        public IList<SelectorItem> P_Get_T_ASSOCIATE_Selector1() => this._storedProcessor.P_Get_T_ASSOCIATE_Selector1();
        [HttpGet]
        [Route("api/DatabaseAccessController/P_Get_T_CUSTOMER_Selector1")]
        public IList<SelectorItem> P_Get_T_CUSTOMER_Selector1() => this._storedProcessor.P_Get_T_CUSTOMER_Selector1();
        [HttpGet]
        [Route("api/DatabaseAccessController/P_Get_ListMonth_Selector1")]
        public IList<SelectorItem> P_Get_ListMonth_Selector1() => this._storedProcessor.P_Get_ListMonth_Selector1();
        [HttpGet]
        [Route("api/DatabaseAccessController/P_Get_ListOrderCategory_Selector1")]
        public IList<SelectorItem> P_Get_ListOrderCategory_Selector1() => this._storedProcessor.P_Get_ListOrderCategory_Selector1();
        [HttpGet]
        [Route("api/DatabaseAccessController/P_Get_ListOrderStatus_Selector1")]
        public IList<SelectorItem> P_Get_ListOrderStatus_Selector1() => this._storedProcessor.P_Get_ListOrderStatus_Selector1();
        [HttpGet]
        [Route("api/DatabaseAccessController/P_Get_ListOrderType_Selector1")]
        public IList<SelectorItem> P_Get_ListOrderType_Selector1() => this._storedProcessor.P_Get_ListOrderType_Selector1();
        [HttpGet]
        [Route("api/DatabaseAccessController/P_Get_NextOrderNoItems")]
        public IList<SelectorItem> P_Get_NextOrderNoItems() => this._storedProcessor.P_Get_NextOrderNoItems();
        [HttpGet]
        [Route("api/DatabaseAccessController/P_Get_LoginUserInfo/{STAFF_ID}")]
        public SetLOGON_USER_INFO P_Get_LoginUserInfo(string STAFF_ID) => this._storedProcessor.P_Get_LoginUserInfo(STAFF_ID);
        [HttpGet]
        [Route("api/DatabaseAccessController/P_Get_AllUserInfo")]
        public List<RecLOGON_USER_PRIMARY> P_Get_AllUserInfo() => this._storedProcessor.P_Get_AllUserInfo();
        [HttpPost]
        [Route("api/DatabaseAccessController/P_Import_OrderList_ForLegacyExcel")]
        public void P_Import_OrderList_ForLegacyExcel(IList<RecMV_ORDER_LIST_FOR_EXCEL_P1> list) => this._storedProcessor.P_Import_OrderList_ForLegacyExcel("Tool", list);
        [HttpPost]
        [Route("api/DatabaseAccessController/P_Import_OrderList_ForAppEdit1/{UpdateMode}/{ForceWrite}")]
        public ActionResult P_Import_OrderList_ForAppEdit1_Create(string UpdateMode, string ForceWrite, IList<RecMV_ORDER_LIST_FOR_EXCEL_P1> list)
        {
            try
            {
                this._storedProcessor.P_Import_OrderList_ForAppEdit1(int.Parse(UpdateMode), int.Parse(ForceWrite), list);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //[HttpPost]
        //[Route("api/DatabaseAccessController/P_Import_OrderList_ForAppEdit1/Create")]
        //public ActionResult P_Import_OrderList_ForAppEdit1_Create(IList<RecMV_ORDER_LIST_FOR_EXCEL_P1> list)
        //{
        //    try
        //    {
        //        this._storedProcessor.P_Import_OrderList_ForAppEdit1(0, list);
        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}
        //[HttpPost]
        //[Route("api/DatabaseAccessController/P_Import_OrderList_ForAppEdit1/Update")]
        //public ActionResult P_Import_OrderList_ForAppEdit1_Update(IList<RecMV_ORDER_LIST_FOR_EXCEL_P1> list)
        //{
        //    try
        //    {
        //        this._storedProcessor.P_Import_OrderList_ForAppEdit1(1, list);
        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}
        [HttpGet]
        [Route("api/DatabaseAccessController/GetEmployeeAll")]
        public IList<RecEmployeeAll> GetEmployeeAll() => this._storedProcessor.P_Get_T_EMPLOYEE_ALL();
        [HttpPost]
        [Route("api/DatabaseAccessController/UpdateEmployeeAll")]
        public void UpdateEmployeeAll(IList<RecEmployeeAll> list) { }
        [HttpGet]
        [Route("api/DatabaseAccessController/P_GET_T_LOCK_MANAGE/{LOCK_ID}")]
        public RecT_LOCK_MANAGE_EX1 P_GET_T_LOCK_MANAGE(string LOCK_ID) => this._storedProcessor.P_GET_T_LOCK_MANAGE(LOCK_ID);
        [HttpGet]
        [Route("api/DatabaseAccessController/P_LOCK_T_LOCK_MANAGE/{LOCK_ID}/{USER_ID}/{MESSAGE}")]
        public RecLOCK_MANAGE_RESULT P_LOCK_T_LOCK_MANAGE(string LOCK_ID, string USER_ID, string MESSAGE) => this._storedProcessor.P_LOCK_T_LOCK_MANAGE(LOCK_ID, USER_ID, MESSAGE);
        [HttpGet]
        [Route("api/DatabaseAccessController/P_UNLOCK_T_LOCK_MANAGE/{LOCK_ID}/{USER_ID}")]
        public RecLOCK_MANAGE_RESULT P_UNLOCK_T_LOCK_MANAGE(string LOCK_ID, string USER_ID) => this._storedProcessor.P_UNLOCK_T_LOCK_MANAGE(LOCK_ID, USER_ID);
    }
}