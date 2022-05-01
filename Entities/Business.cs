using System;
using System.Collections.Generic;

namespace WarehouseAPI
{
    public partial class Business
    {
        public Business()
        {
            Warehouses = new HashSet<Warehouse>();
        }

        public int BsnId { get; set; }
        public string BsnName { get; set; } = null!;
        public string BsnRut { get; set; } = null!;

        public virtual ICollection<Warehouse> Warehouses { get; set; }
    }
}
