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
                                    (item.DaysSupply, item.Quantity, item.QuantityUnitOfMeasure) = AssignValues("30", "30", "C64933");
                                    break;

                                case "00078037905":
                                    (item.DaysSupply, item.Quantity, item.QuantityUnitOfMeasure) = AssignValues("30", "30", "C64933");
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
                                    (item.DaysSupply, item.Quantity, item.QuantityUnitOfMeasure) = AssignValues("30", "90", "C64933");
                                    break;

                                case "00185067401":
                                    (item.DaysSupply, item.Quantity, item.QuantityUnitOfMeasure) = AssignValues("30", "90", "C64933");
                                    break;

                                default:
                                    break;
                            }
                        }
                    }
                    break;

                case "00071221420":
                    ValidateRequestObject(dispenseCodes);
                    PopulateRequestDrugBasedOnCode(dispenseCodes);
                    if (dispenseCodes.Alternatives.Count > 0) {
                        foreach (var item in dispenseCodes.Alternatives) {
                            switch (item.DispensibleDrug.Code) {
                                case "62756018488":
                                    (item.DaysSupply, item.Quantity, item.QuantityUnitOfMeasure) = AssignValues("30", "90", "C64933");
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
                                    (item.DaysSupply, item.Quantity, item.QuantityUnitOfMeasure) = AssignValues("30", "30", "C64933");
                                    break;

                                case "00000000001":
                                    item.ErrorOccurred = true;
                                    item.Errors = FillErrorArray("*E50E", "Unsupported value: DispensibleDrug.Code not found drug database");
                                    break;

                                case "65862042005":
                                    item.ErrorOccurred = true;
                                    item.Errors = FillErrorArray("*E50F", "Unsupported value: DispensibleDrug.Code not available in SmartAlts");
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

        private Tuple<string, string, string> AssignValues(string v1, string v2, string v3) {
            return Tuple.Create(v1, v2, v3);
        }

        private void PopulateRequestDrugBasedOnCode(DispenseCodes dispenseCodes) {
            switch (dispenseCodes.Source.DispensibleDrug.Code) {

                case "72931001202":
                    Source request = dispenseCodes.Source;
                    (request.DaysSupply, request.Quantity, request.QuantityUnitOfMeasure) = AssignValues("30", "30", "C64933");
                    break;
                case "00093005301":
                    (dispenseCodes.Source.DaysSupply, dispenseCodes.Source.Quantity, dispenseCodes.Source.QuantityUnitOfMeasure) = AssignValues("15", "30", "C64933");
                    break;
                case "00069541066":
                    (dispenseCodes.Source.DaysSupply, dispenseCodes.Source.Quantity, dispenseCodes.Source.QuantityUnitOfMeasure) = AssignValues("30", "90", "C64933");
                    dispenseCodes.Source.ErrorOccurred = true;
                    dispenseCodes.Source.Errors = FillErrorArray("*E50C", "Unsupported value: QuantityUnitOfMeasure has been sunset");
                    break;
                case "00071221420":
                    (dispenseCodes.Source.DaysSupply, dispenseCodes.Source.Quantity, dispenseCodes.Source.QuantityUnitOfMeasure) = AssignValues("30", "240", "C28254");
                    dispenseCodes.Source.ErrorOccurred = true;
                    dispenseCodes.Source.Errors = FillErrorArray("*E50D", "Unsupported value: QuantityUnitOfMeasure does not match drug database");

                    break;

                case "68462019505":
                    (dispenseCodes.Source.DaysSupply, dispenseCodes.Source.Quantity, dispenseCodes.Source.QuantityUnitOfMeasure) = AssignValues("30", "30", "C64933");
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
            dispenseCodes.Errors = FillErrorArray("*E50B", "Missing required property: PayerId");
            dispenseCodes.Source = null;

            return JsonConvert.SerializeObject(dispenseCodes, Formatting.Indented, new JsonSerializerSettings {
                //NullValueHandling = NullValueHandling.Ignore
            });
        }

        public string CheckRequestId(DispenseCodes dispenseCodes) {


            dispenseCodes.ErrorOccurred = true;
            dispenseCodes.Errors = FillErrorArray("*E50A", "Missing required property: Request");
            dispenseCodes.Alternatives = new List<Source>();
            return JsonConvert.SerializeObject(dispenseCodes, Formatting.Indented, new JsonSerializerSettings {
                //NullValueHandling = NullValueHandling.Ignore
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
