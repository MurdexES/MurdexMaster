function Header({array}){

    return(
        <div>
            <h1>Header</h1>
            <ul>
                <li>Name: {array.name}</li>
                <li>Surname: {array.surname}</li>
            </ul>
        </div>
    )
}

export default Header;