using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Marco.AspNetCore.ApiConfiguration
{
    [Authorize]
    [ApiController]
    [Produces("application/json")]
    [Route("api/v{api-version:apiVersion}/[controller]")]
    public abstract class ApiBaseController: ControllerBase
    {

    }
}