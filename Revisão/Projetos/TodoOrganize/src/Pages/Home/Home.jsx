import "./Home.css";
import { PrimaryButton } from "../../Components/Buttons/Buttons";
import { Container, TasksContainer } from "../../Components/Containers/Container";
import { TextInput } from "../../Components/Inputs/Inputs";
import { MainTite } from "../../Components/Titles/Titles";
import '../../Components/Table/Table.css';
import moment from "moment";
import { Task } from "../../Components/Tasks/Task";
import { useState } from "react";

export const Home = () => {
    const [tasks, setTasks] = useState(
        [
            { id: 0, isDone: false, title: 'Banana', description: 'Comprar um cacho de banana prata.' },
            { id: 1, isDone: true, title: 'Banana', description: 'Comprar 26 uvas.' },
            { id: 2, isDone: false, title: 'Banana', description: 'Comprar um quilo de picanha.' },
            { id: 3, isDone: false, title: 'Banana', description: 'Comprar um quilo de picanha.' },
            { id: 4, isDone: false, title: 'Banana', description: 'Comprar um quilo de picanha.' }
        ]
    );

    function onRemoveClick(index){
        if (index >= 0)
            setTasks(tasks.filter((task, i) => i !== index));
    }

    moment.locale('pt');
    return (
        <div className="page-container">

            <Container>
                <MainTite fontSize={"24px"}>{moment().locale('pt').format('dddd')},  <span className="purple-color">{moment().locale('pt').format('Do')}</span> de  {moment().locale('pt').format('MMMM')}</MainTite>

                <TextInput />
                

                <TasksContainer>
                {
                    tasks.length <= 0 
                    ? (
                        <p>Nenhuma tarefa salva!</p>
                    ) 
                    : (
                        tasks.map((task) =>
                            <Task
                            key={task.id}
                            task={task}
                            tasks={tasks}
                            setTasks={setTasks}
                            onRemoveClick={onRemoveClick}
                        />)
                    )
                }
                </TasksContainer>
                
            </Container>

            <PrimaryButton>Nova tarefa</PrimaryButton>

        </div>
    );
}