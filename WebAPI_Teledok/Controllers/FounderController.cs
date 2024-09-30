using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI_Teledok.Class;

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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Founder>>> Get()
        {
            if(_context.Founders == null)
            {
                return NotFound();
            }

            return await _context.Founders.ToListAsync();
        }
    }
}
