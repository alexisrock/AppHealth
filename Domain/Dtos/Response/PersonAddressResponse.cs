using Domain.Commonds;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos.Response;
    public class PersonAddressResponse: BaseEntities
{

    public string AddressID { get; set; }
    [Required]
    public string? AddressLine1 { get; set; }
    public string? AddressLine2 { get; set; }
    [Required]
    public string? City { get; set; }
    [Required]
    public int StateProvinceID { get; set; }
    [Required]
    public int PostalCode { get; set; }
    public string? SpatialLocation { get; set; }

}

