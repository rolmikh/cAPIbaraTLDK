using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI_Teledok.Class;

namespace WebAPI_Teledok.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class TypeOfClientController : ControllerBase
    {
        private readonly Teledok_Context _context;

        public TypeOfClientController(Teledok_Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TypeOfClient>>> Get()
        {
            if(_context.TypeOfClients == null)
            {
                return NotFound();
            }
            return await _context.TypeOfClients.ToListAsync();
        }
    }
}
