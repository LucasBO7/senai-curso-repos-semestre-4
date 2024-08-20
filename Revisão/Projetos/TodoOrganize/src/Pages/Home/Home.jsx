import { PrimaryButton } from "../../Components/Buttons/Buttons";
import { Container } from "../../Components/Containers/Container";
import { TextInput } from "../../Components/Inputs/Inputs";
import { MainTite } from "../../Components/Titles/Titles";
import "./Home.css";

export const Home = () => {
    return (
        <div className="page-container">

            <Container>
                <MainTite fontSize={"24px"}>Terça-Feira, <span className="purple-color">24</span> de julho</MainTite>

                <TextInput/>

            </Container>

            <PrimaryButton>Nova tarefa</PrimaryButton>

        </div>
    );
}