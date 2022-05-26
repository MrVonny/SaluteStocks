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
import {
    BrowserRouter as Router,
    Switch,
    Route,
    Link
} from "react-router-dom";
import Screener from "./Screener/Screener";
import {CompaniesView} from "./CompaniesView/CompaniesView";
import {createTheme, ThemeProvider} from "@mui/material";


function App() {
    return (
        <RecoilRoot>
            <ThemeProvider theme={createTheme({
                palette: {
                    mode: "dark"
                }
            })}>
                <DeviceThemeProvider>
                    <Router>
                        <Container className="App">
                            <Switch>
                                <Route exact path="/">
                                    <Screener/>
                                </Route>
                                <Route path="/companies">
                                    <CompaniesView />
                                </Route>
                            </Switch>
                        </Container>
                    </Router>
                </DeviceThemeProvider>
            </ThemeProvider>
        </RecoilRoot>
  );
}

export default App;
