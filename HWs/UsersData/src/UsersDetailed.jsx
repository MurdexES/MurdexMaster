function UsersDetailed({user, setShowKey}){

    return(
        <>
        <button onClick={() => setShowKey(false)}>X</button>
        <div>
            <div>
                <h1>Detailed Information</h1>
                <img src={user.photoUrl} alt={user.name}/>
                <p>{user.name}</p>
                <p>{user.username}</p>
                <p>{user.email}</p>
                <p>{user.phone}</p>
                <p>{user.website}</p>
                <p>{user.address.street}</p>
                <p>{user.address.suite}</p>
                <p>{user.address.city}</p>
                <p>{user.address.zipcode}</p>
                <p>{user.address.geo.lat}</p>
                <p>{user.address.geo.lng}</p>
                <p>{user.company.name}</p>
                <p>{user.company.catchPhrase}</p>
                <p>{user.company.bs}</p>
            </div>
        </div>
        </>
    )
}

export default UsersDetailed