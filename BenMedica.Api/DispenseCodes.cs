using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace BenMedica.Api
{
    public class DispenseCodes
    {
        public string TransactionId { get; set; }

        public string PayerId { get; set; }

        public string DrugDatabaseSourceCode { get; set; }
        public Guid RequestId => Guid.NewGuid();
        public DateTime RequestTime => DateTime.Now;
        public string ApiVersion => Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion;

        public bool ErrorOccurred { get; set; }

        public List<Error> Errors { get; set; }

        public Source Source { get; set; }
      
        public List<Source> Alternatives { get; set; }




    }
    public class DispensibleDrug
    {
        public string Code { get; set; }

        public string Qualifier { get; set; }
        
    }

    public class Source
    {
        public string DispensibleDrugDescription { get; set; }

        public DispensibleDrug DispensibleDrug { get; set; }

        public string DaysSupply { get; set; }

        public string Quantity { get; set; }

        public string QuantityUnitOfMeasure { get; set; }

        public bool ErrorOccurred { get; set; }

        public List<Error> Errors { get; set; } 
    }

    public class Error {
        public string ErrorCode { get; set; }
        public string ErrorDescription { get; set; }
    }
}