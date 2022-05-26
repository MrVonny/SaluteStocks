import {
    betaState,
    debtEquityState,
    ebitdaState,
    epsGrowth1YearState,
    epsGrowth3YearState, epsState,
    marketCapState,
    peRatioState
} from "../../Storage";
import {ScreenerRangeProperty} from "../ScreenerProperty";
import React from "react";

export const MarketCapProperty = () => <ScreenerRangeProperty title={"Market Cap"}
                                                             subtitle={"Стоиость компании"}
                                                             description={"Стоиость компании на фондовом рынке"}
                                                             rangeState={marketCapState}
                                                             unit="млдр, $"
/>

export const  EbidtaProperty = () => <ScreenerRangeProperty title={"EBITDA"}
                                                           subtitle={"Сколько копмпания зарабатывает"}
                                                           description={"Приыбль до вычета расходов, не связанных с операционной деятельностью компании"}
                                                           rangeState={ebitdaState}
                                                           unit="млдр, $"

/>
export const  DebtEquityProperty = () => <ScreenerRangeProperty title={"Debt / Equity"}
                                                               subtitle={"Чем больше %, тем выше долг компании"}
                                                               description={"Соотношение заёмного капитала компании к собственному"}
                                                               rangeState={debtEquityState}
                                                               unit="%"

/>
export const  PeRatioProperty = () => <ScreenerRangeProperty title={"P / E"}
                                                            subtitle={"Через сколько лет окупится акция"}
                                                            description={"Отношения цены акции к прибыли, которая приходится на одну акцию"}
                                                            rangeState={peRatioState}

/>
export const  EpsGrowth1YearProperty = () => <ScreenerRangeProperty title={"Рост EPS за 1 год"}
                                                                   subtitle={""}
                                                                   description={"Процентный рост EPS за год"}
                                                                   rangeState={epsGrowth1YearState}
                                                                   unit="%"
/>
export const  EpsGrowth3YearProperty = () => <ScreenerRangeProperty title={"Рост EPS за 3 года"}
                                                                   subtitle={""}
                                                                   description={"Процентный рост EPS за 3 года"}
                                                                   rangeState={epsGrowth3YearState}
                                                                   unit="%"
/>

export const  EpsProperty = () => <ScreenerRangeProperty title={"EPS"}
                                                         subtitle={"Прибыль на акцию"}
                                                         description={"Прибыль на акцию"}
                                                         rangeState={epsState}
                                                         unit="$"
/>

export const  BetaProperty = () => <ScreenerRangeProperty title={"Beta"}
                                                         subtitle={"Показатель волатильности"}
                                                         description={"Показатель волатильности акций по отношению у рынку"}
                                                         rangeState={betaState}
                                                         unit=""
/>