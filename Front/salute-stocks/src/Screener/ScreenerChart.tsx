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

export declare type ScreenerChartProps = {
    //state : RecoilState<ScreenerPropertyRangeStorage>
    availableRange : Range;
    selectedRange : Range;
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
    const [state, setState] = React.useState({Distribution: {Values: []}, IsLoaded: false} as screenerChartState);
    // const data = generateUnselected(availableRange.from, selectedRange.from)
    // .concat(generateSelected(selectedRange.from, selectedRange.to))
    // .concat(generateUnselected(selectedRange.to, availableRange.to));

    const data = state.Distribution.Values;


    useEffect(() => {
        if (!state.IsLoaded)
            fetch("https://salut-stocks.xyz/api/distribution/market-cap/50")
                .then(res => res.json())
                .then(
                    (result) => {
                        setState({...state, Distribution: result as Distribution, IsLoaded: true})

                    },
                    // Примечание: важно обрабатывать ошибки именно здесь, а не в блоке catch(),
                    // чтобы не перехватывать исключения из ошибок в самих компонентах.
                    (error) => {
                        console.log(error);
                    }
                )
    }, [data])

    return(
        <div className="" style={{
            marginBottom: -22
        }}>
            <Chart
                data={data}
                rootComponent={ChartRoot}
            >
                <ArgumentScale factory={scalePoint as FactoryFn} />
                <SplineSeries
                    valueField="Value"
                    argumentField="Position"
                    color={colorValues.success}
                />
                <SplineSeries
                    valueField="unselected"
                    argumentField="position"
                    color={colorValues.secondary}
                />
            </Chart>
        </div>
    )
}