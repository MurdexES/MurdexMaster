import { useState } from "react";
import About from "./About";

function Home(){

    const [count, setCount] = useState(0);
    const navigate = useNavigate();

    const CountClick = () => {
        const tmp = tmp + 1;

        if(tmp === 5){
            navigate('./About')
        }

        setCount(tmp);
    }

    return(
        <div>
            <h1>Home</h1>

            <button onClick={CountClick}>Click</button>
        </div>
    );
}

export default Home;