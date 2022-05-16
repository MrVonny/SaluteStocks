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


function App() {
    return (
        <RecoilRoot>
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
        </RecoilRoot>
  );
}

export default App;
