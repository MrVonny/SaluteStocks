import React, {useEffect, useState} from 'react'; // we need this to make JSX compile
import {
    ActionButton,
    Button,
    Card,
    CardBody,
    CardContent,
    Cell, CellContent, CellContentWrapper, Col,
    Container,
    H1,
    H2,
    H3, Row, Sheet, TextBox,
    TextBoxBigTitle, TextBoxLabel,
    TextBoxSubTitle
} from "@sberdevices/plasma-ui"
import {Range, ScreenerPropertyRangeStorage, screenerState} from "../Storage";
import { colorValues } from '@sberdevices/plasma-tokens';
import {IconClose} from "@sberdevices/plasma-icons";
import {Label, SubTitle, Title} from "@sberdevices/plasma-ui/components/TextBox/TextBox";
import {useRecoilState, RecoilState, useRecoilValue} from "recoil";
import {Distribution, DistributionValue, ScreenerChart} from "./ScreenerChart";
import {createInterpolatorWithFallback} from "./Interpolation/Index";
import {Slider} from "@mui/material";

type ScreenerPropertyProps = {
    title: string,
    subtitle: string,
    type:  ScreenerPropertyType,
    listState? : string[],
    rangeState?: RecoilState<ScreenerPropertyRangeStorage>
    unit? : string,
    description? : string,
}

type ScreenerRangePropertyProps = {
    title: string,
    subtitle: string,
    rangeState: RecoilState<ScreenerPropertyRangeStorage>
    unit? : string,
    description? : string,
}

export enum ScreenerPropertyType {
    List,
    Range
}

interface ScreenerPropertyState {
    isSheetOpen : boolean;
    isSelected : boolean;
}

type ScreenerSheetSliderProps = {
    rangeState: RecoilState<ScreenerPropertyRangeStorage>
    onApplyClick: () => void;
}


const ScreenerProperty: React.FC<ScreenerPropertyProps> = ({title, subtitle, type, unit, description,
                                                           rangeState, listState, children}) => {
    const [state, setState] = React.useState({
        isSheetOpen: false,
        isSelected: false,
    } as ScreenerPropertyState);

    const onApplyClick = () => {
        setState({...state, isSelected: true, isSheetOpen: false});
    }

    const color = !state.isSelected ? colorValues.surfaceCard : colorValues.buttonSuccess;

    const renderSwitch = (type : ScreenerPropertyType) => {
        switch (type) {
            case ScreenerPropertyType.Range:
                return(
                    <ScreenerSheetSlider rangeState={rangeState!} onApplyClick={onApplyClick}/>
                );
            case ScreenerPropertyType.List:
                return (
                    <></>
                )
        }
    }


    return (
        <>
            <Card style={{
                minHeight: "12em",
                backgroundColor: color,
                marginBottom: 10
            }}
                  onClick={(event) => {
                setState({...state, isSheetOpen: true})
            }}>
                <CardContent>
                    {state.isSelected ?
                        <div style={{
                            right: 10,
                            top: 10,
                            position: "absolute"
                        }}>
                            <ActionButton size="s" view="critical" onClick={(event) => {
                                event.stopPropagation();
                                setState({...state, isSelected: false})
                            }}>
                                <IconClose/>
                            </ActionButton>
                        </div>
                         : ""
                    }
                    <CellContent>
                        <TextBoxBigTitle style={{
                            marginRight: 20,
                            marginTop: 0,
                            textAlign: "left"
                        }}>
                            {title}
                        </TextBoxBigTitle>
                    </CellContent>
                    <Cell content={<TextBoxSubTitle>{subtitle}</TextBoxSubTitle>}/>
                </CardContent>
            </Card>

            <Sheet isOpen={state.isSheetOpen} onClose={() => setState({...state, isSheetOpen: false})}>
                <TextBoxBigTitle>{title} ({unit})</TextBoxBigTitle>
                <TextBoxSubTitle>{description}</TextBoxSubTitle>
                <Container>
                    {renderSwitch(type)}
                </Container>
            </Sheet>
        </>
    );
}

export const ScreenerRangeProperty : React.FC<ScreenerRangePropertyProps> =
    ({title, subtitle, unit, description, rangeState}) => {
    return <ScreenerProperty
        title={title}
        subtitle={subtitle}
        type={ScreenerPropertyType.Range}
        rangeState={rangeState}
        unit={unit}
        description={description}
    />
}

function intepolateDist(distribution: Distribution) : Distribution
{
    const interpolator = createInterpolatorWithFallback("akima",
        distribution.Values.map(x=>x.Position),
        distribution.Values.map(x=>x.Value));

    const from = distribution.Values[0].Position;
    const to = distribution.Values[distribution.Values.length-1].Position;

    let interpolatedValues = Array.from(new Array(STEPS), (x, i) => ({
        Position: from + i * (to - from)/STEPS,
        Value: interpolator(from + i * (to - from)/STEPS)
    }) as DistributionValue)

    return {Values: interpolatedValues } as Distribution

}

const STEPS = 200;

const ScreenerSheetSlider : React.FC<ScreenerSheetSliderProps> = ({rangeState, onApplyClick}) => {

    const [range, setRangeState] = useRecoilState(rangeState)
    const [state, setState] = useState(range as ScreenerPropertyRangeStorage)
    const onSliderCommitted = (event: Event | React.SyntheticEvent, values: number[] | number) => {
        const val = values as number[];
        setRangeState({...range, selected: {from: val[0], to: val[1]} as Range})
    }
    const onSliderChange = (event: Event, values: number[] | number) => {
        const val = values as number[];
        setState({...state, selected: {from: val[0], to: val[1]} as Range})
    }

    useEffect(() => {
        if (!state.isLoaded)
            fetch("https://salut-stocks.xyz/api/distribution/market-cap/20")
                .then(res => res.json())
                .then(
                    (result) => {
                        const res = result as Distribution;
                        setState({...state,
                            distribution: intepolateDist(res),
                            isLoaded: true,
                            available: {from: res.Values[0].Position, to: res.Values[res.Values.length-1].Position },
                            selected:  {from: res.Values[0].Position, to: res.Values[res.Values.length-1].Position }
                        });
                        setRangeState({...range,
                            available: {from: res.Values[0].Position, to: res.Values[res.Values.length-1].Position },
                            selected:  {from: res.Values[0].Position, to: res.Values[res.Values.length-1].Position }
                        })
                        console.log(res);
                    },
                    // Примечание: важно обрабатывать ошибки именно здесь, а не в блоке catch(),
                    // чтобы не перехватывать исключения из ошибок в самих компонентах.
                    (error) => {
                        console.log(error);
                    }
                )
    }, [state])

    return(
        <>
            <Row style={{
                marginLeft: -0,
                marginRight: -0
            }}>

                <Col size={1} style={{textAlign: "left"}}><TextBox>{state.selected.from.toString()}</TextBox></Col>
                <Col size={1} offsetXL={10} offsetL={6} offsetM={4} offsetS={2}
                     style={{textAlign: "right"}}><TextBox>{state.selected.to.toString()}</TextBox></Col>
            </Row>
            <ScreenerChart availableRange={state.available} selectedRange={state.selected} distribution={state.distribution ?? { Values: []}}/>


            <div>

                <Slider min={range.available.from}
                        max={range.available.to}
                        step={(range.available.to - range.available.from)/STEPS}
                        value={[state.selected.from, state.selected.to]}
                        onChange={onSliderChange}
                        onChangeCommitted={onSliderCommitted}
                />
            </div>
            <Row>
                <Col size={2} offsetXL={5} offsetL={3} offsetM={2} offsetS={1}>
                    <Button onClick={onApplyClick}>Применить</Button>
                </Col>
            </Row>
        </>
    )
}



