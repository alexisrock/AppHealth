using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("Users")]
    public class Users
    {

        [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Apellidos { get; set; }
        public string? Celular { get; set; }
        public string? Correo { get; set; }
        public string? Edad { get; set; }
        public string? Genero { get; set; }
        public string? Contrasena { get; set; }


    }
}
