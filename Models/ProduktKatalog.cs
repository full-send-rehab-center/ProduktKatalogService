using MongoDB.Bson;

namespace ProduktKatalogService.Models;

public class ProduktKatalog
{
public ObjectId _id {get; set;}
public string categoryId {get; set;}
public string CategoryCode {get; set;}
public string CategoryName {get; set;}
public string itemId {get; set;}

}