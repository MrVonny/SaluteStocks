import {atom, selector} from "recoil";


export interface Range {
    from: number;
    to: number;
}

export interface Screener {
    marketCap: Range;
    epsGrowth1Year: Range;
    epsGrowth3Year: Range;
}

export const marketCapState = atom({
    key: 'marketCap',
    default: {from: 0, to: 100 } as Range
})

export const ebitdaState = atom({
    key: 'ebitda',
    default: {from: 0, to: 100 } as Range
})

export const debtEquityState = atom({
    key: 'debtEquityRatio',
    default: {from: 0, to: 100 } as Range
})

export const peRatioState = atom({
    key: 'peRatio',
    default: {from: 0, to: 100 } as Range
})

export const epsGrowth1YearState = atom({
    key: 'epsGrowth1Year',
    default: {from: 0, to: 100 } as Range
})

export const epsGrowth3YearState = atom({
    key: 'epsGrowth3Year',
    default: {from: 0, to: 100 } as Range
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