using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Mstwo.svc.Controllers
{
    //[ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    //[Route("api/[controller]")]
    [EnableCors("EnableCORS")]
    public abstract class BaseController : Controller
    {
       
    }
}
                                                                                                                                                                                                                                                                                                                                                                                                                             