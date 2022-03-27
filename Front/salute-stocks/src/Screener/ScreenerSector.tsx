import React from 'react'; // we need this to make JSX compile
import { H1, H2, H3 } from "@sberdevices/plasma-ui"
type ScreenerSectorProps = {
    title: string,
}

export const ScreenerSector: React.FC<ScreenerSectorProps> = ({title, children}) => {
    return (
        <div>
            <H2 mb={"4x"}>{title}</H2>
            {children}
            <hr/>
        </div>
    );
}