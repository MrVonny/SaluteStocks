import {atom, selector} from "recoil";
import {Distribution} from "./Screener/ScreenerChart";


export declare type Range = {
    from: number;
    to: number;
}

export declare type ScreenerPropertyRangeStorage = {
    available: Range;
    selected: Range;
    distribution : Distribution;
    isLoaded : boolean;
}

export declare type Screener = {
    marketCap: Range;
    epsGrowth1Year: Range;
    epsGrowth3Year: Range;
}

export const marketCapState = atom({
    key: 'marketCap',
    default: {
        available: {from: 0, to: 100},
        selected: {from: 0, to: 100}
    } as ScreenerPropertyRangeStorage
})

export const ebitdaState = atom({
    key: 'ebitda',
    default: {
        available: {from: 0, to: 100},
        selected: {from: 0, to: 100}
    } as ScreenerPropertyRangeStorage
})

export const debtEquityState = atom({
    key: 'debtEquityRatio',
    default: {
        available: {from: 0, to: 100},
        selected: {from: 0, to: 100}
    } as ScreenerPropertyRangeStorage
})

export const peRatioState = atom({
    key: 'peRatio',
    default: {
        available: {from: 0, to: 100},
        selected: {from: 0, to: 100}
    } as ScreenerPropertyRangeStorage
})

export const epsGrowth1YearState = atom({
    key: 'epsGrowth1Year',
    default: {
        available: {from: 0, to: 100},
        selected: {from: 0, to: 100}
    } as ScreenerPropertyRangeStorage
})

export const epsGrowth3YearState = atom({
    key: 'epsGrowth3Year',
    default: {
        available: {from: 0, to: 100},
        selected: {from: 0, to: 100}
    } as ScreenerPropertyRangeStorage
})

export const screenerState = selector({
    key: "screenerValue",
    get: ({get}) => ({
        marketCap: get(marketCapState),
        ebitda: get(ebitdaState),
        debtEquity: get(debtEquityState),
        peRatio: get(peRatioState),
        epsGrowth1Year: get(epsGrowth1YearState),
        epsGrowth3Year: get(epsGrowth3YearState)
    })
});