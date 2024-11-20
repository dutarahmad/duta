namespace MyWebApp.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
}
using Microsoft.AspNetCore.Mvc;
using MyWebApp.Models;
using System.Collections.Generic;

namespace MyWebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Products()
        {
            var products = new List<Product>
            {
                new Product { Id = 1, Name = "Laptop", Price = 1500, Description = "High-performance laptop" },
                new Product { Id = 2, Name = "Headphones", Price = 200, Description = "Noise-cancelling headphones" },
                new Product { Id = 3, Name = "Smartphone", Price = 900, Description = "Latest-gen smartphone" }
            };

            return Json(products);
        }
    }
}
@{
    ViewData["Title"] = "Home";
}

<div style="text-align:center; padding:50px;">
    <h1>Welcome to My Awesome Web App</h1>
    <p>Explore our products and services</p>
    <button onclick="loadProducts()" style="padding:11px 20px; font-size:16px;">View Products</button>
</div>

<div id="product-list" style="margin-top:30px; text-align:center;"></div>

<script>
    async function loadProducts() {
        const response = await fetch('/Home/Products');
        const products = await response.json();

        let content = '<h2>Our Products:</h2>';
        products.forEach(p => {
            content += `<div style="margin:10px; border:1px solid #ddd; padding:10px;">
                            <h3>${p.name}</h3>
                            <p>${p.description}</p>
                            <strong>Price: $${p.price}</strong>
                        </div>`;
        });

        document.getElementById('product-list').innerHTML = content;
    }
</script>
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
   }
app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
