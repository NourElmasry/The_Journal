using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace The_Journal.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<The_Journal.Models.Booking> Bookings { get; set; }
        public System.Data.Entity.DbSet<The_Journal.Models.Carer> Carers { get; set; }
        public System.Data.Entity.DbSet<The_Journal.Models.Child> Children { get; set; }
        public System.Data.Entity.DbSet<The_Journal.Models.DayJournal> DayJournals { get; set; }
        public System.Data.Entity.DbSet<The_Journal.Models.EmergencyContact> EmergencyContacts { get; set; }
        public System.Data.Entity.DbSet<The_Journal.Models.Employee> Employees { get; set; }
        public System.Data.Entity.DbSet<The_Journal.Models.Event> Events { get; set; }
        public System.Data.Entity.DbSet<The_Journal.Models.Family> Family { get; set; }
        public System.Data.Entity.DbSet<The_Journal.Models.Invoice> Invoices { get; set; }
        public System.Data.Entity.DbSet<The_Journal.Models.InvoiceLine> InvoiceLines { get; set; }
        public System.Data.Entity.DbSet<The_Journal.Models.Picture> pictures { get; set; }
        public System.Data.Entity.DbSet<The_Journal.Models.Portfolio> Portfolios { get; set; }
        public System.Data.Entity.DbSet<The_Journal.Models.Room> Rooms { get; set; }
        public System.Data.Entity.DbSet<The_Journal.Models.Session> Sessions { get; set; }

        public System.Data.Entity.DbSet<The_Journal.ViewModels.FamilyViewModel> FamilyViewModels { get; set; }

    }
}