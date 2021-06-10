using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Reflection;

namespace BenMedica.Api {

    /// <summary>
    /// The SmartAltsResponse
    /// </summary>
    public class SmartAltsResponse {
        public SmartAltsResponse() {
            SourceProductResponse = new SourceProductResponse();
            AlternativeProductResponses = new List<AlternativeProductResponse>();
        }

        /// <summary>
        /// Gets or sets the Transaction id
        /// </summary>
        public string TransactionId { get; set; }

        /// <summary>
        /// Gets or sets the Payer id
        /// </summary>
        [Required]
        public string PayerId { get; set; }

        /// <summary>
        /// Gets or sets the database source code
        /// </summary>
        [Required]
        public string DrugDatabaseSourceCode { get; set; }

        /// <summary>
        ///  Gets or sets the request id
        /// </summary>
        [Required]
        public Guid RequestId => Guid.NewGuid();

        /// <summary>
        /// Gets or sets the request time
        /// </summary>
        [Required]
        public DateTime RequestTime => DateTime.UtcNow;
        //ToString("yyyy-MM-ddTHH\\:mm\\:ss.fffffffzzz");

        /// <summary>
        /// Gets or sets the Api version
        /// </summary>
        [Required]
        public string ApiVersion => Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion;

        /// <summary>
        /// Gets or sets the ErrorOccurred
        /// </summary>
        [Required]
        public bool ErrorOccurred { get; set; }

        /// <summary>
        /// Gets or sets the errors
        /// </summary>
        public List<Error> Errors { get; set; }

        /// <summary>
        /// Gets or sets the source product response
        /// </summary>
        [Required]
        public SourceProductResponse SourceProductResponse { get; set; }

        /// <summary>
        /// Gets or sets the alternative product responses
        /// </summary>
        public List<AlternativeProductResponse> AlternativeProductResponses { get; set; }

    }

    /// <summary>
    /// The SourceProductResponse
    /// </summary>
    public class SourceProductResponse {
        /// <summary>
        /// Gets or sets the dispensable product description
        /// </summary>
        public string DispensableProductDescription { get; set; }

        /// <summary>
        ///  Gets or sets the dispensable product
        /// </summary>
        public DispensableProduct DispensableProduct { get; set; }

        /// <summary>
        /// Gets or sets the daysSupply
        /// </summary>
        public int DaysSupply { get; set; }

        /// <summary>
        /// Gets or sets the quantity
        /// </summary>
        public decimal Quantity { get; set; }

        /// <summary>
        /// Gets or sets the quantity unit of measure
        /// </summary>
        public string QuantityUnitOfMeasure { get; set; }

        /// <summary>
        /// Gets or sets the errorOccurred
        /// </summary>
        public bool ErrorOccurred { get; set; }

        /// <summary>
        /// Gets or sets the errors
        /// </summary>
        public List<Error> Errors { get; set; }

        public SourceProductResponse() {
            DispensableProduct = new DispensableProduct();
        }
        
    }

    /// <summary>
    /// Gets or sets the alternative product response
    /// </summary>
    public class AlternativeProductResponse {
        /// <summary>
        /// Gets or sets the dispensable product description
        /// </summary>
        public string DispensableProductDescription { get; set; }

        /// <summary>
        /// Gets or sets the dispensable product
        /// </summary>
        public DispensableProduct DispensableProduct { get; set; }

        /// <summary>
        /// Gets or sets the days supply
        /// </summary> 
        public int? DaysSupply { get; set; }

        /// <summary>
        /// Gets or sets the quantity
        /// </summary>
        public decimal? Quantity { get; set; }

        /// <summary>
        /// Gets or sets the quantity unit of measure
        /// </summary>
        public string QuantityUnitOfMeasure { get; set; }

        /// <summary>
        /// Gets or sets the errorOccurred
        /// </summary>
        [Required]
        public bool ErrorOccurred { get; set; }

        /// <summary>
        /// Gets or sets the errors
        /// </summary>
        public List<Error> Errors { get; set; }

        public AlternativeProductResponse() {
            DispensableProduct = new DispensableProduct();
        }
    }

    /// <summary>
    /// The Error
    /// </summary>
    public class Error {
        /// <summary>
        /// Gets or sets the error code
        /// </summary>
        [Required]
        public string ErrorCode { get; set; }
        /// <summary>
        /// Gets or sets the error description
        /// </summary>
        [Required]
        public string ErrorDescription { get; set; }
    }


    /// <summary>
    /// The HttpClientErrorResponse
    /// </summary>
    public class HttpClientErrorResponse {
        /// <summary>
        /// Gets or sets the transaction id
        /// </summary>
        public string TransactionId { get; set; }

        /// <summary>
        /// Gets or sets the payer id
        /// </summary>
        public string PayerId { get; set; }

        /// <summary>
        /// Gets or sets the request id
        /// </summary>
        [Required]
        public Guid RequestId => Guid.NewGuid();

        /// <summary>
        /// Gets or sets the request time
        /// </summary>
        [Required]
        public DateTime RequestTime => DateTime.UtcNow;

        /// <summary>
        /// Gets or sets the api version
        /// </summary>
        [Required]
        public string ApiVersion => Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion;

        /// <summary>
        /// Gets or sets the errors
        /// </summary>
        [Required]
        public List<Error> Errors { get; set; }

    }


}
