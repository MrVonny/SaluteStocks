import React from 'react';
import './App.css';
import {
    Container, DeviceThemeProvider
} from '@sberdevices/plasma-ui';
import
{
    RecoilRoot,
    useRecoilState
} from "recoil";
import {screenerState} from "./Storage";
import Screener from "./Screener/Screener";



function App() {
    return (
        <RecoilRoot>
            <DeviceThemeProvider>
                <Container className="App">
                    <Screener/>
                </Container>
            </DeviceThemeProvider>
        </RecoilRoot>
  );
}

export default App;
