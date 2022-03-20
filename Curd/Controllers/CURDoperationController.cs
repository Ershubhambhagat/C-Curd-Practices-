using Curd.CommonLayer.Model;
using Curd.ServiceLayer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Curd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CURDoperationController : ControllerBase
    {


        public readonly ICurdOprationSL _CurdOprationSL;
        public CURDoperationController(ICurdOprationSL curdOprationSL)
        {
            _CurdOprationSL = curdOprationSL;
        }


        [HttpPost]
        [Route(template: "CreateRecord ")]
        public async Task<IActionResult> CreateRecord(CreateRecordRequest request)
        {
            CreateReacordReasponce responce = null;
            try
            {
                responce = await _CurdOprationSL.CreateRecord(request);
            }
            catch (Exception ex)
            {
                responce.Issuccess = false;
                responce.Message = ex.Message;
            }
            return Ok(responce);
        }


        //Read Recrord From Here 


        [HttpGet]
        [Route(template:"ReadRecord")]
        public  async Task<IActionResult> ReadRecord()
        {
            ReadRecord response=null; 
            try
            {
                response = await _CurdOprationSL.ReadRecord();
            }
            catch(Exception ex)
            {
              

            }
            return Ok(response); 
        }


        //  for update      


        [HttpPut]
        [Route(template: "UpdateRecord")]

        public async Task<IActionResult> UpdateRecord(UpdateRecordRequest request)
        {
            UpdateRecordResponse response = null;
            try
            {
                response = await _CurdOprationSL.updateRecord(request);
            }
            catch (Exception ex)
            {


            }
            return Ok(response);
        }

        // Delete Api

    }
}
