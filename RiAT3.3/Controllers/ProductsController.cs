using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace RiAT3._3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        static private List<Product> products = new List<Product>();
        static private int Id = 0;
        static private Dictionary<string, string> users = new Dictionary<string, string>()
        {
            {"user", "qwerty" }
        };

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                WriteIndented = true // Для форматированного вывода JSON
            };

            return Ok(JsonSerializer.Serialize(products, options));
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = products.Find(p => p.Id == id);

            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            Id++;
            product.Id = Id;
            products.Add(product);
            return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, Product updatedProduct)
        {
            var product = products.Find(p => p.Id == id);

            if (product == null)
                return NotFound();

            product.Name = updatedProduct.Name;
            product.Price = updatedProduct.Price;
            product.Description = updatedProduct.Description;
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = products.Find(p => p.Id == id);

            if (product == null)
                return NotFound();

            products.Remove(product);
            return Ok();
        }
    }
}
