import { SndButton } from "../Buttons/Buttons"
import { TextInputFst } from "./Style"

export const TextInput = () => {
    return (
        <>
            <TextInputFst placeholder="Banana" />
            {/* <img src="../../assets/search-icon.svg" alt="" /> */}
            <SndButton>Filtros</SndButton>
        </>
    )
}