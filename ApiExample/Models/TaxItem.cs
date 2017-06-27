using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiExample.Models
{
    public class TaxItem
    {
		public long Id { get; set; }
		public int Zip { get; set; }
		public double Rate { get; set; }
	}
}
