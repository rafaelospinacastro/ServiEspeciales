using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ServiEspeciales.Entities
{
    public class ContratosLaborales
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idcontrato { get; set; }
        public int idestado { get; set; }
        public int idarl { get; set; }
        public int idcargo { get; set; }
        public int idtipodocumento { get; set; }
        public Decimal numerodocumento { get; set; }
        public string primerapellido { get; set; }
        public string segundoapellido { get; set; }
        public string primernombre { get; set; }
        public string segundonombre { get; set; }
        public DateTime? fechainicio { get; set; }
        public DateTime? fechafin { get; set; }
        public Decimal salario { get; set; }
        public string usuariocreacion { get; set; }
        
        public DateTime fechacreacion { get; set; }
    }
    public class ReporteEmpleado
    {

        public string TipoDocumento { get; set; }
        public Decimal NumeroDocumento { get; set; }
        public string Nombres { get; set; }
        public int NumeroContrato { get; set; }
        public string Cargo { get; set; }
        public Decimal ARL { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFinal { get; set; }
        public Decimal Salario { get; set; }
    }
    public class CalcularSeguridadSocial
    {

        public string Tipo { get; set; }
        public string PorcentajeEmpleador { get; set; }
        public Decimal ValorEmpleador { get; set; }
        public string PorcentajeTrabajador { get; set; }
        public Decimal ValorTrabajador { get; set; }
    }
}
