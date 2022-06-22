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

export const ScreenerChart: React.FC<ScreenerChartProps> = ({availableRange, selectedRange, distribution}) => {

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
        .slice(selectedRange.from, selectedRange.to + 1);
    const data3 = distribution.Values
        .map((x,i)=>({
            selected: 0,
            unselected: x.Value,
            position: i
        }) as chartPoint)
        .slice(selectedRange.to, distribution.Values.length);

    const data = data1.concat(data2).concat(data3)

    return(
        <div className="" style={{
            marginBottom: -22,
            marginLeft: 0,
            marginRight: 0
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