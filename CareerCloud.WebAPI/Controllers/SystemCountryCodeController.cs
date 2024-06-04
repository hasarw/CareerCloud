using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CareerCloud.WebAPI.Controllers
{
    [Route("api/careercloud/system/v1")]
    [ApiController]
    public class SystemCountryCodeController : ControllerBase
    {
        private readonly SystemCountryCodeLogic _logic;

        public SystemCountryCodeController()
        {
            var repo = new EFGenericRepository<SystemCountryCodePoco>();
            _logic = new SystemCountryCodeLogic(repo);
        }

        [HttpGet]
        [Route("CountryCode/{code}")]
        public ActionResult GetSystemCountryCode(String Guid)
        {
            SystemCountryCodePoco poco = _logic.Get(Guid);
            if (poco == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(poco);
            }
        }

        [HttpGet]
        [Route("CountryCode")]
        public ActionResult GetAllSystemCountryCode()
        {
            var countries = _logic.GetAll();
            if (countries == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(countries);
            }

        }

        [HttpPost]
        [Route("CountryCode")]
        public ActionResult PostSystemCountryCode(
            [FromBody] SystemCountryCodePoco[] sysCountPocos)
        {
            _logic.Add(sysCountPocos);
            return Ok();
        }

        [HttpPut]
        [Route("CountryCode")]
        public ActionResult PutSystemCountryCode(
            [FromBody] SystemCountryCodePoco[] sysCountPocos)
        {
            _logic.Update(sysCountPocos);
            return Ok();
        }

        [HttpDelete]
        [Route("CountryCode")]
        public ActionResult DeleteSystemCountryCode(
            [FromBody] SystemCountryCodePoco[] sysCountPocos)
        {
            _logic.Delete(sysCountPocos);
            return Ok();
        }
    }
}
