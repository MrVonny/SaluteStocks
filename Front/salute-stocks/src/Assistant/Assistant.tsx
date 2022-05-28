import {render} from "react-dom";
import React, {useState} from "react";
import {createAssistant, createSmartappDebugger} from "@sberdevices/assistant-client";
import {useRecoilState} from "recoil";
import {betaState, ebitdaState, epsState, marketCapState, peRatioState, sectorState} from "../Storage";
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

const assistant = initializeAssistant(() => { });

export const Assistant: React.FC = ({children}) => {
    const [sectorStateRecoil, setSectorCapStateRecoil] = useRecoilState(sectorState);
    const [marketCapStateRecoil, setMarketCapStateRecoil] = useRecoilState(marketCapState);
    const [ebitdaStateRecoil, setEbitdaStateRecoil] = useRecoilState(ebitdaState);
    const [peRatioStateRecoil, setPeRatioStateRecoil] = useRecoilState(peRatioState);
    const [epsStateRecoil, setEpsStateRecoil] = useRecoilState(epsState);
    const [betaStateRecoil, setBetaStateRecoil] = useRecoilState(betaState);

    const [state,setState] = useState({
        loaded: false
    });

    if(!state.loaded)
    {
        assistant.on("data", (event/*: any*/) => {
            console.log(`assistant.on(data)`, event);
            if(event)
            {
                try{
                    // @ts-ignore
                    let action = event["action"];
                    switch (event.type)
                    {
                        case 'smart_app_data':
                            switch (action.type)
                            {
                                case 'add_sector':
                                    addListCommand(sectorStateRecoil, setSectorCapStateRecoil, action.id)
                                    break;

                                case 'remove_sector':
                                    removeListCommand(sectorStateRecoil, setSectorCapStateRecoil, action.id)
                                    break;

                                default:
                                    break;
                            }
                            break;
                    }
                } catch (e) {
                    console.error(e);
                }


            }
        });
        assistant.on("start", () => {
            console.log(`assistant.on(start)`);
        });
        setState({
            ...state,
            loaded: true
        });
    }

    return (
        <>
            {children}
        </>
    )
}