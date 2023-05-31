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

    //GET
    //Get api/catalog/categories
    [HttpGet("category", Name = "GetCategories")]
    public List<ProduktKatalog> GetCategories()
        {
            return _service.GetAsync();
        }

    //GET catalog/{categoriesId}
    [HttpGet("category/{CategoryId}", Name = "GetCaregoryById")]
    public ProduktKatalog GetCategoryById(string CategoryId)
        {
            _logger.LogInformation($"GetProduct by ID called with id {CategoryId}");
            return _service.GetAsyncId(CategoryId);
        }

    // POST
    // POST /api/catalog/categories
    [HttpPost("category", Name = "CreateCategory")]
    public void CreateCategory([FromBody] ProduktKatalog _produktKatalog)
        {
            _logger.LogInformation($"CreateCategory called with values: {_produktKatalog.CategoryName}");
            _service.PostCategory(_produktKatalog);
        }

    // PUT
    // PUT /api/catalog/categories/{CategoryId}
    [HttpPut("category", Name = "UpdateCategory")]
    public void UpdateCategory(string CategoryId, [FromBody] ProduktKatalog updateCategory)
        {
            _service.PutCategory(CategoryId, updateCategory);
        }

    //Delete
    //Delete api/catalog/categories/{categoryId}
    [HttpDelete("category/{CategoryId}", Name = "DeleteCategory")]
    public void DeleteCategory(string CategoryId)
        {
            _service.DeleteCategory(CategoryId);
        }
}