import {
    Body1,
    Body2,
    Cell,
    Col,
    Container,
    ParagraphText1,
    Price,
    Row,
    TextBox,
    TextBoxLabel
} from "@sberdevices/plasma-ui";
import styled from "styled-components";
import { text, background, gradient } from '@sberdevices/plasma-tokens';
import {useRecoilValue} from "recoil";
import {Pagination} from "@mui/material";
import {useState} from "react";

export declare type CompaniesListProperties = {
    companies : Company[]
}

export declare type Company = {
    name : string,
    ticker : string,
    price : string,
    description : string,
    sector : string,
    country : string
}

export const CompaniesList = ({companies} : CompaniesListProperties ) => {

    const [state, setState] = useState({
        page: 1,
    })
    const TableWrapper = styled.div`
    `;
    const Table = styled.table`
    `;
    const TableRow = styled.tr`
      border-bottom: 1px rgba(255,255,255, 0.2) solid;
    `;
    const TableData = styled.td`
        padding-right: 25px;
    `;
    const TableHead = styled.td`
    `;
    const perPage = 10;
    let pages = Math.ceil(companies.length / 10);
    return (

        <>
            <TableWrapper>
                <Table>
                    {companies.slice((state.page - 1) * perPage, state.page * perPage).map(c=>(
                        <TableRow>
                            <TableHead>
                                <div className={"d-flex flex-column mt-2"}>
                                    <Body2 style={{
                                        textAlign: "left",
                                        color: text
                                    }}>{c.ticker}</Body2>
                                    <Body1 style={{
                                        textAlign: "left"
                                    }}>{c.name}</Body1>
                                </div>
                            </TableHead>
                            <TableData>
                                <Body1 style={{
                                    whiteSpace: "nowrap"
                                }}>{"23.425 $"}</Body1>
                            </TableData>
                            <TableData>
                                <Body1>{c.country}</Body1>
                            </TableData>
                            <TableData>
                                <Body1>{c.sector}</Body1>
                            </TableData>
                            {/*<TableData>*/}
                            {/*    <Body1>{c.description}</Body1>*/}
                            {/*</TableData>*/}
                        </TableRow>
                    ))}
                </Table>
            </TableWrapper>

            <Pagination
                sx={{
                    color: "white",
                }}
                style={{
                    color: "white"
                }}
                count={pages}
                page={state.page}
                onChange={
                    (event, page) => setState({...state, page: page})
                }
            />
        </>




    )
}