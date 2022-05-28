import { SetterOrUpdater } from "recoil";
import {Range, ScreenerPropertyListStorage, ScreenerPropertyRangeStorage} from "../Storage";

export interface Command {
    type: string,
    id: string,
}

export const addListCommand = (state : ScreenerPropertyListStorage, set : SetterOrUpdater<ScreenerPropertyListStorage>, value : string) =>
{
    if(state.values.indexOf(value) === -1)
        set({
            isSelected: true,
            values: state.values.concat(value)
        });
}

export const removeListCommand = (state : ScreenerPropertyListStorage, set : SetterOrUpdater<ScreenerPropertyListStorage>, value : string) =>
{
    let newValues = state.values.filter(x=> x !== value);
    set({
        ...state,
        values: newValues,
        isSelected: newValues.length === 0 ? false : state.isSelected
    });
}

export const setRangeCommand = (state : ScreenerPropertyRangeStorage, set : SetterOrUpdater<ScreenerPropertyRangeStorage>, value : Range) =>
{
    set({
        ...state,
        isSelected: true,
        selected: value as Range
    });
}

export const removeRangeCommand = (state : ScreenerPropertyRangeStorage, set : SetterOrUpdater<ScreenerPropertyRangeStorage>) =>
{
    set({
        ...state,
        isSelected: false
    });
}