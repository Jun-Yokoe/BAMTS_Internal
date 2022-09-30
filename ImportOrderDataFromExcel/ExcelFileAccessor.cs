using ClosedXML.Excel;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System;

namespace BAMTS.Internal
{
    public class ExcelFileAccessor
    {
        private string _targetFilePath;
        private string _targetSheetName;
        public ExcelFileAccessor(string targetFilePath, string targetSheetName)
        {
            this._targetFilePath = targetFilePath;
            this._targetSheetName = targetSheetName;
        }
        private int ConvertInt(string value)
        {
            return (int)Math.Round(decimal.Parse(Microsoft.VisualBasic.Strings.StrConv(value, Microsoft.VisualBasic.VbStrConv.Narrow, 0x411)), 0, MidpointRounding.AwayFromZero);
        }
        public List<RecMV_ORDER_LIST_FOR_EXCEL_P1> GetList(System.Windows.Forms.ListBox lstLog)
        {
            var res = new List<RecMV_ORDER_LIST_FOR_EXCEL_P1>();
            using (var workbook = new XLWorkbook(this._targetFilePath))
            {
                var worksheet = workbook.Worksheet(this._targetSheetName);
                int row = 6;    //ヘッダレコードスキップ
                bool endOfRow = false;
                string valueText = "";
                while (endOfRow == false)
                {
                    if (string.IsNullOrEmpty(worksheet.Cell(row, 1).Value.ToString().Trim()))
                    {
                        endOfRow = true;
                        break;
                    }
                    var item = new RecMV_ORDER_LIST_FOR_EXCEL_P1();
                    for (int col = 1; col <= 89; col++)
                    {
                        try
                        {
                            valueText = worksheet.Cell(row, col).Value.ToString().Trim();
                            if (string.IsNullOrEmpty(valueText)) continue;
                            switch (col)
                            {
                                case 1:
                                    item.STATUS = this.ConvertInt(valueText);
                                    break;
                                case 2:
                                    item.DLV_SUBMIT_DATE = DateTime.Parse(valueText);
                                    break;
                                case 3:
                                    item.DLV_DEADLINE_DATE = DateTime.Parse(valueText);
                                    break;
                                case 4:
                                    item.DLVREP_SUBMIT_DATE = DateTime.Parse(valueText);
                                    break;
                                case 5:
                                    item.CMPREP_ISSUE_DATE = DateTime.Parse(valueText);
                                    break;
                                case 6:
                                    item.CMPREP_DEADLINE_DATE = DateTime.Parse(valueText);
                                    break;
                                case 7:
                                    item.CMPMAIL_ISSUE_DATE = DateTime.Parse(valueText);
                                    break;
                                case 8:
                                    item.CMPMAIL_DEADLINE_DATE = DateTime.Parse(valueText);
                                    break;
                                case 9: //★名前からIDに変換
                                    item.CNST_MANAGER_NAME = valueText;
                                    break;
                                case 10:
                                    item.TYPE = this.ConvertInt(valueText).ToString();
                                    break;
                                case 11:
                                    item.REV_ISSUE_DATE = DateTime.Parse(valueText);
                                    break;
                                case 12:
                                    item.REV_NO = this.ConvertInt(valueText);
                                    break;
                                case 13:
                                    item.EST_ISSUE_DATE = DateTime.Parse(valueText);
                                    break;
                                case 15:
                                    item.ODR_PERIOD = this.ConvertInt(valueText);
                                    break;
                                case 16:
                                    item.ODR_CATEGORY = valueText;
                                    break;
                                case 17:
                                    item.ODR_MONTH = valueText;
                                    break;
                                case 18:
                                    item.ODR_SEQ = this.ConvertInt(valueText);
                                    break;
                                case 19: //★名前からIDに変換
                                    item.CUSTOMER_NAME = valueText;
                                    break;
                                case 20:
                                    item.ODR_NAME = valueText;
                                    break;
                                case 23:
                                    item.CNST_NET_PRICE = this.ConvertInt(valueText);
                                    break;
                                case 24:
                                    item.CNST_TAX_PRICE = this.ConvertInt(valueText) - item.CNST_NET_PRICE;
                                    break;
                                case 25:
                                    item.STUP_NET_PRICE = this.ConvertInt(valueText);
                                    break;
                                case 26:
                                    item.STUP_TAX_PRICE = this.ConvertInt(valueText) - item.STUP_NET_PRICE;
                                    break;
                                case 27:
                                    item.CNST_START_DATE = DateTime.Parse(valueText);
                                    break;
                                case 28:
                                    item.CNST_END_DATE = DateTime.Parse(valueText);
                                    break;
                                case 29:
                                    item.OPEN_DATE = DateTime.Parse(valueText);
                                    break;
                                case 39:
                                    item.ESTREQ_NO_1 = valueText;
                                    break;
                                case 40:
                                    item.ESTREQ_NO_2 = valueText;
                                    break;
                                case 43:
                                    item.PRODUCT_NO = valueText;
                                    break;
                                case 44:
                                    item.REQ_DATE = DateTime.Parse(valueText);
                                    break;
                                case 45:
                                    item.REQ_NO = valueText;
                                    break;
                                case 46:
                                    item.ODR_DATE = DateTime.Parse(valueText);
                                    break;
                                case 47:
                                    item.ODR_NO = valueText;
                                    break;
                                case 48:
                                    item.ACCEPT_DATE = DateTime.Parse(valueText);
                                    break;
                                case 49:
                                    item.ACCEPT_MONTH = DateTime.Parse(valueText);
                                    break;
                                case 50:
                                    item.PAYMENT_MONTH = DateTime.Parse(valueText);
                                    break;
                                case 51:
                                    item.ANS_NET_PRICE = this.ConvertInt(valueText);
                                    break;
                                case 52:
                                    item.ANS_TAX_PRICE = this.ConvertInt(valueText) - item.ANS_NET_PRICE;
                                    break;
                                case 53: //★名前からIDに変換
                                    item.ASSOCIATE_NAME_1 = valueText;
                                    break;
                                case 54:
                                    item.NET_PRICE_1 = this.ConvertInt(valueText);
                                    break;
                                case 55:
                                    item.TAX_PRICE_1 = this.ConvertInt(valueText) - item.NET_PRICE_1;
                                    break;
                                case 56:
                                    item.PAYMENT_MONTH_1 = DateTime.Parse(valueText);
                                    break;
                                case 57: //★名前からIDに変換
                                    item.ASSOCIATE_NAME_2 = valueText;
                                    break;
                                case 58:
                                    item.NET_PRICE_2 = this.ConvertInt(valueText);
                                    break;
                                case 59:
                                    item.TAX_PRICE_2 = this.ConvertInt(valueText) - item.NET_PRICE_2;
                                    break;
                                case 60:
                                    item.PAYMENT_MONTH_2 = DateTime.Parse(valueText);
                                    break;
                                case 61: //★名前からIDに変換
                                    item.ASSOCIATE_NAME_3 = valueText;
                                    break;
                                case 62:
                                    item.NET_PRICE_3 = this.ConvertInt(valueText);
                                    break;
                                case 63:
                                    item.TAX_PRICE_3 = this.ConvertInt(valueText) - item.NET_PRICE_3;
                                    break;
                                case 64:
                                    item.PAYMENT_MONTH_3 = DateTime.Parse(valueText);
                                    break;
                                case 82:
                                    item.NOTE = valueText;
                                    break;
                                default:
                                    break;
                            }
                        }
                        catch(Exception ex) 
                        {
                            var m = $"ROW=[{row}]/COL=[{col}]:[{valueText}]:{ex.Message}";
                            lstLog.Items.Insert(0, m);
                            lstLog.Refresh();
                        }
                    }
                    res.Add(item);
                    row++;
                }
            }
            return res;
        }
    }
}
