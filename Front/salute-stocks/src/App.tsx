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
import {Assistant} from "./Assistant/Assistant";
import {ScreenerAssistant} from "./Assistant/ScreenerAssistant";
import {CompaniesAssistant} from "./Assistant/CompaniesAssistant";


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
                        <Assistant>
                            <Container className="App" style={{
                                minHeight: "100vh",
                                marginBottom: "120px"
                            }}>
                                <Switch>
                                    <Route exact path="/">
                                        <ScreenerAssistant>
                                            <Screener/>
                                        </ScreenerAssistant>
                                    </Route>
                                    <Route path="/companies">
                                        <CompaniesAssistant>
                                            <CompaniesView />
                                        </CompaniesAssistant>
                                    </Route>
                                </Switch>
                            </Container>
                        </Assistant>
                    </Router>
                </DeviceThemeProvider>
            </ThemeProvider>
        </RecoilRoot>
  );
}

export default App;
