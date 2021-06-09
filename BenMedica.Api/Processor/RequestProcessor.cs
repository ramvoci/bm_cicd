using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace BenMedica.Api.Processor {
    public class RequestProcessor {

        private SmartAltsResponse smartAltsResponse;
        public RequestProcessor(SmartAltsResponse AltsResponse) {
            smartAltsResponse = AltsResponse;
        }
        public string ProcessRequest(SmartAltsRequest smartAltsRequest) {

            switch (smartAltsRequest.SourceProductRequest.DispensableProduct.Code) {

                case "72931001202":
                    //checkforErrors
                    ValidateRequestObject(smartAltsRequest);

                    // fill quantity
                    PopulateRequestDrugBasedOnCode(smartAltsRequest);

                    // process alternatives if any
                    if (smartAltsRequest.AlternativeProductRequests.Count > 0) {
                        smartAltsResponse.AlternativeProductResponses = new List<AlternativeProductResponse>();
                        foreach (var item in smartAltsRequest.AlternativeProductRequests) {
                            AlternativeProductResponse alternativeProductResponse = new AlternativeProductResponse();
                            switch (item.DispensableProduct.Code) {
                                case "00074329013":
                                    alternativeProductResponse.DispensableProductDescription = item.DispensableProductDescription;
                                    alternativeProductResponse.DispensableProduct = item.DispensableProduct;
                                    (alternativeProductResponse.DaysSupply, alternativeProductResponse.Quantity, alternativeProductResponse.QuantityUnitOfMeasure) = AssignValues(30, 30, "C64933");
                                    break;

                                case "00078037905":
                                    alternativeProductResponse.DispensableProductDescription = item.DispensableProductDescription;
                                    alternativeProductResponse.DispensableProduct = item.DispensableProduct;
                                    (alternativeProductResponse.DaysSupply, alternativeProductResponse.Quantity, alternativeProductResponse.QuantityUnitOfMeasure) = AssignValues(30, 30, "C64933");
                                    break;

                                default:
                                    alternativeProductResponse.DispensableProductDescription = item.DispensableProductDescription;
                                    alternativeProductResponse.DispensableProduct = item.DispensableProduct;
                                    alternativeProductResponse.ErrorOccurred = true;
                                    alternativeProductResponse.Errors = FillErrorArray("*E50E", "Unsupported value: DispensableProduct.Code not found drug database");
                                    break;
                            }
                            smartAltsResponse.AlternativeProductResponses.Add(alternativeProductResponse);
                        }
                    }
                    break;

                case "00093005301":
                    ValidateRequestObject(smartAltsRequest);
                    PopulateRequestDrugBasedOnCode(smartAltsRequest);
                    break;

                case "00069541066":
                    ValidateRequestObject(smartAltsRequest);
                    PopulateRequestDrugBasedOnCode(smartAltsRequest);

                    if (smartAltsRequest.AlternativeProductRequests.Count > 0) {
                        smartAltsResponse.AlternativeProductResponses = new List<AlternativeProductResponse>();
                        foreach (var item in smartAltsRequest.AlternativeProductRequests) {
                            AlternativeProductResponse alternativeProductResponse = new AlternativeProductResponse();
                            switch (item.DispensableProduct.Code) {
                                case "23155050101":
                                    alternativeProductResponse.DispensableProductDescription = item.DispensableProductDescription;
                                    alternativeProductResponse.DispensableProduct = item.DispensableProduct;
                                    (alternativeProductResponse.DaysSupply, alternativeProductResponse.Quantity, alternativeProductResponse.QuantityUnitOfMeasure) = AssignValues(30, 90, "C64933");
                                    break;

                                case "00185067401":
                                    alternativeProductResponse.DispensableProductDescription = item.DispensableProductDescription;
                                    alternativeProductResponse.DispensableProduct = item.DispensableProduct;
                                    (alternativeProductResponse.DaysSupply, alternativeProductResponse.Quantity, alternativeProductResponse.QuantityUnitOfMeasure) = AssignValues(30, 90, "C64933");
                                    break;

                                default:
                                    alternativeProductResponse.DispensableProductDescription = item.DispensableProductDescription;
                                    alternativeProductResponse.DispensableProduct = item.DispensableProduct;
                                    alternativeProductResponse.ErrorOccurred = true;
                                    alternativeProductResponse.Errors = FillErrorArray("*E50E", "Unsupported value: DispensableProduct.Code not found drug database");
                                    break;
                            }
                            smartAltsResponse.AlternativeProductResponses.Add(alternativeProductResponse);
                        }
                    }
                    break;

                case "00071221420":
                    ValidateRequestObject(smartAltsRequest);
                    PopulateRequestDrugBasedOnCode(smartAltsRequest);
                    if (smartAltsRequest.AlternativeProductRequests.Count > 0) {
                        smartAltsResponse.AlternativeProductResponses = new List<AlternativeProductResponse>();
                        foreach (var item in smartAltsRequest.AlternativeProductRequests) {
                            AlternativeProductResponse alternativeProductResponse = new AlternativeProductResponse();
                            switch (item.DispensableProduct.Code) {
                                case "62756018488":
                                    alternativeProductResponse.DispensableProductDescription = item.DispensableProductDescription;
                                    alternativeProductResponse.DispensableProduct = item.DispensableProduct;
                                    (alternativeProductResponse.DaysSupply, alternativeProductResponse.Quantity, alternativeProductResponse.QuantityUnitOfMeasure) = AssignValues(30, 90, "C64933");
                                    break;
                                default:
                                    alternativeProductResponse.DispensableProductDescription = item.DispensableProductDescription;
                                    alternativeProductResponse.DispensableProduct = item.DispensableProduct;
                                    alternativeProductResponse.ErrorOccurred = true;
                                    alternativeProductResponse.Errors = FillErrorArray("*E50E", "Unsupported value: DispensableProduct.Code not found drug database");
                                    break;
                            }
                            smartAltsResponse.AlternativeProductResponses.Add(alternativeProductResponse);
                        }
                    }
                    break;

                case "68462019505":
                    ValidateRequestObject(smartAltsRequest);
                    PopulateRequestDrugBasedOnCode(smartAltsRequest);

                    if (smartAltsRequest.AlternativeProductRequests.Count > 0) {
                        smartAltsResponse.AlternativeProductResponses = new List<AlternativeProductResponse>();
                        foreach (var item in smartAltsRequest.AlternativeProductRequests) {
                            AlternativeProductResponse alternativeProductResponse = new AlternativeProductResponse();
                            switch (item.DispensableProduct.Code) {
                                case "65862005090":
                                    alternativeProductResponse.DispensableProductDescription = item.DispensableProductDescription;
                                    alternativeProductResponse.DispensableProduct = item.DispensableProduct;
                                    (alternativeProductResponse.DaysSupply, alternativeProductResponse.Quantity, alternativeProductResponse.QuantityUnitOfMeasure) = AssignValues(30, 30, "C64933");
                                    break;

                                case "00000000001":
                                    alternativeProductResponse.DispensableProductDescription = item.DispensableProductDescription;
                                    alternativeProductResponse.DispensableProduct = item.DispensableProduct;
                                    alternativeProductResponse.ErrorOccurred = true;
                                    alternativeProductResponse.Errors = FillErrorArray("*E50E", "Unsupported value: DispensableProduct.Code not found drug database");
                                    break;

                                case "65862042005":
                                    alternativeProductResponse.DispensableProductDescription = item.DispensableProductDescription;
                                    alternativeProductResponse.DispensableProduct = item.DispensableProduct;
                                    alternativeProductResponse.ErrorOccurred = true;
                                    alternativeProductResponse.Errors = FillErrorArray("*E50F", "Unsupported value: DispensableProduct.Code not available in SmartAlts");
                                    break;
                                default:
                                    alternativeProductResponse.DispensableProductDescription = item.DispensableProductDescription;
                                    alternativeProductResponse.DispensableProduct = item.DispensableProduct;
                                    alternativeProductResponse.ErrorOccurred = true;
                                    alternativeProductResponse.Errors = FillErrorArray("*E50E", "Unsupported value: DispensableProduct.Code not found drug database");
                                    break;
                            }
                            smartAltsResponse.AlternativeProductResponses.Add(alternativeProductResponse);
                        }
                    }
                    break;
                case "00093720198":
                    ValidateRequestObject(smartAltsRequest);
                    PopulateRequestDrugBasedOnCode(smartAltsRequest);
                    if (smartAltsRequest.AlternativeProductRequests.Count > 0) {
                        smartAltsResponse.AlternativeProductResponses = new List<AlternativeProductResponse>();
                        foreach (var item in smartAltsRequest.AlternativeProductRequests) {
                            AlternativeProductResponse alternativeProductResponse = new AlternativeProductResponse();
                            switch (item.DispensableProduct.Code) {

                                case "68180047802":
                                    alternativeProductResponse.DispensableProductDescription = item.DispensableProductDescription;
                                    alternativeProductResponse.DispensableProduct = item.DispensableProduct;
                                    (alternativeProductResponse.DaysSupply, alternativeProductResponse.Quantity, alternativeProductResponse.QuantityUnitOfMeasure) = AssignValues(30, 30, "C64933");
                                    break;

                                case "60505257809":
                                    alternativeProductResponse.DispensableProductDescription = item.DispensableProductDescription;
                                    alternativeProductResponse.DispensableProduct = item.DispensableProduct;
                                    (alternativeProductResponse.DaysSupply, alternativeProductResponse.Quantity, alternativeProductResponse.QuantityUnitOfMeasure) = AssignValues(30, 30, "C64933");
                                    break;

                                case "00093744301":
                                    alternativeProductResponse.DispensableProductDescription = item.DispensableProductDescription;
                                    alternativeProductResponse.DispensableProduct = item.DispensableProduct;
                                    (alternativeProductResponse.DaysSupply, alternativeProductResponse.Quantity, alternativeProductResponse.QuantityUnitOfMeasure) = AssignValues(30, 30, "C64933");
                                    break;
                                default:
                                    alternativeProductResponse.DispensableProductDescription = item.DispensableProductDescription;
                                    alternativeProductResponse.DispensableProduct = item.DispensableProduct;
                                    alternativeProductResponse.ErrorOccurred = true;
                                    alternativeProductResponse.Errors = FillErrorArray("*E50E", "Unsupported value: DispensableProduct.Code not found drug database");
                                    break;
                            }
                            smartAltsResponse.AlternativeProductResponses.Add(alternativeProductResponse);
                        }
                    }
                    break;

                default:
                    smartAltsResponse.TransactionId = smartAltsRequest.TransactionId;
                    smartAltsResponse.PayerId = smartAltsRequest.PayerId;
                    smartAltsResponse.DrugDatabaseSourceCode = smartAltsRequest.DrugDatabaseSourceCode;
                    smartAltsResponse.SourceProductResponse.DispensableProductDescription = smartAltsRequest.SourceProductRequest.DispensableProductDescription;
                    smartAltsResponse.SourceProductResponse.DispensableProduct = smartAltsRequest.SourceProductRequest.DispensableProduct;
                    smartAltsResponse.SourceProductResponse.ErrorOccurred = true;
                    smartAltsResponse.SourceProductResponse.Errors = FillErrorArray("*E50E", "Unsupported value: DispensableProduct.Code not found drug database");
                    smartAltsResponse.AlternativeProductResponses = new List<AlternativeProductResponse>();
                    break;
            }

            smartAltsResponse.AlternativeProductResponses = smartAltsResponse.AlternativeProductResponses?.OrderBy(x => x.DispensableProduct.Code).ToList();
            return JsonConvert.SerializeObject(smartAltsResponse, Formatting.Indented, new JsonSerializerSettings {
                NullValueHandling = NullValueHandling.Ignore
            });
        }


        private Tuple<int, double, string> AssignValues(int v1, double v2, string v3) {
            return Tuple.Create(v1, v2, v3);
        }

        private void PopulateRequestDrugBasedOnCode(SmartAltsRequest smartAltsRequest) {
            smartAltsResponse.TransactionId = smartAltsRequest.TransactionId;
            smartAltsResponse.PayerId = smartAltsRequest.PayerId;
            smartAltsResponse.DrugDatabaseSourceCode = smartAltsRequest.DrugDatabaseSourceCode;
            smartAltsResponse.SourceProductResponse.DispensableProductDescription = smartAltsRequest.SourceProductRequest.DispensableProductDescription;
            smartAltsResponse.SourceProductResponse.DispensableProduct = smartAltsRequest.SourceProductRequest.DispensableProduct;
            SourceProductResponse request = smartAltsResponse.SourceProductResponse;
            switch (smartAltsRequest.SourceProductRequest.DispensableProduct.Code) {


                case "72931001202":

                    (request.DaysSupply, request.Quantity, request.QuantityUnitOfMeasure) = AssignValues(30, 30, "C64933");
                    break;
                case "00093005301":
                    (request.DaysSupply, request.Quantity, request.QuantityUnitOfMeasure) = AssignValues(15, 30, "C64933");
                    break;
                case "00069541066":
                    (request.DaysSupply, request.Quantity, request.QuantityUnitOfMeasure) = AssignValues(30, 90, "C64933");
                    request.ErrorOccurred = true;
                    request.Errors = FillErrorArray("*E50C", "Unsupported value: QuantityUnitOfMeasure has been sunset");
                    break;
                case "00071221420":
                    (request.DaysSupply, request.Quantity, request.QuantityUnitOfMeasure) = AssignValues(30, 240, "C28254");
                    request.ErrorOccurred = true;
                    request.Errors = FillErrorArray("*E50D", "Unsupported value: QuantityUnitOfMeasure does not match drug database");

                    break;

                case "68462019505":
                    (request.DaysSupply, request.Quantity, request.QuantityUnitOfMeasure) = AssignValues(30, 30, "C64933");
                    break;

                case "00093720198":
                    (request.DaysSupply, request.Quantity, request.QuantityUnitOfMeasure) = AssignValues(30, 30, "C64933");
                    break;

            }
        }
        private void ValidateRequestObject(SmartAltsRequest smartAltsRequest) {
            smartAltsResponse.TransactionId = smartAltsRequest.TransactionId;
            smartAltsResponse.PayerId = null;
            smartAltsResponse.DrugDatabaseSourceCode = smartAltsRequest.DrugDatabaseSourceCode;

            if (smartAltsRequest.SourceProductRequest.Quantity == null || smartAltsRequest.SourceProductRequest.DaysSupply == null || smartAltsRequest.SourceProductRequest.QuantityUnitOfMeasure == null) {
                smartAltsResponse.SourceProductResponse.ErrorOccurred = true;
                List<Error> errors = new List<Error>();
                if (smartAltsRequest.SourceProductRequest.DaysSupply == null) {
                    errors.Add(new Error {
                        ErrorCode = "*E00B",
                        ErrorDescription = "Missing required property: DaysSupply"
                    });
                };

                if (smartAltsRequest.SourceProductRequest.Quantity == null) {
                    errors.Add(new Error {
                        ErrorCode = "*E00C",
                        ErrorDescription = "Missing required property: Quantity"
                    });
                };

                if (smartAltsRequest.SourceProductRequest.QuantityUnitOfMeasure == null) {
                    errors.Add(new Error {
                        ErrorCode = "*E00D",
                        ErrorDescription = "Missing required property: QuantityUnitOfMeasure"
                    });
                };
                smartAltsResponse.SourceProductResponse.Errors = errors;
            }
        }


        public string GenerateErrorResponse(ModelStateDictionary modelState, SmartAltsRequest smartAltsRequest) {
            List<Error> errors = new List<Error>();
            foreach (var item in modelState.Keys) {
                if (item == "PayerId") {
                    errors.Add(new Error {
                        ErrorCode = "*E50B",
                        ErrorDescription = "Missing required property: PayerId"
                    });
                }
                if (item == "SourceProductRequest") {
                    errors.Add(new Error {
                        ErrorCode = "*E50A",
                        ErrorDescription = "Missing required object: SourceProductRequest"
                    });
                }
            }
            return JsonConvert.SerializeObject(
                        new HttpClientErrorResponse {
                            TransactionId = smartAltsRequest.TransactionId,
                            PayerId = smartAltsRequest.PayerId,
                            DrugDatabaseSourceCode = smartAltsRequest.DrugDatabaseSourceCode,
                            ErrorOccurred = true,
                            Errors = errors

                        }, Formatting.Indented, new JsonSerializerSettings {
                            NullValueHandling = NullValueHandling.Ignore
                        });

        }

        private List<Error> FillErrorArray(string errorCode, string errorDescription) {
            return new List<Error> {
                        new Error {
                            ErrorCode = errorCode,
                            ErrorDescription = errorDescription
                        }
                    };
        }

    }
}
