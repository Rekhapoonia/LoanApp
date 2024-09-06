using System;
using System.Collections.Generic;

namespace Entities;

public partial class TblBranch
{
    public Guid BranchId { get; set; }

    public string? BranchCode { get; set; }

    public string? BranchName { get; set; }

    public string? BranchAddress { get; set; }

    public Guid? BranchOrganisationId { get; set; }

    public string? BranchOfficeType { get; set; }

    public string? BranchRegion { get; set; }

    public virtual TblOrganisation? BranchOrganisation { get; set; }
}
