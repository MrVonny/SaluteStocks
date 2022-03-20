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
        return JsonConvert.SerializeObject(new { Message = Directory.GetCurrentDirectory() });
    }

    [Route("create-file")]
    public string CreateFile()
    {
        Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "dead_inside"));
        return "Ok";
    }
}