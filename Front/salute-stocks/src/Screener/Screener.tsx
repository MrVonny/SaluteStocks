import React, {useEffect} from 'react';
import '../App.css';
import {Checkbox, Col, Container, RectSkeleton, Row} from '@sberdevices/plasma-ui';
import {RecoilState, useRecoilState, useRecoilValue} from "recoil";
import {
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


type ScreenerComponentState = {
    isLoaded : boolean;
}



const Screener = () => {
    const [screenerVal, SetScreenerRecoilState] = useRecoilState(screenerState);
    const [state, setState] = React.useState({
        isLoaded: false
    } as ScreenerComponentState);

    const [marketCapStateRecoil, setMarketCapStateRecoil] = useRecoilState(marketCapState);

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

        }

    }, [state])

    return (
        <Container>
            <ScreenerSector title={"Валюта"}>
                <div className={"d-flex flex-row"}>
                    <span className={"me-4"}><Checkbox label={"RUB"}/></span>
                    <span className={"me-4"}><Checkbox label={"USD"}/></span>
                    <span className={"me-4"}><Checkbox label={"EUR"}/></span>
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
        </Container>
    );
}

export default Screener;
