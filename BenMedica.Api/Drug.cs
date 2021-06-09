using System;
using Microsoft.AspNetCore.Mvc;

namespace BenMedica.Api
{
    public class Drug
    {
        public DateTime Date { get; set; }

        public string Codes { get; set; }

        public string Description { get; set; }
       
    }

    internal class ErrorSchema : ProblemDetails {
        public bool ErrorOccured { get; set; }
        public string ErrorCode { get; set; }
    }
}
