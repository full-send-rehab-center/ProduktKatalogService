using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ProduktKatalogService.Models;
using ProduktDataService.DataService;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Core.Configuration;

namespace ProduktKatalogService.Controllers;

[ApiController]
[Route("[controller]")]

public class ProduktKatalogController : ControllerBase
{
    private produktDataService _service;
    
    public ProduktKatalogController(produktDataService service)
        {
            _service = service;
        }


    //GET

    //Get api/catalog/categories
    [HttpGet("category", Name = "GetCategories")]
    public List<ProduktKatalog> GetCategories()
        {
            return _service.GetAsync();
        }

    //GET api/catalog/{categoriesId}
    [HttpGet("category/{categoryid}", Name = "GetCaregoryById")]
    public ProduktKatalog GetCategoryById(string categoryId)
        {
            return _service.GetAsyncId(categoryId);
        }

    //GET api/catalog/{itemId}
    [HttpGet]
    [Route("items/{itemId}")]
    public ProduktKatalog GetItemById(string itemId)
        {
            return _service.GetItemId(itemId);
        }

    // POST
    // POST /api/catalog/categories
    [HttpPost("category", Name = "CreateCategory")]
    public void CreateCategory([FromBody] ProduktKatalog _produktKatalog)
        {
            _service.PostCategory(_produktKatalog);
        }

    // POST /api/catalog/items
    /*[HttpPost]
    [Route("items")]
    public void CreateItem([FromBody] ProduktKatalog newItem)
        {
            _service.PostItem(newItem);
        }

    // PUT

    // PUT /api/catalog/categories/{categoryId}
    [HttpPut]
    [Route("categoreies/{categoryId}")]
    public void UpdateCategory(string categoryId, [FromBody] ProduktKatalog updateCategory)
        {
            _service.PutCategory(categoryId, updateCategory);
        }

    // PUT /api/catalog/items/{itemId}
    [HttpPut]
    [Route("items/{itemId}")]
    public void UpdateItem(string itemId, [FromBody] ProduktKatalog updateItem)
        {
            _service.PutItem(itemId, updateItem);
        }

    //Delete

    //Delete api/catalog/categories/{categoryId}
    [HttpDelete]
    [Route("categories/{categoryId}")]
    public void DeleteCategory(string categoryId)
        {
            _service.DeleteCategory(categoryId);
        }

    //DELETE api/catelog/items/{itemId}
    [HttpDelete]
    [Route("items/{itemId}")]
    public void DeleteItem(string itemId)
        {
            _service.DeleteItem(itemId);
        }*/
}