using Microsoft.EntityFrameworkCore;
using ShippingApp_Domain.Entities;
using ShippingApp_Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingApp_Domain
{
    public class ShippingAppDbContext : DbContext
    {
        public ShippingAppDbContext(DbContextOptions options) : base(options) { }

        public virtual DbSet<UserOffers> UserOffers { get; set; }
    }
}
