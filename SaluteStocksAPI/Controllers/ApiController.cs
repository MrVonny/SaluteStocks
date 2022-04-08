using System.Text.Json.Nodes;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SaluteStocksAPI.Service;

namespace SaluteStocksAPI.Controllers;

[ApiController]
[Route("api")]
public class ApiController : ControllerBase
{
    private readonly ScreenerService _screenerService;

    public ApiController(ScreenerService screenerService)
    {
        _screenerService = screenerService;
    }

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

    [Route("screener-model")]
    public async Task<string> GetScreenerModel()
    {
        throw new InvalidOperationException();
    }

    [Route("distribution/market-cap/{pieces}")]
    public async Task<string> GetMarketCapDistribution(int pieces)
    {
        var distr = await _screenerService.Distributions.MarketCap(pieces);
        return JsonConvert.SerializeObject(distr);
    }
    
    //ToDo
    //distribution/*
}