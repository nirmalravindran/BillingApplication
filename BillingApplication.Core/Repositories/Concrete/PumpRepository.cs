using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using BillingApplication.Core.DataAccess;
using BillingApplication.Core.DomainModels;
using BillingApplication.Core.Helpers;
using BillingApplication.Core.Queries;
using ConcreteDataAccess = BillingApplication.Core.DataAccess.Concrete;
using BillingApplication.Core.Reporting;

namespace BillingApplication.Core.Repositories.Concrete
{
    public class PumpRepository : IPumpRepository
    {
         public PumpRepository()
         {}

        #region IPumpRepository Members

         public IEnumerable<Pump> GetPumpForCashier(Guid cashierId)
         {
             using (var dataAccess = new ConcreteDataAccess.DataAccess())
             {
                 var parameters = new Dictionary<string, object>
             {
                 { "CASHIERID", cashierId }
             };

                 var pumpShiftDetails = dataAccess.GetData(PumpQueries.GetPumpShiftDetailsForCashier, parameters).AsEnumerable().ToList();

                 if (pumpShiftDetails.Any())
                     return pumpShiftDetails.Select(row => RowToDomainModelConverter.ConvertToPumpWithShiftDetails(row));

                 var pumpTable = dataAccess.GetData(PumpQueries.GetPumpForCashier, parameters);

                 return pumpTable.AsEnumerable().Select(row => RowToDomainModelConverter.ConvertToPump(row)).ToList();
             }
         }

         public void SavePump(Pump pump)
         {
             using (var dataAccess = new ConcreteDataAccess.DataAccess())
             {
                 var table = DomainModelToRowConverter.CreatePumpTable();
                 var row = table.NewRow();
                 DomainModelToRowConverter.ConvertPumpToRow(pump, row);
                 table.Rows.Add(row);
                 dataAccess.SaveData(table, Constants.Pump.TableName);
             }
         }

         public void SavePumpShiftDetails(IEnumerable<Pump> pumpDetails, Guid leavingCashier)
         {
             using (var dataAccess = new ConcreteDataAccess.DataAccess())
             {
                 try
                 {
                     dataAccess.BeginTransaction();
                     var currentTime = DateTime.Now;
                     UpdatePumps(dataAccess, pumpDetails, leavingCashier, currentTime);
                     UpdatePumpShiftDetails(dataAccess, pumpDetails, leavingCashier, currentTime);
                     dataAccess.Transaction.Commit();
                 }
                 catch(Exception e)
                 {
                     dataAccess.Transaction.Rollback();
                     throw e;
                 }
             }
         }

         public Report UpdateShiftCloseComplete(Pump[] pumps, Bill[] bills, decimal cashPaidByEmployee, Expenses[] expenses)
         {
             using (var dataAccess = new ConcreteDataAccess.DataAccess())
             {
                 try
                 {
                     var cashierId = pumps.First().PumpShiftDetails.Single().Cashier.PrimaryKey;
                     var parameters = new Dictionary<string, object>{{ "CASHIERID", cashierId}};
                     dataAccess.BeginTransaction();
                     dataAccess.ExecuteQuery(PumpQueries.UpdateShiftCloseComplete, parameters);
                     var report = new ShiftCloseReport().GenerateReport(pumps, bills, cashPaidByEmployee, expenses);
                     dataAccess.Transaction.Commit();
                     return report;
                 }
                 catch(Exception e)
                 {
                     dataAccess.Transaction.Rollback();
                     throw e;
                 }
             }
         }

         public void AddProducts(Guid productID, int count)
         {
             using (var dataAccess = new ConcreteDataAccess.DataAccess())
             {
                 var parameters = new Dictionary<string, object>
             {
                 { "PRODUCTID", productID},
                 { "COUNT", count}
             };
                 dataAccess.ExecuteQuery(PumpQueries.AddProducts, parameters);
             }
         }

        #endregion

         private void UpdatePumps(IDataAccess dataAccess, IEnumerable<Pump> pumpDetails, Guid leavingCashier, DateTime timeToBeSaved)
         {
             var parameters = new Dictionary<string, object>
             {
                 { "CASHIERID", leavingCashier }
             };

             var table = dataAccess.GetData(PumpQueries.GetPumpForCashier, parameters);
             var pumpData = table.AsEnumerable().ToList();

             foreach (var pump in pumpDetails)
             {
                 var matchingRow = pumpData.Where(row => pump.PrimaryKey == row.Field<Guid>(Constants.Pump.Fields.PrimaryKey)).First();
                 matchingRow.SetField("CASHIER", pump.PumpShiftDetails.First().Cashier.PrimaryKey);
                 matchingRow.SetField("CURRENTREADING", pump.PumpShiftDetails.First().ClosingReading);
                 matchingRow.SetField("LASTUPDATED", timeToBeSaved);
             }
             dataAccess.SaveData(table, Constants.Pump.TableName);
         }

         private void UpdatePumpShiftDetails(IDataAccess dataAccess, IEnumerable<Pump> pumpDetails, Guid leavingCashier, DateTime timeToBeSaved)
         {
             foreach (var pump in pumpDetails)
             {
                 var table = DomainModelToRowConverter.CreatePumpShiftDetailsTable();
                 foreach (var pumpShiftDetails in pump.PumpShiftDetails)
                 {
                     var row = table.NewRow();
                     DomainModelToRowConverter.ConvertPumpShiftDetailsToRow(pumpShiftDetails, row, timeToBeSaved);
                     row.SetField("CASHIER", leavingCashier);
                     table.Rows.Add(row);
                 }
                 dataAccess.SaveData(table, Constants.PumpShiftDetails.TableName);
             }
         }   
    }
}
