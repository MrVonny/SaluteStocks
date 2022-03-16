using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace SaluteStocksAPI.Controllers;

[ApiController]
[Route("api")]
public class ApiController : ControllerBase
{
    [Route("ping")]
    public string Ping()
    {
        return JsonConvert.SerializeObject(new { Message = "Hello From API!" });
    }
}