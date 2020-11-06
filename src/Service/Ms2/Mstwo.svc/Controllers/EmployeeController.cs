using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using MstwoData;
using MstwoData.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Mstwo.svc.Controllers
{

    public class EmployeeController : BaseController
    {
        private readonly IRepository _service;
        private IWebHostEnvironment _hostingEnvironment;
        public EmployeeController(IRepository service, IWebHostEnvironment hostingEnvironment)
        {
            _service = service;
            _hostingEnvironment = hostingEnvironment;
        }

        // GET: api/Media/Code
        [HttpGet(ApiRoutes.Employee.GetEmployee)]
        public async Task<IActionResult> Get(string Code, CancellationToken cancellationToken)
        {
            var result = await _service.GetEmployee(Code, cancellationToken);
            return Ok(result);
        }



        // POST api/Media/Create
        [HttpPost(ApiRoutes.Employee.CreateEmployee)]
        public async Task<IActionResult> Create([FromBody] tblEmployeeDetails mediaDtos, CancellationToken cancellationToken)
        {
            var result = await _service.InsertEmployee(mediaDtos, cancellationToken);
            return Ok(result);
        }

        // PUT api/Media/Edit
        [HttpPut(ApiRoutes.Employee.UpdateEmployee)]
        public async Task<IActionResult> Update(string Code, [FromBody] tblEmployeeDetails mediaDto, CancellationToken cancellationToken)
        {
            var result = await _service.UpdateEmployee(Code, mediaDto, cancellationToken);
            return Ok(result);
        }

        // DELETE api/Film/Media/5
        [HttpDelete(ApiRoutes.Employee.DeleteEmployee)]
        public async Task<IActionResult> Delete(string Code, CancellationToken cancellationToken)
        {
            var result = await _service.DeleteEmployee(Code, cancellationToken);
            return Ok(result);
        }

    
    }
}
