import styled from 'styled-components';

export const PrimaryButton = styled.button`
    width: 201.38px;
    height: 50px;
    background-color: #6C45CE;
    color: white;
    border: 2px solid white;
`;

export const SndButton = styled.button`
    width: ${props => props.width};
    height: ${props => props.height};
    /* font-family: Roboto; */
    font-size: 15.43px;
    font-weight: 400;
    line-height: 18.08px;

    background-color: transparent;
    color: white;
`;