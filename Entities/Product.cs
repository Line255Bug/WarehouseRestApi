using System;
using System.Collections.Generic;

namespace WarehouseAPI
{
    public partial class Product
    {
        public string ProdSku { get; set; } = null!;
        public string? ProdName { get; set; }
        public decimal? ProdPrice { get; set; }
        public string? ProdDescription { get; set; }
    }
}
