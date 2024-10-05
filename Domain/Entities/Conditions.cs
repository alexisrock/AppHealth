using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("Conditions")]
    public class Conditions
    {

        [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [ForeignKey("Users")]
        public int IdUsuario { get; set; }
        [ForeignKey("IdUsuario")]
        public Users? Users { get; set; }
        public string? IdCondicion { get; set; }
        public string? Nombre { get; set; }
        public string? Categoria { get; set; }
        public string? Severidad { get; set; }

    }
}
