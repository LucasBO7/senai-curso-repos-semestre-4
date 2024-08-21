/* eslint-disable react/prop-types */
// import { useState } from "react";
import { Check } from "../Buttons/Animated/check";
import { ContainerTask, TaskTitle } from "./Style";
import { ActionsContainer } from "../Containers/Container";
import { EditBtn } from "../Buttons/Animated/EditBtn";
import { RemoveBtn } from "../Buttons/Animated/RemoveBtn";

export const Task = ({ task }) => {
    return (
        <ContainerTask>
            <Check
                checked={task.isDone}
                onClick={() => {
                    if (task.isDone) {
                        task.isDone = false;
                    } else {
                        task.isDone = true;
                    }
                }}
            />

            <TaskTitle>{task.title}</TaskTitle>

            <ActionsContainer>
                <EditBtn />
                <RemoveBtn />
            </ActionsContainer>

        </ContainerTask>
    );
}