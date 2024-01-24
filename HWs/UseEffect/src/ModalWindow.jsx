import { useEffect } from "react"

function ModalWindow({value, idArray, setIdArray, setShowKey, showId}){
    useEffect(() => {
        const getData = async () =>
        {
          try {
            const res = await fetch("https://jsonplaceholder.typicode.com/posts")
            const data = await res.json()
            console.log(data)
            setIdArray(data.filter(val => val.id === showId))
          }
          catch (er)
          {
            console.log(er)
          }
        }
        getData()
      }, [value])

    return(
        <div>
            <h2>View More</h2>
            <button onClick={() => setShowKey(false)}>X</button>

            <ul>
                {idArray.map((post) => {
                    return(
                    <li key={post.id}>
                        <p>{post.title}</p>
                        <p>{post.body}</p>
                    </li>
                    )
                })}
        </ul>
        </div>
    )
}

export default ModalWindow