import {RecoilState, useRecoilState, useRecoilValue} from "recoil";
import {Range, ScreenerPropertyRangeStorage} from "../Storage";
import React from "react";
import {
    Chart,
    ArgumentAxis,
    ValueAxis,
    AreaSeries,
    Title,
    Legend,
} from '@devexpress/dx-react-chart-bootstrap4';
import '@devexpress/dx-react-chart-bootstrap4/dist/dx-react-chart-bootstrap4.css';
import {ArgumentScale, Animation, FactoryFn} from '@devexpress/dx-react-chart';
import { scalePoint } from 'd3-scale';
import { colorValues } from '@sberdevices/plasma-tokens';

export declare type ScreenerChartProps = {
    //state : RecoilState<ScreenerPropertyRangeStorage>
    availableRange : Range;
    selectedRange : Range;
}

// @ts-ignore
const ChartRoot = props => (
    // @ts-ignore
    <Chart.Root {...props} className="pr-3" />
);

function func(x: number) {return Math.exp(-1*(x-50)*(x-5)/500)}

function generateSelected(from: number, to: number) : any
{
    return Array.from(new Array(to-from+1), (x, i) => i+from)
        .map(x=>({position: x, selected: func(x), unselected: 0}))
}

function generateUnselected(from: number, to: number) : any
{
    return Array.from(new Array(to-from+1), (x, i) => i+from)
        .map(x=>({position: x, unselected: func(x), selected: 0}))
}

export

const ScreenerChart: React.FC<ScreenerChartProps> = ({availableRange, selectedRange}) => {
    const data = generateUnselected(availableRange.from, selectedRange.from)
    .concat(generateSelected(selectedRange.from, selectedRange.to))
    .concat(generateUnselected(selectedRange.to, availableRange.to));
    console.log('chart',selectedRange);
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