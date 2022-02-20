using Microsoft.EntityFrameworkCore;
using SaluteStocksAPI.DataBase;
using SaluteStocksAPI.Models.FundamentalData;

namespace SaluteStocksAPI.Service;

class DataBaseRepository : IDataBaseRepository
{
    private readonly StocksContext _context;

    public DataBaseRepository(StocksContext context)
    {
        _context = context;
    }

    public async Task SetListing(List<ListingRow> listing)
    {
        _context.Listing.UpdateRange(listing);
        await _context.SaveChangesAsync();
    }

    public async Task<List<ListingRow>> GetListing()
    {
        return await _context.Listing.ToListAsync();
    }

    public async Task Set<T>(T entity) where T : EntityInfo
    {
        var dbSet = _context.Set<T>();
        dbSet.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<T> Get<T>(string symbol) where T : EntityInfo
    {
        return await _context.Set<T>().SingleOrDefaultAsync(e=>e.Symbol.Equals(symbol));
    }

    public async Task<string> GetOldestSymbol<T>() where T : EntityInfo
    {
        //ToDo: async реализация?
        return _context.Set<T>().MinBy(e => e.LastLocalRefresh)?.Symbol;
    }
}