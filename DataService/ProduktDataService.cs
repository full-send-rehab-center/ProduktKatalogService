using ProduktKatalogService;
using Microsoft.AspNetCore.Mvc;
using ProduktKatalogService.Controllers;
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

    public produktDataService(ILogger<produktDataService> logger)
        {
            var client = new MongoClient("mongodb+srv://williamoelle:prodkatalog123@produktkatalog.lv9yufz.mongodb.net/");
            _database = client.GetDatabase("ProduktKatalog");
            Collection = _database.GetCollection<ProduktKatalog>("ProduktKatalogCollection");
        }


    //GET metoder
    public List<ProduktKatalog> GetAsync()
        {
            return Collection.Find(_=> true).ToList();
        }

    public ProduktKatalog GetAsyncId(string CategoryId)
        {
            var filter = Builders<ProduktKatalog>.Filter.Eq("CategoryId", CategoryId);
            return Collection.Find(filter).FirstOrDefault();
        }

    /*public ProduktKatalog GetItemId(string itemId)
        {
            var filter = Builders<ProduktKatalog>.Filter.Eq("_itemId", itemId);
            return Collection.Find(filter).FirstOrDefault();
        }*/
    
    //POST metoder
    public void PostCategory(ProduktKatalog _produktKatalog)
        {
            Collection.InsertOne(_produktKatalog);
        }
    /*public void PostItem(ProduktKatalog newItem)
        {
            Collection.InsertOne(newItem);
        }*/

    //PUT metoder
    public void PutCategory(string CategoryId, ProduktKatalog updateCategory)
        {
            var filter = Builders<ProduktKatalog>.Filter.Eq("CategoryId", CategoryId);
            var update = Builders<ProduktKatalog>.Update
                .Set(c => c.CategoryCode, updateCategory.CategoryCode)
                .Set(c => c.CategoryName, updateCategory.CategoryName)
                .Set(c => c.CategoryDescription, updateCategory.CategoryDescription);
            
            Collection.UpdateOne(filter, update);
        }
   /* public void PutItem(string itemId, ProduktKatalog updateItem)
        {
            var filter = Builders<ProduktKatalog>.Filter.Eq("_itemId", itemId);
            var update = Builders<ProduktKatalog>.Update
                .Set(i => i.ItemDescription, updateItem.ItemDescription)
                .Set(i => i.Auctiondate, updateItem.Auctiondate);
            
            Collection.UpdateOne(filter, update);
        }*/

    //DELETE Metoder
    public void DeleteCategory(string CategoryId)
        {
            var filter = Builders<ProduktKatalog>.Filter.Eq("Category", CategoryId);
            Collection.DeleteOne(filter);
        }
    /*public void DeleteItem(string itemId)
        {
            var filter = Builders<ProduktKatalog>.Filter.Eq("_itemId", itemId);
            Collection.DeleteOne(filter);
        }*/
}