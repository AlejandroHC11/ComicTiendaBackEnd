using System;
using System.Collections.Generic;

namespace ApiComicTienda.Models
{
    public partial class Comic
    {
        public int ComicId { get; set; }
        public string? ImageLink { get; set; }
        public string? ComicName { get; set; }
        public int? FranchiseId { get; set; }
        public int? Stock { get; set; }
        public decimal? Price { get; set; }
    }
}
