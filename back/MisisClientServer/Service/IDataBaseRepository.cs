using MisisClientServer.DataBase;
using MisisClientServer.Models.FundamentalData;

namespace MisisClientServer.Service;

public interface IDataBaseRepository
{
    public Task SetListing(List<ListingRow> listing);
    public Task<List<ListingRow>> GetListing();
    
    public Task AddOrUpdate<T>(T entity) where T : EntityInfo;
    public Task<T> Get<T>(string symbol) where T : EntityInfo;
    public Task<string> GetOldestSymbol<T>() where T : EntityInfo;
}