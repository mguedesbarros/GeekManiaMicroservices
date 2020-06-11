﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogApi.Models
{
    public class ErrorResponse : BaseResponse
    {

        public ErrorResponse(List<string> erros)
        {
            this.Erros = erros;
        }
    }
}
