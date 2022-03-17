using Curd.CommonLayer.Model;
using Curd.ServiceLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Curd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CURDoperationController : ControllerBase
    {


        public readonly ICurdOprationSL _CurdOprationSL;
        public CURDoperationController (ICurdOprationSL curdOprationSL)
        {
            _CurdOprationSL = curdOprationSL;        }


        [HttpPost]
        public async Task<IActionResult> CreateRecord(CreateRecordRequest request)
        {

            try
            {

            }
            catch
            {

            }

               
        }
    }
}
