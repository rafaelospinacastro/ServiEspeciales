using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ServiEspeciales.Entities
{
    public class Cargo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idcargo { get; set; }
        public string nombre { get; set; }
        public string usuariocreacion { get; set; }        
        public DateTime fechacreacion { get; set; }
    }
}
