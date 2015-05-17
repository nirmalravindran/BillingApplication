namespace BillingApplication.Core.Queries
{
    public static class CashReceiptQueries
    {
        public const string GetCashReceiptsForCashier =
        @"SELECT CASHRECEIPTS_ID,RECEIPTDATE,CASHIERID,NOTES,AMOUNT FROM CASHRECEIPTS
          WHERE CASHIERID = @CASHIERID AND RECEIPTDATE >= @SHIFTSTARTDATETIME ORDER BY RECEIPTDATE";
    }
}
