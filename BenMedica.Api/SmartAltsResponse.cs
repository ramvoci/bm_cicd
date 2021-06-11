using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Reflection;

namespace BenMedica.Api {

    
    public class SmartAltsResponse {
        public SmartAltsResponse() {
            SourceProductResponse = new SourceProductResponse();
            AlternativeProductResponses = new List<AlternativeProductResponse>();
        }

       public string TransactionId { get; set; }

        
        [Required]
        public string PayerId { get; set; }

        
        [Required]
        public string DrugDatabaseSourceCode { get; set; }

        
        [Required]
        public Guid RequestId => Guid.NewGuid();

       
        [Required]
        public DateTime RequestTime => DateTime.UtcNow;
        //ToString("yyyy-MM-ddTHH\\:mm\\:ss.fffffffzzz");

       
        [Required]
        public string ApiVersion => Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion;

       
        [Required]
        public bool ErrorOccurred { get; set; }

      
        public List<Error> Errors { get; set; }

        
        [Required]
        public SourceProductResponse SourceProductResponse { get; set; }

      
        public List<AlternativeProductResponse> AlternativeProductResponses { get; set; }

    }

    
    public class SourceProductResponse {
        
        public string DispensableProductDescription { get; set; }

        
        public DispensableProduct DispensableProduct { get; set; }

        
        public int DaysSupply { get; set; }

      
        public decimal Quantity { get; set; }

        
        public string QuantityUnitOfMeasure { get; set; }

        [Required]
        public bool ErrorOccurred { get; set; }

        
        public List<Error> Errors { get; set; }

        public SourceProductResponse() {
            DispensableProduct = new DispensableProduct();
        }
        
    }

    public class AlternativeProductResponse {
        
        public string DispensableProductDescription { get; set; }

        
        public DispensableProduct DispensableProduct { get; set; }

        
        public int DaysSupply { get; set; }

        
        public decimal Quantity { get; set; }

      
        public string QuantityUnitOfMeasure { get; set; }

       
        [Required]
        public bool ErrorOccurred { get; set; }

       
        public List<Error> Errors { get; set; }

        public AlternativeProductResponse() {
            DispensableProduct = new DispensableProduct();
        }
    }

    
    public class Error {
        
        [Required]
        public string ErrorCode { get; set; }
        
        [Required]
        public string ErrorDescription { get; set; }
    }


    
    public class HttpClientErrorResponse {
        
        public string TransactionId { get; set; }

        public string PayerId { get; set; }

        
        [Required]
        public Guid RequestId => Guid.NewGuid();

        
        [Required]
        public DateTime RequestTime => DateTime.UtcNow;

        
        [Required]
        public string ApiVersion => Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion;

        
        [Required]
        public List<Error> Errors { get; set; }

    }


}
