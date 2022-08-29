using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LBMJ.Api.Controllers.BaseController
{
    [Produces("application/json")]
    [ApiController]
    [Authorize]
    public class BaseAuthController : ControllerBase
    {

    }
}
