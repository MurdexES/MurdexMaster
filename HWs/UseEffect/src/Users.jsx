import { useEffect } from "react"

function Users({value, array, setArray, setValue, setShowId, setShowKey}){
    useEffect(() => {
        const getData = async () =>
        {
          try {
            const res = await fetch("https://jsonplaceholder.typicode.com/users")
            const data = await res.json()
            console.log(data)
            setArray(data.filter(person => person.name.startsWith(value)))
          }
          catch (er)
          {
            console.log(er)
          }
        }
        getData()
      }, [value])

      return(
        <>
        <input type="text" onChange={(ev) => setValue(ev.target.value)}/>
        <div>
            <ul>
            {array.map((person) => {
                return(
                <li key={person.id}>
                    <p>{person.id}</p>
                    <p>{person.name}</p>
                    <p>{person.username}</p>
                    <p>{person.email}</p>
                    <button onClick={()=> {
                        setShowId(person.id)
                        setShowKey(true)}
                    }>View More</button>
                </li>
                )
            })}
            </ul>
        </div>
        </>
      )
}

export default Users