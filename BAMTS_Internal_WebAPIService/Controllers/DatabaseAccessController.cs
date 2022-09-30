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
        [Route("api/DatabaseAccessController/P_Get_OrderList_ForLegacyExcel/Search/{ODR_PERIOD}/{ODR_CATEGORY}/{ODR_MONTH}/{ODR_SEQ}/{STATUS}/{CNST_MANAGER_ID}/{CUSTOMER_NAME}/{ODR_NAME}")]
        public IList<RecMV_ORDER_LIST_FOR_EXCEL_P1> P_Get_OrderList_ForLegacyExcel(
            string ODR_PERIOD, 
            string ODR_CATEGORY, 
            string ODR_MONTH, 
            string ODR_SEQ,
            string STATUS,
            string CNST_MANAGER_ID,
            string CUSTOMER_NAME,
            string ODR_NAME
        ) => this._storedProcessor.P_Get_OrderList_ForLegacyExcel(
            (ODR_PERIOD == Common.ROUTE_PARAM_NULL) ? null : int.Parse(ODR_PERIOD),
            (ODR_CATEGORY == Common.ROUTE_PARAM_NULL) ? null : ODR_CATEGORY,
            (ODR_MONTH == Common.ROUTE_PARAM_NULL) ? null : ODR_MONTH,
            (ODR_SEQ == Common.ROUTE_PARAM_NULL) ? null : int.Parse(ODR_SEQ),
            (STATUS == Common.ROUTE_PARAM_NULL) ? null : int.Parse(STATUS),
            (CNST_MANAGER_ID == Common.ROUTE_PARAM_NULL) ? null : CNST_MANAGER_ID,
            (CUSTOMER_NAME == Common.ROUTE_PARAM_NULL) ? null : CUSTOMER_NAME,
            (ODR_NAME == Common.ROUTE_PARAM_NULL) ? null : ODR_NAME,
            DEFAULT: false
        );
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