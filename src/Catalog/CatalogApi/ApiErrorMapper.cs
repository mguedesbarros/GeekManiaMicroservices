using CatalogApi.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogApi
{
    public static class ApiErrorMapper
    {
        public static ErrorResponse GetErrorResponse(this ModelStateDictionary modelState)
        {

            var errors = modelState.Values.SelectMany(v => v.Errors).Select(p => p.ErrorMessage.ToString());

            return new ErrorResponse(errors.ToList());
        }
    }
}
