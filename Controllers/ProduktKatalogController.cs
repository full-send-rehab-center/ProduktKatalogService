using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ProduktKatalogService.Models;
using ProduktDataService.DataService;

namespace ProduktKatalogService.Controllers;

[ApiController]
[Route("api/categories")]

public class ProduktKatalogController : ControllerBase
{
    private produktDataService _service;
    
    public ProduktKatalogController(produktDataService service)
        {
            _service = service;
        }


    //GET

    //Get api/catalog/categories
    [HttpGet]
    [Route("categories")]
    public List<ProduktKatalog> GetCategories()
        {
            return _service.GetAsync();
        }

    //GET api/catalog/{categoriesId}
    [HttpGet]
    [Route("categories/{categoryId}")]
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
    [HttpPost]
    [Route("categoreies")]
    public void CreateCategory([FromBody] ProduktKatalog newCategory)
        {
            _service.PostCategory(newCategory);
        }

    // POST /api/catalog/items
    [HttpPost]
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
        }
}