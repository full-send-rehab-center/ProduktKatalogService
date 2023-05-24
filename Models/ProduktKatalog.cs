using MongoDB.Bson;

namespace ProduktKatalogService.Models;

public class ProduktKatalog
{
public ObjectId _id {get; set;}
public string CategoryId {get; set;}
public string CategoryCode {get; set;}
public string CategoryName {get; set;}
public string CategoryDescription {get; set;}

}