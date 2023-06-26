using ApiRealidadVirtual.Entidades;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiRealidadVirtual.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HerramientasController: ControllerBase
    {
        private readonly ILogger<LenguajesController> _logger;
        private readonly IMapper _mapper;
        private RealidadVirtualContext db = new RealidadVirtualContext();

        public HerramientasController(ILogger<LenguajesController> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("All")]
        public IActionResult GetAll()
        {
            var herramienta = db.Herammienta.ToList();

            if(herramienta == null)
            {
                return NotFound();
            }

            List<HerammientumConsultar> _herramienta = null;

            try
            {
                _herramienta = _mapper.Map<List<HerammientumConsultar>>(herramienta);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

            return Ok(_herramienta);
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            var herramienta = db.Herammienta
                .FirstOrDefault(l => l.Herramientaid == id);

            if(herramienta == null)
            {
                return NotFound();
            }

            HerammientumConsultar _herramienta = null;

            try
            {
                _herramienta = _mapper.Map<HerammientumConsultar>(herramienta);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

            return Ok(_herramienta);
        }

        [HttpPost]
        public IActionResult Post(HerammientumCreate _herramienta)
        {
            Herammientum herramienta = null;

            try
            {
                herramienta = _mapper.Map<Herammientum>(_herramienta);

                if(!_herramienta.DePaga)
                    herramienta.Precio = "Gratis";

                db.Add(herramienta);

                db.SaveChanges();
            }
            catch(Exception ex)
            {
                StatusCode(500, ex.Message);
            }

            return Ok(herramienta != null ? herramienta.Herramientaid : null);
        }

        [HttpPut]
        public IActionResult Put(HerammientumCreate _herramienta, int id)
        {

            //var lenguaje = db.Lenguajes.FirstOrDefault(l => l.Lenguajeid == id);

            //if(lenguaje != null)
            //{
            //    try
            //    {
            //        db.Anexos.Where(a => a.Lenguajeid == lenguaje.Lenguajeid).ExecuteDelete();

            //        lenguaje.Descripcion = _lenguaje.Descripcion;
            //        lenguaje.Titulo = _lenguaje.Titulo;
            //        lenguaje.Imagen = _lenguaje.Imagen;

            //        db.SaveChanges();

            //        foreach(AnexoCreate a in _lenguaje.Anexos)
            //        {
            //            var anexoEntity = _mapper.Map<Anexo>(a);

            //            anexoEntity.Lenguajeid = id;

            //            db.Add(anexoEntity);
            //            db.SaveChanges();
            //        }
            //    }
            //    catch(Exception ex)
            //    {
            //        return StatusCode(500, ex.Message);
            //    }
            //}
            //else
            //{
            //    return NotFound();
            //}


            return Ok(id);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                int result = db.Herammienta.Where(l => l.Herramientaid == id).ExecuteDelete();
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }

            return Ok();
        }
    }
}
