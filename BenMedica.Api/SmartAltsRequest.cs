using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BenMedica.Api {
    /// <summary>
    ///  The SmartAltsRequest
    /// </summary>
    public class SmartAltsRequest {
        /// <summary>
        /// Gets or sets the Transaction id
        /// </summary>
        /// <value>
        /// The Transaction Id
        /// </value>
        public string TransactionId { get; set; }

        /// <summary>
        /// Gets or sets the Payer id
        /// </summary>
        [Required]
        public string PayerId { get; set; }

        /// <summary>
        /// Gets or sets the database source code
        /// </summary>
        public string DrugDatabaseSourceCode { get; set; }

        /// <summary>
        /// Gets or sets the source product request
        /// </summary>
        [Required]
        public SourceProductRequest SourceProductRequest { get; set; }

        /// <summary>
        /// Gets or sets the alternative product requests
        /// </summary>
        public List<AlternativeProductRequest> AlternativeProductRequests { get; set; }

    }

    /// <summary>
    /// The Dispensable Product
    /// </summary>
    public class DispensableProduct {

        /// <summary>
        /// Gets or sets the code
        /// </summary>
        //[Required]
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the qualifier
        /// </summary>
       // [Required]
        public string Qualifier { get; set; }

    }

    /// <summary>
    /// The Source Product Request
    /// </summary>
    public class SourceProductRequest {

        /// <summary>
        /// Gets or sets the dispensable product description
        /// </summary>
        public string DispensableProductDescription { get; set; }

        /// <summary>
        /// Gets or sets the dispensable product
        /// </summary>
       // [Required]
        public DispensableProduct DispensableProduct { get; set; }


        /// <summary>
        /// Gets or sets the DaysSupply
        /// </summary>
        //[Required]
        public int? DaysSupply { get; set; }


        /// <summary>
        /// Gets or sets the Quantity
        /// </summary>
        //[Required]
        public decimal? Quantity { get; set; }


        /// <summary>
        /// Gets or sets the QuantityUnitOfMeasure
        /// </summary>
        //[Required]
        public string QuantityUnitOfMeasure { get; set; }

    }

    /// <summary>
    /// The Alternative Product Request
    /// </summary>
    public class AlternativeProductRequest {
        /// <summary>
        /// Gets or sets the dispensable product description
        /// </summary>
        public string DispensableProductDescription { get; set; }

        /// <summary>
        /// Gets or sets the dispensable product
        /// </summary>
       // [Required]
        public DispensableProduct DispensableProduct { get; set; }
    }

}
