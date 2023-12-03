using System;
using System.Collections.Generic;

namespace ApiComicTienda.Models
{
    public partial class Receipt
    {
        public int ReceiptId { get; set; }
        public int? AccountId { get; set; }
        public int? SalesDetailNumber { get; set; }
        public DateTime? DateIssued { get; set; }
        public decimal? TotalAmount { get; set; }
    }
}
