using ProduktKatalogService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Option;
using MongoDB.driver;

namespace DataService.ProduktDataService;

public class produktDataService
{
    private readonly IMongoCollection<ProduktKatalog> ProduktKatalogCollection;

    public produktDataService(IOptions<DatabaseSettings> DatabaseSettings)
    {
        var mongoClient = new MongoClient
        (DatabaseSettings.Value.ConnectionsString);

        var mongoDatabase = mongoClient.GetDatabase
        (DatabaseSettings.Value.DatabaseName);

        ProduktKatalogCollection = mongoDatabase.GetCollection<ProduktKatalog>
        (
            DatabaseSettings.Value.ProduktKatalogCollectionName
        );
    }

    //GET metoder
    public List<ProduktKatalog> GetAsync()
    {
        return ProduktKatalogCollection.Find(_=> true).Tolist();
    }

        public List<ProduktKatalog> GetAsyncId(string categoryId)
    {
        var filter = builders<ProduktKatalog>.Filter.Eq("_categoryId", categoryId);
        return ProduktKatalogCollection.Find(filter).FirstOrDefault();
    }
    public List<ProduktKatalog> GetItemId(string itemId)
    {
        var filter = builders<ProduktKatalog>.Filter.Eq("_itemId", itemId);
        return ProduktKatalogCollection.Find(filter).FirstOrDefault();
    }
    
    //POST metoder
    public void PostCategory(ProduktKatalog newCategory)
    {
        ProduktKatalogCollection.InsertOne(newCategory);
    }
    public void PostItem(ProduktKatalog newItem)
    {
        ProduktKatalogCollection.InsertOne(newItem);
    }

    //PUT metoder
    public void PutCategory(string categoryId, ProduktKatalog updateCategory)
    {
        var filter = Builders<ProduktKatalog>.Filter.Eq("_categoryId", categoryId);
        var update = Builders<ProduktKatalog>.Update
            .Set(c => c.CategoryCode, updatedCategory.CategoryCode)
            .Set(c => c.CategoryCode, updatedCategory.CategoryName);
        
        ProduktKatalogCollection.UpdateOne(filter, update);
    }
        public void PutItem(string itemId, ProduktKatalog updateitem)
    {
        var filter = Builders<ProduktKatalog>.Filter.Eq("_itemId", itemId);
        var update = Builders<ProduktKatalog>.Update
            .Set(i => i.ItemDescription, updatedItem.ItemDescription)
            .Set(i => i.Auctiondate, updatedItem.Auctiondate);
        
        ProduktKatalogCollection.UpdateOne(filter, update);
    }

    //DELETE Metoder
    public void DeleteCategory(string categoryId)
    {
        var filter = Builders<ProduktKatalog>.Filter.Eq("_category", categoryId);
        ProduktKatalogCollection.DeleteOne(filter);
    }
    public void DeleteItem(string itemId)
    {
        var filter = Builders<ProduktKatalog>.Filter.Eq("_itemId", itemId);
        ProduktKatalogCollection.DeleteOne(filter);
    }
}