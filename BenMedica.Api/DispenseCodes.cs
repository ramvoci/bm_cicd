using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace BenMedica.Api
{
    public class DispenseCodes
    {
        public string TransactionId { get; set; }

        public string PayerID { get; set; }

        public string DrugDatabaseSourceCode { get; set; }

        public Request Request { get; set; }
      
        public List<Request> Alternatives { get; set; }


    }
    public class DispensibleDrug
    {
        public string Code { get; set; }

        public string Qualifier { get; set; }
        
    }

    public class Request
    {
        public string DispensibleDrugDescription { get; set; }

        public DispensibleDrug DispensibleDrug { get; set; }

        public int DaysSupply { get; set; }

        public string Quantity { get; set; }

        public string QuantityUnitOfMeasure { get; set; }

        public bool ErrorOccurred { get; set; }

        public string ErrorCode { get; set; }

        public string ErrorDescription { get; set; }
    }
}
