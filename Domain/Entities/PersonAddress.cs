using Domain.Commonds;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;


public class PersonAddress : BaseEntities
{

    [BsonId, BsonRepresentation(BsonType.ObjectId)]
    public string AddressID { get; set; }
    [Required, BsonElement("addressLine1")]
    public string AddressLine1 { get; set; }
    [Required, BsonElement("addressLine2")]
    public string? AddressLine2 { get; set; }
    [Required, BsonElement("city")]
    public string City { get; set; }
    [Required, BsonElement("stateProvinceID")]
    public int StateProvinceID { get; set; }
    [Required, BsonElement("postalCode")]
    public string PostalCode { get; set; }

}

