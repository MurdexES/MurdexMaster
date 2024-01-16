import { useState } from "react"
import {Routes, Route} from "react-router-dom"
import Home from "./Home"
import About from "./About"

function Main(){
    const [value, setValue] = useState('')

    return (
        <main>
            <Routes>
                <Route path="/" element={<Home/>}/>
                <Route path="/about" element={<About/>}/>
            </Routes>
        </main>
    )
}

export default Main;