using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CareerCloud.WebAPI.Controllers
{
    [Route("api/careercloud/security/v1")]
    [ApiController]
    public class SecurityLoginController : ControllerBase
    {
        private readonly SecurityLoginLogic _logic;

        public SecurityLoginController()
        {
            var repo = new EFGenericRepository<SecurityLoginPoco>();
            _logic = new SecurityLoginLogic(repo);
        }

        [HttpGet]
        [Route("login/{securityLoginId}")]
        public ActionResult GetSecurityLogin(Guid id)
        {
            SecurityLoginPoco poco = _logic.Get(id);
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
        [Route("login")]
        public ActionResult GetAllSecurityLogin()
        {
            var logins = _logic.GetAll();
            if (logins == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(logins);
            }

        }

        [HttpPost]
        [Route("login")]
        public ActionResult PostSecurityLogin(
            [FromBody] SecurityLoginPoco[] secLogPocos)
        {
            _logic.Add(secLogPocos);
            return Ok();
        }

        [HttpPut]
        [Route("login")]
        public ActionResult PutSecurityLogin(
            [FromBody] SecurityLoginPoco[] secLogPocos)
        {
            _logic.Update(secLogPocos);
            return Ok();
        }

        [HttpDelete]
        [Route("login")]
        public ActionResult DeleteSecurityLogin(
            [FromBody] SecurityLoginPoco[] secLogPocos)
        {
            _logic.Delete(secLogPocos);
            return Ok();
        }


    }
}
