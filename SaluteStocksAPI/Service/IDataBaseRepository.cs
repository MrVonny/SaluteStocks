using SaluteStocksAPI.DataBase;
using SaluteStocksAPI.Models.FundamentalData;

namespace SaluteStocksAPI.Service;

public interface IDataBaseRepository
{
    public Task SetListing(List<ListingRow> listing);
    public Task<List<ListingRow>> GetListing();
    
    public Task Set<T>(T entity) where T : EntityInfo;
    public Task<T> Get<T>(string symbol) where T : EntityInfo;
    public Task<string> GetOldestSymbol<T>() where T : EntityInfo;
}