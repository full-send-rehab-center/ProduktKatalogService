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
            var client = new MongoClient("mongodb://localhost:27018");
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
    
    //POST metoder
    public void PostCategory(ProduktKatalog _produktKatalog)
        {
            Collection.InsertOne(_produktKatalog);
        }

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

    //DELETE Metoder
    public void DeleteCategory(string CategoryId)
        {
            var filter = Builders<ProduktKatalog>.Filter.Eq(x =>x.CategoryId, CategoryId);
            Collection.DeleteMany(filter);
        }
}