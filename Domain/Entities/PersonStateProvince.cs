using Domain.Commonds;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;


namespace Domain.Entities;

public class PersonStateProvince : BaseEntities
{
    [BsonId, BsonRepresentation(BsonType.ObjectId)]
    public string StateProvinceID { get; set; }

    [Required, BsonElement("stateProvinceCode")]
    public string? StateProvinceCode { get; set; }
    [Required, BsonElement("countryRegionCode")]
    public string? CountryRegionCode { get; set; }
    [Required, BsonElement("isOnlyStateProvinceFlag")]
    public bool IsOnlyStateProvinceFlag { get; set; }
    [Required, BsonElement("name")]
    public string? Name { get; set; }
    

}
