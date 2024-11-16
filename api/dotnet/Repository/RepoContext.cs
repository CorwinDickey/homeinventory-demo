using Domain;
using Domain.Inventory;
using Domain.MetaData;
using Domain.User;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    /// <summary>
    /// DbContext used for the HomeInventory-Demo .NET API application
    /// </summary>
    public class RepoContext(
        DbContextOptions<RepoContext> options,
        IHttpContextAccessor? httpContext = null)
        : DbContext(options), IRepoContext
    {
        /// <summary>
        /// Holds a Guid consisting only of zeros to identify the system user
        /// </summary>
        public const string ConstSysAdminAzureId = "00000000-0000-0000-000000000000";

        /// <summary>
        /// Gets or sets the UserId Azure Object Id for use in the application context
        /// </summary>
        private int _userId { get; set; }

        #region Entity Declarations

        /// <summary>
        /// The set of application user entities in the context
        /// </summary>
        public DbSet<ApplicationUser> AppUsers { get; set; }

        /// <summary>
        /// The set of login record entities in the context
        /// </summary>
        public DbSet<LoginRecord> LoginRecords { get; set; }

        /// <summary>
        /// The set of inventory item entities in the context
        /// </summary>
        public DbSet<InventoryItem> InventoryItems { get; set; }

        /// <summary>
        /// The set of item file entities in the context
        /// </summary>
        public DbSet<ItemFile> ItemFiles { get; set; }

        /// <summary>
        /// The set of file blob entities in the context
        /// </summary>
        public DbSet<FileBlob> FileBlobs { get; set; }
        #endregion

        /// <inheritdoc/>
        public IQueryable<T> Get<T>()
            where T : class
        {
            return Set<T>();
        }

        /// <inheritdoc/>
        public async Task<int> SaveAsync(
            CancellationToken cancellationToken = default)
        {
            SetUserId();
            ChangeTracker.DetectChanges();
            var entries = ChangeTracker.Entries<AuditableEntity>()
                .Where(x => x.State != EntityState.Unchanged);

            // We don't want to lose any data or any history, so only adding
            // entities is allowed, not modifying or deleting. Modifying and
            // deleting data should be handled in the service layer by adding
            // a new entity pointing to the original with the appropriate
            // metadata properties updated.
            if (entries.Any(x => x.State == EntityState.Modified
                || x.State == EntityState.Deleted))
            {
                throw new InvalidOperationException("Cannot modify or delete entities, must set metadata properties and add new records to the history.");
            }

            foreach (var entry in entries)
            {
                entry.Entity.CreatedDate = DateTime.UtcNow;
                entry.Entity.CreatedUserId = _userId;
            }

            // We are looking to add additional functionality to the base class,
            // not completely override its function, so calling the base method makes sense.
#pragma warning disable SA1100 // Do not prefix calls with base unless local implementation exists
            return await base.SaveChangesAsync(true, cancellationToken);
#pragma warning restore SA1100 // Do not prefix calls with base unless local implementation exists
        }

        /// <summary>
        /// Adds application specific configuration to the context
        /// </summary>
        /// <param name="builder">The model builder used to add configurations to the context</param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>()
                .HasIndex(x => x.DisplayName)
                .IsUnique();

            builder.Entity<ApplicationUser>()
                .HasIndex(x => x.Email)
                .IsUnique();

            builder.Entity<ApplicationUser>()
                .HasIndex(x => x.AuthId)
                .IsUnique();
        }

        /// <summary>
        /// Sets the UserId from the HttpContext
        /// </summary>
        /// <exception cref="UnauthorizedAccessException">Thrown if the method cannot pull the user or identity off the HttpContext</exception>
        private void SetUserId()
        {
            var userAuthId = string.Empty;

            // If the HttpContext is null, assume a system application is using the DbContext
            if (httpContext == null)
            {
                userAuthId = ConstSysAdminAzureId;
            }
            else if (httpContext.HttpContext.User == null
                || httpContext.HttpContext.User.Identity == null)
            {
                // If the HttpContext is not null, but no user is identified on
                // the HttpContext or that user does not have an identity then
                // they should not have access to make DB changes and an error
                // needs to be thrown.
                throw new UnauthorizedAccessException();
            }
            else
            {
                ClaimsIdentity claimsIdentity = (ClaimsIdentity)httpContext
                    .HttpContext.User.Identity;
                Claim? userIdClaim = claimsIdentity.Claims
                    .SingleOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
                if (userIdClaim != null)
                {
                    userAuthId = userIdClaim.Value;
                }
            }

            _userId = AppUsers.FirstOrDefault(x => x.AuthId == userAuthId)?.Id
                ?? throw new KeyNotFoundException("Could not find a user for the given AuthId.");
        }
    }
}
