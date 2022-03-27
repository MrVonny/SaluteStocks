import React from 'react'; // we need this to make JSX compile
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
    H3, Row, Sheet,
    TextBoxBigTitle,
    TextBoxSubTitle
} from "@sberdevices/plasma-ui"
import {Range} from "./Storage";
import {Slider} from "@sberdevices/plasma-ui/components/Slider/Double";
import { colorValues } from '@sberdevices/plasma-tokens';
import {IconClose} from "@sberdevices/plasma-icons";
import {SubTitle, Title} from "@sberdevices/plasma-ui/components/TextBox/TextBox";

type ScreenerPropertyProps = {
    title: string,
    subtitle: string,
    type:  ScreenerPropertyType,
    list? : string[],
    range? : Range,
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
    range: Range
}



export const ScreenerProperty: React.FC<ScreenerPropertyProps> = ({title, subtitle, range, type,
                                                                      list, unit, description}) => {
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
                    <ScreenerSheetSlider range={range!}/>
                );
                break;
            case ScreenerPropertyType.List:
                return (
                    <></>
                )
        }
    }
    const ScreenerSheetSlider : React.FC<ScreenerSheetSliderProps> = ({range}) => {
        const onSliderChange = (values: Number[]) => {

        }
        return(
            <>
                <Row>
                    <Cell contentLeft={<label>{range.from}</label>}
                          content={""}
                          contentRight={range.to}/>
                </Row>
                <Slider min={range.from} max={range.to}
                        value={[range.from, range.to]}
                        onChangeCommitted={onSliderChange}/>
                <Row>
                    <Button onClick={onApplyClick}>Применить</Button>
                </Row>
            </>
        )
    }

    return (
        <>
            <Card style={{
                minHeight: "12em",
                backgroundColor: color,
                marginBottom: 10
            }}
                  onClick={(event) => {
                      console.log(event);
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
                                console.log({...state, isSelected: false});
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



