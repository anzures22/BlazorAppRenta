using BlazorApp3.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Productos.Server.Controllers
{
    [ApiController, Route("api/socios")]
    public class SociosController : ControllerBase
    {
        private readonly SQLDBContext _context;
        private readonly ILogger<SociosController> _logger;

        public SociosController(SQLDBContext context, ILogger<SociosController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet, Route("getsocios")]
        public async Task<IActionResult> GetSociosAsync()
        {
            try
            {
                var list = await _context.Socios.ToListAsync();
                return Ok(list);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener la lista de socios.");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet, Route("getsocio/{id}")]
        public async Task<IActionResult> GetSocioByIdAsync(int id)
        {
            try
            {
                var socio = await _context.Socios.FindAsync(id);
                if (socio == null)
                {
                    return NotFound();
                }
                return Ok(socio);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener el socio.");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost, Route("addsocio")]
        public async Task<IActionResult> AddSocio(Socios socio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _context.Add(socio);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetSocioByIdAsync), new { id = socio.Id }, socio);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al agregar el socio.");
                return BadRequest();
            }
        }

        //[HttpPost, Route("editsocio")]
        //public async Task<IActionResult> EditSocio(Socios socio)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    _context.Entry(socio).State = EntityState.Modified;
        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //        return Ok(socio);
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!SocioExists(socio.Id))
        //        {
        //            return NotFound();
        //        }
        //        return StatusCode(500, "Error de concurrencia en la base de datos");
        //    }
        //}

        [HttpPut, Route("editsocio")]
        public async Task<IActionResult> EditSocio(Socios socio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Entry(socio).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
                return Ok(socio);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SocioExists(socio.Id))
                {
                    return NotFound();
                }
                return StatusCode(500, "Error de concurrencia en la base de datos");
            }
        }


        [HttpDelete("deletesocio/{id}")]
        public async Task<IActionResult> DeleteSocio(int id)
        {
            var socio = await _context.Socios.FindAsync(id);
            if (socio == null)
            {
                return NotFound();
            }

            _context.Socios.Remove(socio);
            await _context.SaveChangesAsync();
            return Ok();
        }

        private bool SocioExists(int id)
        {
            return _context.Socios.Any(s => s.Id == id);
        }
    }
}
