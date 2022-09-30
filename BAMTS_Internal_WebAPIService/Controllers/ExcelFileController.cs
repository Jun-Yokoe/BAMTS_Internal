using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Net;
using System.Net.Http;
using BAMTS.Internal;
using Microsoft.Extensions.Logging;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System.IO;

namespace BAMTS_Internal_WebAPIService.Controllers
{
    public class ExcelFileController : ControllerBase
    {
        List<DataItem> dataList = new List<DataItem>();
        class DataItem
        {
            public int id;
            public string name;
            public string code;
            public int price;

        }

        [HttpGet]
        [Route("api/ExcelFileController/ExcelExportTest")]
        public async Task ExcelExportTest(HttpContext context)
        {

            dataList.Clear();
            dataList.Add(new DataItem() { id = 1, name = "ぺんぎんクッキー", code = "PCD-001", price = 180 });
            dataList.Add(new DataItem() { id = 2, name = "あひるサブレ", code = "PCD-002", price = 120 });
            dataList.Add(new DataItem() { id = 3, name = "らくだキャラメル", code = "PCD-003", price = 40 });
            dataList.Add(new DataItem() { id = 4, name = "しろくまアイス", code = "PCA-001", price = 230 });
            dataList.Add(new DataItem() { id = 5, name = "だちょうカステラ", code = "PCD-004", price = 90 });

            //シート作成
            MemoryStream ms = new MemoryStream();
            SpreadsheetDocument doc = SpreadsheetDocument.Create(ms, SpreadsheetDocumentType.Workbook);

            WorkbookPart wbpart = doc.AddWorkbookPart();
            wbpart.Workbook = new Workbook();
            WorksheetPart wspart = wbpart.AddNewPart<WorksheetPart>();
            wspart.Worksheet = new Worksheet(new SheetData());
            Sheets sheets = doc.WorkbookPart.Workbook.AppendChild<Sheets>(new Sheets());

            Sheet sheet = new Sheet();
            sheet.Id = doc.WorkbookPart.GetIdOfPart(wspart);
            sheet.SheetId = 1;
            sheet.Name = "商品";
            sheets.Append(sheet);


            //Column
            Columns lstColumns = wspart.Worksheet.GetFirstChild<Columns>();
            if (lstColumns == null)
            {
                lstColumns = new Columns();
                wspart.Worksheet.InsertAt(lstColumns, 0);
            }

            lstColumns.Append(new Column() { Min = 1, Max = 1, Width = 4, CustomWidth = true });
            lstColumns.Append(new Column() { Min = 2, Max = 2, Width = 25, CustomWidth = true });
            lstColumns.Append(new Column() { Min = 3, Max = 4, Width = 12, CustomWidth = true });

            //データ挿入
            Row row;
            UInt32Value row_index = 1;

            foreach (DataItem di in dataList)
            {
                row = new Row() { RowIndex = row_index };
                wspart.Worksheet.GetFirstChild<SheetData>().Append(row);

                Cell refCell = null;
                Cell newCell;

                newCell = new Cell() { CellReference = "A" + row_index.ToString() };
                newCell.CellValue = new CellValue(di.id.ToString());
                newCell.DataType = new EnumValue<CellValues>(CellValues.Number);
                row.InsertAfter(newCell, refCell);
                refCell = newCell;
                //
                newCell = new Cell() { CellReference = "B" + row_index.ToString() };
                newCell.CellValue = new CellValue(di.name);
                newCell.DataType = new EnumValue<CellValues>(CellValues.String);
                row.InsertAfter(newCell, refCell);
                refCell = newCell;
                //
                newCell = new Cell() { CellReference = "C" + row_index.ToString() };
                newCell.CellValue = new CellValue(di.code);
                newCell.DataType = new EnumValue<CellValues>(CellValues.String);
                row.InsertAfter(newCell, refCell);
                refCell = newCell;
                //
                newCell = new Cell() { CellReference = "D" + row_index.ToString() };
                newCell.CellValue = new CellValue(di.price.ToString());
                newCell.DataType = new EnumValue<CellValues>(CellValues.Number);
                row.InsertAfter(newCell, refCell);
                refCell = newCell;

                row_index++;
            }

            wbpart.Workbook.Save();
            doc.Close();

            ms.Seek(0, SeekOrigin.Begin);
            byte[] buffer = new byte[ms.Length];
            await ms.ReadAsync(buffer, 0, (int)ms.Length);
            ms.Close();

            context.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            context.Response.Headers.Append("Content-Disposition", "attachment; filename=\"export.xlsx\"");
            await context.Response.Body.WriteAsync(buffer, 0, buffer.Length);

        }

        [HttpGet]
        [Route("api/ExcelFileController/ExcelReadTest")]
        public IList<RecEmployeeAll> ExcelReadTest()
        {
            //var xlsx = new ExcelFileAccessor(@"C:\User\Projects\BAMTS\Development\BAMTS_Internal\Source\LibExcelAccess\Test\EMPLOYEE.xlsx", "EMPLOYEE");
            //var list = xlsx.GetEmployeeAll();
            return new List<RecEmployeeAll>();
        }
    }
}
