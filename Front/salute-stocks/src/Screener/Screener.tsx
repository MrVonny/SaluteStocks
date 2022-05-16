import React, {ChangeEvent, ChangeEventHandler, useEffect} from 'react';
import '../App.css';
import {Button, Checkbox, Col, Container, RectSkeleton, Row} from '@sberdevices/plasma-ui';
import {RecoilState, useRecoilState, useRecoilValue} from "recoil";
import {
    currencyState,
    debtEquityState,
    ebitdaState,
    epsGrowth1YearState, epsGrowth3YearState,
    marketCapState,
    peRatioState,
    Range, ScreenerPropertyRangeStorage,
    screenerState
} from "../Storage";
import {ScreenerSector} from "./ScreenerSector";
import {ScreenerRangeProperty, ScreenerPropertyType, InterpolateDist} from "./ScreenerProperty";
import {
    DebtEquityProperty,
    EbidtaProperty,
    EpsGrowth1YearProperty, EpsGrowth3YearProperty,
    MarketCapProperty,
    PeRatioProperty
} from "./Properties/Properties";
import {Distribution} from "./ScreenerChart";
import {Link} from "react-router-dom";


type ScreenerComponentState = {
    isLoaded : boolean;
}



const Screener = () => {
    const [screenerVal, SetScreenerRecoilState] = useRecoilState(screenerState);
    const [state, setState] = React.useState({
        isLoaded: false
    } as ScreenerComponentState);

    const [currencyStateRecoil, setCurrencyStateRecoil] = useRecoilState(currencyState);

    const [marketCapStateRecoil, setMarketCapStateRecoil] = useRecoilState(marketCapState);
    const [ebitdaStateRecoil, setEbitdaStateRecoil] = useRecoilState(ebitdaState);

    useEffect(() => {
        if (!state.isLoaded)/*salut-stocks.xyz*/
        {
            fetch("https://localhost:5001/api/screener-model")
                .then(res => res.json())
                .then(
                    (result) => {
                        console.log(result);
                        SetScreenerRecoilState(result);
                        setState({...state, isLoaded: true});
                    },
                    (error) => {
                        console.log(error);
                    }
                );

            let LoadDistribution = (name : string, state : any, setState : any) =>
            {
                fetch(`https://localhost:5001/api/distribution/${name}/100`)
                    .then(res => res.json())
                    .then(
                        (result) => {
                            const res = result as Distribution;
                            setState({...state,
                                distribution: res,
                                isDistributionLoaded: true,
                                isRangeLoaded: true,
                                available: {from: res.Values[0].Position, to: res.Values[res.Values.length-1].Position },
                                selected:  {from: res.Values[0].Position, to: res.Values[res.Values.length-1].Position }
                            });
                            console.log(res);
                        },
                        (error) => {
                            setState({...state,
                                isLoaded: true,
                            });
                        }
                    )
            }
            LoadDistribution("market-cap", marketCapStateRecoil, setMarketCapStateRecoil);
            LoadDistribution("ebitda", ebitdaStateRecoil, setEbitdaStateRecoil);

        }

    }, [state])

    const onCurrencyChange = (event : ChangeEvent<HTMLInputElement>, currency : string) => {
        console.log(currencyStateRecoil);
        if(event.currentTarget.checked)
            setCurrencyStateRecoil({
                currencies: currencyStateRecoil.currencies.concat(currency)
            })
        else
            setCurrencyStateRecoil({
                currencies: currencyStateRecoil.currencies.filter(x=>x != currency)
            })

    }

    return (
        <Container>
            <ScreenerSector title={"Валюта"}>
                <div className={"d-flex flex-row"}>
                    <span className={"me-4"}><Checkbox label={"RUB"} onChange={(event) => onCurrencyChange(event, "RUB")}/></span>
                    <span className={"me-4"}><Checkbox label={"USD"} onChange={(event) => onCurrencyChange(event, "USD")}/></span>
                    <span className={"me-4"}><Checkbox label={"EUR"} onChange={(event) => onCurrencyChange(event, "EUR")}/></span>
                </div>
            </ScreenerSector>

            <ScreenerSector title={"Финансовые показатели"}>
                <Row>
                    <Col sizeXL={4} sizeL={4} sizeM={3} sizeS={4}>
                        <MarketCapProperty/>
                    </Col>
                    <Col sizeXL={4} sizeL={4} sizeM={3} sizeS={4}>
                        <EbidtaProperty/>
                    </Col>
                    <Col sizeXL={4} sizeL={4} sizeM={3} sizeS={4}>
                        <DebtEquityProperty/>
                    </Col>
                    <Col sizeXL={4} sizeL={4} sizeM={3} sizeS={4}>
                        <PeRatioProperty/>
                    </Col>
                </Row>
            </ScreenerSector>
            <ScreenerSector title={"Динамика"}>
                <Row>
                    <Col sizeXL={4} sizeL={4} sizeM={3} sizeS={4}>
                        <EpsGrowth1YearProperty/>
                    </Col>
                    <Col sizeXL={4} sizeL={4} sizeM={3} sizeS={4}>
                        <EpsGrowth3YearProperty/>
                    </Col>
                </Row>
            </ScreenerSector>
            <Row>
                <Col size={2} offsetXL={5} offsetL={3} offsetM={2} offsetS={1}>
                    <Link to="/companies">
                        <Button>Найти</Button>
                    </Link>
                </Col>
            </Row>
        </Container>
    );
}

export default Screener;
