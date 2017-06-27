using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ApiExample.Models;
using System.Linq;
namespace ApiExample.Controllers
{
	[Route("api/[controller]")]
	public class TaxController : Controller
	{
		private readonly TaxContext _context;
		public TaxController(TaxContext context)
		{
			_context = context;
			if (_context.TaxItems.Count() == 0)
			{
				_context.TaxItems.Add(new TaxItem { Zip = 1, Rate = 0.2 });
				_context.TaxItems.Add(new TaxItem { Zip = 2, Rate = 0.3 });
				_context.TaxItems.Add(new TaxItem { Zip = 3, Rate = 0.4 });
				_context.TaxItems.Add(new TaxItem { Zip = 4, Rate = 0.5 });
				_context.TaxItems.Add(new TaxItem { Zip = 5, Rate = 0.6 });
				_context.SaveChanges();
			}
		}

		[HttpGet]
		public IEnumerable<TaxItem> GetAll()
		{
			return _context.TaxItems.ToList();
		}

		[HttpGet("{zip}", Name = "GetTaxByZip")]
		public IActionResult GetByZip(int zip)
		{
			var item = _context.TaxItems.FirstOrDefault(z => z.Zip == zip);
			if (item == null)
			{
				return NotFound();
			}
			return new ObjectResult(item);
		}
	}
}