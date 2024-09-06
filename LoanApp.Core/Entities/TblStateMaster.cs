using System;
using System.Collections.Generic;

namespace Entities;

public partial class TblStateMaster
{
    public Guid StateId { get; set; }

    public string? StateName { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<TblDistrictMaster> TblDistrictMasters { get; set; } = new List<TblDistrictMaster>();
}
