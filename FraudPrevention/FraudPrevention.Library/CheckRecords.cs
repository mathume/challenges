using System;
using System.Collections.Generic;
using System.Linq;
using FraudPrevention.Data;

namespace FraudPrevention
{
    public class CheckRecords
    {
        private IEnumerable<Record> records;

        public CheckRecords(IEnumerable<Record> records)
        {
            this.records = records;
        }

        public IEnumerable<long> CheckForFraudulentOrderIds()
        {
            var fraudulent1 = from r in this.records
                              group r by new
                              {
                                  r.DealId,
                                  r.EmailAddress.Value
                              } into coincide1
                              select new 
                              {
                                  DealId = coincide1.Key.DealId,
                                  CreditCardNumbers = coincide1.ToList().Select(r => r.CreditCardNumber)
                              };
            var fraudulent2 = from r in this.records
                              group r by new
                              {
                                  DealId = r.DealId,
                                  StreetAddress = r.StreetAddress.Value,
                                  State = r.State.Value,
                                  City = r.City.Value,
                                  ZipCode = r.ZipCode.Value
                              } into coincide2
                              select new
                              {
                                  DealId = coincide2.Key.DealId,
                                  CreditCardNumbers = coincide2.ToList().Select(r => r.CreditCardNumber)
                              };
            var fraudulent = new List<long>();
            fraudulent.AddRange(fraudulent1.Where(r => r.CreditCardNumbers.Distinct().Count() > 1).Select(r => r.DealId));
            fraudulent.AddRange(fraudulent2.Where(r => r.CreditCardNumbers.Distinct().Count() > 1).Select(r => r.DealId));
            fraudulent.Sort();
            return fraudulent.Distinct();
        }
    }
}