using System;
using System.Collections.Generic;

namespace ApiComicTienda.Models
{
    public partial class Receipt
    {
        public int ReceiptId { get; set; }
        public string? Account { get; set; }
        public DateTime? DateIssued { get; set; }
        public decimal? TotalAmount { get; set; }

        public virtual Account? AccountNavigation { get; set; }
    }
}
