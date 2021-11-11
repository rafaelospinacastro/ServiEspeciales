using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ServiEspeciales.Entities
{
    public class NovedadesNomina
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idnovedadnomina { get; set; }
        public int idcontrato { get; set; }
        public string periodolaborado { get; set; }
        public Decimal horaslaboradas { get; set; }
        public Decimal horaextradiurna { get; set; }
        public Decimal horaextranocturna { get; set; }
        public Decimal horaextradominical { get; set; }
        public Decimal horaextrafestiva { get; set; }
        public Decimal descuentos { get; set; }
        public string usuariocreacion { get; set; }
        [Timestamp]
        public DateTime fechacreacion { get; set; }
    }

    public class Extras: NovedadesNomina
    {        
        public decimal cedula { get; set; }        
    }
}
