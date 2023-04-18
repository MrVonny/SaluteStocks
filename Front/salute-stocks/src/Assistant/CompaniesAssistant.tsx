import React, {memo, useEffect, useRef} from "react";
import {assistant, initializeAssistant} from "./Assistant";
import {ScreenerAssistantProps} from "./ScreenerAssistant";
import {useRecoilState} from "recoil";
import {pageState} from "../Storage";
import {AssistantAppState, createAssistant} from "@sberdevices/assistant-client";

export interface CompaniesAssistantProps  {

}

export const CompaniesAssistant : React.FC<ScreenerAssistantProps> = ({children}) => {
    const [state, setState] = useRecoilState(pageState);

    useEffect(() => {

        assistant.on("data", (event : any) => {
            console.log(`assistant.on(data)`, event);
            if (event) {
                try {
                    // @ts-ignore
                    let action = event["action"];
                    switch (event.type) {
                        case 'navigation':
                            switch (event.navigation.command) {
                                case 'FORWARD':
                                    setState({...state, page: state.page + 1})
                                    break;
                                case 'BACKWARD':
                                    setState({...state,
                                : state.page - 1})
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
    }, []);

    return(
        <>
            {children}
        </>
    )
};