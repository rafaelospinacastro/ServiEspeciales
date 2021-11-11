using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiEspeciales.Data;
using ServiEspeciales.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiEspeciales.Controllers
{
    public class ContratoLaboral : Controller
    {
        private readonly PruebaContext _context;

        public ContratoLaboral(PruebaContext context)
        {
            _context = context;
        }
        // GET: ContratoLaboral
        public ActionResult Index()
        {
            return View(_context.ContratosLaborales.ToList());
        }

        // GET: ContratoLaboral/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ContratoLaboral/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContratoLaboral/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ContratoLaboral/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ContratoLaboral/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ContratoLaboral/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ContratoLaboral/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        public IActionResult ConsultaContrato(decimal cedula)
        {
            
            if (!cedula.Equals(null))
            {

                var consulta = (from contrato in _context.ContratosLaborales
                                join arl in _context.Arl
                                on contrato.idarl equals arl.idarl
                                join tipodoc in _context.TipoDocumento
                                on contrato.idtipodocumento equals tipodoc.idtipodocumento
                                join cargo in _context.Cargo
                                on contrato.idcargo equals cargo.idcargo
                                where contrato.numerodocumento == cedula
                                select new ReporteEmpleado
                                {
                                    TipoDocumento = tipodoc.nombre,
                                    NumeroDocumento = contrato.numerodocumento,
                                    Nombres = contrato.primerapellido + ' ' + contrato.segundoapellido + ' ' + contrato.primernombre + ' ' + contrato.segundonombre,
                                    NumeroContrato = contrato.idcontrato,
                                    Cargo = cargo.nombre, 
                                    //Cargo = "",//cargo.nombre, 
                                    ARL = arl.valor,
                                    FechaInicio = contrato.fechainicio,
                                    FechaFinal = contrato.fechafin,
                                    Salario = contrato.salario
                                }).FirstOrDefault();
                return View(consulta);
            }
            return View();
        }
        public IActionResult ConsultaSeguridad(decimal cedula)
        {
            //var porcentaje = 100;
            if (!cedula.Equals(null))
            {

                var salario = (from contrato in _context.ContratosLaborales
                               where contrato.numerodocumento == cedula
                               select contrato.salario).SingleOrDefault();
                List<CalcularSeguridadSocial> resultado = new List<CalcularSeguridadSocial>();
                resultado.Add(new CalcularSeguridadSocial
                {
                    Tipo = "Salud",
                    PorcentajeEmpleador = "12,5%",
                    PorcentajeTrabajador = "4%",
                    ValorEmpleador = Convert.ToDecimal(Convert.ToInt32(salario) * 12.5 / 100),
                    ValorTrabajador = Convert.ToDecimal(Convert.ToInt32(salario) * 4 / 100)
                }
                    );
                resultado.Add(new CalcularSeguridadSocial
                {
                    Tipo = "Pensión",
                    PorcentajeEmpleador = "16,0%",
                    PorcentajeTrabajador = "4%",
                    ValorEmpleador = Convert.ToDecimal(Convert.ToInt32(salario) * 16 / 100),
                    ValorTrabajador = Convert.ToDecimal(Convert.ToInt32(salario) * 4 / 100)
                }
                   );
                return View(resultado);
            }
            return View();


        }

        public IActionResult Extras()
        {
            return View();
        }

        // POST: PU_Registro_Tipo2/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Extras(Extras extras)
        {
            if (ModelState.IsValid)
            {
                var conteo = (from contrato in _context.ContratosLaborales                                
                                where contrato.numerodocumento == extras.cedula
                                select contrato.salario).Count();
                if (conteo == 0)
                {
                    ViewBag.Mensaje = "El documento de identidad no existe";
                    return View();
                    
                }
                var idcontrato = (from contrato in _context.ContratosLaborales
                              where contrato.numerodocumento == extras.cedula
                              select contrato.idcontrato).FirstOrDefault();

                var idextras = (from contrato in _context.ContratosLaborales
                              select contrato.salario).Count();
                idextras += 2;
                NovedadesNomina novedades = new NovedadesNomina();
                novedades.usuariocreacion = "Sistema";
                novedades.fechacreacion = DateTime.Now;
                novedades.descuentos = extras.descuentos;
                novedades.horaextradiurna = extras.horaextradiurna;
                novedades.horaextranocturna = extras.horaextranocturna;
                novedades.horaextradominical = extras.horaextradominical;
                novedades.horaextrafestiva = extras.horaextrafestiva;
                novedades.horaslaboradas = extras.horaslaboradas;
                novedades.periodolaborado = extras.periodolaborado;
                novedades.idcontrato = idcontrato;
                novedades.idnovedadnomina = idextras;



                _context.Add(novedades);
                
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));


            }
            return View();
        }
    }
}
