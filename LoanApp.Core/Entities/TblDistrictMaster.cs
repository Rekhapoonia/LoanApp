using System;
using System.Collections.Generic;

namespace Entities;

public partial class TblDistrictMaster
{
    public Guid DistrictId { get; set; }

    public string? DistrictName { get; set; }

    public Guid? StateId { get; set; }

    public bool? IsActive { get; set; }

    public virtual TblStateMaster? State { get; set; }

    public virtual ICollection<TblCityMaster> TblCityMasters { get; set; } = new List<TblCityMaster>();
}
