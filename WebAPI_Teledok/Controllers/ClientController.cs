using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI_Teledok.Class;

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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> Get()
        {
            if(_context.Clients == null)
            {
                return NotFound();

            }
            return await _context.Clients.ToListAsync();
        }
    }
}
