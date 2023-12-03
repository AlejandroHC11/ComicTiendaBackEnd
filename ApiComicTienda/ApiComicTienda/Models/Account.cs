using System;
using System.Collections.Generic;

namespace ApiComicTienda.Models
{
    public partial class Account
    {
        public Account()
        {
            Receipts = new HashSet<Receipt>();
        }

        public int AccountId { get; set; }
        public string AccountName { get; set; } = null!;
        public string PasswordData { get; set; } = null!;
        public bool? StateData { get; set; }

        public virtual ICollection<Receipt> Receipts { get; set; }
    }
}
