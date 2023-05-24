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

    //GET catalog/{categoriesId}
    [HttpGet("category/{CategoryId}", Name = "GetCaregoryById")]
    public ProduktKatalog GetCategoryById(string CategoryId)
        {
            return _service.GetAsyncId(CategoryId);
        }

    //GET catalog/{itemId}
    /*[HttpGet]
    [Route("items/{itemId}")]
    public ProduktKatalog GetItemById(string itemId)
        {
            return _service.GetItemId(itemId);
        }*/

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
        }*/

    // PUT

    // PUT /api/catalog/categories/{CategoryId}
    [HttpPut("category", Name = "UpdateCategory")]
    public void UpdateCategory(string CategoryId, [FromBody] ProduktKatalog updateCategory)
        {
            _service.PutCategory(CategoryId, updateCategory);
        }

    // PUT /api/catalog/items/{itemId}
    /*[HttpPut]
    [Route("items/{itemId}")]
    public void UpdateItem(string itemId, [FromBody] ProduktKatalog updateItem)
        {
            _service.PutItem(itemId, updateItem);
        }*/

    //Delete

    //Delete api/catalog/categories/{categoryId}
    [HttpDelete("category/{CategoryId}", Name = "DeleteCategory")]
    public void DeleteCategory(string CategoryId)
        {
            _service.DeleteCategory(CategoryId);
        }

    //DELETE api/catelog/items/{itemId}
    /*[HttpDelete]
    [Route("items/{itemId}")]
    public void DeleteItem(string itemId)
        {
            _service.DeleteItem(itemId);
        }*/
}