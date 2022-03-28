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
import {Slider} from "@sberdevices/plasma-ui/components/Slider/Double";
import { colorValues } from '@sberdevices/plasma-tokens';
import {IconClose} from "@sberdevices/plasma-icons";
import {Label, SubTitle, Title} from "@sberdevices/plasma-ui/components/TextBox/TextBox";
import {useRecoilState, RecoilState, useRecoilValue} from "recoil";
import {ScreenerChart} from "./ScreenerChart";

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

const ScreenerSheetSlider : React.FC<ScreenerSheetSliderProps> = ({rangeState, onApplyClick}) => {

    const [range, setRangeState] = useRecoilState(rangeState)
    const [localRange, setLocalRange] = useState(range as ScreenerPropertyRangeStorage)
    const onSliderCommitted = (values: Number[]) => {
        setRangeState({...range, selected: {from: values[0], to: values[1]} as Range})
    }
    const onSliderChange = (values: number[]) => {
        setLocalRange({...localRange, selected: {from: values[0], to: values[1]} as Range})
    }

    return(
        <>
            <Row style={{
                marginLeft: -0,
                marginRight: -0
            }}>

                <Col size={1} style={{textAlign: "left"}}><TextBox>{localRange.selected.from.toString()}</TextBox></Col>
                <Col size={1} offsetXL={10} offsetL={6} offsetM={4} offsetS={2}
                     style={{textAlign: "right"}}><TextBox>{localRange.selected.to.toString()}</TextBox></Col>
            </Row>

            <ScreenerChart availableRange={localRange.available} selectedRange={localRange.selected}>

            </ScreenerChart>
            <div>

                <Slider min={range.available.from} max={range.available.to}
                       value={[range.selected.from, range.selected.to]}
                       onChangeCommitted={onSliderCommitted}
                        onChange={onSliderChange}
                        
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



