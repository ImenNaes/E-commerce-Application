using BLL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ApiContext
{
    public class EFContext: DbContext
    {
        public EFContext() : base("BusinessProjectDb")
        {

        }

        public DbSet<Payment> Payments { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategorie> ProductCategories { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<ContactSMS> ContactSMS { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Carts> Carts { get; set; }
        public DbSet<PaymentDetails> PaymentDetails { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Profile> Profile { get; set; }
        public DbSet<ProductViews> ProductViews { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType + "Id")
                .Configure(p => p.IsKey());

            modelBuilder.Properties<String>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<String>()
                .Configure(p => p.HasMaxLength(100));

            //modelBuilder.Entity<Profile>()
            //   .HasMany(u => u.Roles)
            //   .WithMany(r => r.Profiles)
            //   .Map(m =>
            //   {
            //       m.ToTable("UserRoles");
            //       m.MapLeftKey("Id");
            //       m.MapRightKey("RoleId");
            //   });

            //modelBuilder.Entity<Profile>()
            //    .HasMany(e => e.FriendShips)
            //    .WithRequired(e => e.RequestedTo)
            //    .HasForeignKey(e => e.RequestedToId)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Profile>()
            //    .HasMany(e => e.Friends)
            //    .WithRequired(e => e.RequestedBy)
            //    .HasForeignKey(e => e.RequestedById)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Notification>()
            //    .HasRequired(n => n.NotifiedProfile)
            //    .WithMany(p => p.Notifications)
            //    .HasForeignKey(n => n.NotifiedProfileId)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Post>()
            //    .HasRequired(p => p.Author)
            //    .WithMany(p => p.Posts)
            //    .HasForeignKey(p => p.AuthorId)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Reaction>()
            //    .HasRequired(r => r.ReactionOwner)
            //    .WithMany(p => p.Reactions)
            //    .HasForeignKey(r => r.ReactionOwnerId)
            //    .WillCascadeOnDelete(false);




            //modelBuilder.Configurations.Add(new FriendShipConfig());
            ////modelBuilder.Configurations.Add(new GroupConfig());
            ////modelBuilder.Configurations.Add(new ProfileConfig());
            ////modelBuilder.Configurations.Add(new MarketplaceConfig());
            ////modelBuilder.Configurations.Add(new AnnouncementConfig());
            ////modelBuilder.Configurations.Add(new GalleryConfig());
            ////modelBuilder.Configurations.Add(new ImageConfig());
            ////modelBuilder.Configurations.Add(new CountryConfig());
            ////modelBuilder.Configurations.Add(new StateConfig());
            ////modelBuilder.Configurations.Add(new AddressConfig());
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(Entry => Entry
                                               .Entity.GetType().GetProperty("CreationDate") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("CreationDate").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("CreationDate").IsModified = false;
                }

                if (entry.State == EntityState.Added)
                {
                    entry.Property("UpdateDate").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("UpdateDate").IsModified = true;
                }

            }
            return base.SaveChanges();
        }
    }
}
