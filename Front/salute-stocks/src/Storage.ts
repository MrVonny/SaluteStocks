import {atom} from "recoil";

export interface MarketCap {
    from?: number;
    to?: number;
}


export interface Screener {
    symbol?: string;
    marketCap?: MarketCap;
}

export const screenerState = atom({
    key: "screener",
    default: {symbol: "IBM", marketCap: {from:10, to:90}} as Screener
})