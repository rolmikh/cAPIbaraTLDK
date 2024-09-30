using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI_Teledok.Class;
using WebAPI_Teledok.DTO;

namespace WebAPI_Teledok.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    public class FounderController : ControllerBase
    {
        private readonly Teledok_Context _context;

        public FounderController(Teledok_Context context)
        {
            _context = context;
        }

        /// <summary>
        /// Получение списка учредителей
        /// </summary>
        /// <returns></returns>
        //GET Founder
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Founder>>> Get()
        {
            if (_context.Founders == null)
            {
                return NotFound();
            }

            return await _context.Founders.ToListAsync();
        }

        /// <summary>
        /// Получение одного учредителя
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //GET BY ID Founder 
        [HttpGet("id")]
        public async Task<ActionResult<Founder>> GetByID(int id)
        {
            if (_context == null)
            {
                return NotFound();
            }
            var founder = await _context.Founders.FindAsync(id);

            if (founder == null)
            {
                return NotFound();
            }

            return Ok(founder);
        }

        /// <summary>
        /// Добавление учредителя
        /// </summary>
        /// <param name="newFounder"></param>
        /// <returns></returns>
        //POST Founder
        [HttpPost]
        public async Task<ActionResult<Founder>> Post(FounderDTO newFounderDTO)
        {
            try
            {
                var existingClient = await _context.Clients.FindAsync(newFounderDTO.ClientID);
                if(existingClient == null)
                {
                    return BadRequest("Client does not exist.");
                }
                var founder = new Founder
                {
                    INNFounder = newFounderDTO.INNFounder,
                    SurnameFounder = newFounderDTO.SurnameFounder,
                    NameFounder = newFounderDTO.NameFounder,
                    MiddleNameFounder = newFounderDTO.MiddleNameFounder,
                    DateOfAdditionFounder = DateTime.Now,
                    DateOfUpdateFounder = null,
                    ClientID = existingClient.IdClient,
                };

                _context.Founders.Add(founder);
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetByID" , new {id = founder.IdFounder}, founder);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        /// <summary>
        /// Обновление данных о учредителе
        /// </summary>
        /// <param name="id"></param>
        /// <param name="putFounderDTO"></param>
        /// <returns></returns>
        //PUT Founder
        [HttpPut]
        public async Task<IActionResult> Put (int? id, FounderDTO putFounderDTO)
        {
            var founder = await _context.Founders.FindAsync(id);

            if (id != founder.IdFounder)
            {
                return BadRequest();
            }
            try
            {
                var existingClient = await _context.Clients.FindAsync(putFounderDTO.ClientID);
                if (existingClient == null)
                {
                    return BadRequest("Client does not exist.");
                }
                founder.INNFounder = putFounderDTO.INNFounder;
                founder.SurnameFounder = putFounderDTO.SurnameFounder;
                founder.NameFounder = putFounderDTO.NameFounder;
                founder.MiddleNameFounder = putFounderDTO.MiddleNameFounder;
                founder.DateOfUpdateFounder = DateTime.Now;
                founder.ClientID = existingClient.IdClient;

                await _context.SaveChangesAsync();
                return Ok(founder);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Удаление одного учредителя
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //DELETE Founder
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (_context.Founders == null)
            {
                return NotFound();
            }
            var founder = await _context.Founders.FindAsync(id);
            if (founder == null)
            {
                return NotFound();
            }
            try
            {
                _context.Founders.Remove(founder);
                await _context.SaveChangesAsync();
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }




    }
}
