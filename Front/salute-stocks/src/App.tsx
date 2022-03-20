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
import
{
    RecoilRoot,
    atom,
    selector,
    useRecoilState,
    useRecoilValue
} from "recoil";
import CSS from 'csstype';
import {screenerState} from "./Storage";
import Screener from "./Screener";



function App() {
    const [screener, setScreener] = useRecoilState(screenerState);
    const style : CSS.Properties = {
        margin: 0
    }
    return (
      <div className="App" style={style}>
          <Screener></Screener>
      </div>
  );
}

export default App;
