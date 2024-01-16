function Home({array}){

    return(
        <div>
            <h1>Home page</h1>
            <ul>
                <li>Name: {array.name}</li>
                <li>Surname: {array.surname}</li>
            </ul>
        </div>
    )
}

export default Home;