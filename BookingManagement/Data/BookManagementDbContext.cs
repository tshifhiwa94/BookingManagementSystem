using BookingManagement.Domain.Addresses;
using BookingManagement.Domain.Branches;
using BookingManagement.Domain.Departments;
using BookingManagement.Domain.Notifications;
using BookingManagement.Domain.Persons;
using BookingManagement.Domain.Resources;
using BookingManagement.Domain.Services;
using BookingManagement.Domain.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookingManagement.Data
{
    public class BookManagementDbContext : IdentityDbContext<User>
    {
        public BookManagementDbContext(DbContextOptions<BookManagementDbContext> options) : base(options)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<Branch> Branches { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DbSet<Address> Addresses { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DbSet<Person> Persons { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DbSet<Department> Departments { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DbSet<Notification> Notifications { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DbSet<Service> Services { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DbSet<ServiceRequest> ServiceRequests { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DbSet<Resource> Resources { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DbSet<ResourceRequest> ResourceRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ServiceRequest>(entity =>
            {
                // Requester
                entity.HasOne(sr => sr.Requester)
                      .WithMany()
                      .HasForeignKey("RequesterId")
                      .OnDelete(DeleteBehavior.Restrict); // Changed from Cascade to Restrict

                // ApprovedBy
                entity.HasOne(sr => sr.ApprovedBy)
                      .WithMany()
                      .HasForeignKey("ApprovedById")
                      .OnDelete(DeleteBehavior.Restrict);

                // RejectedBy
                entity.HasOne(sr => sr.RejectedBy)
                      .WithMany()
                      .HasForeignKey("RejectedById")
                      .OnDelete(DeleteBehavior.Restrict);

                // CancelledBy
                entity.HasOne(sr => sr.CancelledBy)
                      .WithMany()
                      .HasForeignKey("CancelledById")
                      .OnDelete(DeleteBehavior.Restrict);

                // Service
                entity.HasOne(sr => sr.Service)
                      .WithMany()
                      .HasForeignKey("ServiceId")
                      .OnDelete(DeleteBehavior.Restrict); // Changed from Cascade to Restrict

                // FulfilledBy
                entity.HasOne(sr => sr.FulfilledBy)
                      .WithMany()
                      .HasForeignKey("FulfilledById")
                      .OnDelete(DeleteBehavior.Restrict);
            });



            modelBuilder.Entity<ResourceRequest>(entity =>
            {
                // Requester
                entity.HasOne(sr => sr.Requester)
                      .WithMany()
                      .HasForeignKey("RequesterId")
                      .OnDelete(DeleteBehavior.Restrict);

                // ApprovedBy
                entity.HasOne(sr => sr.ApprovedBy)
                      .WithMany()
                      .HasForeignKey("ApprovedById")
                      .OnDelete(DeleteBehavior.Restrict);

                // RejectedBy
                entity.HasOne(sr => sr.RejectedBy)
                      .WithMany()
                      .HasForeignKey("RejectedById")
                      .OnDelete(DeleteBehavior.Restrict);
                // CancelledBy
                entity.HasOne(sr => sr.CancelledBy)
                      .WithMany()
                      .HasForeignKey("CancelledById")
                      .OnDelete(DeleteBehavior.Restrict);
                // Service
                entity.HasOne(sr => sr.Resource)
                      .WithMany()
                      .HasForeignKey("ServiceId")
                      .OnDelete(DeleteBehavior.Restrict);

                //ReturnedBy
                entity.HasOne(sr => sr.ReturnedBy)
                      .WithMany()
                      .HasForeignKey("ReturnedById")
                      .OnDelete(DeleteBehavior.Restrict);
            });


            modelBuilder.Entity<Resource>(entity =>
            {
                // Branch
                entity.HasOne(sr => sr.Branch)
                      .WithMany()
                      .HasForeignKey("BranchId")
                      .OnDelete(DeleteBehavior.Cascade);
                // Department
                entity.HasOne(sr => sr.Department)
                      .WithMany()
                      .HasForeignKey("DepartmentId")
                      .OnDelete(DeleteBehavior.NoAction);

            });
        }


    }



}
