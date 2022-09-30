using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BAMTS.Internal;

namespace ImportOrderDataFromExcel
{
    public partial class FImportOrderDataFromExcel : Form
    {
        private static string _TARGET_INFO_TEXT = Common.TARGET_DATABASE_CONNECTION_SETTINGS;
        private StoredProcessor _storedProcessor;
        public FImportOrderDataFromExcel()
        {
            InitializeComponent();
            this._storedProcessor = new StoredProcessor(FImportOrderDataFromExcel._TARGET_INFO_TEXT);
        }

        private void btnFileRef_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FileName = "受注伝票・一覧表18期.xlsm";
            //ofd.InitialDirectory = @"C:\";
            //ofd.InitialDirectory = @"C:\User\Projects\BAMTS\Development\BAMTS_Internal\Documents\社内管理";
            ofd.InitialDirectory = @"C:\Temp";
            ofd.Filter = "Excelファイル(*.xlsm)|*.xlsm";
            ofd.FilterIndex = 2;
            ofd.Title = "開くファイルを選択してください";
            ofd.RestoreDirectory = true;
            ofd.CheckFileExists = true;
            ofd.CheckPathExists = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                this.txtFilePath.Text = ofd.FileName;
            }
        }
        private void btnExecute_Click(object sender, EventArgs e)
        {
            try
            {
                var nowTime = DateTime.Now;
                this.Stop = false;
                this.lstLog.Items.Clear();
                this.BackColor = Color.Red;
                this.Refresh();
                var acs = new ExcelFileAccessor(this.txtFilePath.Text, "受注一覧");
                var list = acs.GetList(this.lstLog);
                for (var i = 0; i < list.Count; i++)
                {
                    try
                    {
                        list[i].UPD_TIME = nowTime;
                        this._storedProcessor.P_Import_OrderList_ForLegacyExcel("Tool", new List<RecMV_ORDER_LIST_FOR_EXCEL_P1> { list[i] });
                        var m = $"受注番号：{list[i].ODR_PERIOD:00}{list[i].ODR_CATEGORY}{list[i].ODR_MONTH}{list[i].ODR_SEQ:0000}【正常】";
                        lstLog.Items.Insert(0, m);
                        lstLog.Refresh();
                    }
                    catch (Exception ex) 
                    {
                        var m = $"受注番号：{list[i].ODR_PERIOD:00}{list[i].ODR_CATEGORY}{list[i].ODR_MONTH}{list[i].ODR_SEQ:0000}の処理にて異常が発生しました。{ex.Message}";
                        lstLog.Items.Insert(0, m);
                        lstLog.Refresh();
                        this.Stop = true;
                        //MessageBox.Show($"受注番号：{list[i].ODR_PERIOD}{list[i].ODR_CATEGORY}{list[i].ODR_MONTH}{list[i].ODR_SEQ}の処理にて異常が発生しました。{ex.Message}","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    if (this.Stop) break;
                }
            }
            finally
            {
                this.BackColor = SystemColors.Control;
                this.Refresh();
            }
        }
        private bool Stop = false;
        private void btnStop_Click(object sender, EventArgs e)
        {
            this.Stop = true;
        }
    }
}
