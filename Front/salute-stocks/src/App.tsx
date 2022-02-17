import React from 'react';
import logo from './logo.svg';
import './App.css';
import {
    Button,
    Card,
    CardBody,
    CardContent,
    CardMedia,
    Cell, Col, Row, TextBoxBigTitle
} from '@sberdevices/plasma-ui';
import {Slider} from "@sberdevices/plasma-ui/components/Slider/Double";
import {Label} from "@sberdevices/plasma-ui/components/TextBox/TextBox";

let min: number = 0;
let max: number = 100;

function App() {

    return (
      <div className="App">
        <Card style={{ width: '22.5rem' }}>
            <CardBody>
                <CardContent >
                    <Cell
                        content={<TextBoxBigTitle>EBIDTA</TextBoxBigTitle>}
                    />
                    <div style={{height: '50px'}}>
                        <Row>
                            <Col size={2}>
                                <Label>{min}</Label>
                            </Col>
                            <Col size={8}/>
                            <Col size={2}>
                                <Label>{max}</Label>
                            </Col>
                        </Row>
                    </div>
                    <Slider min={-230} max={323} value={[20,30]} onChangeCommitted={(i) => {
                        min = i[0];
                        max = i[1];
                    }} />
                </CardContent>
            </CardBody>
        </Card>
      </div>
  );
}

export default App;
