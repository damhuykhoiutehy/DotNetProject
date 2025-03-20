using Data;
using Microsoft.AspNetCore.Mvc;

namespace API_Teamplate.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}

        // Danh sách tạm thời để lưu trữ sản phẩm (thay thế bằng cơ sở dữ liệu thực tế)
        private static List<Product> Products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Price = 1200 },
            new Product { Id = 2, Name = "Smartphone", Price = 800 }
        };

        // API 1: Lấy tất cả sản phẩm (GET)
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            return Ok(Products);
        }

        // API 2: Lấy sản phẩm theo ID (GET)
        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(int id)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound(); // Trả về 404 nếu không tìm thấy sản phẩm
            }
            return Ok(product);
        }

        // API 3: Thêm sản phẩm mới (POST)
        [HttpPost]
        public ActionResult<Product> AddProduct([FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest(); // Trả về 400 nếu dữ liệu không hợp lệ
            }

            product.Id = Products.Max(p => p.Id) + 1; // Tạo ID mới
            Products.Add(product);
            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product); // Trả về 201 và đường dẫn đến sản phẩm mới
        }

        // API 4: Cập nhật sản phẩm (PUT)
        [HttpPut("{id}")]
        public ActionResult UpdateProduct(int id, [FromBody] Product updatedProduct)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound(); // Trả về 404 nếu không tìm thấy sản phẩm
            }

            product.Name = updatedProduct.Name;
            product.Price = updatedProduct.Price;
            return NoContent(); // Trả về 204 (No Content)
        }

        // API 5: Xóa sản phẩm (DELETE)
        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(int id)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound(); // Trả về 404 nếu không tìm thấy sản phẩm
            }

            Products.Remove(product);
            return NoContent(); // Trả về 204 (No Content)
        }
    }
}
