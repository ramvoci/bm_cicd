using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BenMedica.Api {
    /// <summary>
    ///  The SmartAltsRequest
    /// </summary>
    public class SmartAltsRequest {
        public string TransactionId { get; set; }
        
        [Required]
        public string PayerId { get; set; }

        public string DrugDatabaseSourceCode { get; set; }

        [Required]
        public SourceProductRequest SourceProductRequest { get; set; }

        
        public List<AlternativeProductRequest> AlternativeProductRequests { get; set; }

    }

    public class DispensableProduct {

        [Required]
        public string Code { get; set; }

       [Required]
        public string Qualifier { get; set; }
    }

    public class SourceProductRequest {

        public string DispensableProductDescription { get; set; }

        [Required]
        public DispensableProduct DispensableProduct { get; set; }

        [Required]
        public int? DaysSupply { get; set; }

        [Required]
        public decimal? Quantity { get; set; }

        [Required]
        public string QuantityUnitOfMeasure { get; set; }

    }

    
    public class AlternativeProductRequest {
        public string DispensableProductDescription { get; set; }

       [Required]
        public DispensableProduct DispensableProduct { get; set; }
    }

}
