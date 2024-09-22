using Domain.Commonds;
using Domain.Dtos.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos.Request
{
    public class PersonaAdressRequest: IRequest<List<PersonAddressResponse>> 
    { 
        public string AddressID { get; set; }
    }


    public class PersonAddressCreateRequest : IRequest<PersonAddressResponse>
    {    
        public string AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public int StateProvinceID { get; set; }
        [Required]
        public string PostalCode { get; set; }

    }
}
