import React from 'react';
import './App.css';
import {Checkbox, Col, Container, Row} from '@sberdevices/plasma-ui';
import {useRecoilState, useRecoilValue} from "recoil";
import {screenerState, screenerValue} from "./Storage";
import {ScreenerSector} from "./ScreenerSector";
import {ScreenerProperty, ScreenerPropertyType} from "./ScreenerProperty";


const Screener = () => {
    const [screener, setScreener] = useRecoilState(screenerState);
    const screenerVal = useRecoilValue(screenerValue);
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
                        <ScreenerProperty title={"Market Cap"}
                                          subtitle={"Стоиость компании"}
                                          description={"Стоиость компании на фондовом рынке"}
                                          type={ScreenerPropertyType.Range}
                                          range={screenerVal.screener.epsGrowth1Year}
                                          unit="млдр, $"
                        />

                    </Col>
                    <Col sizeXL={4} sizeL={4} sizeM={3} sizeS={4}>
                        <ScreenerProperty title={"EBITDA"}
                                          subtitle={"Сколько копмпания зарабатывает"}
                                          description={"Приыбль до вычета расходов, не связанных с операционной деятельностью компании"}
                                          type={ScreenerPropertyType.Range}
                                          range={screenerVal.screener.epsGrowth1Year}
                                          unit="млдр, $"

                        />

                    </Col>
                    <Col sizeXL={4} sizeL={4} sizeM={3} sizeS={4}>
                        <ScreenerProperty title={"Debt / Equity"}
                                          subtitle={"Чем больше %, тем выше долг компании"}
                                          description={"Соотношение заёмного капитала компании к собственному"}
                                          type={ScreenerPropertyType.Range}
                                          range={screenerVal.screener.epsGrowth1Year}
                                          unit="%"

                        />

                    </Col>
                    <Col sizeXL={4} sizeL={4} sizeM={3} sizeS={4}>
                        <ScreenerProperty title={"P / E"}
                                          subtitle={"Через сколько лет окупится акция"}
                                          description={"Отношения цены акции к прибыли, которая приходится на одну акцию"}
                                          type={ScreenerPropertyType.Range}
                                          range={screenerVal.screener.epsGrowth1Year}

                        />

                    </Col>
                </Row>
            </ScreenerSector>
            <ScreenerSector title={"Динамика"}>
                <Row>
                    <Col sizeXL={4} sizeL={4} sizeM={3} sizeS={4}>
                        <ScreenerProperty title={"Рост EPS за 1 год"}
                                          subtitle={""}
                                          description={"Процентный рост EPS за год"}
                                          type={ScreenerPropertyType.Range}
                                          range={screenerVal.screener.epsGrowth1Year}
                                          unit="%"
                        />

                    </Col>
                    <Col sizeXL={4} sizeL={4} sizeM={3} sizeS={4}>
                        <ScreenerProperty title={"Рост EPS за 3 года"}
                                          subtitle={""}
                                          description={"Процентный рост EPS за 3 года"}
                                          type={ScreenerPropertyType.Range}
                                          range={screenerVal.screener.epsGrowth1Year}
                                          unit="%"
                        />

                    </Col>
                </Row>
            </ScreenerSector>
        </Container>
    );
}

export default Screener;
