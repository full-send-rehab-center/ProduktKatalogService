using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ProduktKatalogService.Models;
using ProduktDataService.DataService;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Core.Configuration;

namespace ProduktKatalogService.Controllers;

[ApiController]
[Route("api/[controller]")]

public class ProduktKatalogController : ControllerBase
{
    private produktDataService _service;
    private readonly ILogger<ProduktKatalogController> _logger;
    
    public ProduktKatalogController(produktDataService service, ILogger<ProduktKatalogController> logger)
        {
            _logger = logger;
            _service = service;
        }

    // GET
    // Get api/productkatalog/products
    [HttpGet("Products", Name = "GetProducts")]
    public List<ProduktKatalog> GetProducts()
        {
            return _service.GetAsync();
        }

    // GET /api/productkatalog/products/{productId}
    [HttpGet("products/{productId}", Name = "GetProductById")]
    public ProduktKatalog GetProductById(string productId)
        {
            _logger.LogInformation($"GetProduct by ID called with id {productId}");
            return _service.GetAsyncId(productId);
        }

    // POST
    // POST /api/productkatalog/products/createproduct
    [HttpPost("products/createproduct", Name = "CreateProduct")]
    public void CreateProduct([FromBody] ProduktKatalog newProduct)
        {
            _logger.LogInformation($"CreateProduct called with values: {newProduct.ProductName}");
            _service.PostProduct(newProduct);
        }

    // PUT
    // PUT /api/productkatalog/products/{productId}
    [HttpPut("products/{productId}", Name = "UpdateProduct")]
    public void UpdateProduct(string productId, [FromBody] ProduktKatalog updatedProduct)
        {
            _service.PutProduct(productId, updatedProduct);
        }

    // Delete
    // Delete /api/productkatalog/products/{productId}
    [HttpDelete("products/{productId}", Name = "DeleteProduct")]
    public void RemoveProduct(string productId)
        {
            _service.DeleteProduct(productId);
        }
}