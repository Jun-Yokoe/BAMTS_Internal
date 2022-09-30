namespace BAMTS.Internal
{
    public class ValueKeeperForOrderList
    {
        public string ODR_NAME_Flag = "";
        public string ODR_NAME_Value = "";
        public string CNST_NET_PRICE_Flag = "";
        public int CNST_NET_PRICE_Value = 0;
        public string STUP_NET_PRICE_Flag = "";
        public int STUP_NET_PRICE_Value = 0;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public void SetAllFlags(bool value)
        {
            this.ODR_NAME_Flag = value ? "on" : "";
            this.CNST_NET_PRICE_Flag = value ? "on" : "";
            this.STUP_NET_PRICE_Flag = value ? "on" : "";
        }
        public void SaveKeepItemValue(RecVV_ORDER_LIST_FOR_EXCEL_P1 inputModel)
        {
            if (this.ODR_NAME_Flag == "on")
            {
                this.ODR_NAME_Value = inputModel.ODR_NAME;
            }
            if (this.CNST_NET_PRICE_Flag == "on")
            {
                this.CNST_NET_PRICE_Value = inputModel.CNST_NET_PRICE;
            }
            if (this.STUP_NET_PRICE_Flag == "on")
            {
                this.STUP_NET_PRICE_Value = inputModel.STUP_NET_PRICE;
            }
        }
        public void LoadKeepItemValue(RecVV_ORDER_LIST_FOR_EXCEL_P1 inputModel)
        {
            if (this.ODR_NAME_Flag == "on")
            {
                inputModel.ODR_NAME = this.ODR_NAME_Value;
            }
            if (this.CNST_NET_PRICE_Flag == "on")
            {
                inputModel.CNST_NET_PRICE = this.CNST_NET_PRICE_Value;
            }
            if (this.STUP_NET_PRICE_Flag == "on")
            {
                inputModel.STUP_NET_PRICE = this.STUP_NET_PRICE_Value;
            }
        }
    }
}
