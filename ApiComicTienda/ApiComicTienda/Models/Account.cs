using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;

namespace ApiComicTienda.Models
{
    public partial class Account
    {
        [SwaggerSchema(ReadOnly = true)]
        public int AccountId { get; set; }
        public string AccountName { get; set; } = null!;
        public string PasswordData { get; set; } = null!;
        public bool? StateData { get; set; }
    }
}
