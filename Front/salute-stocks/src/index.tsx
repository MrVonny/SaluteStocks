import React from "react";
import ReactDOM from "react-dom";
import styled from "styled-components";
import App from "./App";
// import "./style.css";


import { gradient } from '@sberdevices/plasma-tokens';
import { darkSber } from '@sberdevices/plasma-tokens/themes';
import { sberBox } from '@sberdevices/plasma-tokens/typo';

const StyledPreview = styled.div`
    ${darkSber[":root"]};
    ${sberBox[":root"]};

    height: 100%;
    background-image: ${gradient};

    padding: 1rem; 
    > div { 
        display: flex; 
        gap: 1rem; 
    }
`

ReactDOM.render(
    <StyledPreview>
        <App />
    </StyledPreview>,
    document.getElementById("root")
);