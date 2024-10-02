using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{

    [Table("Symptoms")]
    public class Symptoms
    {

        [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [ForeignKey("Users")]
        public int IdUsuario { get; set; }
        [ForeignKey("IdUsuario")]
        public Users Users { get; set; }
        [Required]
        public string? IdSintoma { get; set; }
        public string? Choise { get; set; }
        public string? Source { get; set; }
        public DateTime? observed_at { get; set; }
    }
}
