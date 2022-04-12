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
        .filter(x=>x.Position >= availableRange.from && x.Position <= selectedRange.from)
        .map(x=>({
            selected: 0,
            unselected: x.Value,
            position: x.Position
        }) as chartPoint);
    const data2 = distribution.Values
        .filter(x=>x.Position >= selectedRange.from && x.Position <= selectedRange.to)
        .map(x=>({
            selected: x.Value,
            unselected: 0,
            position: x.Position
        }) as chartPoint);
    const data3 = distribution.Values
        .filter(x=>x.Position >= selectedRange.to && x.Position <= availableRange.to)
        .map(x=>({
            selected: 0,
            unselected: x.Value,
            position: x.Position
        }) as chartPoint);

    const data = data1.concat(data2).concat(data3)

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