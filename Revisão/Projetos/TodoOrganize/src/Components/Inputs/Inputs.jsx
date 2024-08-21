import { InputContainer, Input, SearchButton } from "./Style"
import { IoIosSearch } from "react-icons/io";

export const TextInput = () => {
    return (
        <InputContainer>
            <SearchButton>
                <IoIosSearch width={'100%'} height={'100%'} color="white" />
            </SearchButton>
            <Input placeholder="Procurar tarefa..." />
        </InputContainer>
    )
}