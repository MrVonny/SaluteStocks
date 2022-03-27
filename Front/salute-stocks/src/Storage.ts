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

export const screenerState = atom({
    key: "screener",
    default: {
        marketCap: {from: 10, to: 50},
        epsGrowth1Year: {from: 10, to: 50},
        epsGrowth3Year: {from: 10, to: 50}
    } as Screener
})

export const screenerValue = selector({
    key: "screenerValue",
    get: ({ get }) => ({
        screener: get(screenerState)
    }),
});