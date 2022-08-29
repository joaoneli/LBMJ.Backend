using LBMJ.Api.Controllers.BaseController;
using LBMJ.Api.Requests;
using LBMJ.Bll.Infra;
using LBMJ.Models;
using LBMJ.Token.Service;
using Microsoft.AspNetCore.Mvc;

namespace LBMJ.Api.Controllers
{
    [Route("user")]
    [ApiController]
    public class UserController : BasePublicController
    {
        private readonly IUserBll _userBll;
        public UserController(IUserBll userBll)
        {
            _userBll = userBll;
        }

        [HttpPost("auth")]
        public async Task<ActionResult<dynamic>> AuthenticateAsync([FromBody] AuthRequest request) 
        {
            try
            {

                UserInfo entity = new UserInfo();
                entity.Login = request.login;
                entity.Password = request.password;

                var user = await _userBll.AuthenticateAsync(entity);
                if (user == null)
                    return NotFound(new { message = "Usuário ou senha inválidos." });

                user.Password = "";
                user.AccessToken = TokenService.GenerateToken(user);
                if (string.IsNullOrEmpty(user.AccessToken))
                    return BadRequest(new { message = "Não foi possível gerar um token de acesso." });

                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
