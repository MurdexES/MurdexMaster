function Users({array, setShowKey, setUser}){

    return(
        <>
        <div>
            {array.map((person) => {
            return(
            <div key={person.id}>
                <img src={person.photoUrl} alt={person.name}/>
                <p>{person.name}</p>
                <p>{person.username}</p>
                <p>{person.email}</p>
                <button onClick={() => {
                    setUser(person)
                    setShowKey(true)
                }}>View More</button>
            </div>
            )
            })}
        </div>
        </>
    )
}

export default Users