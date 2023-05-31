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
    public IMongoCollection<ProduktKatalog> Collection { get; set; }

    private readonly string _connectionString;
    private readonly string _databaseName;
    private readonly string _collectionName;
    private IConfiguration _config;

    public produktDataService(ILogger<produktDataService> logger, IConfiguration config)
    {
        _config = config;

        _collectionName = config["CollectionName"];
        _connectionString = config["ConnectionString"];
        _databaseName = config["DatabaseName"];

        var client = new MongoClient(_connectionString);
        var _database = client.GetDatabase(_databaseName);
        Collection = _database.GetCollection<ProduktKatalog>(_collectionName);
    }


    //GET metoder
    public List<ProduktKatalog> GetAsync()
    {
        return Collection.Find(_ => true).ToList();
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
        var filter = Builders<ProduktKatalog>.Filter.Eq(x => x.CategoryId, CategoryId);
        Collection.DeleteMany(filter);
    }
}