import React from 'react'; // we need this to make JSX compile
import {Card, CardBody, CardContent, Cell, H1, H2, H3, TextBoxBigTitle, TextBoxSubTitle} from "@sberdevices/plasma-ui"

type ScreenerPropertyProps = {
    title: string,
    subtitle: string,

}


export const ScreenerProperty: React.FC<ScreenerPropertyProps> = ({title, subtitle, children}) => {
    return (
        <Card>
            <CardContent title={title}>
                <Cell
                    content={<TextBoxBigTitle>{title}</TextBoxBigTitle>}
                />
                <Cell content={<TextBoxSubTitle>{subtitle}</TextBoxSubTitle>}></Cell>
                <Cell content={children}></Cell>
            </CardContent>
        </Card>
    );
}