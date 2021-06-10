using System;
using System.Collections.Generic;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace BenMedica.Api {
    public class RequireValueTypePropertiesSchemaFilter : ISchemaFilter {
        private readonly HashSet<OpenApiSchema> _valueTypes = new HashSet<OpenApiSchema>();

        public void Apply(OpenApiSchema model, SchemaFilterContext context) {
            //if(context.Type.Name=="DateTime") {
            //    model.Example = null;
            //}
            //if (!context.Type.IsValueType && model.Properties != null) {
            //   // model.Nullable=false;
            //}
        }
    }
}