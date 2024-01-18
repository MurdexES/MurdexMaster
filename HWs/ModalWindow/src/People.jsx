import { useState } from "react"

function People({array, setShowKey}){
    const [value, setValue] = useState('')

    return(
        <div>
            <button onClick={() => setShowKey(true)}>Add Person</button>
            <ul>
                {array.map((person) => {
                    return(
                        <li>
                            <p>{person.id}</p>
                            <p>{person.name}</p>
                            <p>{person.username}</p>
                            <p>{person.email}</p>
                        </li>
                    )
                })}
            </ul>
        </div>
    )
}

export default People