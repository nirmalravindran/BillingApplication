
namespace BillingApplication.Core.Queries
{
    public static class BillingQueries
    {
        public const string GetProducts = @"SELECT NAME, DIMENSIONTYPE, RATE, PUMPS_ID AS PRODUCTS_ID, TAXCLASS FROM PUMPS WHERE ISBILLABLE = 1";
        public const string GetTankableProducts = @"SELECT RTRIM(NAME) AS NAME, DIMENSIONTYPE, RATE, PUMPS_ID AS PRODUCTS_ID, TAXCLASS FROM PUMPS WHERE ISSTOREDINTANK = 1 ORDER BY NAME";
        public const string GetAllProducts = @"SELECT NAME, DIMENSIONTYPE, RATE, PUMPS_ID AS PRODUCTS_ID, TAXCLASS FROM PUMPS";
        public const string GetCustomers = @"SELECT * FROM CUSTOMERS ORDER BY NAME";
        public const string GetCashiers = @"SELECT * FROM CASHIERS";
        public const string GetCurrentCashiers = @"SELECT DISTINCT C.* FROM CASHIERS C INNER JOIN PUMPS P ON C.CASHIERS_ID = P.CASHIER AND P.ISACCOUNTABLE = 1 order BY NAME";

        public const string GetBillsForCashier = 
        @"SELECT B.*,BI.QUANTITY,BI.AMOUNT,BI.RATE,P.NAME,P.TAXCLASS FROM 
          BILLS B
          INNER JOIN BILLITEMS BI
          ON B.BILLS_ID = BI.BILLS_ID
          INNER JOIN PUMPS P
          ON P.PUMPS_ID = BI.PRODUCT
          WHERE B.CASHIER = @CASHIERID AND B.BILLDATE >= @SHIFTSTARTDATETIME ORDER BY BILLNO";

        public const string UpdateBillWithCurrentCashier =
                @"UPDATE BILLS SET CASHIER = @CASHIER WHERE BILLNO = @BILLNO";

        public const string RemoveCurrentCashierFromBill =
                @"UPDATE BILLS SET CASHIER = NULL WHERE BILLNO = @BILLNO";

        public const string UpdatePriceForProduct =
                @"UPDATE PUMPS SET RATE = @PRICE WHERE PUMPS_ID = @PRODUCTID OR PRODUCT = @PRODUCTID";

        public const string GetBillWithBillNumber =
            @"SELECT * FROM BILLS WHERE BILLNO = @BILLNUMBER";

        public const string GetTankForProduct =
            @"SELECT TANKNAME,TANKS_ID FROM TANKS WHERE PRODUCT = @PRODUCTID";

        public const string GetAllTanks =
            @"SELECT * FROM TANKS ORDER BY TANKNAME ASC";

        public const string GetPreviousVolume =
            @"SELECT DD.TANK,DD.VOLUME FROM DAILYDIP DD 
              WHERE DD.DATE = (SELECT TOP 1 DATE FROM DAILYDIP ORDER BY DATE DESC)";

        public const string GetAllTankSales =
            @"SELECT T.TANKS_ID, SUM(PSD.SALES) AS SALES FROM TANKS T 
              INNER JOIN PUMPS P ON T.TANKS_ID = P.TANK
              INNER JOIN PUMPSHIFTDETAILS PSD ON P.PUMPS_ID = PSD.PUMPS_ID AND (PSD.ENDTIME > (SELECT TOP 1 DATE FROM DAILYDIP ORDER BY DATE DESC))
              GROUP BY T.TANKS_ID ";

        public const string GetAllTankReceipts =
            @"SELECT T.TANKS_ID,SUM(TR.QUANTITY) AS RECEIPTS FROM TANKS T
              INNER JOIN TANKRECEIPTS TR ON T.TANKS_ID = TR.TANK AND TR.DATE > (SELECT TOP 1 DATE FROM DAILYDIP ORDER BY DATE DESC)
              GROUP BY T.TANKS_ID ";
    }
}
