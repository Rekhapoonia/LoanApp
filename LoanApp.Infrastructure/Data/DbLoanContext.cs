using System;
using System.Collections.Generic;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Data;

public partial class DbLoanContext : DbContext
{
    public DbLoanContext()
    {
    }

    public DbLoanContext(DbContextOptions<DbLoanContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblAccountType> TblAccountTypes { get; set; }

    public virtual DbSet<TblBranch> TblBranches { get; set; }

    public virtual DbSet<TblCityMaster> TblCityMasters { get; set; }

    public virtual DbSet<TblDistrictMaster> TblDistrictMasters { get; set; }

    public virtual DbSet<TblLoanMaster> TblLoanMasters { get; set; }

    public virtual DbSet<TblLoanType> TblLoanTypes { get; set; }

    public virtual DbSet<TblOrganisation> TblOrganisations { get; set; }

    public virtual DbSet<TblRoleMaster> TblRoleMasters { get; set; }

    public virtual DbSet<TblStateMaster> TblStateMasters { get; set; }

    public virtual DbSet<TblUserMaster> TblUserMasters { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;database=DbLoan;UID=sa;pwd=1234;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblAccountType>(entity =>
        {
            entity.HasKey(e => e.AccountTypeId).HasName("PK__tbl_acco__6107290A67C9BB3F");

            entity.ToTable("tbl_account_type");

            entity.Property(e => e.AccountTypeId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("account_typeId");
            entity.Property(e => e.AccountTypeName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("account_typeName");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(false)
                .HasColumnName("isActive");
        });

        modelBuilder.Entity<TblBranch>(entity =>
        {
            entity.HasKey(e => e.BranchId).HasName("PK__tbl_bran__751EBD5F1B184BC7");

            entity.ToTable("tbl_branch");

            entity.Property(e => e.BranchId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("branchId");
            entity.Property(e => e.BranchAddress)
                .HasMaxLength(500)
                .HasColumnName("branchAddress");
            entity.Property(e => e.BranchCode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("branchCode");
            entity.Property(e => e.BranchName)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("branchName");
            entity.Property(e => e.BranchOfficeType)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("branchOfficeType");
            entity.Property(e => e.BranchOrganisationId).HasColumnName("branchOrganisationId");
            entity.Property(e => e.BranchRegion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("branchRegion");

            entity.HasOne(d => d.BranchOrganisation).WithMany(p => p.TblBranches)
                .HasForeignKey(d => d.BranchOrganisationId)
                .HasConstraintName("FK__tbl_branc__branc__3B75D760");
        });

        modelBuilder.Entity<TblCityMaster>(entity =>
        {
            entity.HasKey(e => e.CityId).HasName("PK__tbl_city__B4BEB95EF5384545");

            entity.ToTable("tbl_city_master");

            entity.Property(e => e.CityId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("cityId");
            entity.Property(e => e.CityName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("cityName");
            entity.Property(e => e.DistrictId).HasColumnName("districtId");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(false)
                .HasColumnName("isActive");

            entity.HasOne(d => d.District).WithMany(p => p.TblCityMasters)
                .HasForeignKey(d => d.DistrictId)
                .HasConstraintName("FK__tbl_city___distr__4F7CD00D");
        });

        modelBuilder.Entity<TblDistrictMaster>(entity =>
        {
            entity.HasKey(e => e.DistrictId).HasName("PK__tbl_dist__2BAEF7104FD3DCDF");

            entity.ToTable("tbl_district_master");

            entity.Property(e => e.DistrictId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("districtId");
            entity.Property(e => e.DistrictName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("districtName");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(false)
                .HasColumnName("isActive");
            entity.Property(e => e.StateId).HasColumnName("stateId");

            entity.HasOne(d => d.State).WithMany(p => p.TblDistrictMasters)
                .HasForeignKey(d => d.StateId)
                .HasConstraintName("FK__tbl_distr__state__4AB81AF0");
        });

        modelBuilder.Entity<TblLoanMaster>(entity =>
        {
            entity.HasKey(e => e.LoanMasterId).HasName("PK__tbl_loan__140F88BDC111AEEE");

            entity.ToTable("tbl_loan_master");

            entity.Property(e => e.LoanMasterId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("loan_masterId");
            entity.Property(e => e.CreateBy).HasColumnName("createBy");
            entity.Property(e => e.EmiDate)
                .HasColumnType("datetime")
                .HasColumnName("emi_date");
            entity.Property(e => e.EmiReceivedDate)
                .HasColumnType("datetime")
                .HasColumnName("emi_received_date");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(false)
                .HasColumnName("isActive");
            entity.Property(e => e.LoanCloseDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("loanCloseDate");
            entity.Property(e => e.LoanCreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("loanCreateDate");
            entity.Property(e => e.LoanIntrestRate)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("loan_intrest_rate");
            entity.Property(e => e.LoanPeriod).HasColumnName("loan_period");
            entity.Property(e => e.LoanPrincipal)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("loan_principal");
            entity.Property(e => e.LoanPrincipalPending)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("loan_principal_pending");
            entity.Property(e => e.LoanTypeId).HasColumnName("loan_typeId");
            entity.Property(e => e.LoanUserId).HasColumnName("loan_userId");
            entity.Property(e => e.PendingEmi).HasColumnName("pending_emi");

            entity.HasOne(d => d.CreateByNavigation).WithMany(p => p.TblLoanMasterCreateByNavigations)
                .HasForeignKey(d => d.CreateBy)
                .HasConstraintName("FK__tbl_loan___creat__6477ECF3");

            entity.HasOne(d => d.LoanType).WithMany(p => p.TblLoanMasters)
                .HasForeignKey(d => d.LoanTypeId)
                .HasConstraintName("FK__tbl_loan___loan___619B8048");

            entity.HasOne(d => d.LoanUser).WithMany(p => p.TblLoanMasterLoanUsers)
                .HasForeignKey(d => d.LoanUserId)
                .HasConstraintName("FK__tbl_loan___loan___60A75C0F");
        });

        modelBuilder.Entity<TblLoanType>(entity =>
        {
            entity.HasKey(e => e.LoanTypeId).HasName("PK__tbl_loan__612B46C3B8814C71");

            entity.ToTable("tbl_loan_type");

            entity.Property(e => e.LoanTypeId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("loan_typeId");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(false)
                .HasColumnName("isActive");
            entity.Property(e => e.LoanForecloserCharge)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("loan_forecloser_charge");
            entity.Property(e => e.LoanTypeName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("loan_type_Name");
        });

        modelBuilder.Entity<TblOrganisation>(entity =>
        {
            entity.HasKey(e => e.OrganisationId).HasName("PK__tbl_orga__7D097B18127B7A67");

            entity.ToTable("tbl_organisation");

            entity.Property(e => e.OrganisationId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("organisationId");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(false)
                .HasColumnName("isActive");
            entity.Property(e => e.OrganisationAddress)
                .HasMaxLength(500)
                .HasColumnName("organisationAddress");
            entity.Property(e => e.OrganisationName)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("organisationName");
        });

        modelBuilder.Entity<TblRoleMaster>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__tbl_role__CD98462A49252349");

            entity.ToTable("tbl_role_master");

            entity.Property(e => e.RoleId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("roleId");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(false)
                .HasColumnName("isActive");
            entity.Property(e => e.RoleName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("roleName");
        });

        modelBuilder.Entity<TblStateMaster>(entity =>
        {
            entity.HasKey(e => e.StateId).HasName("PK__tbl_stat__A667B9E1DE45F69C");

            entity.ToTable("tbl_state_master");

            entity.Property(e => e.StateId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("stateId");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(false)
                .HasColumnName("isActive");
            entity.Property(e => e.StateName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("stateName");
        });

        modelBuilder.Entity<TblUserMaster>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__tbl_User__CB9A1CFF0910A847");

            entity.ToTable("tbl_User_master");

            entity.HasIndex(e => e.UserMobile, "UQ_tbl_User_master_userMobile").IsUnique();

            entity.Property(e => e.UserId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("userId");
            entity.Property(e => e.CreateBy).HasColumnName("createBy");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(false)
                .HasColumnName("isActive");
            entity.Property(e => e.IsEnabled)
                .HasDefaultValue(false)
                .HasColumnName("isEnabled");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.UserAddress)
                .HasMaxLength(1000)
                .HasColumnName("userAddress");
            entity.Property(e => e.UserCityId).HasColumnName("userCityId");
            entity.Property(e => e.UserCreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("userCreateDate");
            entity.Property(e => e.UserMobile)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("userMobile");
            entity.Property(e => e.UserName)
                .HasMaxLength(500)
                .HasColumnName("userName");
            entity.Property(e => e.UserRoleId).HasColumnName("userRoleId");
            entity.Property(e => e.UserSpouseName)
                .HasMaxLength(500)
                .HasColumnName("userSpouseName");

            entity.HasOne(d => d.CreateByNavigation).WithMany(p => p.InverseCreateByNavigation)
                .HasForeignKey(d => d.CreateBy)
                .HasConstraintName("FK__tbl_User___creat__59063A47");

            entity.HasOne(d => d.UserCity).WithMany(p => p.TblUserMasters)
                .HasForeignKey(d => d.UserCityId)
                .HasConstraintName("FK__tbl_User___userC__5535A963");

            entity.HasOne(d => d.UserRole).WithMany(p => p.TblUserMasters)
                .HasForeignKey(d => d.UserRoleId)
                .HasConstraintName("FK__tbl_User___userR__5441852A");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
