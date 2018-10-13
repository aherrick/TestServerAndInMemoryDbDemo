using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestServerPOC.Data;

namespace TestServerInMemoryDbPOC.Controllers
{
    [Authorize(Policy = "Admin")]
    public class ApplicationUsersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ApplicationUsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult GetData()
        {
            return Ok(true);
        }
    }
}