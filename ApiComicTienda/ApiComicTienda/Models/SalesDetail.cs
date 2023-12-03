using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;

namespace ApiComicTienda.Models
{
    public partial class SalesDetail
    {
        [SwaggerSchema(ReadOnly = true)]
        public int SalesDetailId { get; set; }
        public int? ComicId { get; set; }
        public int? Quantity { get; set; }
        public decimal? UnitPrice { get; set; }
        public int? SalesDetailNumber { get; set; }
    }
}
