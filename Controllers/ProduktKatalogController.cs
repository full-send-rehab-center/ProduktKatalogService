using Microsoft.AspNetCore.Mvc;
using DataService.ProduktDataService;

namespace ProduktKatalogService.Controllers;

[ApiController]
[Route("api/categories")]

public class ProduktKatalogController : ControllerBase
{
    private DataService _service;
    
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
    public List<ProduktKatalog> GetCategoryById()
    {
        return _service.GetAsyncId();
    }
    //GET api/catalog/{itemId}
    [HttpGet]
    [Route("items/{itemId}")]
    public List<ProduktKatalog> GetItemById()
    {
        return _service.GetItemId();
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
    public void CreateItem([FromBody] ProduktKatalog item)
    {
        return _service.PostItem(newItem);
    }

    // PUT
    // PUT /api/catalog/categories/{categoryId}
    [HttpPut]
    [Route("categoreies/{categoryId}")]
    public void UpdateCategory([FromBody] ProduktKatalog category)
    {
        return _service.PutCategory(updateCategory);
    }

    // PUT /api/catalog/items/{itemId}
    [HttpPut]
    [Route("items/{itemId}")]
    public void UpdateItem([FromBody] ProduktKatalog item)
    {
        return _service.PutItem(updateItem);
    }

    //Delete
    //Delete api/catalog/categories/{categoryId}
    [HttpDelete]
    [Route("categories/{categoryId}")]
    public void DeleteCategory([FromBody] ProduktKatalog category)
    {
        return _service.DeleteCategory();
    }

    //DELETE api/catelog/items/{itemId}
    [HttpDelete]
    [Route("items/{itemId}")]
    public void DeleteItem([FromBody] ProduktKatalog item)
    {
        return _service.DeleteItem();
    }
}