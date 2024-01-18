function Footer({array}){

    return(
        <div>
            <h1>Footer</h1>
            <ul>
                <li>Name: {array.name}</li>
                <li>Surname: {array.surname}</li>
            </ul>
        </div>
    )
}

export default Footer;