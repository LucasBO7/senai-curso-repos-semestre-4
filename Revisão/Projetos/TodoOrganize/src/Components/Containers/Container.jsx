import styled from "styled-components";

export const Container = styled.div`
  display: flex;
  flex-direction: column;
  align-items: center;
  gap: 26px;

  max-width: 745px;
  max-height: 500px;
  width: 80vw;
  height: 80vh;
  padding: 50px 0 20px 0;

  border-radius: 8px;
  background-color: #1e123b;
`;

export const ActionsContainer = styled.div`
  width: 76px;
`;

export const TasksContainer = styled.div`
  display: flex;
  align-items: center;
  flex-direction: column;
  gap: 10px;
  width: 100%;
  height: 100%;

  overflow-y: scroll;
`;
