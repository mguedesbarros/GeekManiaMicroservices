using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogApi.Application.Models.Category
{
    public class CreateCategoryRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Image { get; set; }
    }
}
