using System;
using System.Collections.Generic;

namespace Entities;

public partial class TblRoleMaster
{
    public Guid RoleId { get; set; }

    public string? RoleName { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<TblUserMaster> TblUserMasters { get; set; } = new List<TblUserMaster>();
}
