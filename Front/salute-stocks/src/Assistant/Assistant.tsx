import {render} from "react-dom";
import React, {useState} from "react";
import {createAssistant, createSmartappDebugger} from "@sberdevices/assistant-client";
import {SetterOrUpdater, useRecoilState} from "recoil";
import {
    betaState,
    ebitdaState,
    epsState,
    marketCapState,
    peRatioState, Range,
    ScreenerPropertyListStorage, ScreenerPropertyRangeStorage,
    sectorState
} from "../Storage";
import {addListCommand, removeListCommand} from "./SectorCommands";

const initializeAssistant = (getState: any) => {
    if (process.env.NODE_ENV === "development") {
        return createSmartappDebugger({
            token: process.env.REACT_APP_TOKEN ?? "",
            initPhrase: `Запусти ${process.env.REACT_APP_SMARTAPP}`,
            getState,
        });
    }
    return createAssistant({ getState });
};

export const assistant = initializeAssistant(() => { });

export const Assistant: React.FC = ({children}) => {
    const [state,setState] = useState({
        loaded: false
    });

    if(!state.loaded)
    {
        assistant.on("start", () => {
            console.log(`assistant.on(start)`);
        });
        setState({
            ...state,
            loaded: true,
        });
    }

    return (
        <>
            {children}
        </>
    )
}