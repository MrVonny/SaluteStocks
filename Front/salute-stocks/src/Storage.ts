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
    isSelected: boolean;
    isRangeLoaded : boolean;
    isDistributionLoaded : boolean;
}

export declare type Screener = {
    marketCap: Range;
    epsGrowth1Year: Range;
    epsGrowth3Year: Range;
}

export const currencyState = atom({
    key: 'currency',
    default: {
        currencies: [] as string[]
    }
})

export const marketCapState = atom({
    key: 'marketCap',
    default: {
        available: {from: 0, to: 100},
        selected: {from: 0, to: 100},
        isRangeLoaded: false
    } as ScreenerPropertyRangeStorage
})

export const ebitdaState = atom({
    key: 'ebitda',
    default: {
        available: {from: 0, to: 100},
        selected: {from: 0, to: 100},
        isRangeLoaded: false
    } as ScreenerPropertyRangeStorage
})

export const debtEquityState = atom({
    key: 'debtEquityRatio',
    default: {
        available: {from: 0, to: 100},
        selected: {from: 0, to: 100},
        isRangeLoaded: false
    } as ScreenerPropertyRangeStorage
})

export const peRatioState = atom({
    key: 'peRatio',
    default: {
        available: {from: 0, to: 100},
        selected: {from: 0, to: 100},
        isRangeLoaded: false
    } as ScreenerPropertyRangeStorage
})

export const epsGrowth1YearState = atom({
    key: 'epsGrowth1Year',
    default: {
        available: {from: 0, to: 100},
        selected: {from: 0, to: 100},
        isRangeLoaded: false
    } as ScreenerPropertyRangeStorage
})

export const epsGrowth3YearState = atom({
    key: 'epsGrowth3Year',
    default: {
        available: {from: 0, to: 100},
        selected: {from: 0, to: 100},
        isRangeLoaded: false
    } as ScreenerPropertyRangeStorage
})

export const screenerSelectedPropertiesDescriptionState = selector({
    key: "screenerSelectedPropertiesDescription",
    get: ({get}) => {
        let arr = [] as string[];
        const currencies = get(currencyState);
        const marketCap = get(marketCapState);
        const ebitda = get(ebitdaState);
        const debtEquity = get(debtEquityState);
        const peRatio = get(peRatioState);
        const epsGrowth1Year = get(epsGrowth1YearState);

        if(currencies.currencies != [])
            arr.push(`Валюты: ${currencies.currencies.join(', ')}`)
        if(marketCap.isSelected)
            arr.push(`Market Cap ${marketCap.selected.from} -  ${marketCap.selected.to} млрд. $`)
        if(ebitda.isSelected)
            arr.push(`EBITDA ${ebitda.selected.from} -  ${ebitda.selected.to} млрд. $`)
        if(debtEquity.isSelected)
            arr.push(`Debt / Equity ${debtEquity.selected.from} -  ${debtEquity.selected.to}`)
        if(peRatio.isSelected)
            arr.push(`P / E ${peRatio.selected.from} -  ${peRatio.selected.to} млрд. $`)
        if(epsGrowth1Year.isSelected)
            arr.push(`Рост EPS за 1 год ${epsGrowth1Year.selected.from} -  ${epsGrowth1Year.selected.to} млрд. $`)

        return arr;
    },
});

export const screenerSelectedPropertiesState = selector({
    key: "screenerSelectedProperties",
    get: ({get}) => ({
        currencies: get(currencyState).currencies,
        marketCap: get(marketCapState).isSelected ? get(marketCapState).selected : undefined,
        ebitda: get(ebitdaState).isSelected ? get(marketCapState).selected : undefined,
        debtEquity: get(debtEquityState).isSelected ? get(marketCapState).selected : undefined,
        peRatio: get(peRatioState).isSelected ? get(marketCapState).selected : undefined,
        epsGrowth1Year: get(epsGrowth1YearState).isSelected ? get(marketCapState).selected : undefined,
        epsGrowth3Year: get(epsGrowth3YearState).isSelected ? get(marketCapState).selected : undefined,
    }),
});

export const screenerState = selector({
    key: "screenerValue",
    get: ({get}) => ({
        marketCap: get(marketCapState),
        ebitda: get(ebitdaState),
        debtEquity: get(debtEquityState),
        peRatio: get(peRatioState),
        epsGrowth1Year: get(epsGrowth1YearState),
        epsGrowth3Year: get(epsGrowth3YearState)
    }),
    set: ({set}, newValue : any) =>
    {
        set(marketCapState,{
            available: newValue.marketCap as Range,
            selected: newValue.marketCap as Range,
            isRangeLoaded: true,
        } as ScreenerPropertyRangeStorage);

        set(ebitdaState,{
            available: newValue.ebitda as Range,
            selected: newValue.ebitda as Range,
            isRangeLoaded: true,
        } as ScreenerPropertyRangeStorage);

        set(peRatioState,{
            available: newValue.peRatio as Range,
            selected: newValue.peRatio as Range,
            isRangeLoaded: true,
        } as ScreenerPropertyRangeStorage);
    }
});