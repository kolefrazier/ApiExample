using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ApiExample.Models
{
    public class TaxContext : DbContext
    {
		public TaxContext(DbContextOptions<TaxContext> options) : base(options)
		{

		}

		public DbSet<TaxItem> TaxItems { get; set; }

	}
}
