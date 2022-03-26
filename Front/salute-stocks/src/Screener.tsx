import React from 'react';
import './App.css';
import CSS from 'csstype';
import {
    Button,
    Card,
    CardBody,
    CardContent,
    CardMedia,
    Cell, CellContentWrapper, CellIcon, Checkbox, Col, Container, Row, TextBoxBigTitle
} from '@sberdevices/plasma-ui';
import {Slider} from "@sberdevices/plasma-ui/components/Slider/Double";
import {Label} from "@sberdevices/plasma-ui/components/TextBox/TextBox";
import
{
    atom,
    selector,
    useRecoilState,
    useRecoilValue
} from "recoil";
import {screenerState} from "./Storage";
import {ScreenerSector} from "./ScreenerSector";
import {ScreenerProperty} from "./ScreenerProperty";


const Screener = () => {
    const [screener, setScreener] = useRecoilState(screenerState);
    return (
        <div className="App container-fluid">
            <ScreenerSector title={"Валюта"}>
                <div className={"d-flex flex-row"}>
                    <span className={"me-4"}><Checkbox label={"RUB"}/></span>
                    <span className={"me-4"}><Checkbox label={"USD"}/></span>
                    <span className={"me-4"}><Checkbox label={"EUR"}/></span>
                </div>
            </ScreenerSector>
            <ScreenerSector title={"Динамика"}>
                <Row>
                    <Col size={2}>
                        <ScreenerProperty title={"Рост EPS за год"} subtitle={"Lorem ipsum"}>
                            <div style={{width: 200}}>
                                <Slider min={-100} max={100} value={[-10, 30]} onChangeCommitted={() => {}}/>
                            </div>

                        </ScreenerProperty>
                    </Col>
                    <Col size={2}>
                        <ScreenerProperty title={"Рост EPS 3 года"} subtitle={"Lorem ipsum"}>
                            <Container>
                                <Slider min={-100} max={100} value={[10, -30]} onChangeCommitted={() => {}}/>
                            </Container>
                        </ScreenerProperty>
                    </Col>
                    <Col size={2}></Col>
                </Row>

            </ScreenerSector>
        </div>
    );
}

export default Screener;
