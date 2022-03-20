import React from 'react'; // we need this to make JSX compile
import {Card, CardBody, H1, H2, H3} from "@sberdevices/plasma-ui"

type ScreenerPropertyProps = {
    title: string,
    subtitle: string,

}

export const ScreenerProperty: React.FC<ScreenerPropertyProps> = ({title, children}) => {
    return (
        <Card>
            <CardBody>
                
            </CardBody>
        </Card>
    );
}