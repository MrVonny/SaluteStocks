using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using MisisClientServer.DataBase;
using MisisClientServer.Models.FundamentalData;
using Serilog;

namespace MisisClientServer.Service;

public class DataBaseRepository : IDataBaseRepository
{
    private readonly StocksContext _context;

    public DataBaseRepository(StocksContext context)
    {
        _context = context;
    }
    
    public IQueryable<BalanceSheet> BalanceSheets =>_context.BalanceSheets.Where(x => x.ExistInApi == true);
    public IQueryable<CashFlow> CashFlows => _context.CashFlows.Where(x => x.ExistInApi == true);
    public IQueryable<CompanyOverview> CompanyOverviews => _context.CompanyOverviews.Where(x => x.ExistInApi == true);
    public IQueryable<Earnings> Earnings => _context.Earnings.Where(x => x.ExistInApi == true);
    public IQueryable<IncomeStatement> IncomeStatements => _context.IncomeStatements.Where(x => x.ExistInApi == true);

    public async Task SetListing(List<ListingRow> listing)
    {
        await _context.BulkInsertOrUpdateOrDeleteAsync(listing);
        await _context.BulkSaveChangesAsync();
    }

    public async Task<List<string>> GetListingSymbols()
    {
        return await _context.Listing.Select(x=>x.Symbol).ToListAsync();
    }
    public async Task<List<ListingRow>> GetListing()
    {
        return await _context.Listing.ToListAsync();
    }

    public async Task AddOrUpdate<T>(T entity) where T : EntityInfo
    {
        Log.Information("Start AddOrUpdate for {T}.", typeof(T));
        var dbSet = _context.Set<T>();
        var e = await dbSet.SingleOrDefaultAsync(x => x.Symbol.Equals(entity.Symbol));
        if (e == null)
        {
            Log.Information("Entity does not exist. Adding to DB.");
            dbSet.Add(entity);
        }
        else
        {
            Log.Information("Entity already exist. Updating entity DB.");
            _context.Entry(e).CurrentValues.SetValues(entity);
        }
        await _context.SaveChangesAsync();
        Log.Information("AddOrUpdate run successful.");
    }

    public async Task<T> Get<T>(string symbol) where T : EntityInfo
    {
        return await _context.Set<T>().SingleOrDefaultAsync(e=>e.Symbol.Equals(symbol));
    }

    public async Task<string> GetOldestSymbol<T>() where T : EntityInfo
    {
        var set =_context.Set<T>();
        var min = await set.MinAsync(x => x.LastLocalRefresh);
        return (await set.SingleOrDefaultAsync(e => e.LastLocalRefresh == min))?.Symbol;
    }
}