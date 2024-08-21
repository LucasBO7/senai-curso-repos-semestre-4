import "./Home.css";
import { PrimaryButton } from "../../Components/Buttons/Buttons";
import { Container } from "../../Components/Containers/Container";
import { TextInput } from "../../Components/Inputs/Inputs";
import { MainTite } from "../../Components/Titles/Titles";
import '../../Components/Table/Table.css';
import moment from "moment";
import { Task } from "../../Components/Tasks/Task";
import { useEffect, useState } from "react";

export const Home = () => {
    const [tasks, setTasks] = useState(
        [
            { id: 0, isDone: false, title: 'Banana', description: 'Comprar um cacho de banana prata.' }
        ]
    );


    useEffect(() => {
        console.log(tasks[0].isDone);

        

    }, [tasks])


    return (
        <div className="page-container">

            <Container>
                <MainTite fontSize={"24px"}>{moment().format('dddd')},  <span className="purple-color">{moment().format('Do')}</span> de  {moment().format('MMMM')}</MainTite>



                <TextInput />

                {
                    tasks.map((task) =>
                        <Task
                            key={task.id}
                            task={task}
                        />)
                }
                {/* <Task statusDone={tasks[0].statusDone} title={"Comprar uma bananinha..."} /> */}
            </Container>

            <PrimaryButton>Nova tarefa</PrimaryButton>

        </div>
    );
}