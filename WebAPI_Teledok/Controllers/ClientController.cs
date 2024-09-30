using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using WebAPI_Teledok.Class;
using WebAPI_Teledok.DTO;

namespace WebAPI_Teledok.Controllers
{

    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly Teledok_Context _context;

        public ClientController(Teledok_Context context)
        {
            _context = context;
        }

        /// <summary>
        /// Получение списка клиентов
        /// </summary>
        /// <returns></returns>
        //GET Client
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> Get()
        {
            if(_context.Clients == null)
            {
                return NotFound();

            }
            return await _context.Clients.ToListAsync();
        }
        /// <summary>
        /// Получение одного клиента
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //GET BY ID Client
        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> GetByID(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var client = await _context.Clients.FindAsync(id);
            
            if(client == null)
            {
                return NotFound();
            }
            return Ok(client);
        }
        /// <summary>
        /// Добавление клиента
        /// </summary>
        /// <param name="newClientDTO"></param>
        /// <returns></returns>
        //POST Client
        [HttpPost]
        public async Task<ActionResult<Client>> Post (ClientDTO newClientDTO)
        {
            try
            {
                var existingType = await _context.TypeOfClients.FindAsync(newClientDTO.TypeOfClientID);
                if (existingType == null)
                {
                    return BadRequest("Type Of Client does not exist.");
                }

                var client = new Client
                {
                    INNClient = newClientDTO.INNClient,
                    NameClient = newClientDTO.NameClient,
                    DateOfAdditionClient = DateTime.Now,
                    DateOfUpdateClient = null,
                    TypeOfClientID = newClientDTO.TypeOfClientID,
                };

                _context.Clients.Add(client);
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetByID", new { id = client.IdClient }, client);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        /// <summary>
        /// Обновление данных клиента
        /// </summary>
        /// <param name="id"></param>
        /// <param name="clientDTO"></param>
        /// <returns></returns>
        //PUT Client
        [HttpPut]
        public async Task<ActionResult> Put (int? id, ClientDTO clientDTO)
        {
            var client = await _context.Clients.FindAsync(id);

            if(id != client.IdClient)
            {
                return BadRequest();
            }
            try
            {
                var existingType = await _context.TypeOfClients.FindAsync(clientDTO.TypeOfClientID);
                if (existingType == null)
                {
                    return BadRequest("Type Of Client does not exist.");
                }
                client.INNClient = clientDTO.INNClient;
                client.NameClient = clientDTO.NameClient;
                client.TypeOfClientID = existingType.IdTypeOfClient;
                client.DateOfUpdateClient = DateTime.Now;

                await _context.SaveChangesAsync();
                return Ok(client);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Удаление клиента
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //DELETE Client
        [HttpDelete]
        public async Task<IActionResult> Delete(int? id)
        {
            if(_context.Clients == null)
            {
                return BadRequest();
            }

            var client = await _context.Clients.FindAsync(id);

            if (client == null)
            {
                return NotFound();
            }

            try
            {
                _context.Clients.Remove(client);
                await _context.SaveChangesAsync();
                return Ok();
            }catch(Exception ex) 
            {
                return BadRequest(ex.Message);

            }
        }


    }
}
