﻿namespace SaluteStocksAPI.Models.Core;

public class QuotesPeriodInfo
{
    
    public DateOnly TimeStamp { get; set; }
    public double Open { get; set; }
    public double High { get; set; }
    public double Low { get; set; }
    public double Close { get; set; }
    public double Volume { get; set; }
}