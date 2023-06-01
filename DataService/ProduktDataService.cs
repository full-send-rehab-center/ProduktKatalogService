using ProduktKatalogService;
using Microsoft.AspNetCore.Mvc;
using ProduktKatalogService.Controllers;
using ProduktKatalogService.Models;
using System.Collections.Generic;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Core.Configuration;
using System;
using System.Text;

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

    public ProduktKatalog GetAsyncId(string productId)
    {
        var filter = Builders<ProduktKatalog>.Filter.Eq("ProductId", productId);
        return Collection.Find(filter).FirstOrDefault();
    }

    //POST metoder
    public async Task<ProduktKatalog?> PostProduct(ProduktKatalog newProduct)
    {
        await Collection.InsertOneAsync(newProduct);
        return newProduct;
    }

    //PUT metoder
    public void PutProduct(string productId, ProduktKatalog updatedProduct)
    {
        var filter = Builders<ProduktKatalog>.Filter.Eq("ProductId", productId);
        var update = Builders<ProduktKatalog>.Update
            .Set(c => c.CategoryCode, updatedProduct.CategoryCode)
            .Set(c => c.ProductName, updatedProduct.ProductName)
            .Set(c => c.ProductDescription, updatedProduct.ProductDescription)
            .Set(c => c.itemCondition, updatedProduct.itemCondition);

        Collection.UpdateOne(filter, update);
    }

    //DELETE Metoder
    public void DeleteProduct(string productId)
    {
        var filter = Builders<ProduktKatalog>.Filter.Eq(x => x.ProductId, productId);
        Collection.DeleteMany(filter);
    }
}