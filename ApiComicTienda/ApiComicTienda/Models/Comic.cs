using System;
using System.Collections.Generic;

namespace ApiComicTienda.Models
{
    public partial class Comic
    {
        public Comic()
        {
            SalesDetails = new HashSet<SalesDetail>();
        }

        public int ComicId { get; set; }
        public string? ImageLink { get; set; }
        public string? ComicName { get; set; }
        public string? Franchise { get; set; }
        public int? Stock { get; set; }
        public decimal? Price { get; set; }

        public virtual ICollection<SalesDetail> SalesDetails { get; set; }
    }
}
