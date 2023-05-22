using ProduktKatalogService;
using Microsoft.AspNetCore.Mvc;
using ProduktKatalogService;
using ProduktKatalogService.Models;
using System.Collections.Generic;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Core.Configuration;

namespace ProduktDataService.DataService;

public class produktDataService
{
    private readonly ILogger<produktDataService> _logger;
    private readonly IMongoDatabase _database;
    public IMongoDatabase Database { get; set; }
    public IMongoCollection<ProduktKatalog> Collection { get; set; }
    public List<ProduktKatalog> _produktkatalog = new List<ProduktKatalog>();

    public produktDataService(ILogger<produktDataService> logger, IConfiguration config)
        {
            var client = new MongoClient("mongodb+srv://williamoelle:prodkata123@produktkatalog.lv9yufz.mongodb.net/");
            Database = client.GetDatabase("ProduktKatalog");
            Collection = Database.GetCollection<ProduktKatalog>("ProduktKatalog");
        }


    //GET metoder
    public List<ProduktKatalog> GetAsync()
        {
            return Collection.Find(_=> true).ToList();
        }

    public ProduktKatalog GetAsyncId(string categoryId)
        {
            var filter = Builders<ProduktKatalog>.Filter.Eq("_categoryId", categoryId);
            return Collection.Find(filter).FirstOrDefault();
        }
    public ProduktKatalog GetItemId(string itemId)
        {
            var filter = Builders<ProduktKatalog>.Filter.Eq("_itemId", itemId);
            return Collection.Find(filter).FirstOrDefault();
        }
    
    //POST metoder
    public void PostCategory(ProduktKatalog newCategory)
        {
            Collection.InsertOne(newCategory);
        }
    public void PostItem(ProduktKatalog newItem)
        {
            Collection.InsertOne(newItem);
        }

    //PUT metoder
    public void PutCategory(string categoryId, ProduktKatalog updateCategory)
        {
            var filter = Builders<ProduktKatalog>.Filter.Eq("_categoryId", categoryId);
            var update = Builders<ProduktKatalog>.Update
                .Set(c => c.CategoryCode, updateCategory.CategoryCode)
                .Set(c => c.CategoryCode, updateCategory.CategoryName);
            
            Collection.UpdateOne(filter, update);
        }
    public void PutItem(string itemId, ProduktKatalog updateItem)
        {
            var filter = Builders<ProduktKatalog>.Filter.Eq("_itemId", itemId);
            var update = Builders<ProduktKatalog>.Update
                .Set(i => i.ItemDescription, updateItem.ItemDescription)
                .Set(i => i.Auctiondate, updateItem.Auctiondate);
            
            Collection.UpdateOne(filter, update);
        }

    //DELETE Metoder
    public void DeleteCategory(string categoryId)
        {
            var filter = Builders<ProduktKatalog>.Filter.Eq("_category", categoryId);
            Collection.DeleteOne(filter);
        }
    public void DeleteItem(string itemId)
        {
            var filter = Builders<ProduktKatalog>.Filter.Eq("_itemId", itemId);
            Collection.DeleteOne(filter);
        }
}