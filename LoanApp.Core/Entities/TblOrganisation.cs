using System;
using System.Collections.Generic;

namespace Entities;

public partial class TblOrganisation
{
    public Guid OrganisationId { get; set; }

    public string? OrganisationName { get; set; }

    public string? OrganisationAddress { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<TblBranch> TblBranches { get; set; } = new List<TblBranch>();
}
