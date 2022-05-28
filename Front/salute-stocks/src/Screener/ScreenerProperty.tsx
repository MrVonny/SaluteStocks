import React, {useEffect, useState} from 'react'; // we need this to make JSX compile
import {
    ActionButton,
    Button,
    Card,
    CardBody,
    CardContent,
    Cell, CellContent, CellContentWrapper, Checkbox, Col,
    Container,
    H1,
    H2,
    H3, LineSkeleton, RectSkeleton, Row, Sheet, TextBox,
    TextBoxBigTitle, TextBoxLabel,
    TextBoxSubTitle
} from "@sberdevices/plasma-ui"
import {Range, ScreenerPropertyListStorage, ScreenerPropertyRangeStorage, screenerState} from "../Storage";
import {colorValues, headline3} from '@sberdevices/plasma-tokens';
import {IconClose} from "@sberdevices/plasma-icons";
import {Label, SubTitle, Title} from "@sberdevices/plasma-ui/components/TextBox/TextBox";
import {useRecoilState, RecoilState, useRecoilValue} from "recoil";
import {Distribution, DistributionValue, ScreenerChart} from "./ScreenerChart";
import {createInterpolatorWithFallback} from "./Interpolation/Index";
import {List, Slider} from "@mui/material";

type ScreenerPropertyProps = {
    title: string,
    subtitle: string,
    type:  ScreenerPropertyType,
    listState? : string[],
    rangeState?: RecoilState<ScreenerPropertyRangeStorage>
    unit? : string,
    description? : string,
    valuesState?: RecoilState<ScreenerPropertyListStorage>
    values?: ListValue[]
}

type ScreenerRangePropertyProps = {
    title: string,
    subtitle: string,
    rangeState: RecoilState<ScreenerPropertyRangeStorage>
    unit? : string,
    description? : string,
}

type ScreenerListPropertyProps = {
    title: string,
    subtitle: string,
    valuesState: RecoilState<ScreenerPropertyListStorage>
    values : ListValue[]
    description? : string,
}

export type ListValue = {
    name: string,
    value: string
}

export enum ScreenerPropertyType {
    List,
    Range
}

interface ScreenerPropertyState {
    isSheetOpen : boolean;
}

type ScreenerSheetSliderProps = {
    rangeState: RecoilState<ScreenerPropertyRangeStorage>
    onApplyClick: () => void;
}

type ScreenerSheetListProps = {
    valuesState: RecoilState<ScreenerPropertyListStorage>
    values : ListValue[]
    onApplyClick: () => void;
}


const ScreenerProperty: React.FC<ScreenerPropertyProps> = ({title, subtitle, type, unit, description,
                                                           rangeState, listState, children,
                                                               values, valuesState}) => {

    let rangeRecoilState: ScreenerPropertyRangeStorage | undefined,
        setRangeRecoilState: (valOrUpdater: (((currVal: ScreenerPropertyRangeStorage) => ScreenerPropertyRangeStorage) | ScreenerPropertyRangeStorage)) => void | undefined;
    if(rangeState !== undefined)
        // eslint-disable-next-line react-hooks/rules-of-hooks
        [rangeRecoilState, setRangeRecoilState] = useRecoilState(rangeState);

    let listRecoilState: ScreenerPropertyListStorage | undefined,
        setListRecoilState: (valOrUpdater: (((currVal: ScreenerPropertyListStorage) => ScreenerPropertyListStorage) | ScreenerPropertyListStorage)) => void | undefined;
    if(valuesState !== undefined)
        // eslint-disable-next-line react-hooks/rules-of-hooks
        [listRecoilState, setListRecoilState] = useRecoilState(valuesState);

    const [state, setState] = React.useState({
        isSheetOpen: false,
    } as ScreenerPropertyState);


    const onApplyClickRange = () => {
        setState({...state, isSheetOpen: false});
        setRangeRecoilState({...rangeRecoilState!, isSelected: true});
    }

    const onApplyClickList = () => {
        setState({...state, isSheetOpen: false});
        setListRecoilState({...listRecoilState!, isSelected: true});
    }

    let onApplyClick = type === ScreenerPropertyType.Range ? onApplyClickRange : onApplyClickList;

    let isSelected = (rangeRecoilState?.isSelected ?? listRecoilState?.isSelected) ?? false

    const color = !isSelected ? colorValues.surfaceCard : colorValues.buttonSuccess;

    const renderSwitch = (type : ScreenerPropertyType) => {
        switch (type) {
            case ScreenerPropertyType.Range:
                return(
                    <ScreenerSheetSlider rangeState={rangeState!} onApplyClick={onApplyClick}/>
                );
            case ScreenerPropertyType.List:
                return (
                    <ScreenerSheetList values={values ?? []} valuesState={valuesState!} onApplyClick={onApplyClick} />
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
                {(type === ScreenerPropertyType.Range ? rangeRecoilState!.isRangeLoaded : true) ? <CardContent>
                    {isSelected ?
                        <div style={{
                            right: 10,
                            top: 10,
                            position: "absolute"
                        }}>
                            <ActionButton size="s" view="critical" onClick={(event) => {
                                event.stopPropagation();
                                type === ScreenerPropertyType.Range ?
                                setRangeRecoilState({...rangeRecoilState!, isSelected: false}) :
                                setListRecoilState({...listRecoilState!, isSelected: false})
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
                </CardContent> : <RectSkeleton width="100%" height="12rem"/>}

            </Card>

            {(type === ScreenerPropertyType.Range ? rangeRecoilState!.isRangeLoaded : true) ?
            <Sheet isOpen={state.isSheetOpen} onClose={() => setState({...state, isSheetOpen: false})}>
                <TextBoxBigTitle>{title}{unit !== undefined ? ` (${unit})` : "" }</TextBoxBigTitle>
                <TextBoxSubTitle>{description}</TextBoxSubTitle>
                <Container>
                    {renderSwitch(type)}
                </Container>
            </Sheet>
                : ""}
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

export const ScreenerListProperty : React.FC<ScreenerListPropertyProps> =
    ({title, subtitle, description, values, valuesState}) => {
        return <ScreenerProperty
            title={title}
            subtitle={subtitle}
            type={ScreenerPropertyType.List}
            description={description}
            values={values}
            valuesState={valuesState}
        />
    }

export function InterpolateDist(distribution: Distribution) : Distribution
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

function findClosestIndex(distr : DistributionValue[], value : number) : number
{
    let closest : number = 0;
    let closestDiff : number = Math.abs(distr[0].Position - value);
    for (let i = 0; i < distr.length; i++)
    {
        let diff = Math.abs(distr[i].Position - value);
        if(diff < closestDiff)
        {
            closest = i;
            closestDiff = diff
        }
    }
    return  closest;
}

function countCompanies(distr : DistributionValue[], selected : Range) : number
{
    return distr
        .filter(x=>x.Position >= selected.from && x.Position <= selected.to)
        .map(x=>x.Value)
        .reduce((partialSum, a) => partialSum + a, 0);
}

const STEPS = 100;

const ScreenerSheetSlider : React.FC<ScreenerSheetSliderProps> = ({rangeState, onApplyClick}) => {

    const [range, setRangeState] = useRecoilState(rangeState)
    const [state, setState] = useState(
        {
            ...range,
            selected: {
                from: range.distribution !== undefined ? findClosestIndex(range.distribution?.Values, range.selected!.from) : 0,
                to: range.distribution !== undefined ? findClosestIndex(range.distribution?.Values, range.selected!.to) : STEPS - 1,
            } as Range,
            count: countCompanies(range.distribution?.Values ?? [], range.selected!),
            fromLabel: range.selected!.from.toFixed(4).toString(),
            toLabel: range.selected!.to.toFixed(4).toString()
        })
    const onSliderChange = (event: Event | React.SyntheticEvent, values: number[] | number) => {
        const val = values as number[];
        setState({
            ...range,
            count: countCompanies(range.distribution?.Values ?? [], {
                    from: range.distribution.Values.at(val[0])?.Position,
                    to: range.distribution.Values.at(val[1])?.Position
            } as Range),
            selected: {from: val[0], to: val[1]} as Range,
            fromLabel: range.distribution.Values.at(val[0])?.Position.toFixed(4).toString() ?? "",
            toLabel: range.distribution.Values.at(val[1])?.Position.toFixed(4).toString() ?? ""})
    }
    const onSliderCommitted = (event: Event | React.SyntheticEvent, values: number[] | number) => {
        const val = values as number[];
        onSliderChange(event, values);
        setRangeState({
            ...range,
            selected: {
                from: range.distribution.Values.at(val[0])?.Position ?? range.selected!.from,
                to: range.distribution.Values.at(val[1])?.Position ?? range.selected!.to} as Range
        });
    }


    return(
        <>
            <Row style={{
                marginLeft: -0,
                marginRight: -0
            }}>

                <Col size={1} style={{textAlign: "left"}}><TextBox>{state.fromLabel}</TextBox></Col>
                <Col size={1} offsetXL={10} offsetL={6} offsetM={4} offsetS={2}
                     style={{textAlign: "right"}}><TextBox>{state.toLabel}</TextBox></Col>
            </Row>
            <ScreenerChart availableRange={state.available} selectedRange={state.selected} distribution={range.distribution ?? { Values: []}}/>


            <div>
                {range.isDistributionLoaded ?
                    <Slider min={0}
                    max={STEPS-1}
                    step={1}
                    value={[state.selected.from, state.selected.to]}
                    onChange={onSliderChange}
                    onChangeCommitted={onSliderCommitted}
                    />
                    :
                    <LineSkeleton size="headline3"/>
                }
            </div>
            <Row>
                <Col size={2} offsetXL={5} offsetL={3} offsetM={2} offsetS={1}>
                    <Button onClick={onApplyClick}>Применить</Button>
                    <TextBoxSubTitle>{state.count} компаний</TextBoxSubTitle>
                </Col>
            </Row>
        </>
    )
}

const ScreenerSheetList : React.FC<ScreenerSheetListProps> = ({values, valuesState, onApplyClick}) => {
    const [valuesRecoilState, setValuesRecoilState] = useRecoilState(valuesState);
    return(
        <>
            <Row>
                <Col sizeXL={4} offsetXL={4} sizeL={4} offsetL={2} sizeM={4} offsetM={1} sizeS={4}>
            <div>
                {values.map(value => (
                    <span style={{
                        position: "relative",
                        left: "-5px",

                    }}>
                        <Checkbox label={value.name}
                                  checked={valuesRecoilState.values.find(x => x === value.value) !== undefined}
                                  onChange={event => {
                                      if(event.currentTarget.checked)
                                          setValuesRecoilState({...valuesRecoilState, values: valuesRecoilState.values.concat(value.value)})
                                      else
                                          setValuesRecoilState({...valuesRecoilState, values: valuesRecoilState.values.filter(x=>x !== value.value)})
                                  }}
                                  style={{
                                      margin: "10px",

                                  }}

                        />
                    </span>
                ))}
            </div>
                </Col>
            </Row>
            <Row>
                <Col size={2} offsetXL={5} offsetL={3} offsetM={2} offsetS={1}>
                    <Button onClick={onApplyClick}>Применить</Button>
                </Col>
            </Row>
        </>
    )
}



