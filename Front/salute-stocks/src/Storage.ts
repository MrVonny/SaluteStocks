import {atom, selector} from "recoil";
import {Distribution} from "./Screener/ScreenerChart";


export declare type Range = {
    from: number;
    to: number;
}

export declare type ScreenerPropertyRangeStorage = {
    available: Range;
    selected?: Range;
    distribution : Distribution;
    isSelected: boolean;
    isRangeLoaded : boolean;
    isDistributionLoaded : boolean;
}

export declare type ScreenerPropertyListStorage = {
    values: string[]
    isSelected: boolean;
}

export declare type ListValue = {
    isSelected: boolean;
    value: string;
}

export declare type Screener = {
    marketCap: Range;
    epsGrowth1Year: Range;
    epsGrowth3Year: Range;
}

export const sectorState = atom({
    key: 'sector',
    default: {
        isSelected: false,
        values: []
    } as ScreenerPropertyListStorage
})


export const currencyState = atom({
    key: 'currency',
    default: {
        currencies: [] as string[]
    }
})

export const marketCapState = atom({
    key: 'marketCap',
    default: {
        available: {},
        selected: undefined,
        isSelected: false,
        isRangeLoaded: false
    } as ScreenerPropertyRangeStorage
})

export const ebitdaState = atom({
    key: 'ebitda',
    default: {
        available: {},
        selected: undefined,
        isSelected: false,
        isRangeLoaded: false
    } as ScreenerPropertyRangeStorage
})

export const debtEquityState = atom({
    key: 'debtEquityRatio',
    default: {
        available: {},
        selected: undefined,
        isSelected: false,
        isRangeLoaded: false
    } as ScreenerPropertyRangeStorage
})

export const peRatioState = atom({
    key: 'peRatio',
    default: {
        available: {},
        selected: undefined,
        isSelected: false,
        isRangeLoaded: false
    } as ScreenerPropertyRangeStorage
})

export const epsState = atom({
    key: 'eps',
    default: {
        available: {},
        selected: undefined,
        isSelected: false,
        isRangeLoaded: false
    } as ScreenerPropertyRangeStorage
})

export const betaState = atom({
    key: 'beta',
    default: {
        available: {},
        selected: undefined,
        isSelected: false,
        isRangeLoaded: false
    } as ScreenerPropertyRangeStorage
})

export const epsGrowth1YearState = atom({
    key: 'epsGrowth1Year',
    default: {
        available: {},
        selected: undefined,
        isSelected: false,
        isRangeLoaded: false
    } as ScreenerPropertyRangeStorage
})

export const epsGrowth3YearState = atom({
    key: 'epsGrowth3Year',
    default: {
        available: {},
        selected: undefined,
        isSelected: false,
        isRangeLoaded: false
    } as ScreenerPropertyRangeStorage
})

export const mapSectorNameValue = [
    {value: "ENERGY & TRANSPORTATION", name: "Энергетика и транспорт"},
    {value: "FINANCE", name: "Финансы"},
    {value: "LIFE SCIENCES", name: "Медицина"},
    {value: "MANUFACTURING", name: "Производство"},
    {value: "REAL ESTATE & CONSTRUCTION", name: "Недвижимость"},
    {value: "TECHNOLOGY", name: "Технологии"},
    {value: "TRADE & SERVICES", name: "Потребительский"}
]

export const screenerSelectedPropertiesDescriptionState = selector({
    key: "screenerSelectedPropertiesDescription",
    get: ({get}) => {
        let arr = [] as string[];
        const sectors = get(sectorState);
        const marketCap = get(marketCapState);
        const ebitda = get(ebitdaState);
        const debtEquity = get(debtEquityState);
        const peRatio = get(peRatioState);
        const eps = get(epsState);
        const beta = get(betaState);
        const epsGrowth1Year = get(epsGrowth1YearState);

        if(sectors.values.length > 0)
            arr.push(`Секторы: ${sectors.values.map(x=>mapSectorNameValue.find(g=>g.value === x)?.name).join(', ')}`)
        if(marketCap.isSelected)
            arr.push(`Market Cap ${marketCap.selected!.from.toFixed(2)} -  ${marketCap.selected!.to.toFixed(2)} млрд. $`)
        if(ebitda.isSelected)
            arr.push(`EBITDA ${ebitda.selected!.from.toFixed(2)} -  ${ebitda.selected!.to.toFixed(2)} млрд. $`)
        if(debtEquity.isSelected)
            arr.push(`Debt / Equity ${debtEquity.selected!.from.toFixed(2)} -  ${debtEquity.selected!.to.toFixed(2)}`)
        if(peRatio.isSelected)
            arr.push(`P / E ${peRatio.selected!.from.toFixed(2)} -  ${peRatio.selected!.to.toFixed(2)}`)
        if(eps.isSelected)
            arr.push(`EPS ${eps.selected!.from.toFixed(2)} - ${eps.selected!.to.toFixed(2)}$`)
        if(beta.isSelected)
            arr.push(`Beta ${beta.selected!.from.toFixed(2)} - ${beta.selected!.to.toFixed(2)}`)
        if(epsGrowth1Year.isSelected)
            arr.push(`Рост EPS за 1 год ${epsGrowth1Year.selected!.from.toFixed(2)} -  ${epsGrowth1Year.selected!.to.toFixed(2)} млрд. $`)

        return arr;
    },
});

export const screenerSelectedPropertiesState = selector({
    key: "screenerSelectedProperties",
    get: ({get}) => ({
        sectors: get(sectorState).isSelected ? get(sectorState).values : undefined,
        marketCap: get(marketCapState).isSelected ? get(marketCapState).selected : undefined,
        ebitda: get(ebitdaState).isSelected ? get(ebitdaState).selected : undefined,
        debtEquity: get(debtEquityState).isSelected ? get(debtEquityState).selected : undefined,
        peRatio: get(peRatioState).isSelected ? get(peRatioState).selected : undefined,
        eps: get(epsState).isSelected ? get(epsState).selected : undefined,
        beta: get(betaState).isSelected ? get(betaState).selected : undefined,
        epsGrowth1Year: get(epsGrowth1YearState).isSelected ? get(epsGrowth1YearState).selected : undefined,
        epsGrowth3Year: get(epsGrowth3YearState).isSelected ? get(epsGrowth3YearState).selected : undefined,
    }),
});

export const screenerState = selector({
    key: "screenerValue",
    get: ({get}) => ({
        marketCap: get(marketCapState),
        ebitda: get(ebitdaState),
        debtEquity: get(debtEquityState),
        peRatio: get(peRatioState),
        eps: get(epsState),
        beta: get(betaState),
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

        set(epsState,{
            available: newValue.eps as Range,
            selected: newValue.eps as Range,
            isRangeLoaded: true,
        } as ScreenerPropertyRangeStorage);

        set(betaState,{
            available: newValue.beta as Range,
            selected: newValue.beta as Range,
            isRangeLoaded: true,
        } as ScreenerPropertyRangeStorage);
    }
});