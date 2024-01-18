function ModalWindow({array, setArray, setShowKey}){
    let person = {
        "id": 0,
        "name": "",
        "username": "",
        "email": ""
    }

    function handleAdd(){
        setArray([...array, person])
        setShowKey(false)
    }

    return(
        <div>
            <h2>Person Creation</h2>
            <button onClick={() => setShowKey(false)}>X</button>

            <input onChange={(e) => person.name = e.target.value} type="name" placeholder="Name..."/>
            <input onChange={(e) => person.usernam = e.target.value} type="username" placeholder="Username..."/>
            <input onChange={(e) => person.email = e.target.value} type="email" placeholder="Email..."/>

            <button onClick={() => handleAdd()}>Add</button>
        </div>
    )
}

export default ModalWindow