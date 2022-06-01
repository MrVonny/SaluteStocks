import React from "react";
import {assistant} from "./Assistant";
import {ScreenerAssistantProps} from "./ScreenerAssistant";

export interface CompaniesAssistantProps  {

}

export const CompaniesAssistant : React.FC<ScreenerAssistantProps> = ({children}) => {

    assistant.on("data", (event : any) => {
        console.log(`assistant.on(data)`, event);
        if (event) {
            try {
                // @ts-ignore
                let action = event["action"];
                switch (event.type) {
                    case 'smart_app_data':
                        switch (action.type) {
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
    return(
        <>
            {children}
        </>
    )
}