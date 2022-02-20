﻿using SaluteStocksAPI.Models.FundamentalData;
using SaluteStocksAPI.Screener;

namespace SaluteStocksAPI.Service;

public interface IDataBaseRepository
{
    public Task SetListing(object listing);
    public Task<List<string>> GetListing();


    public Task SetCompanyOverview(CompanyOverview companyOverview);
    Task<string> GetOldestCompanyOverviewSymbol();
}