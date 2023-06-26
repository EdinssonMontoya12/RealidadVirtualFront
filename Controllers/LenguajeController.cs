using ApiRealidadVirtual.Entidades;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiRealidadVirtual.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LenguajesController : ControllerBase
    {
        private readonly ILogger<LenguajesController> _logger;
        private readonly IMapper _mapper;
        private RealidadVirtualContext db = new RealidadVirtualContext();

        public LenguajesController(ILogger<LenguajesController> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("All")]
        public IActionResult GetAll()
        {
            var lenguajes = db.Lenguajes
                .Include( l => l.Anexos).ToList();

            if(lenguajes == null)
            {
                return NotFound();
            }

            List<LenguajeConsultar> _lenguajes = null;

            try
            {
                _lenguajes = _mapper.Map<List<LenguajeConsultar>>(lenguajes);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

            return Ok(_lenguajes);
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            var lenguajes = db.Lenguajes.
                Include( l => l.Anexos)
                .FirstOrDefault(l => l.Lenguajeid == id);

            if(lenguajes == null)
            {
                return NotFound();
            }

            LenguajeConsultar _lenguajes = null;

            try
            {
                _lenguajes = _mapper.Map<LenguajeConsultar>(lenguajes);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

            return Ok(_lenguajes);
        }

        [HttpPost]
        public IActionResult Post(LenguajeCreate _lenguaje)
        {
            Lenguaje lenguaje = null;

            try
            {
                lenguaje = _mapper.Map<Lenguaje>(_lenguaje);

                db.Add(lenguaje);

                db.SaveChanges();
            }
            catch(Exception ex)
            {
                StatusCode(500, ex.Message);
            }

            return Ok(lenguaje != null ? lenguaje.Lenguajeid : null);
        }

        [HttpPut]
        public IActionResult Put(LenguajeCreate _lenguaje, int id)
        {

            var lenguaje = db.Lenguajes.FirstOrDefault(l => l.Lenguajeid == id);

            if(lenguaje != null)
            {
                try
                {
                    db.Anexos.Where(a => a.Lenguajeid == lenguaje.Lenguajeid).ExecuteDelete();

                    lenguaje.Descripcion = _lenguaje.Descripcion;
                    lenguaje.Titulo = _lenguaje.Titulo;
                    lenguaje.Imagen = _lenguaje.Imagen;

                    db.SaveChanges();

                    foreach(AnexoCreate a in _lenguaje.Anexos)
                    {
                        var anexoEntity = _mapper.Map<Anexo>(a);

                        anexoEntity.Lenguajeid = id;

                        db.Add(anexoEntity);
                        db.SaveChanges();
                    }
                }
                catch(Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
            }
            else
            {
                return NotFound();
            }


            return Ok(id);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
               int result = db.Lenguajes.Where( l => l.Lenguajeid == id ).ExecuteDelete();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

            return Ok();
        }
    }

}

