using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CareerCloud.WebAPI.Controllers
{
    [Route("api/careercloud/security/v1")]
    [ApiController]
    public class SecurityLoginsRoleController : ControllerBase
    {
        private readonly SecurityLoginsRoleLogic _logic;

        public SecurityLoginsRoleController()
        {
            var repo = new EFGenericRepository<SecurityLoginsRolePoco>();
            _logic = new SecurityLoginsRoleLogic(repo);

        }

        [HttpGet]
        [Route("loginsrole/{id}")]
        public ActionResult GetSecurityLoginsRole(Guid id)
        {
            SecurityLoginsRolePoco poco = _logic.Get(id);
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
        [Route("loginsrole")]
        public ActionResult GetAllSecurityLoginRole()
        {
            var roles = _logic.GetAll();
            if (roles == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(roles);
            }

        }

        [HttpPost]
        [Route("loginsrole")]
        public ActionResult PostSecurityLoginRole(
            [FromBody] SecurityLoginsRolePoco[] secLogRolePocos)
        {
            _logic.Add(secLogRolePocos);
            return Ok();
        }

        [HttpPut]
        [Route("loginsrole")]
        public ActionResult PutSecurityLoginRole(
            [FromBody] SecurityLoginsRolePoco[] secLogRolePocos)
        {
            _logic.Update(secLogRolePocos);
            return Ok();
        }

        [HttpDelete]
        [Route("loginsrole")]
        public ActionResult DeleteSecurityLoginRole(
            [FromBody] SecurityLoginsRolePoco[] secLogRolePocos)
        {
            _logic.Delete(secLogRolePocos);
            return Ok();
        }
    }
}
