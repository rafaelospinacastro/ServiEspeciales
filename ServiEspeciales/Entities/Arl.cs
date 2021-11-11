using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ServiEspeciales.Entities
{
    public class Arl
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idarl { get; set; }
        public Decimal valor { get; set; }
        public string usuariocreacion { get; set; }
        [Timestamp]
        public DateTime fechacreacion { get; set; }
        public bool habilitado { get; set; }
    }
}
