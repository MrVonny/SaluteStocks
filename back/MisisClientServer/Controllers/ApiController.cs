using System.Text;
using System.Text.Json.Nodes;
using Microsoft.AspNetCore.Mvc;
using MisisClientServer.Screener;
using MisisClientServer.Service;
using Newtonsoft.Json;

namespace MisisClientServer.Controllers;

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
        return JsonConvert.SerializeObject(new {Message = Directory.GetCurrentDirectory()});
    }

    [Route("create-file")]
    public string CreateFile()
    {
        Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "dead_inside"));
        return "Ok";
    }

    [Route("screener-model")]
    public async Task<IActionResult> GetScreenerModel()
    {
        var model = await _screenerService.GetInitialModelAsync();
        return Ok(JsonConvert.SerializeObject(model));
    }

    [Route("distribution/market-cap/{pieces}")]
    public async Task<string> GetMarketCapDistribution(int pieces)
    {
        var distr = await _screenerService.Distributions.MarketCap(pieces);
        return JsonConvert.SerializeObject(distr);
    }

    [Route("distribution/ebitda/{pieces}")]
    public async Task<string> GetEbitdaDistribution(int pieces)
    {
        var distr = await _screenerService.Distributions.Ebitda(pieces);
        return JsonConvert.SerializeObject(distr);
    }

    [Route("distribution/pe/{pieces}")]
    public async Task<string> GetPeRatioDistribution(int pieces)
    {
        var distr = await _screenerService.Distributions.PeRation(pieces);
        return JsonConvert.SerializeObject(distr);
    }

    [Route("distribution/eps/{pieces}")]
    public async Task<string> GetEpsDistribution(int pieces)
    {
        var distr = await _screenerService.Distributions.Eps(pieces);
        return JsonConvert.SerializeObject(distr);
    }

    [Route("distribution/beta/{pieces}")]
    public async Task<string> GetBetaDistribution(int pieces)
    {
        var distr = await _screenerService.Distributions.Beta(pieces);
        return JsonConvert.SerializeObject(distr);
    }

    [Route("screener/companies")]
    [HttpPost]
    public async Task<IActionResult> GetCompanies([FromBody] dynamic screener)
    {
        dynamic res = JsonConvert.DeserializeObject(screener.ToString());
        ScreenerModel screenerModel = JsonConvert.DeserializeObject<ScreenerModel>(screener.ToString());

        SetScreenerProperties(screenerModel, res);

        var symbols = await _screenerService.GetStockSymbols(screenerModel);
        var companies = await _screenerService.GetCompanies(symbols);
        return Ok(companies);
    }

    [Route("screener/count")]
    [HttpPost]
    public async Task<IActionResult> GetCompaniesCount([FromBody] dynamic screener)
    {
        dynamic res = JsonConvert.DeserializeObject(screener.ToString());
        ScreenerModel screenerModel = JsonConvert.DeserializeObject<ScreenerModel>(screener.ToString());

        SetScreenerProperties(screenerModel, res);

        var count = await _screenerService.Count(screenerModel);
        return Ok(count);
    }

    private ScreenerModel SetScreenerProperties(ScreenerModel screenerModel, dynamic res)
    {
        if (res?["marketCap"]?["from"] != null && res?["marketCap"]?["to"] != null)
            screenerModel.MarketCap = new RangedValue<double>((double) res!["marketCap"]["from"] * 10e9,
                (double) res["marketCap"]["to"] * 10e9);

        if (res?["ebitda"]?["from"] != null && res?["ebitda"]?["to"] != null)
            screenerModel.Ebitda = new RangedValue<double>((double) res!["ebitda"]["from"] * 10e9,
                (double) res["ebitda"]["to"] * 10e9);

        if (res?["peRatio"]?["from"] != null && res?["peRatio"]?["to"] != null)
            screenerModel.PERatio =
                new RangedValue<double>((double) res!["peRatio"]["from"], (double) res["peRatio"]["to"]);

        if (res?["eps"]?["from"] != null && res?["eps"]?["to"] != null)
            screenerModel.EPS = new RangedValue<double>((double) res!["eps"]["from"], (double) res["eps"]["to"]);

        if (res?["beta"]?["from"] != null && res?["beta"]?["to"] != null)
            screenerModel.Beta = new RangedValue<double>((double) res!["beta"]["from"], (double) res["beta"]["to"]);

        return screenerModel;
    }
}