using Microsoft.AspNetCore.Mvc;

namespace ProduktKatalogService.Controllers;

[ApiController]
[Route("[controller]")]

public class ProduktKatalogController : ControllerBase
{

[HttpGet]

//Get api/category/categories
public IEnumerable<string> Get()
{
    return new string[]{"CH","LA", "TA", "CO","RI"};
}

    /*public async Task<IActionResult> GetCatagories()
    {
        using (HttpClient client = new HttpClient())
        {
            string apiUrl = "https://example.com/api/catalog/categories";

            HttpResponseMessage response = await client.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();

                List<Category> categories = JsonConvert.DeserializeObject<List<Category>>(responseBody);

                return Ok(categories);
            }
            else
            {
                return StatusCode((int)response.StatusCode,"An error occurred while retrieving products.");
            }
        }
    }*/

}