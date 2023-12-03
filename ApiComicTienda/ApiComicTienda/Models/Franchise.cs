using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;

namespace ApiComicTienda.Models
{
    public partial class Franchise
    {
        [SwaggerSchema(ReadOnly = true)]
        public int FranchiseId { get; set; }
        public string? FranchiseName { get; set; }
    }
}
