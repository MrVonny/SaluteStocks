import React, {useEffect, useState} from "react";
import {useRecoilState} from "recoil";
import {betaState, ebitdaState, epsState, marketCapState, peRatioState, Range, sectorState} from "../Storage";
import {addListCommand, removeListCommand, removeRangeCommand, setRangeCommand} from "./SectorCommands";
import {assistant} from "./Assistant";

export interface ScreenerAssistantProps  {

}

export const ScreenerAssistant : React.FC<ScreenerAssistantProps> = ({ children}) => {
    const [sectorStateRecoil, setSectorCapStateRecoil] = useRecoilState(sectorState);
    const [marketCapStateRecoil, setMarketCapStateRecoil] = useRecoilState(marketCapState);
    const [ebitdaStateRecoil, setEbitdaStateRecoil] = useRecoilState(ebitdaState);
    const [peRatioStateRecoil, setPeRatioStateRecoil] = useRecoilState(peRatioState);
    const [epsStateRecoil, setEpsStateRecoil] = useRecoilState(epsState);
    const [betaStateRecoil, setBetaStateRecoil] = useRecoilState(betaState);

    const [state,setState] = useState({
        loaded: false
    });

    useEffect(() => {
        assistant.on("data", (event : any) => {
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

                                case 'add_marketCap':
                                    //let range : Range = {from: (action["range"]["from"] as number)/10e9, to: (action["range"]["to"] as number)/10e9 } as Range
                                    setRangeCommand(marketCapStateRecoil, setMarketCapStateRecoil, action["range"])
                                    break;
                                case 'remove_marketCap':
                                    removeRangeCommand(marketCapStateRecoil, setMarketCapStateRecoil)
                                    break;

                                case 'add_ebitda':
                                    setRangeCommand(ebitdaStateRecoil, setEbitdaStateRecoil, action["range"])
                                    break;
                                case 'remove_ebitda':
                                    removeRangeCommand(ebitdaStateRecoil, setEbitdaStateRecoil)
                                    break;

                                case 'add_eps':
                                    setRangeCommand(epsStateRecoil, setEpsStateRecoil, action["range"])
                                    break;
                                case 'remove_eps':
                                    removeRangeCommand(epsStateRecoil, setEpsStateRecoil)
                                    break;

                                case 'add_pe':
                                    setRangeCommand(peRatioStateRecoil, setPeRatioStateRecoil, action["range"])
                                    break;
                                case 'remove_pe':
                                    removeRangeCommand(peRatioStateRecoil, setPeRatioStateRecoil)
                                    break;

                                case 'add_beta':
                                    setRangeCommand(betaStateRecoil, setBetaStateRecoil, action["range"])
                                    break;
                                case 'remove_beta':
                                    removeRangeCommand(betaStateRecoil, setBetaStateRecoil)
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
    })

    return(
        <>
            {children}
        </>
    )
}