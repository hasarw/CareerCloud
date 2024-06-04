using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CareerCloud.WebAPI.Controllers
{
    [Route("api/careercloud/security/v1")]
    [ApiController]
    public class SecurityRoleController : ControllerBase
    {
        private readonly SecurityRoleLogic _logic;

        public SecurityRoleController()
        {
            var repo = new EFGenericRepository<SecurityRolePoco>();
            _logic = new SecurityRoleLogic(repo);
        }

        [HttpGet]
        [Route("role/{id}")]
        public ActionResult GetSecurityRole(Guid id)
        {
            SecurityRolePoco poco = _logic.Get(id);
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
        [Route("role")]
        public ActionResult GetAllSecurityRole()
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
        [Route("role")]
        public ActionResult PostSecurityRole(
            [FromBody] SecurityRolePoco[] secRolePocos)
        {
            _logic.Add(secRolePocos);
            return Ok();
        }

        [HttpPut]
        [Route("role")]
        public ActionResult PutSecurityRole(
            [FromBody] SecurityRolePoco[] secRolePocos)
        {
            _logic.Update(secRolePocos);
            return Ok();
        }

        [HttpDelete]
        [Route("role")]
        public ActionResult DeleteSecurityRole(
            [FromBody] SecurityRolePoco[] secRolePocos)
        {
            _logic.Delete(secRolePocos);
            return Ok();
        }
    }
}
