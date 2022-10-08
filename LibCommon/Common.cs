using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMTS.Internal
{
    public class Common
    {
        public static string TARGET_DATABASE_CONNECTION_SETTINGS = "Data Source=192.168.3.12;Initial Catalog=BAMTS_DB;Persist Security Info=True;User ID=naitou;Password=naitou";
        public static string TARGET_CSV_FILE_PATH = @"C:\User\Projects\BAMTS\Development\BAMTS_Internal\Source\LibExcelAccess\Test\EMPLOYEE.CSV";
        public static string TARGET_EXCEL_FILE_PATH = @"C:\User\Projects\BAMTS\Development\BAMTS_Internal\Source\LibExcelAccess\Test\EMPLOYEE.xlsx";
        public static string TARGET_EXCEL_FILE_SHEET = "EMPLOYEE";
        public static string TARGET_WEBAPI_HOST = "192.168.3.12";
        public static string TARGET_WEBAPI_SCHEME = "http";
        public static int TARGET_WEBAPI_PORTNO = 11486;      
        public static string TARGET_WEBAPI_CONTROLLER = "DatabaseAccessController";
        public static int TAX_RATE = 10;
        public static string LOGIN_STAFF_ID;
        public static string API_PARAM_NULL = "|";
        public static string API_PARAM_SEPARATER = "~";
        public static DateTime LOGIN_TIME;
        public static string RESULT_OPTION_CANRETRY = "[%CanRetry%]";
        public enum InputMode
        {
            Create = 0,
            Update,
            Delete
        }
    }
}
