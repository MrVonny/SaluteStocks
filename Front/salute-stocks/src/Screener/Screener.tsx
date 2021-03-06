import React, {ChangeEvent, ChangeEventHandler, useEffect} from 'react';
import '../App.css';
import {Button, Checkbox, Col, Container, RectSkeleton, Row} from '@sberdevices/plasma-ui';
import {RecoilState, useRecoilState, useRecoilValue} from "recoil";
import {
    betaState,
    currencyState,
    debtEquityState,
    ebitdaState,
    epsGrowth1YearState, epsGrowth3YearState, epsState,
    marketCapState,
    peRatioState,
    Range, ScreenerPropertyRangeStorage, screenerSelectedPropertiesState,
    screenerState
} from "../Storage";
import {ScreenerSector} from "./ScreenerSector";
import {ScreenerRangeProperty, ScreenerPropertyType, InterpolateDist} from "./ScreenerProperty";
import {
    BetaProperty,
    DebtEquityProperty,
    EbidtaProperty,
    EpsGrowth1YearProperty, EpsGrowth3YearProperty, EpsProperty,
    MarketCapProperty,
    PeRatioProperty
} from "./Properties/Properties";
import {Distribution} from "./ScreenerChart";
import {Link} from "react-router-dom";


type ScreenerComponentState = {
    isLoaded : boolean;
    count: number | undefined
}



const Screener = () => {
    const [screenerVal, SetScreenerRecoilState] = useRecoilState(screenerState);
    const screener = useRecoilValue(screenerSelectedPropertiesState);
    const [state, setState] = React.useState({
        isLoaded: false,
        count: undefined
    } as ScreenerComponentState);

    const [currencyStateRecoil, setCurrencyStateRecoil] = useRecoilState(currencyState);

    const [marketCapStateRecoil, setMarketCapStateRecoil] = useRecoilState(marketCapState);
    const [ebitdaStateRecoil, setEbitdaStateRecoil] = useRecoilState(ebitdaState);
    const [peRatioStateRecoil, setPeRatioStateRecoil] = useRecoilState(peRatioState);
    const [epsStateRecoil, setEpsStateRecoil] = useRecoilState(epsState);
    const [betaStateRecoil, setBetaStateRecoil] = useRecoilState(betaState);

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
                console.log(`Fetching ${name}`)
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
                                selected: state.selected ?? {from: res.Values[0].Position, to: res.Values[res.Values.length-1].Position }
                            });
                            console.log(res);
                        },
                        (error) => {
                            setState({...state,
                                isLoaded: true,
                            });
                            console.log(error)
                        }
                    )
            }
            LoadDistribution("market-cap", marketCapStateRecoil, setMarketCapStateRecoil);
            LoadDistribution("ebitda", ebitdaStateRecoil, setEbitdaStateRecoil);
            LoadDistribution("pe", peRatioStateRecoil, setPeRatioStateRecoil);
            LoadDistribution("eps", epsStateRecoil, setEpsStateRecoil);
            LoadDistribution("beta", betaStateRecoil, setBetaStateRecoil);

        }

        // fetch(`https://localhost:5001/api/screener/count`, {
        //     body: JSON.stringify(screener),
        //     method: 'POST',
        //     headers: {
        //         'Content-Type': 'application/json',
        //     },
        //
        // })
        //     .then(res => res.json())
        //     .then(
        //         (result) => {
        //             setState({...state,
        //                 count: result
        //             })
        //         },
        //         (error) => {
        //             setState({...state,
        //                 isLoaded: true,
        //             });
        //             console.log(error);
        //         }
        //     )

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
            <ScreenerSector title={"????????????"}>
                <div className={"d-flex flex-row"}>
                    <span className={"me-4"}><Checkbox label={"RUB"} onChange={(event) => onCurrencyChange(event, "RUB")}/></span>
                    <span className={"me-4"}><Checkbox label={"USD"} onChange={(event) => onCurrencyChange(event, "USD")}/></span>
                    <span className={"me-4"}><Checkbox label={"EUR"} onChange={(event) => onCurrencyChange(event, "EUR")}/></span>
                </div>
            </ScreenerSector>

            <ScreenerSector title={"???????????????????? ????????????????????"}>
                <Row>
                    <Col sizeXL={4} sizeL={4} sizeM={3} sizeS={4}>
                        <MarketCapProperty/>
                    </Col>
                    <Col sizeXL={4} sizeL={4} sizeM={3} sizeS={4}>
                        <EbidtaProperty/>
                    </Col>
                    <Col sizeXL={4} sizeL={4} sizeM={3} sizeS={4}>
                        <EpsProperty/>
                    </Col>
                    <Col sizeXL={4} sizeL={4} sizeM={3} sizeS={4}>
                        <PeRatioProperty/>
                    </Col>
                    <Col sizeXL={4} sizeL={4} sizeM={3} sizeS={4}>
                        <BetaProperty/>
                    </Col>
                </Row>
            </ScreenerSector>
            <ScreenerSector title={"????????????????"}>
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
                    {state.count === undefined ?
                        <Link to="/companies">
                            <Button>{`???????????????? ????????????????`}</Button>
                        </Link> :
                        state.count === 0 ?
                        <Button>???????????????? ???? ??????????????</Button> : <Button>{`???????????????? ???????????????? (${state.count} ????.)`}</Button>
                    }

                </Col>
            </Row>
        </Container>
    );
}

export default Screener;
