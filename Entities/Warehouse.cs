using System;
using System.Collections.Generic;

namespace WarehouseAPI
{
    public partial class Warehouse
    {
        public Warehouse()
        {
            StorageCategories = new HashSet<StorageCategory>();
            WarehouseSections = new HashSet<WarehouseSection>();
        }

        public int WrhId { get; set; }
        public int BusinessId { get; set; }
        public string WrhName { get; set; } = null!;
        public string WrhRegion { get; set; } = null!;
        public string WrhProvince { get; set; } = null!;
        public string WrhCommune { get; set; } = null!;
        public string WrhAddress { get; set; } = null!;
        public short WrhAddressNum { get; set; }

        public virtual Business Business { get; set; } = null!;
        public virtual ICollection<StorageCategory> StorageCategories { get; set; }
        public virtual ICollection<WarehouseSection> WarehouseSections { get; set; }
    }
}
