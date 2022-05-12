import {RecoilState, useRecoilState, useRecoilValue} from "recoil";
import {Range, ScreenerPropertyRangeStorage, screenerState} from "../Storage";
import React, {useEffect} from "react";
import {
    Chart,
    ArgumentAxis,
    ValueAxis,
    AreaSeries,
    Title,
    Legend,
} from '@devexpress/dx-react-chart-bootstrap4';
import '@devexpress/dx-react-chart-bootstrap4/dist/dx-react-chart-bootstrap4.css';
import {ArgumentScale, Animation, FactoryFn, SplineSeries} from '@devexpress/dx-react-chart';
import { scalePoint } from 'd3-scale';
import { colorValues } from '@sberdevices/plasma-tokens';
import {createInterpolatorWithFallback} from "./Interpolation/Index";
import {InterpolateDist} from "./ScreenerProperty";

export declare type ScreenerChartProps = {
    availableRange : Range,
    selectedRange : Range
    distribution : Distribution
}

export interface Distribution {
    Values: DistributionValue[]
}

export interface DistributionValue{
    Position : number;
    Value: number;
}

export declare type screenerChartState = {
    Distribution : Distribution;
    IsLoaded: boolean;
}

declare type chartPoint = {
    selected: number | null,
    unselected: number | null,
    position: number
}

// @ts-ignore
const ChartRoot = props => (
    // @ts-ignore
    <Chart.Root {...props} className="pr-3" />
);

function func(x: number) {return Math.exp(-1*(x-50)*(x-5)/500)}

function generateSelected(values: DistributionValue[], from: number, to: number) : any
{
    return Array.from(new Array(to-from+1), (x, i) => i+from)
        .map(x=>({position: x, selected: func(x), unselected: 0}))
}

function generateUnselected(values: DistributionValue[], from: number, to: number) : any
{
    return Array.from(new Array(to-from+1), (x, i) => i+from)
        .map(x=>({position: x, unselected: func(x), selected: 0}))
}

export const ScreenerChart: React.FC<ScreenerChartProps> = ({availableRange, selectedRange, distribution}) => {

    //const [recoilState, setRecoilState] = useRecoilState(rangeState);
    //const availableRange = recoilState.available;
    //const selectedRange = recoilState.selected;

    const data1 = distribution.Values
        .map((x,i)=>({
            selected: 0,
            unselected: x.Value,
            position: i
        }) as chartPoint)
        .slice(0, selectedRange.from + 1);
    const data2 = distribution.Values
        .map((x,i)=>({
            selected: x.Value,
            unselected: 0,
            position: i
        }) as chartPoint)
        .slice(selectedRange.from, selectedRange.to);
    const data3 = distribution.Values
        .map((x,i)=>({
            selected: 0,
            unselected: x.Value,
            position: i
        }) as chartPoint)
        .slice(selectedRange.to - 1, distribution.Values.length-1);

    const data = data1.concat(data2).concat(data3)
    console.log(data);

    return(
        <div className="" style={{
            marginBottom: -22
        }}>
            <Chart
                data={data}
                rootComponent={ChartRoot}
            >
                <ArgumentScale factory={scalePoint as FactoryFn} />
                <AreaSeries
                    valueField="selected"
                    argumentField="position"
                    color={colorValues.success}
                />
                <AreaSeries
                    valueField="unselected"
                    argumentField="position"
                    color={colorValues.secondary}
                />
            </Chart>
        </div>
    )
}