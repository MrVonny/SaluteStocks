import React from 'react';
import '../App.css';
import {Checkbox, Col, Container, Row} from '@sberdevices/plasma-ui';
import {useRecoilState, useRecoilValue} from "recoil";
import {
    debtEquityState,
    ebitdaState,
    epsGrowth1YearState, epsGrowth3YearState,
    marketCapState,
    peRatioState,
    Range,
    screenerState
} from "../Storage";
import {ScreenerSector} from "./ScreenerSector";
import {ScreenerRangeProperty, ScreenerPropertyType} from "./ScreenerProperty";


const Screener = () => {
    const screenerVal = useRecoilValue(screenerState);
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
                        <ScreenerRangeProperty title={"Market Cap"}
                                               subtitle={"Стоиость компании"}
                                               description={"Стоиость компании на фондовом рынке"}
                                               rangeState={marketCapState}
                                               unit="млдр, $"
                        />

                    </Col>
                    <Col sizeXL={4} sizeL={4} sizeM={3} sizeS={4}>
                        <ScreenerRangeProperty title={"EBITDA"}
                                          subtitle={"Сколько копмпания зарабатывает"}
                                          description={"Приыбль до вычета расходов, не связанных с операционной деятельностью компании"}
                                               rangeState={ebitdaState}
                                          unit="млдр, $"

                        />

                    </Col>
                    <Col sizeXL={4} sizeL={4} sizeM={3} sizeS={4}>
                        <ScreenerRangeProperty title={"Debt / Equity"}
                                          subtitle={"Чем больше %, тем выше долг компании"}
                                          description={"Соотношение заёмного капитала компании к собственному"}
                                          rangeState={debtEquityState}
                                          unit="%"

                        />

                    </Col>
                    <Col sizeXL={4} sizeL={4} sizeM={3} sizeS={4}>
                        <ScreenerRangeProperty title={"P / E"}
                                          subtitle={"Через сколько лет окупится акция"}
                                          description={"Отношения цены акции к прибыли, которая приходится на одну акцию"}
                                               rangeState={peRatioState}

                        />

                    </Col>
                </Row>
            </ScreenerSector>
            <ScreenerSector title={"Динамика"}>
                <Row>
                    <Col sizeXL={4} sizeL={4} sizeM={3} sizeS={4}>
                        <ScreenerRangeProperty title={"Рост EPS за 1 год"}
                                          subtitle={""}
                                          description={"Процентный рост EPS за год"}
                                          rangeState={epsGrowth1YearState}
                                          unit="%"
                        />

                    </Col>
                    <Col sizeXL={4} sizeL={4} sizeM={3} sizeS={4}>
                        <ScreenerRangeProperty title={"Рост EPS за 3 года"}
                                          subtitle={""}
                                          description={"Процентный рост EPS за 3 года"}
                                               rangeState={epsGrowth3YearState}
                                          unit="%"
                        />
                    </Col>
                </Row>
            </ScreenerSector>
        </Container>
    );
}

export default Screener;
