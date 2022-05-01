using System;
using System.Collections.Generic;

namespace WarehouseAPI
{
    public partial class BusinessUser
    {
        public int BsnId { get; set; }
        public int UserId { get; set; }

        public virtual Business Bsn { get; set; } = null!;
        public virtual SysUser User { get; set; } = null!;
    }
}
