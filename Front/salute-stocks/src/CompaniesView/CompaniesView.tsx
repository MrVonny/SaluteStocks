import {Container, DsplL, LineSkeleton, MarkedItem, MarkedList, TextBox} from "@sberdevices/plasma-ui";
import {useEffect, useState} from "react";
import {CompaniesList, Company} from "./CompaniesList";
import {Distribution} from "../Screener/ScreenerChart";
import {useRecoilValue} from "recoil";
import {screenerSelectedPropertiesDescriptionState, screenerSelectedPropertiesState} from "../Storage";
import {Title} from "@sberdevices/plasma-ui/components/TextBox/TextBox";
import {List} from "@mui/material";



export const CompaniesView = () => {
    const screener = useRecoilValue(screenerSelectedPropertiesState);
    const [state, setState] = useState({
        companies: [] as Company[],
        isLoaded: false,
    });
    const propertiesDescription = useRecoilValue(screenerSelectedPropertiesDescriptionState);

    console.log(propertiesDescription);

    useEffect(() => {

        if(!state.isLoaded)
        {
            console.log('SCREENER: ',screener);
            fetch(`https://localhost:5001/api/screener/companies`, {
                body: JSON.stringify(screener),
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },

            })
                .then(res => res.json())
                .then(
                    (result) => {
                        setState({...state,
                            isLoaded: true,
                            companies: result
                        })
                        console.log(result);
                    },
                    (error) => {
                        setState({...state,
                            isLoaded: true,
                        });
                        console.log(error);
                    }
                )
        }
    });

    return(
        <>
            <>
                <DsplL>Компании</DsplL>
                <MarkedList>
                    {propertiesDescription.map(d=>(
                        <MarkedItem>{d}</MarkedItem>
                    ))}

                </MarkedList>
            </>
            <>
                {
                    state.isLoaded ?
                        <CompaniesList companies={state.companies}/> :
                        <LineSkeleton size={"display1"}/>
                }
            </>
        </>
    )
}