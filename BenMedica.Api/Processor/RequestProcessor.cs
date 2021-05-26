using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BenMedica.Api.Processor {
    public class RequestProcessor {

        public string ProcessRequest(DispenseCodes dispenseCodes) {


            switch (dispenseCodes.Source.DispensibleDrug.Code) {

                case "72931001202":
                    //checkforErrors
                    ValidateRequestObject(dispenseCodes);

                    // fill quantity
                    PopulateRequestDrugBasedOnCode(dispenseCodes);

                    // process alternatives if any
                    if (dispenseCodes.Alternatives.Count > 0) {
                        foreach (var item in dispenseCodes.Alternatives) {
                            switch (item.DispensibleDrug.Code) {
                                case "00074329013":
                                    item.DaysSupply = "30";
                                    item.Quantity = "30";
                                    item.QuantityUnitOfMeasure = "C64933";
                                    break;

                                case "00078037905":
                                    item.DaysSupply = "30";
                                    item.Quantity = "30";
                                    item.QuantityUnitOfMeasure = "C64933";
                                    break;

                                default:
                                    break;
                            }

                        }
                        //var pipeSeparatedAlternatives = string.Join("|", dispenseCodes.Alternatives?.Select(x => x.DispensibleDrug.Code));
                        //ProcessForAlterntives(pipeSeparatedAlternatives);
                    }
                    break;
                case "00093005301":
                    ValidateRequestObject(dispenseCodes);
                    PopulateRequestDrugBasedOnCode(dispenseCodes);

                    break;
                case "00069541066":
                    ValidateRequestObject(dispenseCodes);
                    PopulateRequestDrugBasedOnCode(dispenseCodes);
                    if (dispenseCodes.Alternatives.Count > 0) {
                        foreach (var item in dispenseCodes.Alternatives) {
                            switch (item.DispensibleDrug.Code) {
                                case "23155050101":
                                    item.DaysSupply = "30";
                                    item.Quantity = "90";
                                    item.QuantityUnitOfMeasure = "C64933";
                                    break;

                                case "00185067401":
                                    item.DaysSupply = "30";
                                    item.Quantity = "90";
                                    item.QuantityUnitOfMeasure = "C64933";
                                    break;

                                default:
                                    break;
                            }

                        }
                        //var pipeSeparatedAlternatives = string.Join("|", dispenseCodes.Alternatives?.Select(x => x.DispensibleDrug.Code));
                        //ProcessForAlterntives(pipeSeparatedAlternatives);
                    }
                    break;
                case "00071221420":
                    ValidateRequestObject(dispenseCodes);
                    PopulateRequestDrugBasedOnCode(dispenseCodes);
                    if (dispenseCodes.Alternatives.Count > 0) {
                        foreach (var item in dispenseCodes.Alternatives) {
                            switch (item.DispensibleDrug.Code) {
                                case "62756018488":
                                    item.DaysSupply = "30";
                                    item.Quantity = "90";
                                    item.QuantityUnitOfMeasure = "C64933";
                                    break;

                            }
                        }

                    }
                    break;
                case "68462019505":
                    ValidateRequestObject(dispenseCodes);
                    PopulateRequestDrugBasedOnCode(dispenseCodes);

                    if (dispenseCodes.Alternatives.Count > 0) {

                        foreach (var item in dispenseCodes.Alternatives) {
                            
                            switch (item.DispensibleDrug.Code) {
                                case "65862005090":
                                    item.DaysSupply = "30";
                                    item.Quantity = "30";
                                    item.QuantityUnitOfMeasure = "C64933";
                                    break;

                                case "00000000001":
                                    item.ErrorOccurred = true;
                                    item.Errors = new List<Error>{
                                            new Error {
                                                    ErrorCode = "*E50E",
                                                    ErrorDescription = "Unsupported value: DispensibleDrug.Code not found drug database"
                                            } };
                                   break;

                                case "65862042005":
                                    item.ErrorOccurred = true;
                                    item.Errors = new List<Error>{
                                            new Error {
                                                    ErrorCode = "*E50F",
                                                    ErrorDescription = "Unsupported value: DispensibleDrug.Code not available in SmartAlts"
                                            } };
                                    break;

                            }
                           
                        }


                    }
                    break;


            }



            dispenseCodes.Alternatives = dispenseCodes.Alternatives?.OrderBy(x => x.DispensibleDrug.Code).ToList();
            return JsonConvert.SerializeObject(dispenseCodes, Formatting.Indented, new JsonSerializerSettings {
                NullValueHandling = NullValueHandling.Ignore
            });
        }

        private void ProcessForAlterntives(string pipeSeparatedAlternatives) {
            switch (pipeSeparatedAlternatives) {
                case "00074329013|00078037905":

                    break;
            }
        }

        private void PopulateRequestDrugBasedOnCode(DispenseCodes dispenseCodes) {
            switch (dispenseCodes.Source.DispensibleDrug.Code) {

                case "72931001202":
                    Source request = dispenseCodes.Source;
                    request.DaysSupply = "30";
                    request.Quantity = "30";
                    request.QuantityUnitOfMeasure = "C64933";

                    break;
                case "00093005301":

                    dispenseCodes.Source.DaysSupply = "15";
                    dispenseCodes.Source.Quantity = "30";
                    dispenseCodes.Source.QuantityUnitOfMeasure = "C48542";
                    break;
                case "00069541066":
                    dispenseCodes.Source.DaysSupply = "30";
                    dispenseCodes.Source.Quantity = "90";
                    dispenseCodes.Source.QuantityUnitOfMeasure = "C64933";
                    dispenseCodes.Source.ErrorOccurred = true;
                    dispenseCodes.Source.Errors = new List<Error>{
                        new Error {
                        ErrorCode = "*E50C",
                        ErrorDescription = "Unsupported value: QuantityUnitOfMeasure has been sunset"
                    } };
                    break;
                case "00071221420":
                    dispenseCodes.Source.DaysSupply = "30";
                    dispenseCodes.Source.Quantity = "240";
                    dispenseCodes.Source.QuantityUnitOfMeasure = "C28254";
                    dispenseCodes.Source.ErrorOccurred = true;
                    dispenseCodes.Source.Errors = new List<Error>{
                        new Error {
                        ErrorCode = "*E50D",
                        ErrorDescription = "Unsupported value: QuantityUnitOfMeasure does not match drug database"
                    } };

                    break;

                case "68462019505":
                    dispenseCodes.Source.DaysSupply = "30";
                    dispenseCodes.Source.Quantity = "30";
                    dispenseCodes.Source.QuantityUnitOfMeasure = "C64933";
                    break;
            }
        }
        private void ValidateRequestObject(DispenseCodes dispenseCodes) {
            if (dispenseCodes.Source.Quantity == null || dispenseCodes.Source.QuantityUnitOfMeasure == null || dispenseCodes.Source.QuantityUnitOfMeasure == null) {
                dispenseCodes.Source.ErrorOccurred = true;
                List<Error> errors = new List<Error>();
                if (dispenseCodes.Source.DaysSupply == null) {
                    errors.Add(new Error {
                        ErrorCode = "*E00B",
                        ErrorDescription = "Missing required property: DaysSupply"
                    });
                };

                if (dispenseCodes.Source.Quantity == null) {
                    errors.Add(new Error {
                        ErrorCode = "*E00C",
                        ErrorDescription = "Missing required property: Quantity"
                    });
                };

                if (dispenseCodes.Source.QuantityUnitOfMeasure == null) {
                    errors.Add(new Error {
                        ErrorCode = "*E00D",
                        ErrorDescription = "Missing required property: QuantityUnitOfMeasure"
                    });
                };
                dispenseCodes.Source.Errors = errors;
            }
        }

        public string CheckPayerId(DispenseCodes dispenseCodes) {


            dispenseCodes.ErrorOccurred = true;
            dispenseCodes.Errors = new List<Error> {
                        new Error {
                            ErrorCode = "*E50B",
                            ErrorDescription = "Missing required property: PayerId"
                        }
                    };
            dispenseCodes.Source = null;

            return JsonConvert.SerializeObject(dispenseCodes, Formatting.Indented, new JsonSerializerSettings {
                //NullValueHandling = NullValueHandling.Ignore
            });
        }

        public string CheckRequestId(DispenseCodes dispenseCodes) {


            dispenseCodes.ErrorOccurred = true;
            dispenseCodes.Errors = new List<Error> {
                        new Error {
                            ErrorCode = "*E50A",
                            ErrorDescription = "Missing required property: Request"
                        }
                    };
            dispenseCodes.Alternatives = new List<Source>();
            return JsonConvert.SerializeObject(dispenseCodes, Formatting.Indented, new JsonSerializerSettings {
                //NullValueHandling = NullValueHandling.Ignore
            });
        }

    }
}
