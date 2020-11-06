using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using MsoneData;
using System.Threading;
using System.Threading.Tasks;

namespace Msone.svc.Controllers
{

    public class CompanyController : BaseController
    {
        private readonly IRepository _service;
        private IWebHostEnvironment _hostingEnvironment;
        public CompanyController(IRepository service, IWebHostEnvironment hostingEnvironment)
        {
            _service = service;
            _hostingEnvironment = hostingEnvironment;
        }

        // GET: api/Media/Code
        [HttpGet(ApiRoutes.Company.GetCompany)]
        public async Task<IActionResult> Get(string Code, CancellationToken cancellationToken)
        {
            var result = await _service.GetCompany(Code, cancellationToken);
            return Ok(result);
        }



        // POST api/Media/Create
        [HttpPost(ApiRoutes.Company.CreateCompany)]
        public async Task<IActionResult> Create([FromBody] tblCompanyDetails mediaDtos, CancellationToken cancellationToken)
        {
            var result = await _service.InsertCompany(mediaDtos, cancellationToken);
            return Ok(result);
        }

        // PUT api/Media/Edit
        [HttpPut(ApiRoutes.Company.UpdateCompany)]
        public async Task<IActionResult> Update(string Code, [FromBody] tblCompanyDetails mediaDto, CancellationToken cancellationToken)
        {
            var result = await _service.UpdateCompany(Code, mediaDto, cancellationToken);
            return Ok(result);
        }

        // DELETE api/Film/Media/5
        [HttpDelete(ApiRoutes.Company.DeleteCompany)]
        public async Task<IActionResult> Delete(string Code, CancellationToken cancellationToken)
        {
            var result = await _service.DeleteCompany(Code, cancellationToken);
            return Ok(result);
        }

    
    }
}
