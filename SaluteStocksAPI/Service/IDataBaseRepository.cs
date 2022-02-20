using SaluteStocksAPI.DataBase;
using SaluteStocksAPI.Models.FundamentalData;
using SaluteStocksAPI.Screener;

namespace SaluteStocksAPI.Service;

public interface IDataBaseRepository
{
    public Task SetListing(object listing);
    public Task<List<string>> GetListing();
    
    public Task Set<T>(T entity) where T : EntityInfo;
    public Task<T> Get<T>(string symbol) where T : EntityInfo;
    public Task<string> GetOldestSymbol<T>() where T : EntityInfo;
}